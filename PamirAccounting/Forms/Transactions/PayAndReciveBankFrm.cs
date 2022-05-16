using JntNum2Text;
using PamirAccounting.Commons.Enums;
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
    public partial class PayAndReciveBankFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ComboBoxModel> _Currencies, _varizType, _RemainType, _Customers, _Banks;
        private int? _Id;
        private long? _TransActionId;
        public Domains.Transaction bankTransaction;
        public Domains.Transaction customerTransaction;
        long amount;
        public PayAndReciveBankFrm(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _Id = Id;
            _TransActionId = transActionId;
        }


        public PayAndReciveBankFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void LoadData()
        {
            this.cmbAction.SelectedIndexChanged -= new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            this.cmbAction.SelectedValueChanged -= new System.EventHandler(this.cmbAction_SelectedValueChanged);
            this.cmbVarizType.SelectedValueChanged -= new System.EventHandler(this.cmbVarizType_SelectedValueChanged);

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
            ///////////////////////////
            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();
            cmbCustomers.DataSource = _Customers;
            AutoCompleteStringCollection autoCustomers = new AutoCompleteStringCollection();
            foreach (var item in _Customers)
            {
                autoCustomers.Add(item.Title);
            }

            cmbCustomers.AutoCompleteCustomSource = autoCustomers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";
            ////////////////////////////
            if (_Id != null)
            {
                cmbCustomers.SelectedValue = _Id;
            }

            _RemainType = new List<ComboBoxModel>();
            _RemainType.Add(new ComboBoxModel() { Id = 1, Title = " دریافت (آمد)" });
            _RemainType.Add(new ComboBoxModel() { Id = 2, Title = "پرداخت (رفت )" });

            cmbAction.DataSource = _RemainType;
            cmbAction.ValueMember = "Id";
            cmbAction.DisplayMember = "Title";

            _varizType = new List<ComboBoxModel>();
            _varizType.Add(new ComboBoxModel() { Id = 1, Title = "نامعلوم" });
            _varizType.Add(new ComboBoxModel() { Id = 2, Title = " معلوم" });

            cmbVarizType.DataSource = _varizType;
            cmbVarizType.ValueMember = "Id";
            cmbVarizType.DisplayMember = "Title";

            _Banks = unitOfWork.CustomerServices.FindAll(x => x.GroupId == 2, "Bank").Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}", Type = x.Bank.BaseCurrencyId.GetValueOrDefault() }).ToList();

            cmbBanks.DataSource = _Banks;

            AutoCompleteStringCollection autoBanks = new AutoCompleteStringCollection();
            foreach (var item in _Banks)
            {
                autoBanks.Add(item.Title);
            }
            cmbBanks.AutoCompleteCustomSource = autoBanks;
            cmbBanks.ValueMember = "Id";
            cmbBanks.DisplayMember = "Title";

            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbAction_SelectedIndexChanged);
            this.cmbAction.SelectedValueChanged += new System.EventHandler(this.cmbAction_SelectedValueChanged);
            this.cmbVarizType.SelectedValueChanged += new System.EventHandler(this.cmbVarizType_SelectedValueChanged);
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }


        private void PayAndReciveBankFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCustomers.Handle, 25);
            cmbCustomers.Refresh();
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            SetComboBoxHeight(cmbAction.Handle, 25);
            cmbAction.Refresh();
            SetComboBoxHeight(cmbBanks.Handle, 25);
            cmbBanks.Refresh();
            SetComboBoxHeight(cmbVarizType.Handle, 25);
            cmbVarizType.Refresh();


            cmbAction.Select();
            cmbAction.Focus();
            LoadData();

            if (_TransActionId.HasValue)
            {

                cmbCustomers.Enabled = false;
                cmbCustomers.Visible = true;
                cmbAction.Enabled = false;
                cmbCurrencies.Enabled = true;
                loadTransActionInfo(_TransActionId);
            }
            else
            {

                txtDate.Text = DateTime.Now.ToFarsiFormat();
                lbl_Document_Id_value.Text = unitOfWork.TransactionServices.GetNewDocumentId().ToString();
            }

        }

        private void loadTransActionInfo(long? transActionId)
        {
            var tempTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == transActionId.Value);

            bankTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == tempTransaction.OriginalTransactionId);

            if (bankTransaction.DoubleTransactionId != null)
            {
                customerTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == bankTransaction.DoubleTransactionId);

            }

            lbl_Document_Id_value.Text = bankTransaction.DocumentId.ToString();

            if (bankTransaction.DepositAmount.Value != 0)
            {
                txtAmount.Text = bankTransaction.DepositAmount.Value.ToString();
                cmbAction.SelectedValue = 2;
                lblCustomers.Visible = true;
                cmbVarizType.Visible = false;
                lbl_variz_type.Visible = false;
                txtdesc.Text = bankTransaction.Description;
                cmbCurrencies.SelectedValue = bankTransaction.CurrenyId;
                cmbCurrencies.Enabled = true;
                cmbBanks.SelectedValue = bankTransaction.SourceCustomerId;
                cmbCustomers.SelectedValue = customerTransaction.SourceCustomerId;
                cmbCustomers.Enabled = true;
            }
            else
            {
                if (bankTransaction.TransactionType == (int)TransaActionType.UnkwonReciveBank)
                {
                    cmbVarizType.Visible = true;
                    cmbCustomers.Visible = false;
                    lblCustomers.Visible = false;
                    cmbCustomers.Enabled = true;
                    cmbVarizType.SelectedValue = (int)DepostType.Unkown;
                }
                else
                {
                    cmbVarizType.SelectedValue = (int)DepostType.known;
                    cmbCustomers.Visible = true;
                    lblCustomers.Visible = true;
                    cmbCustomers.SelectedValue = customerTransaction.SourceCustomerId;
                    cmbCustomers.Enabled = true;
                }

                cmbAction.SelectedValue = 1;
                txtAmount.Text = bankTransaction.WithdrawAmount.Value.ToString();
            }

            cmbCurrencies.SelectedValue = bankTransaction.CurrenyId;
            txtReceiptNumber.Text = bankTransaction.ReceiptNumber;
            txtBranchCode.Text = bankTransaction.BranchCode;
            txtDate.Text = bankTransaction.TransactionDateTime.ToFarsiFormat();
            ShowChars();

        }

        private void cmbAction_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((int)cmbAction.SelectedValue == 1)
            {
                cmbCustomers.Visible = false;
                lblCustomers.Visible = false;
                cmbVarizType.Visible = true;
                lbl_variz_type.Visible = true;
            }
            else
            {
                cmbCustomers.Visible = true;
                lblCustomers.Visible = true;
                cmbVarizType.Visible = false;
                lbl_variz_type.Visible = false;
            }

        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbVarizType_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((int)cmbVarizType.SelectedValue == 1)
            {
                cmbCustomers.Visible = false;
                lblCustomers.Visible = false;
            }
            else
            {
                cmbCustomers.Visible = true;
                lblCustomers.Visible = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            if (_TransActionId.HasValue)
            {
                if (CheckEntries() == true)
                {
                    if ((int)cmbAction.SelectedValue == 2)
                    {
                        var balance = unitOfWork.TransactionServices.GetCustomerBalace((int)cmbBanks.SelectedValue, (int)cmbCurrencies.SelectedValue);
                        if (balance < 0 && (balance * -1) > long.Parse(txtAmount.Text))
                        {
                        }
                        else
                        {
                            MessageBox.Show("مبلغ انتخابی از موجودی بانک بیشتر است", "مقادیر ورودی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAmount.Focus();
                            return;
                        }
                    }
                    SaveEdit();
                    Close();

                    MessageBox.Show("اطلاعات با موفقیت ثبت شد.", " ذخیره اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید.", " ذخیره اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtDate.Focus();
                }
            }
            else
            {
                if (CheckEntries() == true)
                {
                    if ((int)cmbAction.SelectedValue == 2)
                    {
                        var balance = unitOfWork.TransactionServices.GetCustomerBalace((int)cmbBanks.SelectedValue, (int)cmbCurrencies.SelectedValue);
                        if (balance < 0 && (balance * -1) > long.Parse(txtAmount.Text))
                        {
                        }
                        else
                        {
                            MessageBox.Show("مبلغ انتخابی از موجودی بانک بیشتر است", "مقادیر ورودی", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAmount.Focus();
                            return;
                        }
                    }

                    SaveNew();
                    CleanForm();
                    MessageBox.Show("اطلاعات با موفقیت ثبت شد.", " ذخیره اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید.", " ذخیره اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
             MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    txtDate.Focus();
                }
            }

        }

        private bool CheckEntries()
        {
            if (txtAmount.Text.Length == 0 || Convert.ToInt64(txtAmount.Text.Replace(",", "")) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SaveNew()
        {
            if ((int)cmbAction.SelectedValue == 1)
            {
                CreateDeposit();
            }
            else
            {
                CreateWithDraw();
            }
            CleanForm();
        }

        private void SaveEdit()
        {
            if ((int)cmbAction.SelectedValue == 1)
            {
                EditDeposit();
            }
            else
            {
                EditWithDraw();
            }

        }


        private void EditDeposit()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));

            bankTransaction.Description = createDescription(txtdesc.Text);

            if ((int)cmbVarizType.SelectedValue == (int)DepostType.Unkown)
            {
                bankTransaction.TransactionType = (int)TransaActionType.UnkwonReciveBank;
                bankTransaction.UnkownAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            }
            else
            {
                bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            }

            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;

            bankTransaction.DepositAmount = 0;
            bankTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            bankTransaction.ReceiptNumber = txtReceiptNumber.Text;
            bankTransaction.BranchCode = txtBranchCode.Text;
            bankTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            bankTransaction.Description = createDescription(txtdesc.Text);
            unitOfWork.TransactionServices.Update(bankTransaction);
            unitOfWork.SaveChanges();

            //ثبت واریز برای مشتری
            if ((int)cmbVarizType.SelectedValue == (int)DepostType.known && customerTransaction != null)
            {


                customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
                customerTransaction.DoubleTransactionId = bankTransaction.Id;
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
                customerTransaction.Description = txtdesc.Text;
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
                customerTransaction.BranchCode = txtBranchCode.Text;
                customerTransaction.Description = createDescription(txtdesc.Text);

                customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                var cDate = txtDate.Text.Split('/');

                PersianCalendar pc = new PersianCalendar();
                TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;

                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();

            }
            //ثبت واریز برای مشتری
            else if ((int)cmbVarizType.SelectedValue == (int)DepostType.known && customerTransaction == null)
            {
                customerTransaction = new Domains.Transaction();
                customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
                customerTransaction.DoubleTransactionId = bankTransaction.Id;
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
                customerTransaction.Description = txtdesc.Text;
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.DocumentId = bankTransaction.DocumentId;
                customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
                customerTransaction.BranchCode = txtBranchCode.Text;
                customerTransaction.Description = createDescription(txtdesc.Text);

                customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                var cDate = txtDate.Text.Split('/');

                PersianCalendar pc = new PersianCalendar();
                TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.OriginalTransactionId = bankTransaction.Id;
                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();

                //sabt sande double
                bankTransaction.DoubleTransactionId = customerTransaction.Id;
                unitOfWork.TransactionServices.Update(bankTransaction);
                unitOfWork.SaveChanges();


                #region Log
                var logDate = DateTime.Now.ToShortDateString();
                var log = new Domains.DailyOperation();
                log.Date = DateTime.Parse(logDate);
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.DocumentId = customerTransaction.DocumentId;
                log.TransactionId = customerTransaction.OriginalTransactionId;
                log.Description = $" {createDescription(txtdesc.Text)} به شماره سند { customerTransaction.DocumentId}";
                log.ActionType = (int)Settings.ActionType.Update;
                log.ActionText = Tools.GetEnumDescription(Settings.ActionType.Update);
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion
            }

        }


        private void EditWithDraw()
        {

            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;
            bankTransaction.Description = createDescription(txtdesc.Text);
            bankTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            bankTransaction.WithdrawAmount = 0;
            bankTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            bankTransaction.ReceiptNumber = txtReceiptNumber.Text;
            bankTransaction.BranchCode = txtBranchCode.Text;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Update(bankTransaction);
            unitOfWork.SaveChanges();
            ///////////////////////////////////////////////////////////////

            customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
            customerTransaction.Description = createDescription(txtdesc.Text);
            customerTransaction.DepositAmount = 0;
            customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
            customerTransaction.BranchCode = txtBranchCode.Text;

            var cDate = txtDate.Text.Split('/');

            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DoubleTransactionId = bankTransaction.Id;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();

            #region Log
            var logDate = DateTime.Now.ToShortDateString();
            var log = new Domains.DailyOperation();
            log.Date = DateTime.Parse(logDate);
            log.Time = DateTime.Now.TimeOfDay;
            log.UserId = CurrentUser.UserID;
            log.UserName = CurrentUser.UserName;
            log.DocumentId = customerTransaction.DocumentId;
            log.TransactionId = customerTransaction.OriginalTransactionId;
            log.Description = $" {createDescription(txtdesc.Text)} به شماره سند { customerTransaction.DocumentId}";
            log.ActionType = (int)Settings.ActionType.Update;
            log.ActionText = Tools.GetEnumDescription(Settings.ActionType.Update);
            unitOfWork.DailyOperationServices.Insert(log);
            unitOfWork.SaveChanges();
            #endregion

        }

        private void CreateWithDraw()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            bankTransaction = new Domains.Transaction();
            bankTransaction.DocumentId = documentId;
            bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;
            bankTransaction.Description = createDescription(txtdesc.Text);
            bankTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            bankTransaction.WithdrawAmount = 0;
            bankTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            bankTransaction.ReceiptNumber = txtReceiptNumber.Text;
            bankTransaction.BranchCode = txtBranchCode.Text;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(bankTransaction);
            unitOfWork.SaveChanges();


            var customerTransaction = new Domains.Transaction();
            customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
            customerTransaction.Description = createDescription(txtdesc.Text);
            customerTransaction.DepositAmount = 0;
            customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            customerTransaction.OriginalTransactionId = bankTransaction.Id;
            customerTransaction.DoubleTransactionId = bankTransaction.Id;
            var cDate = txtDate.Text.Split('/');

            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = documentId;
            customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
            customerTransaction.BranchCode = txtBranchCode.Text;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();

            //sabt sande double
            bankTransaction.OriginalTransactionId = bankTransaction.Id;
            bankTransaction.DoubleTransactionId = customerTransaction.Id;
            unitOfWork.TransactionServices.Update(bankTransaction);
            unitOfWork.SaveChanges();

            #region Log
            var logDate = DateTime.Now.ToShortDateString();
            var log = new Domains.DailyOperation();
            log.Date = DateTime.Parse(logDate);
            log.Time = DateTime.Now.TimeOfDay;
            log.UserId = CurrentUser.UserID;
            log.UserName = CurrentUser.UserName;
            log.DocumentId = customerTransaction.DocumentId;
            log.TransactionId = customerTransaction.OriginalTransactionId;
            log.Description = $" {createDescription(txtdesc.Text)} به شماره سند { customerTransaction.DocumentId}";
            log.ActionType = (int)Settings.ActionType.Insert;
            log.ActionText = Tools.GetEnumDescription(Settings.ActionType.Insert);
            unitOfWork.DailyOperationServices.Insert(log);
            unitOfWork.SaveChanges();
            #endregion
        }

        private void CreateDeposit()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            bankTransaction = new Domains.Transaction();
            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            bankTransaction.Description = createDescription(txtdesc.Text);
            bankTransaction.DocumentId = documentId;

            if ((int)cmbVarizType.SelectedValue == (int)DepostType.Unkown)
            {
                bankTransaction.TransactionType = (int)TransaActionType.UnkwonReciveBank;
                bankTransaction.UnkownAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            }
            else
            {
                bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            }

            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;

            bankTransaction.DepositAmount = 0;
            bankTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            bankTransaction.ReceiptNumber = txtReceiptNumber.Text;
            bankTransaction.BranchCode = txtBranchCode.Text;
            bankTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            bankTransaction.Description = createDescription(txtdesc.Text);
            unitOfWork.TransactionServices.Insert(bankTransaction);
            unitOfWork.SaveChanges();
            //save original id
            bankTransaction.OriginalTransactionId = bankTransaction.Id;
            unitOfWork.TransactionServices.Update(bankTransaction);
            unitOfWork.SaveChanges();

            //ثبت واریز برای مشتری
            if ((int)cmbVarizType.SelectedValue == (int)DepostType.known)
            {

                customerTransaction = new Domains.Transaction();
                customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
                customerTransaction.DoubleTransactionId = bankTransaction.Id;
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
                customerTransaction.Description = txtdesc.Text;
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.DocumentId = documentId;
                customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
                customerTransaction.BranchCode = txtBranchCode.Text;
                customerTransaction.Description = createDescription(txtdesc.Text);

                customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                var cDate = txtDate.Text.Split('/');

                PersianCalendar pc = new PersianCalendar();
                TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.OriginalTransactionId = bankTransaction.Id;
                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();

                //sabt sande double
                bankTransaction.DoubleTransactionId = customerTransaction.Id;
                unitOfWork.TransactionServices.Update(bankTransaction);
                unitOfWork.SaveChanges();

                #region Log
                var logDate = DateTime.Now.ToShortDateString();
                var log = new Domains.DailyOperation();
                log.Date = DateTime.Parse(logDate);
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.DocumentId = customerTransaction.DocumentId;
                log.TransactionId = customerTransaction.OriginalTransactionId;
                log.Description = $" {createDescription(txtdesc.Text)} به شماره سند { customerTransaction.DocumentId}";
                log.ActionType = (int)Settings.ActionType.Insert;
                log.ActionText = Tools.GetEnumDescription(Settings.ActionType.Insert);
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion

            }

        }

        private void PayAndReciveBankFrm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private string createDescription(string value)
        {
            if (value.Length > 0) return value;

            var result = "";
            if ((int)cmbAction.SelectedValue == 1)
            {
                result = " واریز به بانک  توسط ";

                if ((int)cmbVarizType.SelectedValue == (int)DepostType.known)
                {
                    result += cmbCustomers.Text + " " + txtReceiptNumber.Text + " " + cmbBanks.Text + " شعبه " + txtBranchCode.Text;
                }
                else
                {
                    result += " مشتری ناشناس به شماره فیش " + txtReceiptNumber.Text + " " + cmbBanks.Text + " شعبه " + txtBranchCode.Text;
                }
            }
            else
            {
                result = " پرداخت به  " + cmbCustomers.Text + " به شماره فیش " + txtReceiptNumber.Text + " - " + cmbBanks.Text + " شعبه " + txtBranchCode.Text;
            }
            return result;
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            Tools.CheckDate(txtDate);
        }

        private void cmbBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedBank = _Banks.FirstOrDefault(x => x.Id == (int)cmbBanks.SelectedValue);
                cmbCurrencies.SelectedValue = selectedBank.Type;
            }
            catch
            {

               
            }
     
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

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChars();
        }
        private void CleanForm()
        {
            txtAmount.Text = "0";
            lbl_Document_Id_value.Text = unitOfWork.TransactionServices.GetNewDocumentId().ToString();
            txtdesc.Text = "";
            txtDate.Text = DateTime.Now.ToFarsiFormat();
            txtBranchCode.Text = "";
            txtReceiptNumber.Text = "";
            lblNumberString.Text = "";
            cmbAction.SelectedIndex = 0;
            cmbBanks.SelectedIndex = 0;
            cmbCurrencies.SelectedIndex = 0;
            cmbVarizType.SelectedIndex = 0;
            cmbCustomers.SelectedIndex = 0;
            cmbCustomers.Visible = false;
            lblCustomers.Visible = false;
            cmbVarizType.Visible = true;
            lbl_variz_type.Visible = true;
        }
    }
}