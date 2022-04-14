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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Drafts
{
    public partial class shippingOrderFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<ComboBoxBoolModel> _status = new List<ComboBoxBoolModel>();
        private List<ComboBoxModel> _Customers;
        private List<ComboBoxModel> _agencies;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _DestCurrencies = new List<ComboBoxModel>();
        private UnitOfWork unitOfWork;



        public shippingOrderFrm()
        {
            InitializeComponent();
        }

        private void shippingOrderFrm_Load(object sender, EventArgs e)
        {
            unitOfWork = new UnitOfWork();
            initData();
            txtDate.Text = DateTime.Now.ToFarsiFormat();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

        private void initData()
        {
            SetComboBoxHeight(cmbAgency.Handle, 25);
            cmbAgency.Refresh();
            SetComboBoxHeight(cmbCustomer.Handle, 25);
            cmbCustomer.Refresh();
            SetComboBoxHeight(cmbDepositCurreny.Handle, 25);
            cmbDepositCurreny.Refresh();
            SetComboBoxHeight(cmbDraftCurrency.Handle, 25);
            cmbDraftCurrency.Refresh();
            SetComboBoxHeight(cmbStatus.Handle, 25);
            cmbStatus.Refresh();


            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            this.cmbAgency.SelectedIndexChanged -= new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.DataSource = _agencies;
            AutoCompleteStringCollection autoagencies = new AutoCompleteStringCollection();
            foreach (var item in _agencies)
            {
                autoagencies.Add(item.Title);
            }
            cmbAgency.AutoCompleteCustomSource = autoagencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";
            this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.SelectedIndex = 0;
            /////////////////////////////
            _Customers = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            cmbCustomer.DataSource = _Customers;
            AutoCompleteStringCollection autoCustomers = new AutoCompleteStringCollection();
            foreach (var item in _Customers)
            {
                autoCustomers.Add(item.Title);
            }
            cmbCustomer.AutoCompleteCustomSource = autoCustomers;
            cmbCustomer.ValueMember = "Id";
            cmbCustomer.DisplayMember = "Title";
            ////////////////////////////////////
            cmbDraftCurrency.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbDraftCurrency.AutoCompleteCustomSource = autoCurrencies;
            cmbDraftCurrency.ValueMember = "Id";
            cmbDraftCurrency.DisplayMember = "Title";
            ///////////////////////////////////////
            _DestCurrencies.AddRange(_Currencies);
            cmbDepositCurreny.DataSource = _DestCurrencies;
            AutoCompleteStringCollection autoDestCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _DestCurrencies)
            {
                autoDestCurrencies.Add(item.Title);
            }
            cmbDepositCurreny.AutoCompleteCustomSource = autoDestCurrencies;
            cmbDepositCurreny.ValueMember = "Id";
            cmbDepositCurreny.DisplayMember = "Title";
            /////////////////////////////////////////

            _status.Add(new ComboBoxBoolModel() { value = true, Title = "اجرا شود" });
            _status.Add(new ComboBoxBoolModel() { value = false, Title = "اجرا نشود" });
            cmbStatus.DataSource = _status;
            cmbStatus.ValueMember = "value";
            cmbStatus.DisplayMember = "Title";
            calcNumber((int)cmbAgency.SelectedValue);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForms())
                {
                    MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید");
                    return;
                }

                var documentId = unitOfWork.TransactionServices.GetNewDocumentId();

                var draft = new Domains.Draft();

            
                var dDate = txtDate.Text.Split('/');
                PersianCalendar p = new PersianCalendar();
                var draftDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                draft.Date = draftDateTime;
                draft.AgencyId = (int)cmbAgency.SelectedValue;
                draft.Type = 0;
                draft.Number = Int64.Parse(txtNumber.Text);
                draft.OtherNumber = txtOtherNumber.Text;
                draft.Sender = txtSender.Text;
                draft.Reciver = txtReciver.Text;
                draft.FatherName = txtFatherName.Text;
                draft.Description = txtDesc.Text;
                draft.PayPlace = txtPayPlace.Text;
                draft.TypeCurrencyId = (int)cmbDraftCurrency.SelectedValue;
                draft.DraftAmount = long.Parse(txtDraftAmount.Text);
                draft.Rate = double.Parse(txtRate.Text, System.Globalization.CultureInfo.InvariantCulture);
                draft.Rent = double.Parse(txtRent.Text, System.Globalization.CultureInfo.InvariantCulture);
                draft.DepositAmount = double.Parse(txtDepositAmount.Text);
                draft.DepositCurrencyId = (int)cmbDepositCurreny.SelectedValue;
                draft.CustomerId = (int)cmbCustomer.SelectedValue;
                draft.Status = (bool)cmbStatus.SelectedValue;

                unitOfWork.DraftsServices.Insert(draft);
                unitOfWork.SaveChanges();


                // trakonesh moshtari //
                var customerTransaction = new Domains.Transaction();
                customerTransaction.SourceCustomerId = (int)cmbCustomer.SelectedValue;
                // customerTransaction.DestinitionCustomerId = AppSetting.SandoghCustomerId;
                customerTransaction.TransactionType = (int)TransaActionType.HavaleRaft;
                customerTransaction.DocumentId = documentId;
                customerTransaction.DepositAmount = 0;
                customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtDepositAmount.Text.Trim())) ? 0 : long.Parse(txtDepositAmount.Text);
                customerTransaction.Description = $"شماره  {txtNumber.Text} {cmbAgency.Text} , {txtSender.Text} برای " +
                    $"{txtReciver.Text} {txtDraftAmount.Text} {cmbDraftCurrency.Text} به نرخ {txtRate.Text} و کرایه {txtRent.Text} {cmbStatus.Text}  **{txtDesc.Text}";

                customerTransaction.CurrenyId = (int)cmbDepositCurreny.SelectedValue;
                var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;

                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();
                //end moshtari ///

                MessageBox.Show(" حواله با موفقیت ثبت شد");
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Saved !" + ex.Message);
            }
        }

        private void ResetForm()
        {
            txtDate.Text = DateTime.Now.ToFarsiFormat();
            txtNumber.Clear();
            txtOtherNumber.Clear();
            txtSender.Clear();
            txtReciver.Clear();
            txtFatherName.Clear();
            txtPayPlace.Clear();
            txtDesc.Clear();
            cmbDraftCurrency.SelectedIndex = 0;
            cmbDepositCurreny.SelectedIndex = 0;
            txtDraftAmount.Text = "0";
            txtRate.Text = "0";
            txtRent.Text = "0";
            txtDepositAmount.Text = "0";
            cmbCustomer.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            calcNumber((int)cmbAgency.SelectedValue);
        }

        private bool ValidateForms()
        {
            if (!(txtDraftAmount.Text.Length > 0 && long.Parse(txtDraftAmount.Text) > 0))
            {
                return false;
            }

            return true;
        }

        private void txtRent_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }

        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbAgency.SelectedIndex >= 0)
            {
                calcNumber((int)cmbAgency.SelectedValue);
            }
        }

        private void calcNumber(int agenyId)
        {
            var lastDraft = unitOfWork.Drafts.FindAll(x => x.AgencyId == agenyId && x.Type == 0).OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastDraft != null)
            {
                txtNumber.Text = (lastDraft.Number + 1).ToString();
            }
            else
            {
                txtNumber.Text = ((int)cmbAgency.SelectedValue * 100 + 1).ToString();
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }

        private void CalculateDeposit()
        {
            try
            {
                if (txtDraftAmount.Text.Length > 0 && txtRate.Text.Length > 0)
                {
                    double rate;
                    if (double.TryParse(txtRate.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out rate))
                    {
                        var sourceCurrenyId = (int)cmbDraftCurrency.SelectedValue;
                        var destiniationCurrenyId = (int)cmbDepositCurreny.SelectedValue;
                        var currenciesMappings = unitOfWork.CurrenciesMappings.FindFirstOrDefault(x => x.SourceCurrenyId == sourceCurrenyId && x.DestiniationCurrenyId == destiniationCurrenyId);

                        var mappingsAction = (int)MappingActions.Multiplication;

                        if (currenciesMappings == null && (sourceCurrenyId != destiniationCurrenyId))
                        {
                            DialogResult dialogResult = MessageBox.Show("نحوه تبدیل ارز مورد نظر تعریف نشده است .", " ارز", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                   MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            if (sourceCurrenyId != destiniationCurrenyId)
                            {
                                mappingsAction = currenciesMappings.Action;
                            }


                            if (mappingsAction == (int)MappingActions.Division)
                            {
                                var drafAmount = Math.Round(double.Parse(txtDraftAmount.Text) / rate, MidpointRounding.AwayFromZero);
                                var rent = txtRent.Text.Length > 0 ? double.Parse(txtRent.Text) : 0;

                                txtDepositAmount.Text = (drafAmount + rent).ToString();
                            }
                            else if (mappingsAction == (int)MappingActions.Multiplication)
                            {

                                var drafAmount = Math.Round(double.Parse(txtDraftAmount.Text) * rate, MidpointRounding.AwayFromZero);
                                var rent = txtRent.Text.Length > 0 ? double.Parse(txtRent.Text) : 0;

                                txtDepositAmount.Text = (drafAmount + rent).ToString();
                            }
                            else
                            {
                                var drafAmount = Math.Round(double.Parse(txtDraftAmount.Text) + rate, MidpointRounding.AwayFromZero);
                                var rent = txtRent.Text.Length > 0 ? double.Parse(txtRent.Text) : 0;

                                txtDepositAmount.Text = (drafAmount + rent).ToString();
                            }

                        }

                    }
                    else
                    {
                        // TODO: tell the user to enter a correct number
                    }

                }
            }
            catch (Exception)
            {


            }

        }

        private void txtDraftAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbDraftCurrency_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void shippingOrderFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}