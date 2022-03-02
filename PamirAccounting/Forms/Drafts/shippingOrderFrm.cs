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
            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + (pc.GetMonth(DateTime.Now) < 10 ? "0" + pc.GetMonth(DateTime.Now).ToString() : pc.GetMonth(DateTime.Now).ToString()) + "/" + (pc.GetDayOfMonth(DateTime.Now) < 10 ? "0" + pc.GetDayOfMonth(DateTime.Now).ToString() : pc.GetDayOfMonth(DateTime.Now).ToString());
            txtDate.Text = PDate;
        }
        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            this.cmbAgency.SelectedIndexChanged -= new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.DataSource = _agencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";
            this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.SelectedIndex = 0;

            _Customers = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
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
                draft.Rate = double.Parse(txtRate.Text);
                draft.Rent = double.Parse(txtRent.Text);
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
                    $"{txtReciver.Text} {txtDraftAmount.Text} {cmbDepositCurreny.Text} به نرخ {txtRate.Text} و کرایه {txtRent.Text} {cmbStatus.Text}  **{txtDesc.Text}";

                customerTransaction.CurrenyId = (int)cmbDepositCurreny.SelectedValue;
                var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;

                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();
                //end moshtari ///

                MessageBox.Show(" حواله با موفقیت ثبت شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Saved !" + ex.Message);
            }
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
            var lastDraft = unitOfWork.Drafts.FindAll(x => x.AgencyId == agenyId).OrderByDescending(x => x.Id).FirstOrDefault();
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
                            if(sourceCurrenyId != destiniationCurrenyId)
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
    }
}