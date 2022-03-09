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
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();

            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";

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

            _Banks = unitOfWork.CustomerServices.FindAll(x => x.GroupId == 2).Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();

            cmbBanks.DataSource = _Banks;
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
                cmbCustomers.SelectedValue = _Id;
                cmbCustomers.Enabled = false;
                loadTransActionInfo(_TransActionId);
            }
            else
            {
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDate.Text = PDate;
            }

        }

        private void loadTransActionInfo(long? transActionId)
        {
            if (customerTransaction.DoubleTransactionId != null)
            {


                customerTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == transActionId.Value);
                bankTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == customerTransaction.DoubleTransactionId);

                if (customerTransaction.WithdrawAmount.Value != 0)
                {
                    txtAmount.Text = customerTransaction.WithdrawAmount.Value.ToString();
                    cmbAction.SelectedValue = 1;
                }
                else
                {
                    txtAmount.Text = customerTransaction.DepositAmount.Value.ToString();
                    cmbAction.SelectedValue = 2;
                }

                txtdesc.Text = customerTransaction.Description;
                cmbCurrencies.SelectedValue = customerTransaction.CurrenyId;
                cmbCurrencies.Enabled = false;
                cmbCustomers.SelectedValue = customerTransaction.SourceCustomerId;
                cmbCustomers.Enabled = false;

                cmbBanks.SelectedValue = bankTransaction.SourceCustomerId;

                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(customerTransaction.TransactionDateTime).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDate.Text = PDate;
            }
            else
            {

            }
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
            if ((int)cmbVarizType.SelectedValue == (int)DepostType.known)
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

        }


        private void EditWithDraw()
        {

            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            bankTransaction = new Domains.Transaction();
            bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;
            bankTransaction.Description = createDescription(txtdesc.Text);
            bankTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            bankTransaction.WithdrawAmount = 0;
            bankTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Update(bankTransaction);
            unitOfWork.SaveChanges();


            var customerTransaction = new Domains.Transaction();
            customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
            customerTransaction.Description = createDescription(txtdesc.Text);
            customerTransaction.DepositAmount = 0;
            customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var cDate = txtDate.Text.Split('/');

            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DoubleTransactionId = bankTransaction.Id;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();

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
            var cDate = txtDate.Text.Split('/');

            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DoubleTransactionId = bankTransaction.Id;
            customerTransaction.DocumentId = documentId;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();

            //sabt sande double
            bankTransaction.DoubleTransactionId = customerTransaction.Id;
            unitOfWork.TransactionServices.Update(bankTransaction);
            unitOfWork.SaveChanges();
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

                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();

                //sabt sande double
                bankTransaction.DoubleTransactionId = customerTransaction.Id;
                unitOfWork.TransactionServices.Update(bankTransaction);
                unitOfWork.SaveChanges();

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

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtAmount.Text += "000";
            }

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
            txtdesc.Text = "";
            txtBranchCode.Text = "";
            txtReceiptNumber.Text = "";
            lblNumberString.Text = "";
            cmbAction.Select();
            cmbAction.Focus();

        }
    }
}