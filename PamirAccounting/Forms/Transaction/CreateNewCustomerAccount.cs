﻿using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Transaction
{
    public partial class CreateNewCustomerAccount : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private Domains.Transaction transaction;
        private int _Id;
        private long? _TransActionId;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _RemainType;

        public CreateNewCustomerAccount(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _Id = Id;
            _TransActionId = transActionId;
        }

        public CreateNewCustomerAccount()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void CreateNewCustomerAccount_Load(object sender, EventArgs e)
        {
            LoadData();

            if (_TransActionId.HasValue)
            {
                transaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == _TransActionId.Value);

                if (transaction.WithdrawAmount.Value != 0)
                {
                    txtAmount.Text = transaction.WithdrawAmount.Value.ToString();
                    cmbRemainType.SelectedValue = 1;
                }
                else
                {
                    txtAmount.Text = transaction.DepositAmount.Value.ToString();
                    cmbRemainType.SelectedValue = 2;
                }

                txtdesc.Text = transaction.Description;
                cmbCurrencies.SelectedValue = transaction.CurrenyId;
                cmbCurrencies.Enabled = false;

                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(transaction.TransactionDateTime).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDate.Text = PDate;
            }
            else
            {
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDate.Text = PDate;
            }
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

            if (transaction != null)
            {
                transaction.Description = txtdesc.Text;

                if ((int)cmbRemainType.SelectedValue == 1)
                {
                    transaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                    transaction.DepositAmount = 0;
                }
                else
                {
                    transaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
                    transaction.WithdrawAmount = 0;
                }

                transaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
                var dDate = txtDate.Text.Split('/');

                PersianCalendar p = new PersianCalendar();
                var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                transaction.Date = DateTime.Now;
                transaction.TransactionDateTime = TransactionDateTime;
                transaction.UserId = CurrentUser.UserID;

                unitOfWork.TransactionServices.Update(transaction);
                unitOfWork.SaveChanges();
            }
            else
            {
                var account = unitOfWork.Transactions.FindFirstOrDefault(x => x.SourceCustomerId == _Id && x.TransactionType == 1 && x.CurrenyId == (int)cmbCurrencies.SelectedValue);

                if (account != null)
                {
                    MessageBox.Show("برای این ارز قبلا حساب ایجاد شده است");
                    return;
                }

                var newTransaction = new Domains.Transaction();
                newTransaction.SourceCustomerId = _Id;
                newTransaction.TransactionType = (int)TransaActionType.NewAccount;
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

                unitOfWork.TransactionServices.Insert(newTransaction);
                unitOfWork.SaveChanges();
            }


            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtAmount.Text.Length > 0)
            {
                var currencyName = cmbCurrencies.Text;
                lblNumberString.Text = $"{ NumberUtility.GetString(txtAmount.Text.Replace(",", "")) } {currencyName}";
            }
        }
    }
}