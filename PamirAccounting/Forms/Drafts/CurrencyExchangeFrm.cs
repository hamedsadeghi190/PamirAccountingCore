using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
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
    public partial class CurrencyExchangeFrm : DevExpress.XtraEditors.XtraForm
    {
        public long DraftId { get; set; }
        public Domains.Draft _Draft { get; set; }
        private UnitOfWork unitOfWork;
        private List<ComboBoxModel> _Currencies;
        public CurrencyExchangeFrm(long draftId)
        {
            InitializeComponent();
            DraftId = draftId;
            unitOfWork = new UnitOfWork();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CurrencyExchangeFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbConvertedCurrency.DataSource = _Currencies;
            cmbConvertedCurrency.ValueMember = "Id";
            cmbConvertedCurrency.DisplayMember = "Title";

            _Draft = unitOfWork.Drafts.FindAll(x => x.Id == DraftId).Include(x => x.TypeCurrency).FirstOrDefault();


            if (_Draft != null)
            {
                lblDraftAmount.Text = _Draft.DraftAmount.ToString();
                lblDraftCurrency.Text = _Draft.TypeCurrency.Name;

                if (_Draft.ConvertedCurrencyId.HasValue)
                {
                    cmbConvertedCurrency.SelectedValue = _Draft.ConvertedCurrencyId;
                    lblConvetedAmount.Text = _Draft.ConvertedAmount.ToString();
                    txtRate.Text = _Draft.ConvertedRate.ToString();
                    txtRent.Text = _Draft.Rent.ToString();
                    txtExteraDesc.Text = _Draft.ExtraDescription;
                }

            }

        }

        private void CalculateDeposit()
        {
            try
            {
                if (txtRate.Text.Length > 0)
                {
                    double rate;
                    if (double.TryParse(txtRate.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out rate))
                    {
                        var sourceCurrenyId = (int)_Draft.TypeCurrencyId;
                        var destiniationCurrenyId = (int)cmbConvertedCurrency.SelectedValue;
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
                                var drafAmount = Math.Round(_Draft.DraftAmount / rate, MidpointRounding.AwayFromZero);
                                var rent = txtRent.Text.Length > 0 ? double.Parse(txtRent.Text) : 0;

                                lblConvetedAmount.Text = (drafAmount + rent).ToString();
                            }
                            else if (mappingsAction == (int)MappingActions.Multiplication)
                            {

                                var drafAmount = Math.Round(_Draft.DraftAmount * rate, MidpointRounding.AwayFromZero);
                                var rent = txtRent.Text.Length > 0 ? double.Parse(txtRent.Text) : 0;

                                lblConvetedAmount.Text = (drafAmount + rent).ToString();
                            }
                            else
                            {
                                var drafAmount = Math.Round(_Draft.DraftAmount + rate, MidpointRounding.AwayFromZero);
                                var rent = txtRent.Text.Length > 0 ? double.Parse(txtRent.Text) : 0;

                                lblConvetedAmount.Text = (drafAmount + rent).ToString();
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

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }

        private void txtRent_TextChanged(object sender, EventArgs e)
        {
            CalculateDeposit();
        }

        private void cmbConvertedCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblConvertedCurrency.Text = cmbConvertedCurrency.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Draft.ConvertedCurrencyId = (int)cmbConvertedCurrency.SelectedValue;
            _Draft.ConvertedAmount = long.Parse(lblConvetedAmount.Text);
            _Draft.ConvertedRate = double.Parse(txtRate.Text);
            _Draft.Rent =  double.Parse(txtRent.Text);
            _Draft.ExtraDescription = txtExteraDesc.Text;

            unitOfWork.DraftsServices.Update(_Draft);
            unitOfWork.SaveChanges();
            Close();

        }

        private void CurrencyExchangeFrm_KeyUp(object sender, KeyEventArgs e)
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