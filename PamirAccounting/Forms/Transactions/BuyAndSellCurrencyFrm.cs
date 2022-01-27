using DevExpress.XtraEditors;
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

namespace PamirAccounting.Forms.Transactions
{
    public partial class BuyAndSellCurrencyFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private long? _TransActionId;
        private List<CurrencyViewModel>  _DestCurrencies = new List<CurrencyViewModel>();
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

        private void BuyAndSellCurrencyFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {

            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new CurrencyViewModel() { Id = x.Id, Title = x.Name ,Action =x.Action,BaseRate=x.BaseRate}).ToList();

            cmbSellCurrencies.DataSource = _Currencies;
            cmbSellCurrencies.ValueMember = "Id";
            cmbSellCurrencies.DisplayMember = "Title";

            
            _DestCurrencies.AddRange(_Currencies);
            cmbCurrencybuyer.DataSource = _DestCurrencies;
            cmbCurrencybuyer.ValueMember = "Id";
            cmbCurrencybuyer.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            
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
    }
}