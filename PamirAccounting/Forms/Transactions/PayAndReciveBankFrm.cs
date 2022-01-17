using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Transactions
{
    public partial class PayAndReciveBankFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<ComboBoxModel> _Currencies, _varizType, _RemainType, _Customers, _Banks;


        public PayAndReciveBankFrm(int Id)
        {
            _Id = Id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            LoadData();
        }


        public PayAndReciveBankFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            LoadData();
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

        private void CreateWithDraw()
        {
            Domains.Transaction customerlastTransAction = null;
            Domains.Transaction banklastTransAction = null;
            Domains.Transaction customerAccount = null;

            var bankAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbBanks.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
            if (bankAccount == null)
            {
                createAccount((int)cmbBanks.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }
            banklastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)cmbBanks.SelectedValue, (int)cmbCurrencies.SelectedValue);

            var bankTransaction = new Domains.Transaction();

            bankTransaction.TransactionType = 3;
            bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;
            bankTransaction.Description = txtdesc.Text;
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


            customerAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
            if (customerAccount == null)
            {
                createAccount((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }
            customerlastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);

            var customerTransaction = new Domains.Transaction();
            customerTransaction.TransactionType = 3;
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
            customerTransaction.Description = txtdesc.Text;
            customerTransaction.DepositAmount = 0;
            customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);


            customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var cDate = txtDate.Text.Split('/');

            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = TransactionDateTime;
            customerTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(customerTransaction);

            unitOfWork.SaveChanges();
        }

        private void CreateDeposit()
        {
            Domains.Transaction customerlastTransAction = null;
            Domains.Transaction BanklastTransAction = null;
            Domains.Transaction customerAccount = null;

            var bankAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbBanks.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
            if (bankAccount == null)
            {
                createAccount((int)cmbBanks.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }
            BanklastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)cmbBanks.SelectedValue, (int)cmbCurrencies.SelectedValue);

            var bankTransaction = new Domains.Transaction();

            if ((int)cmbVarizType.SelectedValue == (int)DepostType.Unkown)
            {
                bankTransaction.TransactionType = 4;
                bankTransaction.UnkownAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            }
            else
            {
                bankTransaction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                bankTransaction.TransactionType = 3;
            }

            bankTransaction.SourceCustomerId = (int)cmbBanks.SelectedValue;

            bankTransaction.Description = txtdesc.Text;

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

            unitOfWork.TransactionServices.Insert(bankTransaction);


            //ثبت واریز برای مشتری
            if ((int)cmbVarizType.SelectedValue == (int)DepostType.known)
            {
                customerAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
                if (customerAccount == null)
                {
                    createAccount((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);
                }
                customerlastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);

                var customerTransaction = new Domains.Transaction();
                customerTransaction.TransactionType = 3;
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = (int)cmbBanks.SelectedValue;
                customerTransaction.Description = txtdesc.Text;
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                customerTransaction.WithdrawAmount = 0;

                customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
                customerTransaction.BranchCode = txtBranchCode.Text;

                customerTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                var cDate = txtDate.Text.Split('/');

                PersianCalendar pc = new PersianCalendar();
                TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;

                unitOfWork.TransactionServices.Insert(customerTransaction);

            }
            unitOfWork.SaveChanges();
        }

        private void createAccount(int SourceCustomerId, int CurrenyId)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = SourceCustomerId;
            newTransaction.TransactionType = 1;
            newTransaction.Description = "حساب جدید";
            newTransaction.WithdrawAmount = 0;
            newTransaction.DepositAmount = 0;

            newTransaction.CurrenyId = CurrenyId;
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = DateTime.Now;
            newTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(newTransaction);
            unitOfWork.SaveChanges();

        }
    }
}