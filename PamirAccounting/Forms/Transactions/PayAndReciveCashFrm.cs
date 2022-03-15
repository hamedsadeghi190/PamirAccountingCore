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

namespace PamirAccounting.Forms.Transactions
{
    public partial class PayAndReciveCashFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private List<ComboBoxModel> _Currencies, _RemainType, _Customers;
        private int? _CustomerId;
        private long? _TransActionId;
        public Domains.Transaction sandoghTransAction;
        public Domains.Transaction customerTransaction;
        private string CustomerDesc;
        long amount;
        bool isMessageShow = false;
        public PayAndReciveCashFrm(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _CustomerId = Id;
            _TransActionId = transActionId;
        }

        public PayAndReciveCashFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void InitForm()
        {
            this.cmbCurrencies.SelectedIndexChanged -= new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            this.cmbCustomers.SelectedValueChanged -= new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
            this.cmbRemainType.SelectedIndexChanged -= new System.EventHandler(this.cmbRemainType_SelectedIndexChanged);
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();

            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";


            _RemainType = new List<ComboBoxModel>();
            _RemainType.Add(new ComboBoxModel() { Id = 1, Title = "بدهکار (رفت )" });
            _RemainType.Add(new ComboBoxModel() { Id = 2, Title = "طلبکار(آمد)" });

            cmbRemainType.DataSource = _RemainType;
            cmbRemainType.ValueMember = "Id";
            cmbRemainType.DisplayMember = "Title";

            this.cmbCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            this.cmbCustomers.SelectedValueChanged += new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
            this.cmbRemainType.SelectedIndexChanged += new System.EventHandler(this.cmbRemainType_SelectedIndexChanged);
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }


        private void PayAndReciveCashFrm_Load(object sender, EventArgs e)
        {
            InitForm();

            SetComboBoxHeight(cmbCustomers.Handle, 25);
            cmbCustomers.Refresh();
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            SetComboBoxHeight(cmbRemainType.Handle, 25);
            cmbRemainType.Refresh();

            if (_TransActionId.HasValue)
            {
                cmbCustomers.SelectedValue = _CustomerId;
                cmbCustomers.Enabled = false;
                loadTransActionInfo(_TransActionId);
            }
            else
            {
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDate.Text = PDate;

                if (_CustomerId.HasValue)
                {
                    cmbCustomers.SelectedValue = _CustomerId;
                }
            }
        }

        private void loadTransActionInfo(long? transActionId)
        {
            customerTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == transActionId.Value);
            sandoghTransAction = unitOfWork.TransactionServices.FindFirst(x => x.Id == customerTransaction.DoubleTransactionId);

