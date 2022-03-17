﻿using DevExpress.XtraEditors;
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
    public partial class WarrantsPayableFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<ComboBoxBoolModel> _status = new List<ComboBoxBoolModel>();
        private List<ComboBoxModel> _Customers;
        private List<ComboBoxModel> _agencies;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _DestCurrencies = new List<ComboBoxModel>();
        private UnitOfWork unitOfWork;

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


        private void WarrantsPayableFrm_Load(object sender, EventArgs e)
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

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + (pc.GetMonth(DateTime.Now) < 10 ? "0" + pc.GetMonth(DateTime.Now).ToString() : pc.GetMonth(DateTime.Now).ToString()) + "/" + (pc.GetDayOfMonth(DateTime.Now) < 10 ? "0" + pc.GetDayOfMonth(DateTime.Now).ToString() : pc.GetDayOfMonth(DateTime.Now).ToString());
            txtDate.Text = PDate;
            initData();
            cmbCustomer.SelectedValue = AppSetting.NotRunnedDraftsId;

        }

        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = "نمایندگی " + x.Name, Type = 2 }).ToList();

            // this.cmbAgency.SelectedIndexChanged -= new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.DataSource = _agencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";

            //this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.SelectedIndex = 0;

            var _tmpCustomers = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}", Type = 1 }).ToList();
            _Customers = new List<ComboBoxModel>();
            _Customers.AddRange(_tmpCustomers);
            _Customers.AddRange(_agencies);

            cmbCustomer.DataSource = _Customers;
            cmbCustomer.ValueMember = "Id";
            cmbCustomer.DisplayMember = "Title";

            cmbDraftCurrency.DataSource = _Currencies;
            cmbDraftCurrency.ValueMember = "Id";
            cmbDraftCurrency.DisplayMember = "Title";

            _DestCurrencies.AddRange(_Currencies);
            cmbDepositCurreny.DataSource = _DestCurrencies;
            cmbDepositCurreny.ValueMember = "Id";
            cmbDepositCurreny.DisplayMember = "Title";


            _status.Add(new ComboBoxBoolModel() { value = true, Title = "اجرا شود" });
            _status.Add(new ComboBoxBoolModel() { value = false, Title = "اجرا نشود" });
            cmbStatus.DataSource = _status;
            cmbStatus.ValueMember = "value";
            cmbStatus.DisplayMember = "Title";
            calcNumber((int)cmbAgency.SelectedValue);
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
                txtNumber.Text = ((int)cmbAgency.SelectedValue + 100 * 30 + 1).ToString();
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
                var documentId = unitOfWork.TransactionServices.GetNewDocumentId();

                var draft = new Domains.Draft();

                var dDate = txtDate.Text.Split('/');
                PersianCalendar p = new PersianCalendar();
                var draftDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                draft.Date = draftDateTime;
                draft.AgencyId = (int)cmbAgency.SelectedValue;
                draft.Type = 1;
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
                draft.CustomerId = (int)cmbCustomer.SelectedValue;
                draft.Status = (bool)cmbStatus.SelectedValue;

                unitOfWork.DraftsServices.Insert(draft);
                unitOfWork.SaveChanges();

                var selectedIndex = (int)cmbCustomer.SelectedIndex;
                var customer = _Customers.ElementAt(selectedIndex);
                if (customer.Type == 1)
                {

                    // trakonesh moshtari //
                    var customerTransaction = new Domains.Transaction();
                    customerTransaction.SourceCustomerId = (int)cmbCustomer.SelectedValue;
                    // customerTransaction.DestinitionCustomerId = AppSetting.SandoghCustomerId;
                    customerTransaction.TransactionType = (int)TransaActionType.HavaleAmad;
                    customerTransaction.DocumentId = documentId;
                    customerTransaction.WithdrawAmount = 0;
                    customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtDraftAmount.Text.Trim())) ? 0 : long.Parse(txtDraftAmount.Text);
                    customerTransaction.Description = $"شماره  {txtNumber.Text} {cmbAgency.Text} , {txtSender.Text} برای " +
                        $"{txtReciver.Text} {txtDraftAmount.Text} {cmbDepositCurreny.Text} به نرخ {txtRate.Text} و کرایه {txtRent.Text} {cmbStatus.Text}  **{txtDesc.Text}";

                    customerTransaction.CurrenyId = (int)cmbDraftCurrency.SelectedValue;
                    var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                    customerTransaction.Date = DateTime.Now;
                    customerTransaction.TransactionDateTime = TransactionDateTime;
                    customerTransaction.UserId = CurrentUser.UserID;

                    unitOfWork.TransactionServices.Insert(customerTransaction);
                    unitOfWork.SaveChanges();
                    //end moshtari ///

                  
                }
                else

                {
                  
                    var draftForosh = new Domains.Draft();

                    draftForosh.Date = draftDateTime;
                    draftForosh.AgencyId = customer.Id;
                    draftForosh.Type = 0;
                    draftForosh.Number = Int64.Parse(txt_forosh_number.Text);
                    draftForosh.OtherNumber = txt_forosh_ext_number.Text;
                    draftForosh.Sender = txtSender.Text;
                    draftForosh.Reciver = txtReciver.Text;
                    draftForosh.FatherName = txtFatherName.Text;
                    draftForosh.Description = txtDesc.Text;
                    draftForosh.PayPlace = txtPayPlace.Text;
                    draftForosh.TypeCurrencyId = (int)cmbDraftCurrency.SelectedValue;
                    draftForosh.DraftAmount = long.Parse(txtDraftAmount.Text);
                    draftForosh.Rate = double.Parse(txtRate.Text);
                    draftForosh.Rent = double.Parse(txtRent.Text);
                    draftForosh.DepositAmount = double.Parse(txtDepositAmount.Text);
                    draftForosh.DepositCurrencyId = (int)cmbDepositCurreny.SelectedValue;
                    draftForosh.CustomerId = AppSetting.NotRunnedDraftsId;
                    draftForosh.Status = (bool)cmbStatus.SelectedValue;

                    unitOfWork.DraftsServices.Insert(draftForosh);
                    unitOfWork.SaveChanges();

                }


                MessageBox.Show(" حواله با موفقیت ثبت شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Saved !" + ex.Message);
            }
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



       
    }
}