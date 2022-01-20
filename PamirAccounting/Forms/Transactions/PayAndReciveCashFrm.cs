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
    public partial class PayAndReciveCashFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private List<ComboBoxModel> _Currencies, _RemainType, _Customers;
        private int? _Id;
        private long? _TransActionId;
        public Domains.Transaction sandoghTransAction;
        public Domains.Transaction customerTransaction;

        public PayAndReciveCashFrm(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _Id = Id;
            _TransActionId = transActionId;
        }

        public PayAndReciveCashFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void LoadData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();

            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";


            _RemainType = new List<ComboBoxModel>();
            _RemainType.Add(new ComboBoxModel() { Id = 1, Title = "بدهکار (رفت )" });
            _RemainType.Add(new ComboBoxModel() { Id = 2, Title = "طلبکار(آمد)" });

            cmbRemainType.DataSource = _RemainType;
            cmbRemainType.ValueMember = "Id";
            cmbRemainType.DisplayMember = "Title";
        }


        private void PayAndReciveCashFrm_Load(object sender, EventArgs e)
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
                cmbCustomers.SelectedValue = _Id;
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
          
            var sandoghAccount = unitOfWork.TransactionServices.FindLastTransaction(AppSetting.SandoghCustomerId, (int)TransaActionType.NewAccount, (int)cmbCurrencies.SelectedValue);
            var customerAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, (int)TransaActionType.NewAccount, (int)cmbCurrencies.SelectedValue);

            if (sandoghAccount == null)
            {
                createAccount(AppSetting.SandoghCustomerId, (int)cmbCurrencies.SelectedValue);
            }

            if (customerAccount == null)
            {
                createAccount((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }
            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            // trakonesh moshtari //
            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.SandoghCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.PayAndReciveCash;
           
            customerTransaction.DocumentId = documentId;

            if ((int)cmbRemainType.SelectedValue == 1)
            {
                customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                customerTransaction.DepositAmount = 0;
                customerTransaction.Description = (txtdesc.Text.Length > 0) ? txtdesc.Text : Messages.WithdrawCash + " به شماره سند -" + documentId ; 
            }
            else
            {
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.Description = (txtdesc.Text.Length > 0) ? txtdesc.Text : Messages.DepostitCash + " به شماره سند " + documentId;
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


                sandoghTransAction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                sandoghTransAction.WithdrawAmount = 0;
                sandoghTransAction.Description = (txtdesc.Text.Length > 0) ? txtdesc.Text : Messages.DepostitCash + " به شماره سند -" + documentId;
            }
            else
            {
                sandoghTransAction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                sandoghTransAction.DepositAmount = 0;
                sandoghTransAction.Description = (txtdesc.Text.Length > 0) ? txtdesc.Text : Messages.WithdrawCash + " به شماره سند -" + documentId;
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
            // trakonesh moshtari //
            customerTransaction.Description = txtdesc.Text;

            if ((int)cmbRemainType.SelectedValue == 1)
            {
                customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                customerTransaction.DepositAmount = 0;

            }
            else
            {
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
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
                sandoghTransAction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                sandoghTransAction.WithdrawAmount = 0;
            }
            else
            {
                sandoghTransAction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
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

        private void createAccount(int SourceCustomerId, int CurrenyId)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = SourceCustomerId;
            newTransaction.TransactionType = 1;
            newTransaction.Description = Messages.CreateNewAcount;
            newTransaction.WithdrawAmount = 0;
            newTransaction.DepositAmount = 0;
            newTransaction.CurrenyId = CurrenyId;
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = DateTime.Now;
            newTransaction.UserId = CurrentUser.UserID;
            newTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
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