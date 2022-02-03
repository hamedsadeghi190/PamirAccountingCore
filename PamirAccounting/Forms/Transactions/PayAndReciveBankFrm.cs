using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
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

            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();

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



        private void PayAndReciveBankFrm_Load(object sender, EventArgs e)
        {
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

        private void cmbAction_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((int)cmbAction.SelectedValue == 1)
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
                _varizType = new List<ComboBoxModel>();
                _varizType.Add(new ComboBoxModel() { Id = 2, Title = " معلوم" });

                cmbVarizType.DataSource = _varizType;
                cmbVarizType.ValueMember = "Id";
                cmbVarizType.DisplayMember = "Title";
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
                SaveEdit();
            }
            else
            {
                SaveNew();
            }

            Close();
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
            Close();
        }

        private void SaveEdit()
        {
            // throw new NotImplementedException();
        }

        private void CreateWithDraw()
        {


            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            bankTransaction = new Domains.Transaction();
            bankTransaction.DocumentId = documentId;
            bankTransaction.TransactionType = 3;
            bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;
            bankTransaction.Description = createDescription(txtdesc.Text);
            bankTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
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
            customerTransaction.TransactionType = 3;
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
            bankTransaction.Description = createDescription(txtdesc.Text);
            customerTransaction.DepositAmount = 0;
            customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);


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
            bankTransaction = new Domains.Transaction();
            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            bankTransaction.Description = createDescription(txtdesc.Text);
            bankTransaction.DocumentId = documentId;

            if ((int)cmbVarizType.SelectedValue == (int)DepostType.Unkown)
            {
                bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
                bankTransaction.UnkownAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            }
            else
            {
                bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                bankTransaction.TransactionType = (int)TransaActionType.UnkwonReciveBank;
            }

            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;

            bankTransaction.DepositAmount = 0;
            bankTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
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
                customerTransaction.TransactionType = 3;
                customerTransaction.DoubleTransactionId = bankTransaction.Id;
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
                customerTransaction.Description = txtdesc.Text;
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
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

        private string createDescription(string value)
        {
            if (value.Length > 0) return value;

            var result = "";
            if ((int)cmbAction.SelectedValue == 1)
            {
                result = " واریز به بانک  توسط ";

                if ((int)cmbVarizType.SelectedValue == (int)DepostType.known)
                {
                    result += cmbCustomers.Text + " " + txtReceiptNumber.Text + " " + cmbBanks.SelectedText + " شعبه " + txtBranchCode.Text;
                }
                else
                {
                    result += " مشتری ناشناس به شماره فیش " + txtReceiptNumber.Text + " " + cmbBanks.SelectedText + " شعبه " + txtBranchCode.Text;
                }
            }
            else
            {
                result = " پرداخت به  " + cmbCustomers.Text + " به شماره فیش " + txtReceiptNumber.Text + " - " + cmbBanks.SelectedText + " شعبه " + txtBranchCode.Text;
            }
            return result;
        }


        private void createAccount(int SourceCustomerId, int CurrenyId)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = SourceCustomerId;
            newTransaction.TransactionType = 1;
            newTransaction.Description = "حساب جدید";
            newTransaction.WithdrawAmount = 0;
            newTransaction.DepositAmount = 0;
            newTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
            newTransaction.CurrenyId = CurrenyId;
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = DateTime.Now;
            newTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(newTransaction);
            unitOfWork.SaveChanges();

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
                lblNumberString.Text = $"{ NumberUtility.GetString(txtAmount.Text.Replace(",", "")) } {currencyName}";
            }
        }

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChars();
        }
    }
}