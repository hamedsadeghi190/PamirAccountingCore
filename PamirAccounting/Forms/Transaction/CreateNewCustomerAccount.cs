using DevExpress.XtraEditors;
using DNTPersianUtils.Core;
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

namespace PamirAccounting.Forms.Transaction
{
    public partial class CreateNewCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int _Id;
        private List<ComboBoxModel> _Currencies;

        public CreateNewCustomerAccount(int Id)
        {
            InitializeComponent();
            _Id = Id;
            unitOfWork = new UnitOfWork();
        }

        private void CreateNewCustomerAccount_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = _Id;
            newTransaction.TransactionType = 1;
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
            unitOfWork.SaveChanges();
            Close();
        }
    }
}