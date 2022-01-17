using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Transaction
{
    public partial class TransferAccountFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<ComboBoxModel> _Currencies, _SourceCustomers, _destCustomers;


        public TransferAccountFrm(int Id)
        {
            _Id = Id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        public TransferAccountFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }
        private void TransferAccountFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {


            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _SourceCustomers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();

            CmbSource.DataSource = _SourceCustomers;
            CmbSource.ValueMember = "Id";
            CmbSource.DisplayMember = "Title";

            _destCustomers = new List<ComboBoxModel>();
            _destCustomers.AddRange(_SourceCustomers);
            cmbDestiniation.DataSource = _destCustomers;
            cmbDestiniation.ValueMember = "Id";
            cmbDestiniation.DisplayMember = "Title";

            if (_Id != null)
            {
                CmbSource.SelectedValue = _Id;
            }
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            CreateTransfer();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateTransfer()
        {
            Domains.Transaction customerlastTransAction = null;
            Domains.Transaction banklastTransAction = null;
            Domains.Transaction customerAccount = null;

            var bankAccount = unitOfWork.TransactionServices.FindLastTransaction((int)CmbSource.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
            if (bankAccount == null)
            {
                createAccount((int)CmbSource.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }
            banklastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)CmbSource.SelectedValue, (int)cmbCurrencies.SelectedValue);

            var bankTransaction = new Domains.Transaction();

            bankTransaction.TransactionType = 5;
            bankTransaction.DestinitionCustomerId = (int)cmbDestiniation.SelectedValue;
            bankTransaction.SourceCustomerId = (int)CmbSource.SelectedValue;
            bankTransaction.Description = txtDesc.Text;
            bankTransaction.DepositAmount = 0;
            bankTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);


            bankTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(bankTransaction);


            customerAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbDestiniation.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
            if (customerAccount == null)
            {
                createAccount((int)cmbDestiniation.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }
            customerlastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)cmbDestiniation.SelectedValue, (int)cmbCurrencies.SelectedValue);

            var customerTransaction = new Domains.Transaction();
            customerTransaction.TransactionType = 3;
            customerTransaction.SourceCustomerId = (int)cmbDestiniation.SelectedValue;
            customerTransaction.DestinitionCustomerId = (int)CmbSource.SelectedValue;
            customerTransaction.Description = txtDesc.Text;
            customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            customerTransaction.WithdrawAmount = 0;


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