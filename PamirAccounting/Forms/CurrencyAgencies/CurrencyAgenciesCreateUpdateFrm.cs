using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.CurrencyAgencies
{
    public partial class CurrencyAgenciesCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<ComboBoxModel> _Currencies;
        private List<ComboBoxModel> _DestCurrencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<ComboBoxModel> _RoundLimit = new List<ComboBoxModel>();
        private List<ComboBoxModel> _exchangeRate = new List<ComboBoxModel>();
        private CurrenciesMapping _CurrenciesMapping;
        public CurrencyAgenciesCreateUpdateFrm()
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
        public CurrencyAgenciesCreateUpdateFrm(int id)
        {

            InitializeComponent();
            unitOfWork = new UnitOfWork();

            SetComboBoxHeight(cmbDescCurenccy.Handle, 25);
            cmbDescCurenccy.Refresh();
            SetComboBoxHeight(cmbExchangeRate.Handle, 25);
            cmbExchangeRate.Refresh();
            SetComboBoxHeight(cmbroundLimit.Handle, 25);
            cmbroundLimit.Refresh();
            SetComboBoxHeight(cmbSourceCurreny.Handle, 25);
            cmbSourceCurreny.Refresh();
            SetComboBoxHeight(cmbAction.Handle, 25);
            cmbAction.Refresh();
            _Id = id;
        }
        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbSourceCurreny.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbSourceCurreny.AutoCompleteCustomSource = autoCurrencies;
            cmbSourceCurreny.ValueMember = "Id";
            cmbSourceCurreny.DisplayMember = "Title";
            ///////////////////////////////
            _DestCurrencies.AddRange(_Currencies);
            cmbDescCurenccy.DataSource = _DestCurrencies;
            AutoCompleteStringCollection autoDestCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoDestCurrencies.Add(item.Title);
            }
            cmbDescCurenccy.AutoCompleteCustomSource = autoDestCurrencies;
            cmbDescCurenccy.ValueMember = "Id";
            cmbDescCurenccy.DisplayMember = "Title";
            ///////////////////////////////////
   

            _exchangeRate.Add(new ComboBoxModel() { Id = 1, Title = "عادی" });
            _exchangeRate.Add(new ComboBoxModel() { Id = 10, Title = "10 عدد" });
            cmbExchangeRate.DataSource = _exchangeRate;
            AutoCompleteStringCollection autoExchangeRate = new AutoCompleteStringCollection();
            foreach (var item in _exchangeRate)
            {
                autoExchangeRate.Add(item.Title);
            }
            cmbExchangeRate.AutoCompleteCustomSource = autoExchangeRate;
            cmbExchangeRate.ValueMember = "Id";
            cmbExchangeRate.DisplayMember = "Title";



            _Actions.Add(new ComboBoxModel() { Id = 1, Title = "ضرب" });
            _Actions.Add(new ComboBoxModel() { Id = 2, Title = "تقسیم" });
            _Actions.Add(new ComboBoxModel() { Id = 3, Title = "جمع" });

            cmbAction.DataSource = _Actions;
            AutoCompleteStringCollection autoActions = new AutoCompleteStringCollection();
            foreach (var item in _Actions)
            {
                autoActions.Add(item.Title);
            }
            cmbAction.AutoCompleteCustomSource = autoActions;
            cmbAction.ValueMember = "Id";
            cmbAction.DisplayMember = "Title";


            _RoundLimit.Add(new ComboBoxModel() { Id = 1, Title = "رند عادی" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 10, Title = "رند به تغریب 10" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 100, Title = "رند به تغریب 100" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 1000, Title = "رند به تغریب 1000" });
            _RoundLimit.Add(new ComboBoxModel() { Id = 10000, Title = "رند به تغریب 10000" });

            cmbroundLimit.DataSource = _RoundLimit;
            AutoCompleteStringCollection autoRoundLimit = new AutoCompleteStringCollection();
            foreach (var item in _RoundLimit)
            {
                autoRoundLimit.Add(item.Title);
            }
            cmbroundLimit.AutoCompleteCustomSource = autoRoundLimit;
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
            _CurrenciesMapping = unitOfWork.CurrenciesMappings.FindFirst(x => x.Id == _Id);
 
            cmbAction.SelectedValue = _CurrenciesMapping.Action;
            cmbSourceCurreny.SelectedValue = _CurrenciesMapping.SourceCurrenyId;
            cmbDescCurenccy.SelectedValue = _CurrenciesMapping.DestiniationCurrenyId;
            cmbroundLimit.SelectedValue = _CurrenciesMapping.RoundLimit;
            cmbExchangeRate.SelectedValue = _CurrenciesMapping.ExchangeRate;
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

                    _CurrenciesMapping.Action = (int)cmbAction.SelectedValue;
                    _CurrenciesMapping.SourceCurrenyId = (int)cmbSourceCurreny.SelectedValue;
                    _CurrenciesMapping.DestiniationCurrenyId = (int)cmbDescCurenccy.SelectedValue;
                    _CurrenciesMapping.RoundLimit = (int)cmbroundLimit.SelectedValue;
                    _CurrenciesMapping.ExchangeRate = (int)cmbExchangeRate.SelectedValue;

                    unitOfWork.CurrenciesMappingServices.Update(_CurrenciesMapping);
                }
                else
                {
                    var newCurrencyMapping= new CurrenciesMapping()
                    {
             
                        Action = (int)cmbAction.SelectedValue,
                        SourceCurrenyId = (int)cmbSourceCurreny.SelectedValue,
                        DestiniationCurrenyId = (int)cmbDescCurenccy.SelectedValue,
                        RoundLimit = (int)cmbroundLimit.SelectedValue,
                        ExchangeRate = (int)cmbExchangeRate.SelectedValue,
                    };
                    unitOfWork.CurrenciesMappingServices.Insert(newCurrencyMapping);

                }
                unitOfWork.SaveChanges();
                Close();
            }
            catch
            {
                MessageBox.Show("ذخییره تغییرات با شکست مواجه شد");
            }
        }

        private void CurrencyAgenciesCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}