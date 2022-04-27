using DevExpress.XtraEditors;
using PamirAccounting.Domains;
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

namespace PamirAccounting.Forms.Drafts
{
    public partial class WarrantsPayableFrm : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private List<ComboBoxBoolModel> _status = new List<ComboBoxBoolModel>();
        private List<ComboBoxModel> _Customers;
        private List<ComboBoxModel> _agencies;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _DestCurrencies = new List<ComboBoxModel>();
        private UnitOfWork unitOfWork;
        private long? _draftID, relatedDraftId;
        private long? customerTransactionId;

        private Draft draft, relatedDraft;
        private PamirAccounting.Domains.Transaction customerTransaction;
        long documentId;
        #endregion

        #region constructor
        public WarrantsPayableFrm(long draftId)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _draftID = draftId;
        }
        public WarrantsPayableFrm()
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
        #endregion

        private void WarrantsPayableFrm_Load(object sender, EventArgs e)
        {
            initCombox();
            initData();
            loadData();
        }

        private void initCombox()
        {
            SetComboBoxHeight(cmbStatus.Handle, 25);
            cmbStatus.Refresh();
            SetComboBoxHeight(cmbCustomer.Handle, 25);
            cmbCustomer.Refresh();
            SetComboBoxHeight(cmbAgency.Handle, 25);
            cmbAgency.Refresh();
            SetComboBoxHeight(cmbDepositCurreny.Handle, 25);
            cmbDepositCurreny.Refresh();
            SetComboBoxHeight(cmbDraftCurrency.Handle, 25);
            cmbDraftCurrency.Refresh();
            SetComboBoxHeight(cmbStatus.Handle, 25);
            cmbStatus.Refresh();
        }

        private void loadData()
        {
            if (_draftID.HasValue)
            {
                loadDrafts();
            }
            else
            {
                txtDate.Text = DateTime.Now.ToFarsiFormat();
                cmbCustomer.SelectedValue = AppSetting.NotRunnedDraftsId;
                documentId = unitOfWork.TransactionServices.GetNewDocumentId();
                grpHavale.Text = "حوال امد - شماره سند " + documentId;
            }
        }
        private void loadDrafts()
        {
            draft = unitOfWork.DraftsServices.FindFirstOrDefault(x => x.Id == _draftID, "Transaction");

            if (draft.RelatedDraftId.HasValue)
            {
                relatedDraft = unitOfWork.DraftsServices.FindFirstOrDefault(x => x.Id == draft.RelatedDraftId.Value, "Transaction");
                relatedDraftId = draft.RelatedDraftId.Value;
            }
            else
            {
                customerTransaction = unitOfWork.TransactionServices.FindFirstOrDefault(x => x.Id == draft.TransactionId);
                customerTransactionId = draft.TransactionId;
            }


            documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            grpHavale.Text = "حوال امد - شماره سند " + draft.DocumentId;

            txtDate.Text = draft.Date.Value.ToFarsiFormat();
            cmbAgency.SelectedValue = draft.AgencyId;
            txtNumber.Text = draft.Number.ToString();
            txtOtherNumber.Text = draft.OtherNumber.ToString();
            txtSender.Text = draft.Sender;
            txtReciver.Text = draft.Reciver;
            txtFatherName.Text = draft.FatherName;
            txtDesc.Text = draft.Description;
            txtPayPlace.Text = draft.PayPlace;

            cmbDraftCurrency.SelectedValue = draft.TypeCurrencyId;
            txtDraftAmount.Text = draft.DraftAmount.ToString();
            txtRate.Text = draft.Rate.ToString();
            txtRent.Text = draft.Rent.ToString();
            txtDepositAmount.Text = draft.DepositAmount.ToString();
            cmbDepositCurreny.SelectedValue = draft.DepositCurrencyId;

            if (draft.CustomerId.HasValue)
            {
                cmbCustomer.SelectedValue = draft.CustomerId;
            }
            else
            {
                cmbCustomer.SelectedValue = relatedDraft.AgencyId;
            }
            cmbStatus.SelectedValue = draft.Status;
        }

        private void initData()
        {
            this.cmbAgency.SelectedIndexChanged -= new System.EventHandler(this.cmbAgency_SelectedIndexChanged);

            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name, Type = 1 }).ToList();
            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = "نمایندگی " + x.Name, Type = 2 }).ToList();

            // this.cmbAgency.SelectedIndexChanged -= new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.DataSource = _agencies;
            AutoCompleteStringCollection autoagencies = new AutoCompleteStringCollection();
            foreach (var item in _agencies)
            {
                autoagencies.Add(item.Title);
            }
            cmbAgency.AutoCompleteCustomSource = autoagencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";

            //this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.SelectedIndex = 0;

            var _tmpCustomers = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}", Type = 1 }).ToList();
            _Customers = new List<ComboBoxModel>();
            _Customers.AddRange(_tmpCustomers);
            _Customers.AddRange(_agencies);

            cmbCustomer.DataSource = _Customers;
            AutoCompleteStringCollection autoCustomers = new AutoCompleteStringCollection();
            foreach (var item in _Customers)
            {
                autoCustomers.Add(item.Title);
            }
            cmbCustomer.AutoCompleteCustomSource = autoCustomers;
            cmbCustomer.ValueMember = "Id";
            cmbCustomer.DisplayMember = "Title";

            cmbDraftCurrency.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbDraftCurrency.AutoCompleteCustomSource = autoCurrencies;
            cmbDraftCurrency.ValueMember = "Id";
            cmbDraftCurrency.DisplayMember = "Title";

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


            _status.Add(new ComboBoxBoolModel() { value = true, Title = "اجرا شود" });
            _status.Add(new ComboBoxBoolModel() { value = false, Title = "اجرا نشود" });
            cmbStatus.DataSource = _status;
            cmbStatus.ValueMember = "value";
            cmbStatus.DisplayMember = "Title";
            calcNumber((int)cmbAgency.SelectedValue);
            this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
        }
        private void calcNumber(int agenyId)
        {
            var lastDraft = unitOfWork.Drafts.FindAll(x => x.AgencyId == agenyId && x.Type == 1).OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastDraft != null)
            {
                txtNumber.Text = (lastDraft.Number + 1).ToString();
            }
            else
            {
                txtNumber.Text = ((int)cmbAgency.SelectedValue * 10000).ToString();
            }
        }
        private void calcNumberforosh(int agenyId)
        {
            var lastDraft = unitOfWork.Drafts.FindAll(x => x.AgencyId == agenyId && x.Type == 0).OrderByDescending(x => x.Id).FirstOrDefault();
            if (lastDraft != null)
            {
                txt_forosh_number.Text = (lastDraft.Number + 1).ToString();
            }
            else
            {
                txt_forosh_number.Text = (agenyId + 100 * 20 + 1).ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (!_draftID.HasValue)
                {
                    draft = new Draft();
                }

                var dDate = txtDate.Text.Split('/');
                PersianCalendar p = new PersianCalendar();
                var draftDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                draft.Date = draftDateTime;
                draft.AgencyId = (int)cmbAgency.SelectedValue;
                draft.Type = (int)DraftTypes.Amad;
                draft.DocumentId = documentId;
                draft.Number = Int64.Parse(txtNumber.Text);
                draft.OtherNumber = txtOtherNumber.Text;
                draft.Sender = txtSender.Text;
                draft.Reciver = txtReciver.Text;
                draft.FatherName = txtFatherName.Text;
                draft.Description = txtDesc.Text;
                draft.PayPlace = txtPayPlace.Text;
                draft.TypeCurrencyId = (int)cmbDraftCurrency.SelectedValue;
                draft.DraftAmount = long.Parse(txtDraftAmount.Text);
                draft.Rate = double.Parse(txtRate.Text);
                draft.Rent = double.Parse(txtRent.Text);
                draft.DepositAmount = double.Parse(txtDepositAmount.Text);
                draft.DepositCurrencyId = (int)cmbDepositCurreny.SelectedValue;

                //draft.CustomerId = (int)cmbCustomer.SelectedValue;
                var selectedIndex = (int)cmbCustomer.SelectedIndex;
                var customer = _Customers.ElementAt(selectedIndex);

                // customer or agent (2)
                if (customer.Type == 1)
                {
                    draft.CustomerId = (int)cmbCustomer.SelectedValue;
                }

                draft.Status = (bool)cmbStatus.SelectedValue;

                if (_draftID.HasValue)
                {
                    unitOfWork.DraftsServices.Update(draft);
                }
                else
                {
                    unitOfWork.DraftsServices.Insert(draft);
                }
                unitOfWork.SaveChanges();

                // customer or agent (2)
                if (customer.Type == 1)
                {
                    // trakonesh moshtari //
                    if (customerTransaction == null)
                    {
                        customerTransaction = new Domains.Transaction();
                    }

                    customerTransaction.SourceCustomerId = (int)cmbCustomer.SelectedValue;
                    customerTransaction.TransactionType = (int)TransaActionType.HavaleAmad;
                    customerTransaction.DocumentId = documentId;
                    customerTransaction.WithdrawAmount = 0;
                    customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtDepositAmount.Text.Trim())) ? 0 : long.Parse(txtDepositAmount.Text);
                    customerTransaction.Description = $"شماره  {txtNumber.Text} {cmbAgency.Text} , {txtSender.Text} برای " +
                        $"{txtReciver.Text} {txtDraftAmount.Text} {cmbDraftCurrency.Text} به نرخ {txtRate.Text} و کرایه {txtRent.Text} {cmbStatus.Text} و دریافت {txtDepositAmount.Text}{cmbDepositCurreny.Text} **{txtDesc.Text}";

                    customerTransaction.CurrenyId = (int)cmbDepositCurreny.SelectedValue;
                    var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                    customerTransaction.Date = DateTime.Now;
                    customerTransaction.TransactionDateTime = TransactionDateTime;
                    customerTransaction.UserId = CurrentUser.UserID;
                    if (customerTransactionId.HasValue)
                    {
                        unitOfWork.TransactionServices.Update(customerTransaction);
                    }
                    else
                    {
                        unitOfWork.TransactionServices.Insert(customerTransaction);
                    }
                    unitOfWork.SaveChanges();

                    draft.TransactionId = customerTransaction.Id;
                    unitOfWork.DraftsServices.Update(draft);
                    unitOfWork.SaveChanges();


                    //end moshtari ///
                    if (relatedDraftId.HasValue)
                    {
                        draft.RelatedDraftId = null;
                        unitOfWork.DraftsServices.Update(draft);
                        unitOfWork.SaveChanges();

                        unitOfWork.DraftsServices.Delete(relatedDraft);
                        unitOfWork.SaveChanges();
                    }

                }
                else

                {
                    if (!relatedDraftId.HasValue)
                    {
                        relatedDraft = new Draft();
                    }
                    relatedDraft.DocumentId = documentId;
                    relatedDraft.Date = draftDateTime;
                    relatedDraft.AgencyId = customer.Id;
                    relatedDraft.Type = (int)DraftTypes.Raft;
                    relatedDraft.Number = Int64.Parse(txt_forosh_number.Text);
                    relatedDraft.OtherNumber = txt_forosh_ext_number.Text;
                    relatedDraft.Sender = txtSender.Text;
                    relatedDraft.Reciver = txtReciver.Text;
                    relatedDraft.FatherName = txtFatherName.Text;
                    relatedDraft.Description = txtDesc.Text;
                    relatedDraft.PayPlace = txtPayPlace.Text;
                    relatedDraft.TypeCurrencyId = (int)cmbDepositCurreny.SelectedValue;
                    relatedDraft.DraftAmount = long.Parse(txtDepositAmount.Text);
                    relatedDraft.Rate = 1;
                    relatedDraft.Rent = 0;
                    relatedDraft.DepositAmount = double.Parse(txtDepositAmount.Text);
                    relatedDraft.DepositCurrencyId = (int)cmbDepositCurreny.SelectedValue;
                    relatedDraft.CustomerId = AppSetting.NotRunnedDraftsId;
                    relatedDraft.Status = (bool)cmbStatus.SelectedValue;

                    if (relatedDraftId.HasValue)
                    {
                        unitOfWork.DraftsServices.Update(relatedDraft);

                    }
                    else
                    {
                        unitOfWork.DraftsServices.Insert(relatedDraft);
                    }
                    unitOfWork.SaveChanges();

                    draft.RelatedDraftId = relatedDraft.Id;
                    unitOfWork.DraftsServices.Update(draft);
                    unitOfWork.SaveChanges();

                    if (customerTransactionId.HasValue)
                    {
                        draft.TransactionId = null;
                        unitOfWork.DraftsServices.Update(draft);
                        unitOfWork.SaveChanges();

                        unitOfWork.TransactionServices.Delete(customerTransaction);
                        unitOfWork.SaveChanges();
                    }
                }


                MessageBox.Show(" حواله با موفقیت ثبت شد");

                if (_draftID.HasValue)
                {
                    Close();
                }
                else
                {
                    draft = null;
                    customerTransaction = null;
                    clearFrom();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Saved !" + ex.Message);
            }
        }

        private void clearFrom()
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
            cmbCustomer.SelectedValue = AppSetting.NotRunnedDraftsId;
            calcNumber((int)cmbAgency.SelectedValue);
            documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            grpHavale.Text = "حوال امد - شماره سند " + documentId;
            txtNumber.Focus();
        }

        private void CalculateDeposit()
        {
            this.txtDraftAmount.TextChanged -= new System.EventHandler(this.txtDraftAmount_TextChanged);
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

                                var depositAmount = Math.Round((double.Parse(txtDraftAmount.Text) ) / rate, MidpointRounding.AwayFromZero);
                                txtDepositAmount.Text = (depositAmount).ToString();

                            }
                            else if (mappingsAction == (int)MappingActions.Multiplication)
                            {
                           
                                var depositAmount = Math.Round((double.Parse(txtDraftAmount.Text) ) * rate, MidpointRounding.AwayFromZero);
                                txtDepositAmount.Text = (depositAmount).ToString();
                            }
                            else
                            {
                             
                                var depositAmount = Math.Round((double.Parse(txtDraftAmount.Text) ) + rate, MidpointRounding.AwayFromZero);
                                txtDepositAmount.Text = (depositAmount).ToString();
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
            this.txtDraftAmount.TextChanged += new System.EventHandler(this.txtDraftAmount_TextChanged);
        }
        private void txtDraftAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }
        private void txtRent_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }
        private void cmbDepositCurreny_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }
        private void WarrantsPayableFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void cmbDraftCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDepositCurreny.SelectedValue = cmbDraftCurrency.SelectedValue;
        }

        private void txtDraftAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDraftAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtDraftAmount.Text += "000";
            }
            txtDraftAmount.Select(txtDraftAmount.Text.Length, 0);
        }

        private void txtRate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtRate.Text += "000";
            }
            txtRate.Select(txtRate.Text.Length, 0);
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextEdit).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextEdit).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtRent_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                txtRent.Text += "000";
            }
            txtRent.Select(txtRent.Text.Length, 0);
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = (int)cmbCustomer.SelectedIndex;
            var customer = _Customers.ElementAt(selectedIndex);
            if (customer.Type == 2)
            {
                txt_forosh_number.Visible = true;
                txt_forosh_ext_number.Visible = true;
                lbl_forosh_number.Visible = true;
                lbl_forosh_ext_number.Visible = true;
                calcNumberforosh(customer.Id);
            }
            else
            {
                txt_forosh_number.Visible = false;
                txt_forosh_ext_number.Visible = false;
                lbl_forosh_number.Visible = false;
                lbl_forosh_ext_number.Visible = false;


            }
        }
        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcNumber((int)cmbAgency.SelectedValue);

        }
    }
}