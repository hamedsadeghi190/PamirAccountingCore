using JntNum2Text;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.UI.Forms.Transaction
{
    public partial class TransferAccountFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private int? _Id;
        private long? _TransActionId;
        private Domains.Transaction sourceTransaction, destinationTransaction;
        private List<ComboBoxModel> _Currencies, _SourceCustomers, _destCustomers;
        long amount;

        public TransferAccountFrm(int Id, long? transActionId)
        {
            _Id = Id;
            _TransActionId = transActionId;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        public TransferAccountFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

        private void TransferAccountFrm_Load(object sender, EventArgs e)
        {
            this.cmbCurrencies.SelectedIndexChanged -= new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            this.cmbDestiniation.SelectedValueChanged -= new System.EventHandler(this.cmbDestiniation_SelectedIndexChanged);
            this.CmbSource.SelectedIndexChanged -= new System.EventHandler(this.CmbSource_SelectedIndexChanged);
            SetComboBoxHeight(cmbDestiniation.Handle, 25);
            cmbDestiniation.Refresh();
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            SetComboBoxHeight(CmbSource.Handle, 25);
            CmbSource.Refresh();
            LoadData();

            if (_TransActionId.HasValue)
            {
                loadTransferInfo();
            }
            else
            {
                lbl_Document_Id_value.Text = unitOfWork.TransactionServices.GetNewDocumentId().ToString();
                txtDate.Text = DateTime.Now.ToFarsiFormat();
            }
            this.CmbSource.SelectedIndexChanged += new System.EventHandler(this.CmbSource_SelectedIndexChanged);
            this.cmbDestiniation.SelectedIndexChanged += new System.EventHandler(this.cmbDestiniation_SelectedIndexChanged);
            this.cmbCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
        }


        private void loadTransferInfo()
        {
            var orginalTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == _TransActionId.Value);
            sourceTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == orginalTransaction.OriginalTransactionId);
            destinationTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == sourceTransaction.DoubleTransactionId);

            if (sourceTransaction.WithdrawAmount.Value != 0)
            {
                txtAmount.Text = sourceTransaction.WithdrawAmount.Value.ToString();
            }
            else
            {
                txtAmount.Text = sourceTransaction.DepositAmount.Value.ToString();
            }

            txtDesc.Text = sourceTransaction.Description;

            cmbCurrencies.SelectedValue = sourceTransaction.CurrenyId;

            CmbSource.SelectedValue = sourceTransaction.SourceCustomerId;
            _Id = sourceTransaction.SourceCustomerId;
            cmbDestiniation.SelectedValue = sourceTransaction.DestinitionCustomerId;

            txtDate.Text = sourceTransaction.TransactionDateTime.ToFarsiFormat();
        }

        private void LoadData()
        {

            this.CmbSource.SelectedIndexChanged -= new System.EventHandler(this.CmbSource_SelectedIndexChanged);
            this.cmbDestiniation.SelectedIndexChanged -= new System.EventHandler(this.cmbDestiniation_SelectedIndexChanged);
            this.cmbCurrencies.SelectedIndexChanged -= new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbCurrencies.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbCurrencies.AutoCompleteCustomSource = autoCurrencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            ////////////////////////////////////////////
            _SourceCustomers = unitOfWork.CustomerServices.GetAllNotDefaults();
            CmbSource.DataSource = _SourceCustomers;
            AutoCompleteStringCollection autoSourceCustomers = new AutoCompleteStringCollection();
            foreach (var item in _SourceCustomers)
            {
                autoSourceCustomers.Add(item.Title);
            }
            CmbSource.AutoCompleteCustomSource = autoSourceCustomers;
            CmbSource.ValueMember = "Id";
            CmbSource.DisplayMember = "Title";
            ////////////////////////////////////////////
            _destCustomers = new List<ComboBoxModel>();
            _destCustomers.AddRange(_SourceCustomers);
            cmbDestiniation.DataSource = _destCustomers;
            AutoCompleteStringCollection autoDestCustomers = new AutoCompleteStringCollection();
            foreach (var item in _destCustomers)
            {
                autoDestCustomers.Add(item.Title);
            }
            cmbDestiniation.AutoCompleteCustomSource = autoDestCustomers;
            cmbDestiniation.ValueMember = "Id";
            cmbDestiniation.DisplayMember = "Title";

            if (_Id != null)
            {
                CmbSource.SelectedValue = _Id;
            }
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            if (checkEntryData())
            {
                var customer = unitOfWork.Customers.FindFirst(x => x.Id == (int)CmbSource.SelectedValue);
                if (customer.Id == AppSetting.SandoghCustomerId || customer.GroupId == 2)
                {
                    var balance = unitOfWork.TransactionServices.GetCustomerBalace((int)CmbSource.SelectedValue, (int)cmbCurrencies.SelectedValue);
                    if (balance < 0 && (balance * -1) > long.Parse(txtAmount.Text))
                    {
                    }
                    else
                    {
                        MessageBox.Show("مبلغ انتخابی از موجودی حساب بیشتر است", "مقادیر ورودی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Focus();
                        return;
                    }
                }

                if (_TransActionId.HasValue)
                {
                    SaveEdit();
                    MessageBox.Show("عملیات با موفقیت ویزایش گردید", " ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    CreateTransfer();
                    MessageBox.Show("عملیات با موفقیت ثبت گردید", " ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید", "مقادیر ورودی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void SaveEdit()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            sourceTransaction.TransactionType = (int)TransaActionType.Transfer;
            sourceTransaction.DestinitionCustomerId = (int)cmbDestiniation.SelectedValue;
            sourceTransaction.SourceCustomerId = (int)CmbSource.SelectedValue;
            sourceTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            sourceTransaction.DepositAmount = 0;
            sourceTransaction.WithdrawAmount = String.IsNullOrEmpty(txtAmount.Text.Trim()) == true ? 0 : amount;
            sourceTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            sourceTransaction.Date = DateTime.Now;
            sourceTransaction.TransactionDateTime = TransactionDateTime;
            sourceTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Update(sourceTransaction);
            unitOfWork.SaveChanges();


            destinationTransaction.SourceCustomerId = (int)cmbDestiniation.SelectedValue;
            destinationTransaction.DestinitionCustomerId = (int)CmbSource.SelectedValue;
            destinationTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            destinationTransaction.DepositAmount = String.IsNullOrEmpty(txtAmount.Text.Trim()) == true ? 0 : amount;
            destinationTransaction.WithdrawAmount = 0;
            destinationTransaction.TransactionType = (int)TransaActionType.Transfer;
            destinationTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;

            var cDate = txtDate.Text.Split('/');
            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            destinationTransaction.Date = DateTime.Now;
            destinationTransaction.TransactionDateTime = TransactionDateTime;
            destinationTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Update(destinationTransaction);
            unitOfWork.SaveChanges();

            #region Log
            var logDate = DateTime.Now.ToShortDateString();
            var log = new Domains.DailyOperation();
            log.Date = DateTime.Parse(logDate);
            log.Time = DateTime.Now.TimeOfDay;
            log.UserId = CurrentUser.UserID;
            log.UserName = CurrentUser.UserName;
            log.DocumentId = sourceTransaction.DocumentId;
            log.Description = $" {  sourceTransaction.Description } به شماره سند { sourceTransaction.DocumentId}";
            log.ActionType = (int)ActionType.Update;
            log.ActionText = Tools.GetEnumDescription(ActionType.Update);
            unitOfWork.DailyOperationServices.Insert(log);
            unitOfWork.SaveChanges();
            #endregion

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }

        private void CmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }


        private void cmbDestiniation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }


        private void CreateDescription()
        {
            txtDesc.Text = $" انتقال وجه از{CmbSource.Text} به {cmbDestiniation.Text} به مبلغ {txtAmount.Text} {cmbCurrencies.Text}";
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TransferAccountFrm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtAmount.Text += "000";
            }
            txtAmount.Select(txtAmount.Text.Length, 0);
            ShowChars();
        }
        private void ShowChars()
        {
            if (txtAmount.Text.Length > 0)
            {
                var currencyName = cmbCurrencies.Text;
                lblNumberString.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtAmount.Text.Replace(",", ""))) } {currencyName}";
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            Tools.CheckDate(txtDate);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateTransfer()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            sourceTransaction = new Domains.Transaction();
            sourceTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
            sourceTransaction.TransactionType = (int)TransaActionType.Transfer;
            sourceTransaction.DestinitionCustomerId = (int)cmbDestiniation.SelectedValue;
            sourceTransaction.SourceCustomerId = (int)CmbSource.SelectedValue;
            sourceTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            sourceTransaction.DepositAmount = 0;
            sourceTransaction.WithdrawAmount = String.IsNullOrEmpty(txtAmount.Text.Trim()) == true ? 0 : amount;
            sourceTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            sourceTransaction.Date = DateTime.Now;
            sourceTransaction.TransactionDateTime = TransactionDateTime;
            sourceTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(sourceTransaction);
            unitOfWork.SaveChanges();


            destinationTransaction = new Domains.Transaction();
            destinationTransaction.DoubleTransactionId = sourceTransaction.Id;
            destinationTransaction.DocumentId = sourceTransaction.DocumentId;
            destinationTransaction.SourceCustomerId = (int)cmbDestiniation.SelectedValue;
            destinationTransaction.DestinitionCustomerId = (int)CmbSource.SelectedValue;
            destinationTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            destinationTransaction.DepositAmount = String.IsNullOrEmpty(txtAmount.Text.Trim()) == true ? 0 : amount;
            destinationTransaction.WithdrawAmount = 0;
            destinationTransaction.TransactionType = (int)TransaActionType.Transfer;
            destinationTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;

            var cDate = txtDate.Text.Split('/');
            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            destinationTransaction.Date = DateTime.Now;
            destinationTransaction.TransactionDateTime = TransactionDateTime;
            destinationTransaction.UserId = CurrentUser.UserID;
            destinationTransaction.OriginalTransactionId = sourceTransaction.Id;

            unitOfWork.TransactionServices.Insert(destinationTransaction);
            unitOfWork.SaveChanges();

            sourceTransaction.OriginalTransactionId = sourceTransaction.Id;
            sourceTransaction.DoubleTransactionId = destinationTransaction.Id;
            unitOfWork.TransactionServices.Update(sourceTransaction);
            unitOfWork.SaveChanges();

            #region Log
            var logDate = DateTime.Now.ToShortDateString();
            var log = new Domains.DailyOperation();
            log.Date = DateTime.Parse(logDate);
            log.Time = DateTime.Now.TimeOfDay;
            log.UserId = CurrentUser.UserID;
            log.UserName = CurrentUser.UserName;
            log.DocumentId = sourceTransaction.DocumentId;
            log.Description = $" {  sourceTransaction.Description } به شماره سند { sourceTransaction.DocumentId}";
            log.ActionType = (int)ActionType.Insert;
            log.ActionText = Tools.GetEnumDescription(ActionType.Insert);
            unitOfWork.DailyOperationServices.Insert(log);
            unitOfWork.SaveChanges();
            #endregion
        }
        private void CleanForm()
        {
            txtAmount.Text = "0";
            txtDesc.Text = "";
            lblNumberString.Text = "";
            lbl_Document_Id_value.Text = unitOfWork.TransactionServices.GetNewDocumentId().ToString();
            txtDate.Select();
            txtDate.Focus();

        }
        private bool checkEntryData()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            if (txtAmount.Text.Trim().Length < 1 || amount < 1)
            {
                return false;
            }
            return true;
        }
    }
}