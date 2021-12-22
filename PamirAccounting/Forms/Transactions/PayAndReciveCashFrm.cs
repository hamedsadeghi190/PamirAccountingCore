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

namespace PamirAccounting.Forms.Transactions
{
    public partial class PayAndReciveCashFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private int _Id;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _Customers;

        public PayAndReciveCashFrm(int Id)
        {
            InitializeComponent();
            _Id = Id;
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
        }


        private void PayAndReciveCashFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {

            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            newTransaction.DestinitionCustomerId = 4;
            newTransaction.TransactionType = 2;
            newTransaction.Description = txtdesc.Text;
            newTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtwithdraw.Text.Trim())) ? 0 : long.Parse(txtwithdraw.Text);
            newTransaction.DepositAmount = (String.IsNullOrEmpty(txtdeposit.Text.Trim())) ? 0 : long.Parse(txtdeposit.Text);
            newTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = TransactionDateTime;
            newTransaction.UserId = CurrentUser.UserID;
            newTransaction.RemainigAmount = (newTransaction.DepositAmount.Value != 0) ? newTransaction.DepositAmount.Value : newTransaction.WithdrawAmount.Value * -1;
            unitOfWork.TransactionServices.Insert(newTransaction);


            var newTransaction2 = new Domains.Transaction();
            newTransaction2.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            newTransaction2.SourceCustomerId = 4;
            newTransaction2.TransactionType = 2;
            newTransaction2.Description = txtdesc.Text;
            newTransaction2.WithdrawAmount = (String.IsNullOrEmpty(txtdeposit.Text.Trim())) ? 0 : long.Parse(txtdeposit.Text);
            newTransaction2.DepositAmount = (String.IsNullOrEmpty(txtwithdraw.Text.Trim())) ? 0 : long.Parse(txtwithdraw.Text);
            newTransaction2.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate2 = txtDate.Text.Split('/');

            PersianCalendar p2 = new PersianCalendar();
            var TransactionDateTime2 = p2.ToDateTime(int.Parse(dDate2[0]), int.Parse(dDate2[1]), int.Parse(dDate2[2]), 0, 0, 0, 0);
            newTransaction2.Date = DateTime.Now;
            newTransaction2.TransactionDateTime = TransactionDateTime;
            newTransaction2.UserId = CurrentUser.UserID;
            newTransaction2.RemainigAmount = (newTransaction2.DepositAmount.Value != 0) ? newTransaction2.DepositAmount.Value : newTransaction2.WithdrawAmount.Value * -1;
            unitOfWork.TransactionServices.Insert(newTransaction2);
            unitOfWork.SaveChanges();
            Close();
        }
    }
}