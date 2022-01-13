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
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

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
                draft.Rate = long.Parse(txtRate.Text);
                draft.Rent = long.Parse(txtRent.Text);
                draft.DepositAmount = double.Parse(txtDepositAmount.Text);
                draft.DepositCurrencyId = (int)cmbDepositCurreny.SelectedValue;
                draft.CustomerId = (int)cmbCustomer.SelectedValue;
                draft.Status = (bool)cmbStatus.SelectedValue;

                unitOfWork.DraftsServices.Insert(draft);
                unitOfWork.SaveChanges();
                MessageBox.Show(" حواله با موفقیت ثبت شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Saved !" + ex.Message);
            }
        }

        private void txtRent_TextChanged(object sender, EventArgs e)
        {
            if(txtRent.Text.Length>0)
            {
                CalculateDeposit();
                var deposit = txtDepositAmount.Text.Length > 0 ? double.Parse(txtDepositAmount.Text) : 0;
                txtDepositAmount.Text = (deposit + double.Parse(txtRent.Text)).ToString("00.00");
            }
            else
            {
                CalculateDeposit();
                var deposit = txtDepositAmount.Text.Length > 0 ? double.Parse(txtDepositAmount.Text) : 0;
                txtDepositAmount.Text = (deposit + 0).ToString("00.00");
            }
        }

        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAgency.SelectedIndex >= 0)
            {
                var lastDraft = unitOfWork.Drafts.FindAll(x => x.AgencyId == (int)cmbAgency.SelectedValue).OrderByDescending(x => x.Id).FirstOrDefault();
                if (lastDraft != null)
                {
                    txtNumber.Text = (lastDraft.Number + 1).ToString();
                }
                else
                {
                    txtNumber.Text = ((int)cmbAgency.SelectedValue*100 + 1).ToString();
                }
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }

        private void CalculateDeposit()
        {
            if (txtDraftAmount.Text.Length > 0 && txtRate.Text.Length>0)
            {
                txtDepositAmount.Text =  (double.Parse(txtDraftAmount.Text) / double.Parse(txtRate.Text)).ToString("00.00");
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
    }
}