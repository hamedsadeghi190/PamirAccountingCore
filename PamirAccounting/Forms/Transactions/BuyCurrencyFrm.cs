using JntNum2Text;
using PamirAccounting.Domains;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Transactions
{
    public partial class BuyCurrencyFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private long? _TransActionId;
        private List<CurrencyViewModel> _DestCurrencies = new List<CurrencyViewModel>();
        private List<CurrencyViewModel> _Currencies;
        private List<ComboBoxModel> _Customers, _DestCustomers;
        private Domains.Transaction talabkarTransaction, bedehkarTransAction;

        private int sellCurrencyId, buyerCurrencyId;
        private double sellerPrice, sellerRate;
        private Currency destiniationCurrency, sourceCurrency;
        long buyAmount;
        long sellerPrice1;
        public BuyCurrencyFrm(int Id, long? transActionId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _Id = Id;
            _TransActionId = transActionId;
        }


        public BuyCurrencyFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            buyAmount = Convert.ToInt64(txtBuyAmount.Text.Replace(",", ""));
            var rate = Convert.ToDouble(txtBuyRate.Text.Replace(",", ""));

            if (!(txtBuyAmount.Text.Length > 0 && double.Parse(txtBuyAmount.Text) > 0) && !(txtBuyRate.Text.Length > 0 && double.Parse(txtBuyRate.Text) > 0))
            {
                MessageBox.Show("مبالغ وارد شده صحیح نمی باشد", "خطای  اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                return;
            }

            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();

            var dDate = txtDate.Text.Split('/');
            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);

            //bedehkarTransAction //
            if (_TransActionId == null)
            {
                bedehkarTransAction = new Domains.Transaction();
            }

            bedehkarTransAction.DocumentId = documentId;
            bedehkarTransAction.DepositAmount = 0;
            bedehkarTransAction.Rate = (String.IsNullOrEmpty(txtBuyRate.Text.Trim())) ? 0 : rate;
            bedehkarTransAction.WithdrawAmount = (String.IsNullOrEmpty(txtBuyAmount.Text.Trim())) ? 0 : buyAmount;
            bedehkarTransAction.Description = txtDesc.Text;
            bedehkarTransAction.SourceCustomerId = (int)cmbSrcCustomers.SelectedValue;
            bedehkarTransAction.DestinitionCustomerId = (int)cmbTalabkarCustomers.SelectedValue;
            bedehkarTransAction.TransactionType = (int)TransaActionType.BuyCurrency;
            bedehkarTransAction.CurrenyId = (int)cmbCurrencySeller.SelectedValue;
            bedehkarTransAction.Date = DateTime.Now;
            bedehkarTransAction.TransactionDateTime = TransactionDateTime;
            bedehkarTransAction.UserId = CurrentUser.UserID;

            if (_TransActionId.HasValue)
            {
                unitOfWork.TransactionServices.Update(bedehkarTransAction);
            }
            else
            {
                unitOfWork.TransactionServices.Insert(bedehkarTransAction);
            }
            unitOfWork.SaveChanges();
            // end bedehkar///



            // talabkar Transaction//
            if (_TransActionId == null)
            {
                talabkarTransaction = new Domains.Transaction();
            }

            bedehkarTransAction.DoubleTransactionId = bedehkarTransAction.Id;
            bedehkarTransAction.OriginalTransactionId = bedehkarTransAction.Id;
            sellerPrice1 = Convert.ToInt64(txtTargetPrice.Text.Replace(",", ""));
            talabkarTransaction.SourceCustomerId = (int)cmbTalabkarCustomers.SelectedValue;
            talabkarTransaction.DestinitionCustomerId = (int)cmbSrcCustomers.SelectedValue;
            talabkarTransaction.TransactionType = (int)TransaActionType.BuyCurrency;
            talabkarTransaction.DocumentId = documentId;
            talabkarTransaction.DepositAmount = (String.IsNullOrEmpty(txtTargetPrice.Text.Trim())) ? 0 : sellerPrice1;
            talabkarTransaction.WithdrawAmount = 0;
            talabkarTransaction.Description = txtDesc.Text;
            talabkarTransaction.CurrenyId = (int)cmbBuyerCurrencies.SelectedValue;
            talabkarTransaction.Date = DateTime.Now;
            talabkarTransaction.TransactionDateTime = TransactionDateTime;
            talabkarTransaction.UserId = CurrentUser.UserID;

            if (_TransActionId.HasValue)
            {
                unitOfWork.TransactionServices.Update(talabkarTransaction);
            }
            else
            {
                unitOfWork.TransactionServices.Insert(talabkarTransaction);
            }

            unitOfWork.SaveChanges();
            //end talabkarTransaction ///

            bedehkarTransAction.DoubleTransactionId = talabkarTransaction.Id;
            bedehkarTransAction.OriginalTransactionId = bedehkarTransAction.Id;
            unitOfWork.TransactionServices.Update(bedehkarTransAction);
            unitOfWork.SaveChanges();

            if (_TransActionId.HasValue)
                this.Close();
            else
                CleanForm();

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
                txtBuyAmount.Focus();
            }

        }

        private void txtsellerprice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtBuyAmount.Text += "000";
            }

            ShowChars();
            if (e.KeyCode == Keys.Enter)
            {
                cmbBuyerCurrencies.Focus();
            }

        }
        private void ShowChars()
        {
            if (txtBuyAmount.Text.Length > 0)
            {
                var currencyName = cmbBuyerCurrencies.Text;
                lblSrcAmountText.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtBuyAmount.Text.Replace(",", ""))) } {currencyName}";
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
                cmbCurrencySeller.Focus();
            }

        }

        private void txtcurrencybuyer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBuyRate.Focus();
            }

        }

        private void BuyAndSellCurrencyFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
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
            if (_TransActionId.HasValue)
            {
                loadTransactionInfo();
            }
            else
            {
                lbl_Document_Id_value.Text = unitOfWork.TransactionServices.GetNewDocumentId().ToString();
            }
            handleEvents(true);
        }

        private void loadTransactionInfo()
        {
            var OriginalTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == _TransActionId.Value);

            bedehkarTransAction = unitOfWork.TransactionServices.FindFirst(x => x.Id == OriginalTransaction.OriginalTransactionId);
            talabkarTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == bedehkarTransAction.DoubleTransactionId);

            lbl_Document_Id_value.Text = bedehkarTransAction.DocumentId.ToString();
            txtDate.Text = bedehkarTransAction.TransactionDateTime.ToFarsiFormat();
            cmbSrcCustomers.SelectedValue = bedehkarTransAction.SourceCustomerId;
            cmbCurrencySeller.SelectedValue = bedehkarTransAction.CurrenyId;
            txtBuyAmount.Text = bedehkarTransAction.WithdrawAmount.ToString();
            txtBuyRate.Text = bedehkarTransAction.Rate?.ToString();

            txtTargetPrice.Text = talabkarTransaction.DepositAmount.ToString();
            txtDesc.Text = talabkarTransaction.Description;
            cmbTalabkarCustomers.SelectedValue = talabkarTransaction.SourceCustomerId;
            cmbBuyerCurrencies.SelectedValue = talabkarTransaction.CurrenyId;
        }

        private void LoadData()
        {
            SetComboBoxHeight(cmbCurrencySeller.Handle, 25);
            cmbCurrencySeller.Refresh();
            SetComboBoxHeight(cmbSrcCustomers.Handle, 25);
            cmbSrcCustomers.Refresh();
            SetComboBoxHeight(cmbTalabkarCustomers.Handle, 25);
            cmbTalabkarCustomers.Refresh();
            SetComboBoxHeight(cmbBuyerCurrencies.Handle, 25);
            cmbBuyerCurrencies.Refresh();

            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new CurrencyViewModel() { Id = x.Id, Title = x.Name, Action = x.Action, BaseRate = x.BaseRate }).ToList();

            cmbBuyerCurrencies.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbBuyerCurrencies.AutoCompleteCustomSource = autoCurrencies;
            cmbBuyerCurrencies.ValueMember = "Id";
            cmbBuyerCurrencies.DisplayMember = "Title";


            _DestCurrencies.AddRange(_Currencies);
            cmbCurrencySeller.DataSource = _DestCurrencies;
            AutoCompleteStringCollection autoDestCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _DestCurrencies)
            {
                autoDestCurrencies.Add(item.Title);
            }
            cmbCurrencySeller.AutoCompleteCustomSource = autoDestCurrencies;
            cmbCurrencySeller.ValueMember = "Id";
            cmbCurrencySeller.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();

            _DestCustomers = new List<ComboBoxModel>();
            _DestCustomers.AddRange(_Customers);

            cmbTalabkarCustomers.DataSource = _Customers;
            AutoCompleteStringCollection autoCustomers = new AutoCompleteStringCollection();
            foreach (var item in _Customers)
            {
                autoCustomers.Add(item.Title);
            }
            cmbTalabkarCustomers.AutoCompleteCustomSource = autoCustomers;
            cmbTalabkarCustomers.ValueMember = "Id";
            cmbTalabkarCustomers.DisplayMember = "Title";

            cmbSrcCustomers.DataSource = _DestCustomers;
            AutoCompleteStringCollection autoDestCustomers = new AutoCompleteStringCollection();
            foreach (var item in _DestCustomers)
            {
                autoDestCustomers.Add(item.Title);
            }
            cmbSrcCustomers.AutoCompleteCustomSource = autoDestCustomers;
            cmbSrcCustomers.ValueMember = "Id";
            cmbSrcCustomers.DisplayMember = "Title";

            txtDate.Text = DateTime.Now.ToFarsiFormat();
        }

        private void cmbCustomers_SelectedValueChanged(object sender, EventArgs e)
        {
            createDesc();
        }

        private void txtsellerprice_TextChanged(object sender, EventArgs e)
        {
            ShowSellerChars();
            calculateAmount();
            createDesc();

        }
        private void ShowSellerChars()
        {
            try
            {
                if (txtBuyAmount.Text.Length > 0)
                {
                    var currencyName = cmbCurrencySeller.Text;
                    lblSrcAmountText.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtBuyAmount.Text.Replace(",", ""))) } {currencyName}";
                }
            }
            catch (Exception)
            {

            }

        }

        private void ShowbuyerChars()
        {
            try
            {
                if (txtTargetPrice.Text.Length > 0)
                {
                    var currencyName = cmbBuyerCurrencies.Text;
                    lbl_target_mablagh.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtTargetPrice.Text.Replace(",", ""))) } {currencyName}";
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void cmbSellCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSellerChars();
            createDesc();
            calculateAmount();
        }



        private void cmbDestCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            createDesc();
        }

        private void cmbCurrencybuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowbuyerChars();
            calculateAmount();
            createDesc();
        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {

            if (txtBuyRate.Text.Length > 0)
            {
                calculateBuyRate(double.Parse(txtBuyRate.Text.ToString()));
            }
            createDesc();
        }

        private void calculateBuyRate(double rate)
        {
            txtTargetPrice.Text = (double.Parse(txtBuyAmount.Text) * rate).ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void calculateAmount()
        {
            sellCurrencyId = (int)cmbBuyerCurrencies.SelectedValue;
            buyerCurrencyId = (int)cmbCurrencySeller.SelectedValue;

            if (sellCurrencyId == buyerCurrencyId)
            {
                txtBuyRate.Text = "1";
                txtTargetPrice.Text = txtBuyAmount.Text;
                return;
            }
            if (txtBuyAmount.Text.Length > 1)
            {
                return;
            }

            sellerPrice = double.Parse(txtBuyAmount.Text);
            sellerRate = double.Parse(txtBuyRate.Text);

            var currenyMapping = unitOfWork.CurrenciesMappings.FindAll(x => x.SourceCurrenyId == sellCurrencyId
                                                                         && x.DestiniationCurrenyId == buyerCurrencyId)
                                                                         .FirstOrDefault();

            sourceCurrency = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == sellCurrencyId);
            destiniationCurrency = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == buyerCurrencyId);

            if (sourceCurrency.Id == 1)
            {
                switch (destiniationCurrency.Action)
                {
                    case 1:
                        txtBuyRate.Text = destiniationCurrency.BaseRate.ToString();
                        txtTargetPrice.Text = (double.Parse(txtBuyAmount.Text) * destiniationCurrency.BaseRate.Value).ToString();
                        break;

                    case 2:
                        txtBuyRate.Text = destiniationCurrency.BaseRate.ToString();
                        txtTargetPrice.Text = (double.Parse(txtBuyAmount.Text) / destiniationCurrency.BaseRate.Value).ToString();
                        break;

                    default:
                        break;

                }
            }
        }
        private void txtbuyerprice_TextChanged(object sender, EventArgs e)
        {
            ShowbuyerChars();
            //calculateAmount();
            createDesc();
        }

        public void createDesc()
        {
            try
            {
                txtDesc.Text = $"خرید {txtBuyAmount.Text} {cmbCurrencySeller.Text} از {cmbSrcCustomers.Text} به نرخ {txtBuyRate.Text} معادل {txtTargetPrice.Text} {cmbBuyerCurrencies.Text}";
            }
            catch (Exception ex)
            {

            }
        }

        private void handleEvents(bool status)
        {
            if (status)
            {
                this.cmbSrcCustomers.SelectedIndexChanged += new System.EventHandler(this.cmbDestCustomers_SelectedIndexChanged);
                this.txtTargetPrice.TextChanged += new System.EventHandler(this.txtbuyerprice_TextChanged);
                this.txtBuyRate.TextChanged += new System.EventHandler(this.txtrate_TextChanged);
                this.cmbCurrencySeller.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencybuyer_SelectedIndexChanged);
                this.cmbTalabkarCustomers.SelectedValueChanged += new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
                this.cmbBuyerCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbSellCurrencies_SelectedIndexChanged);
                this.txtBuyAmount.TextChanged += new System.EventHandler(this.txtsellerprice_TextChanged);

            }
            else

            {
                this.cmbSrcCustomers.SelectedIndexChanged -= new System.EventHandler(this.cmbDestCustomers_SelectedIndexChanged);
                this.txtTargetPrice.TextChanged -= new System.EventHandler(this.txtbuyerprice_TextChanged);
                this.txtBuyRate.TextChanged -= new System.EventHandler(this.txtrate_TextChanged);
                this.cmbTalabkarCustomers.SelectedValueChanged -= new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
                this.cmbBuyerCurrencies.SelectedIndexChanged -= new System.EventHandler(this.cmbSellCurrencies_SelectedIndexChanged);
                this.cmbCurrencySeller.SelectedIndexChanged -= new System.EventHandler(this.cmbCurrencybuyer_SelectedIndexChanged);
                this.txtBuyAmount.TextChanged -= new System.EventHandler(this.txtsellerprice_TextChanged);
            }
        }

        private void CleanForm()
        {
            txtDesc.Text = "";
            txtBuyAmount.Text = "0";
            txtTargetPrice.Text = "0";
            txtBuyRate.Text = "";
            txtDate.Select();
            txtDate.Focus();

        }
    }
}