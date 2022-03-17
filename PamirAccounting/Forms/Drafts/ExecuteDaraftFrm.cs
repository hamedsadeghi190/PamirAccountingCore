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

namespace PamirAccounting.Forms.Drafts
{
    public partial class ExecuteDaraftFrm : DevExpress.XtraEditors.XtraForm
    {
        public long _draftId;
        public Domains.Draft Draft;
        private List<ComboBoxModel> _Customers;
        private List<CurrencyViewModel> _Currencies;
        private UnitOfWork unitOfWork;
        public ExecuteDaraftFrm(long draftId)
        {
            InitializeComponent();
            _draftId = draftId;
            unitOfWork = new UnitOfWork();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ExecuteDaraftFrm_Load(object sender, EventArgs e)
        {
            Draft = unitOfWork.DraftsServices.FindAll(x => x.Id == _draftId)
                .Include(x=>x.TypeCurrency)
                .Include(x=>x.Agency)
                .FirstOrDefault();
            groupBox1.Text += $" {_draftId} ";
            lbl_sender.Text = Draft.Sender;
            lbl_reciver.Text = Draft.Reciver;
            lbl_agencyName.Text = Draft.Agency.Name;
            lbl_currency.Text = Draft.TypeCurrency.Name;
            lbl_amount.Text = Draft.DraftAmount.ToString();
            lbl_palce.Text = Draft.PayPlace;


            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new CurrencyViewModel() { Id = x.Id, Title = x.Name, Action = x.Action, BaseRate = x.BaseRate }).ToList();

            cmbSellCurrencies.DataSource = _Currencies;
            cmbSellCurrencies.ValueMember = "Id";
            cmbSellCurrencies.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();
            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDate.Text = PDate;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}