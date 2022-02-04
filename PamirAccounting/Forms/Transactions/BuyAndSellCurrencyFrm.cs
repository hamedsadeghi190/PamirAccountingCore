﻿using DevExpress.XtraEditors;
using JntNum2Text;
using PamirAccounting.Forms.Customers;
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
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Transactions
{
    public partial class BuyAndSellCurrencyFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private long? _TransActionId;
        private List<CurrencyViewModel> _DestCurrencies = new List<CurrencyViewModel>();
        private List<CurrencyViewModel> _Currencies;
        private List<ComboBoxModel> _Customers, _DestCustomers;

        public BuyAndSellCurrencyFrm(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _Id = Id;
            _TransActionId = transActionId;
        }


        public BuyAndSellCurrencyFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!(txtbuyerprice.Text.Length>0 && double.Parse(txtbuyerprice.Text)>0 && txtsellerprice.Text.Length > 0 && double.Parse(txtsellerprice.Text) > 0))
            {
                MessageBox.Show("مبالغ وارد شده صحیح نمی باشد", "خطای  اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error,
MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();

            // talabkar Transaction//
            var talabkarTransaction = new Domains.Transaction();

            talabkarTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            talabkarTransaction.DestinitionCustomerId = (int)cmbDestCustomers.SelectedValue;
            talabkarTransaction.TransactionType = (int)TransaActionType.SellAndBuy;
            talabkarTransaction.DocumentId = documentId;
            talabkarTransaction.WithdrawAmount = 0;
            talabkarTransaction.DepositAmount = (String.IsNullOrEmpty(txtsellerprice.Text.Trim())) ? 0 : long.Parse(txtsellerprice.Text);
            talabkarTransaction.Description = txtDesc.Text;
            talabkarTransaction.CurrenyId = (int)cmbSellCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');
            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            talabkarTransaction.Date = DateTime.Now;
            talabkarTransaction.TransactionDateTime = TransactionDateTime;
            talabkarTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(talabkarTransaction);
            unitOfWork.SaveChanges();
            //end talabkarTransaction ///

            //tarakonesh sandogh//
            var bedehkarTransAction = new Domains.Transaction();
            bedehkarTransAction.DoubleTransactionId = talabkarTransaction.Id;
            bedehkarTransAction.DocumentId = documentId;

            bedehkarTransAction.WithdrawAmount = (String.IsNullOrEmpty(txtbuyerprice.Text.Trim())) ? 0 : long.Parse(txtbuyerprice.Text);
            bedehkarTransAction.DepositAmount = 0;
            bedehkarTransAction.Description = txtDesc.Text;


            bedehkarTransAction.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            bedehkarTransAction.SourceCustomerId = AppSetting.SandoghCustomerId;
            bedehkarTransAction.TransactionType = (int)TransaActionType.SellAndBuy;

            bedehkarTransAction.CurrenyId = (int)cmbCurrencybuyer.SelectedValue;
            bedehkarTransAction.Date = DateTime.Now;
            bedehkarTransAction.TransactionDateTime = TransactionDateTime;
            bedehkarTransAction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(bedehkarTransAction);
            unitOfWork.SaveChanges();
            // end trakonesh sandogh///

            talabkarTransaction.DoubleTransactionId = bedehkarTransAction.Id;
            unitOfWork.TransactionServices.Update(talabkarTransaction);
            unitOfWork.SaveChanges();

            Close();

        }

        private void btnshowcustomer1_Click(object sender, EventArgs e)
        {
            var AllCustomersFrm = new SearchAllCustomersFrm();
            AllCustomersFrm.ShowDialog();
        }

        private void btnshowcustomer_Click(object sender, EventArgs e)
        {
            var AllCustomersFrm = new SearchAllCustomersFrm();
            AllCustomersFrm.ShowDialog();
        }
        #region keys
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void txtsellername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }

        }
        private void btnshowcustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsellerprice.Focus();
            }

        }

        private void txtsellerprice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSellCurrencies.Focus();
            }

        }

        private void txtsellercurrency_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }


        }

        private void txtbuyername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }

        }

        private void btnshowcustomer1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCurrencybuyer.Focus();
            }

        }

        private void txtcurrencybuyer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtrate.Focus();
            }

        }

        private void BuyAndSellCurrencyFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtbuyerprice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDesc.Focus();
            }
        }

        private void BtnSave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnClose.Focus();
            }

        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSave.Focus();
            }
        }

        #endregion

        private void BuyAndSellCurrencyFrm_Load(object sender, EventArgs e)
        {
            handleEvents(false);
            LoadData();
            handleEvents(true);
        }

        private void LoadData()
        {

            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new CurrencyViewModel() { Id = x.Id, Title = x.Name, Action = x.Action, BaseRate = x.BaseRate }).ToList();

            cmbSellCurrencies.DataSource = _Currencies;
            cmbSellCurrencies.ValueMember = "Id";
            cmbSellCurrencies.DisplayMember = "Title";


            _DestCurrencies.AddRange(_Currencies);
            cmbCurrencybuyer.DataSource = _DestCurrencies;
            cmbCurrencybuyer.ValueMember = "Id";
            cmbCurrencybuyer.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();

            _DestCustomers = new List<ComboBoxModel>();
            _DestCustomers.AddRange(_Customers);

            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";

            cmbDestCustomers.DataSource = _DestCustomers;
            cmbDestCustomers.ValueMember = "Id";
            cmbDestCustomers.DisplayMember = "Title";

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDate.Text = PDate;
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            createDesc();
        }

        private void txtsellerprice_TextChanged(object sender, EventArgs e)
        {
            ShowSellerChars();
            createDesc();
        }
        private void ShowSellerChars()
        {
            if (txtsellerprice.Text.Length > 0)
            {
                var currencyName = cmbSellCurrencies.Text;
                label1.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtsellerprice.Text.Replace(",", ""))) } {currencyName}";
            }
        }

        private void ShowbuyerChars()
        {
            if (txtbuyerprice.Text.Length > 0)
            {
                var currencyName = cmbCurrencybuyer.Text;
                lbl_target_mablagh.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtbuyerprice.Text.Replace(",", ""))) } {currencyName}";
            }
        }
        private void cmbSellCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSellerChars();
            createDesc();
        }

        private void cmbDestCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            createDesc();
        }

        private void cmbCurrencybuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowbuyerChars();
            createDesc();
        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            createDesc();
        }

        private void txtbuyerprice_TextChanged(object sender, EventArgs e)
        {
            ShowbuyerChars();
            createDesc();
        }

        public void createDesc()
        {
            try
            {
                txtDesc.Text = $"فروش {txtsellerprice.Text} {cmbSellCurrencies.Text} به {cmbCustomers.Text} به نرخ {txtrate.Text} معادل {txtbuyerprice.Text} {cmbCurrencybuyer.Text} ";
            }
            catch (Exception ex)
            {

                
            }
        }

        private void handleEvents(bool status)
        {
            if (status)
            {
                this.cmbDestCustomers.SelectedIndexChanged += new System.EventHandler(this.cmbDestCustomers_SelectedIndexChanged);
                this.txtbuyerprice.TextChanged += new System.EventHandler(this.txtbuyerprice_TextChanged);
                this.txtrate.TextChanged += new System.EventHandler(this.txtrate_TextChanged);
                this.cmbCurrencybuyer.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencybuyer_SelectedIndexChanged);
                this.cmbCustomers.SelectedValueChanged += new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
                this.cmbSellCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbSellCurrencies_SelectedIndexChanged);
                this.txtsellerprice.TextChanged += new System.EventHandler(this.txtsellerprice_TextChanged);

            }
            else

            {
                this.cmbDestCustomers.SelectedIndexChanged -= new System.EventHandler(this.cmbDestCustomers_SelectedIndexChanged);
                this.txtbuyerprice.TextChanged -= new System.EventHandler(this.txtbuyerprice_TextChanged);
                this.txtrate.TextChanged -= new System.EventHandler(this.txtrate_TextChanged);
                this.cmbCustomers.SelectedValueChanged -= new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
                this.cmbSellCurrencies.SelectedIndexChanged -= new System.EventHandler(this.cmbSellCurrencies_SelectedIndexChanged);
                this.cmbCurrencybuyer.SelectedIndexChanged -= new System.EventHandler(this.cmbCurrencybuyer_SelectedIndexChanged);
                this.txtsellerprice.TextChanged -= new System.EventHandler(this.txtsellerprice_TextChanged);
            }
        }
    }
}