            if (customerTransaction.WithdrawAmount.Value != 0)
            {
                txtAmount.Text = customerTransaction.WithdrawAmount.Value.ToString();
                cmbRemainType.SelectedValue = 1;
            }
            else
            {
                txtAmount.Text = customerTransaction.DepositAmount.Value.ToString();
                cmbRemainType.SelectedValue = 2;
            }
            txtdesc.Text = customerTransaction.Description;
            cmbCurrencies.SelectedValue = customerTransaction.CurrenyId;
            cmbCurrencies.Enabled = false;
            cmbCustomers.SelectedValue = customerTransaction.SourceCustomerId;
            cmbCustomers.Enabled = false;

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(customerTransaction.TransactionDateTime).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDate.Text = PDate;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            if (checkEntryData())
            {
                if (_TransActionId.HasValue)
                {
                    SaveEdit();
                    MessageBox.Show("عملیات با موفقیت ویزایش گردید", " ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    SaveNew();
                    MessageBox.Show("عملیات با موفقیت ثبت گردید", " ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                }


            }
            else
            {

                MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید", "مقادیر ورودی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                cmbCurrencies.Focus();
            }
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

        private void SaveNew()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            // trakonesh moshtari //
            var customerTransaction = new Domains.Transaction();

            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.SandoghCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveCash;

            customerTransaction.DocumentId = documentId;

            if ((int)cmbRemainType.SelectedValue == 1)
            {
                customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.DepositAmount = 0;
                customerTransaction.Description = CustomerDesc;
            }
            else
            {
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.Description = CustomerDesc;
            }

            customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');
            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
            //end moshtari ///

            //tarakonesh sandogh//
            var sandoghTransAction = new Domains.Transaction();
            sandoghTransAction.DoubleTransactionId = customerTransaction.Id;
            sandoghTransAction.DocumentId = documentId;

            if ((int)cmbRemainType.SelectedValue == 1)
            {
                sandoghTransAction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                sandoghTransAction.WithdrawAmount = 0;
                sandoghTransAction.Description = txtdesc.Text;
            }
            else
            {
                sandoghTransAction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                sandoghTransAction.DepositAmount = 0;
                sandoghTransAction.Description = txtdesc.Text;
            }


            sandoghTransAction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            sandoghTransAction.SourceCustomerId = AppSetting.SandoghCustomerId;
            sandoghTransAction.TransactionType = (int)TransaActionType.PayAndReciveCash;

            sandoghTransAction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            sandoghTransAction.Date = DateTime.Now;
            sandoghTransAction.TransactionDateTime = TransactionDateTime;
            sandoghTransAction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(sandoghTransAction);
            unitOfWork.SaveChanges();
            // end trakonesh sandogh///

            customerTransaction.DoubleTransactionId = sandoghTransAction.Id;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();

        }

        private void SaveEdit()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            // trakonesh moshtari //
            customerTransaction.Description = txtdesc.Text;

            if ((int)cmbRemainType.SelectedValue == 1)
            {
                customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.DepositAmount = 0;

            }
            else
            {
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.WithdrawAmount = 0;
            }

            customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');
            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();
            //end moshtari ///

            //tarakonesh sandogh//

            if ((int)cmbRemainType.SelectedValue == 1)
            {
                sandoghTransAction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                sandoghTransAction.WithdrawAmount = 0;
            }
            else
            {
                sandoghTransAction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                sandoghTransAction.DepositAmount = 0;
            }


            sandoghTransAction.Description = txtdesc.Text;
            sandoghTransAction.Date = DateTime.Now;
            sandoghTransAction.TransactionDateTime = TransactionDateTime;
            sandoghTransAction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Update(sandoghTransAction);
            unitOfWork.SaveChanges();
            // end trakonesh sandogh///

        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtAmount.Text += "000";
            }

            ShowChars();
            CreateDescription();
        }

        private void ShowChars()
        {
            if (txtAmount.Text.Length > 0)
            {
                try
                {
                    var currencyName = cmbCurrencies.Text;
                    lblNumberString.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtAmount.Text.Replace(",", ""))) } {currencyName}";
                }
                catch
                {

                }

            }
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }

        private void cmbRemainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }

        private void PayAndReciveCashFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = false;
            }
        }

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChars();
            CreateDescription();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            Tools.CheckDate(txtDate);
        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void CreateDescription()
        {
            var currencyName = cmbCurrencies.Text;
            if ((int)cmbRemainType.SelectedValue == 2)
            {
                CustomerDesc = $"{Messages.WithdrawCash } به صندوق  به مبلغ {txtAmount.Text} {currencyName}";
                txtdesc.Text = $"{Messages.DepostitCash } از  {cmbCustomers.Text} ({cmbCustomers.SelectedValue}) به مبلغ {txtAmount.Text} {currencyName}";
            }
            else
            {
                CustomerDesc = $"{Messages.DepostitCash } از صندوق  به مبلغ {txtAmount.Text} {currencyName}";
                txtdesc.Text = $"{Messages.WithdrawCash } به  {cmbCustomers.Text} ({cmbCustomers.SelectedValue}) به مبلغ {txtAmount.Text} {currencyName}";
            }
        }
        private void CleanForm()
        {
            txtAmount.Text = "0";
            txtdesc.Text = "";
            lblNumberString.Text = "";
            txtDate.Select();
            txtDate.Focus();

        }
    }
}