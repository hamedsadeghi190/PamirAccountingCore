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

namespace PamirAccounting.Forms.Transaction
{
    public partial class CreateNewCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private Domains.Transaction transaction;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _RemainType;
        private long? _TransActionId;
        private int _Id;

        public CreateNewCustomerAccount(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _Id = Id;
            _TransActionId = transActionId;
        }

        public CreateNewCustomerAccount()
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

        private void CreateNewCustomerAccount_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            SetComboBoxHeight(cmbRemainType.Handle, 25);
            cmbRemainType.Refresh();
            LoadData();

            if (_TransActionId.HasValue)
            {
                transaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == _TransActionId.Value);

                lbl_Document_Id_value.Text = transaction.DocumentId.ToString();

                if (transaction.WithdrawAmount.Value != 0)
                {
                    txtAmount.Text = transaction.WithdrawAmount.Value.ToString();
                    cmbRemainType.SelectedValue = 1;
                }
                else
                {
                    txtAmount.Text = transaction.DepositAmount.Value.ToString();
                    cmbRemainType.SelectedValue = 2;
                }

                txtdesc.Text = transaction.Description;
                cmbCurrencies.SelectedValue = transaction.CurrenyId;
                cmbCurrencies.Enabled = false;

                txtDate.Text = transaction.TransactionDateTime.ToFarsiFormat();
            }
            else
            {
                txtDate.Text = DateTime.Now.ToFarsiFormat();
                lbl_Document_Id_value.Text = unitOfWork.TransactionServices.GetNewDocumentId().ToString();
            }
        }

        private void LoadData()
        {
         
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

            _RemainType = new List<ComboBoxModel>();
            _RemainType.Add(new ComboBoxModel() { Id = 1, Title = "بدهکار (رفت )" });
            _RemainType.Add(new ComboBoxModel() { Id = 2, Title = "طلبکار(آمد)" });

            cmbRemainType.DataSource = _RemainType;
            cmbRemainType.ValueMember = "Id";
            cmbRemainType.DisplayMember = "Title";
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {

            try
            {
                var amount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                if (amount == 0)
                {
                    MessageBox.Show("مانده از قبل باید بیشتر از صفر باشد.", "خطای ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    return;
                }

                if (transaction != null)
                {
                    transaction.Description = (txtdesc.Text.Length > 0) ? txtdesc.Text : Messages.CreateNewAcount + cmbCurrencies.SelectedText;

                    if ((int)cmbRemainType.SelectedValue == 1)
                    {
                        transaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                        transaction.DepositAmount = 0;
                    }
                    else
                    {
                        transaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                        transaction.WithdrawAmount = 0;
                    }

                    transaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                    var dDate = txtDate.Text.Split('/');

                    PersianCalendar p = new PersianCalendar();
                    var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                    transaction.Date = DateTime.Now;
                    transaction.TransactionDateTime = TransactionDateTime;
                    transaction.UserId = CurrentUser.UserID;

                    unitOfWork.TransactionServices.Update(transaction);
                    unitOfWork.SaveChanges();

                    #region Log
                    var logDate = DateTime.Now.ToShortDateString();
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(logDate);
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.DocumentId = transaction.DocumentId;
                    log.Description = $" {  transaction.Description } به شماره سند { transaction.DocumentId}";
                    log.ActionType = (int)ActionType.Update;
                    log.ActionText = Tools.GetEnumDescription(ActionType.Update);
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion

                }
                else
                {
                    var account = unitOfWork.Transactions.FindFirstOrDefault(x => x.SourceCustomerId == _Id && x.TransactionType == 1 && x.CurrenyId == (int)cmbCurrencies.SelectedValue);

                    if (account != null)
                    {
                        MessageBox.Show("برای این ارز قبلا حساب ایجاد شده است");
                        return;
                    }

                    var newTransaction = new Domains.Transaction();
                    newTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
                    newTransaction.SourceCustomerId = _Id;
                    newTransaction.TransactionType = (int)TransaActionType.NewAccount;
                    newTransaction.Description = (txtdesc.Text.Length > 0) ? txtdesc.Text : Messages.CreateNewAcount + cmbCurrencies.Text;

                    if ((int)cmbRemainType.SelectedValue == 1)
                    {
                        newTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                        newTransaction.DepositAmount = 0;
                    }
                    else
                    {
                        newTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                        newTransaction.WithdrawAmount = 0;
                    }

                    newTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                    var dDate = txtDate.Text.Split('/');

                    PersianCalendar p = new PersianCalendar();
                    var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                    newTransaction.Date = DateTime.Now;
                    newTransaction.TransactionDateTime = TransactionDateTime;
                    newTransaction.UserId = CurrentUser.UserID;

                    unitOfWork.TransactionServices.Insert(newTransaction);
                    unitOfWork.SaveChanges();
                    
                    newTransaction.OriginalTransactionId = newTransaction.Id;
                    unitOfWork.TransactionServices.Update(newTransaction);
                    unitOfWork.SaveChanges();

                    #region Log
                    var logDate = DateTime.Now.ToShortDateString();
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(logDate);
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.DocumentId = newTransaction.DocumentId;
                    log.Description = $" {  newTransaction.Description } به شماره سند { newTransaction.DocumentId}";
                    log.ActionType = (int)ActionType.Insert;
                    log.ActionText = Tools.GetEnumDescription(ActionType.Insert);
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات موفقیت امیز نبود", "خطای ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                AppSetting.SaveLog("newCustomerAccount", "Save", ex);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChars();
        }

        private void CreateNewCustomerAccount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}