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
        private int? _Id;
        private List<ComboBoxModel> _Currencies, _RemainType, _Customers;

        public PayAndReciveCashFrm(int Id)
        {
            InitializeComponent();
            _Id = Id;
            unitOfWork = new UnitOfWork();
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
            if (_Id != null)
            {
                cmbCustomers.SelectedValue = _Id;
            }
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {

            var desctAccount = unitOfWork.TransactionServices.FindLastTransaction(4, 1, (int)cmbCurrencies.SelectedValue);
            var sAccount = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, 1, (int)cmbCurrencies.SelectedValue);
            Domains.Transaction SourcelastTransAction = null;
            Domains.Transaction DestlastTransAction = null;

            if (desctAccount == null)
            {
                createAccount(4, (int)cmbCurrencies.SelectedValue);
            }

            if (sAccount == null)
            {
                createAccount((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);
            }


            DestlastTransAction = unitOfWork.TransactionServices.FindLastTransaction(4, (int)cmbCurrencies.SelectedValue);
            SourcelastTransAction = unitOfWork.TransactionServices.FindLastTransaction((int)cmbCustomers.SelectedValue, (int)cmbCurrencies.SelectedValue);

            var sTransaction = new Domains.Transaction();
            sTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            sTransaction.DestinitionCustomerId = 4;
            sTransaction.TransactionType = 2;
            sTransaction.Description = txtdesc.Text;


            if ((int)cmbRemainType.SelectedValue == 1)
            {
                sTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                sTransaction.DepositAmount = 0;
            }
            else
            {
                sTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                sTransaction.WithdrawAmount = 0;
            }

            sTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            sTransaction.Date = DateTime.Now;
            sTransaction.TransactionDateTime = TransactionDateTime;
            sTransaction.UserId = CurrentUser.UserID;
            var RemainigAmount = (sTransaction.DepositAmount.Value != 0) ? sTransaction.DepositAmount.Value : sTransaction.WithdrawAmount.Value * -1;
            sTransaction.RemainigAmount = SourcelastTransAction.RemainigAmount + RemainigAmount;
            unitOfWork.TransactionServices.Insert(sTransaction);

            var dTransaction2 = new Domains.Transaction();
            if ((int)cmbRemainType.SelectedValue == 1)
            {


                dTransaction2.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                dTransaction2.WithdrawAmount = 0;
            }
            else
            {
                dTransaction2.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                dTransaction2.DepositAmount = 0;
            }


            dTransaction2.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            dTransaction2.SourceCustomerId = 4;
            dTransaction2.TransactionType = 2;
            dTransaction2.Description = txtdesc.Text;

            dTransaction2.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate2 = txtDate.Text.Split('/');

            PersianCalendar p2 = new PersianCalendar();
            var TransactionDateTime2 = p2.ToDateTime(int.Parse(dDate2[0]), int.Parse(dDate2[1]), int.Parse(dDate2[2]), 0, 0, 0, 0);
            dTransaction2.Date = DateTime.Now;
            dTransaction2.TransactionDateTime = TransactionDateTime;
            dTransaction2.UserId = CurrentUser.UserID;

            var RemainigAmount2 = (dTransaction2.DepositAmount.Value != 0) ? dTransaction2.DepositAmount.Value : dTransaction2.WithdrawAmount.Value * -1;
            dTransaction2.RemainigAmount = DestlastTransAction.RemainigAmount + RemainigAmount2;

            unitOfWork.TransactionServices.Insert(dTransaction2);
            unitOfWork.SaveChanges();
            Close();
        }

        private void createAccount(int SourceCustomerId, int CurrenyId)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = SourceCustomerId;
            newTransaction.TransactionType = 1;
            newTransaction.Description = "حساب جدید";
            newTransaction.WithdrawAmount = 0;
            newTransaction.DepositAmount = 0;
            newTransaction.RemainigAmount = 0;
            newTransaction.CurrenyId = CurrenyId;
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = DateTime.Now;
            newTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(newTransaction);
            unitOfWork.SaveChanges();

        }
    }
}