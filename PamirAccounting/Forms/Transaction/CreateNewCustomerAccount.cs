using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Transaction
{
    public partial class CreateNewCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int _Id;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _RemainType;

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

            _RemainType = new List<ComboBoxModel>();
            _RemainType.Add(new ComboBoxModel() { Id = 1, Title = "بدهکار (رفت )" });
            _RemainType.Add(new ComboBoxModel() { Id = 2, Title = "طلبکار(آمد)" });

            cmbRemainType.DataSource = _RemainType;
            cmbRemainType.ValueMember = "Id";
            cmbRemainType.DisplayMember = "Title";
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            var account = unitOfWork.Transactions.FindFirstOrDefault(x => x.SourceCustomerId == _Id && x.TransactionType == 1 && x.CurrenyId == (int)cmbCurrencies.SelectedValue);

            if (account != null)
            {
                MessageBox.Show("برای این ارز قبلا حساب ایجاد شده است");
                return;
            }

            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = _Id;
            newTransaction.TransactionType = 1;
            newTransaction.Description = txtdesc.Text;

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
            newTransaction.RemainigAmount = (newTransaction.DepositAmount.Value != 0) ? newTransaction.DepositAmount.Value : newTransaction.WithdrawAmount.Value * -1;
            unitOfWork.TransactionServices.Insert(newTransaction);
            unitOfWork.SaveChanges();
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}