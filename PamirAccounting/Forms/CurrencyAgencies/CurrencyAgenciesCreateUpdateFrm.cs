using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.CurrencyAgencies
{
    public partial class CurrencyAgenciesCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<ComboBoxModel> _agencies;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _DestCurrencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<ComboBoxModel> _RoundLimit = new List<ComboBoxModel>();
        private List<ComboBoxModel> _exchangeRate = new List<ComboBoxModel>();
        private CurrencyAgency _CurrencyAgency;
        public CurrencyAgenciesCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public CurrencyAgenciesCreateUpdateFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbSourceCurreny.DataSource = _Currencies;
            cmbSourceCurreny.ValueMember = "Id";
            cmbSourceCurreny.DisplayMember = "Title";

            _DestCurrencies.AddRange(_Currencies);
            cmbDescCurenccy.DataSource = _DestCurrencies;
            cmbDescCurenccy.ValueMember = "Id";
            cmbDescCurenccy.DisplayMember = "Title";


            cmbAgency.DataSource = _agencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";


            _exchangeRate.Add(new ComboBoxModel() { Id = 1, Title = "عادی" });
            _exchangeRate.Add(new ComboBoxModel() { Id = 10, Title = "10 عدد" });
            cmbExchangeRate.DataSource = _exchangeRate;
            cmbExchangeRate.ValueMember = "Id";
            cmbExchangeRate.DisplayMember = "Title";



            _Actions.Add(new ComboBoxModel() { Id = 1, Title = "ضرب" });
            _Actions.Add(new ComboBoxModel() { Id = 2, Title = "تقسیم" });
            _Actions.Add(new ComboBoxModel() { Id = 3, Title = "جمع" });

            cmbAction.DataSource = _Actions;
            cmbAction.ValueMember = "Id";
            cmbAction.DisplayMember = "Title";


            _RoundLimit.Add(new ComboBoxModel() { Id = 1, Title = "رند عادی" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 10, Title = "رند به تغریب 10" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 100, Title = "رند به تغریب 100" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 1000, Title = "رند به تغریب 1000" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 10000, Title = "رند به تغریب 10000" });

            cmbroundLimit.DataSource = _RoundLimit;
            cmbroundLimit.ValueMember = "Id";
            cmbroundLimit.DisplayMember = "Title";
        }

        private void CurrencyAgenciesCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            initData();

            if (_Id != null)
            {
                loadEditData();
            }

        }

        private void loadEditData()
        {
            _CurrencyAgency = unitOfWork.CurrencyAgencies.FindFirst(x => x.Id == _Id);
            cmbAgency.SelectedValue = _CurrencyAgency.AgencyId;
            cmbAction.SelectedValue = _CurrencyAgency.Action;
            cmbSourceCurreny.SelectedValue = _CurrencyAgency.SourceCurrenyId;
            cmbDescCurenccy.SelectedValue = _CurrencyAgency.DestiniationCurrenyId;
            cmbroundLimit.SelectedValue = _CurrencyAgency.RoundLimit;
            cmbExchangeRate.SelectedValue = _CurrencyAgency.ExchangeRate;
        }

      

        private void btnexitAgencyCurrency_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSaveAgencyCurrency_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Id != null)
                {
                    _CurrencyAgency.AgencyId = (int)cmbAgency.SelectedValue;
                    _CurrencyAgency.Action = (int)cmbAction.SelectedValue;
                    _CurrencyAgency.SourceCurrenyId = (int)cmbSourceCurreny.SelectedValue;
                    _CurrencyAgency.DestiniationCurrenyId = (int)cmbDescCurenccy.SelectedValue;
                    _CurrencyAgency.RoundLimit = (int)cmbroundLimit.SelectedValue;
                    _CurrencyAgency.ExchangeRate = (int)cmbExchangeRate.SelectedValue;

                    unitOfWork.CurrencyAgenciesServices.Update(_CurrencyAgency);
                }
                else
                {
                    var newCurrencyAgency = new CurrencyAgency()
                    {
                        AgencyId = (int)cmbAgency.SelectedValue,
                        Action = (int)cmbAction.SelectedValue,
                        SourceCurrenyId = (int)cmbSourceCurreny.SelectedValue,
                        DestiniationCurrenyId = (int)cmbDescCurenccy.SelectedValue,
                        RoundLimit = (int)cmbroundLimit.SelectedValue,
                        ExchangeRate = (int)cmbExchangeRate.SelectedValue,
                    };
                    unitOfWork.CurrencyAgenciesServices.Insert(newCurrencyAgency);

                }
                unitOfWork.SaveChanges();
                Close();
            }
            catch
            {
                MessageBox.Show("ذخییره تغییرات با شکست مواجه شد");
            }
        }
    }
}