using Microsoft.EntityFrameworkCore;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Models;
using PamirAccounting.Models.ViewModels;
using PamirAccounting.Services;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Drafts
{
    public partial class DraftsListFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<SummeryDraftViewModels> _dataSummery;
        private List<DraftViewModels> _data;
        private List<ComboBoxModel> _agencies;
        private List<ComboBoxModel> _draftTypes = new List<ComboBoxModel>();
        private UnitOfWork unitOfWork;

        public DraftsListFrm()
        {
            InitializeComponent();
            gridDrafts.AutoGenerateColumns = false;
            grdTotals.AutoGenerateColumns = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            groupBoxSearch.Visible = true;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
        }

        private void btnAgencystatus_Click(object sender, EventArgs e)
        {
            var AgencyStatusFrm = new AgencyStatusFrm((int)cmbAgency.SelectedValue);
            AgencyStatusFrm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void btnExecuteDaraft_Click(object sender, EventArgs e)
        {
        }

        private void DraftsListFrm_Load(object sender, EventArgs e)
        {
            unitOfWork = new UnitOfWork();
            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            this.cmbAgency.SelectedIndexChanged -= new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.DataSource = _agencies;
            AutoCompleteStringCollection autoAgencies = new AutoCompleteStringCollection();
            foreach (var item in _agencies)
            {
                autoAgencies.Add(item.Title);
            }
            cmbAgency.AutoCompleteCustomSource = autoAgencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";
            this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            cmbAgency.SelectedIndex = 0;

            this.cmbType.SelectedIndexChanged -= new System.EventHandler(this.cmbType_SelectedIndexChanged);
            _draftTypes.Add(new ComboBoxModel() { Id = 0, Title = "رفت" });
            _draftTypes.Add(new ComboBoxModel() { Id = 1, Title = "آمد" });
            cmbType.DataSource = _draftTypes;
            cmbType.ValueMember = "Id";
            cmbType.DisplayMember = "Title";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            LoadData();
        }

        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            unitOfWork = new UnitOfWork();
            var tmpData = unitOfWork.DraftsServices.FindAll(x => x.AgencyId == (int)cmbAgency.SelectedValue
                                                            && x.Type == (int)(cmbType.SelectedValue))
                .OrderBy(x => x.Date)
                .Include(x => x.DepositCurrency)
                .Include(x => x.TypeCurrency)
                .Include(x => x.Customer)
                .ToList();

            var rowId = 1;
            var _RowedData = tmpData.Select(q => new DraftViewModels()
            {
                Radif = rowId++,
                Id = q.Id,
                Number = q.Number,
                OtherNumber = q.OtherNumber,
                Sender = q.Sender,
                Reciver = q.Reciver,
                FatherName = q.FatherName,
                PayPlace = q.PayPlace,
                Description = q.Description,
                TypeCurrency = q.TypeCurrency.Name,
                TypeCurrencyId = q.TypeCurrencyId,
                DraftAmount = q.DraftAmount,
                Rate = q.Rate,
                Rent = q.Rent,
                Type = q.Type,
                DepositAmount = q.DepositAmount,
                DepositCurrency = q.DepositCurrency?.Name,
                CustomerId = q.CustomerId,
                RemainAmount = 0,
                Customer = q.Customer?.FirstName + " " + q.Customer?.LastName,
                RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                Date = q.Date != null ? (DateTime.Parse(q.Date.ToString())).ToPersian() : "",
            }).ToList();


            _data = new List<DraftViewModels>();
            _dataSummery = new List<SummeryDraftViewModels>();

            var groupedw = _RowedData.GroupBy(x => x.TypeCurrency);

            foreach (var item in groupedw)
            {
                double totalRemainAmount = 0;
                double TotalRent = 0;
                string CurrenyName = "";

                foreach (var havale in item)
                {
                    CurrenyName = havale.TypeCurrency;
                    totalRemainAmount += havale.DraftAmount;
                    TotalRent += havale.Rent;
                    havale.RemainAmount = totalRemainAmount;
                    _data.Add(havale);
                }

                var cdata = new SummeryDraftViewModels();
                cdata.CurrenyName = CurrenyName;
                cdata.Total = totalRemainAmount;
                cdata.TotalRent = TotalRent;

                _dataSummery.Add(cdata);
            }


            _data = _data.OrderBy(x => x.Radif).ToList();
            gridDrafts.DataSource = null;
            gridDrafts.DataSource = _data;
            gridDrafts.Refresh();

            grdTotals.DataSource = null;
            grdTotals.DataSource = _dataSummery;
            gridDrafts.Refresh();
        }

        private void DraftsListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnAgencystatus_Click(null, null);
            }
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {


        }

        private void gridDrafts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            /////////////////////////////////

            unitOfWork = new UnitOfWork();
            var tmpData = unitOfWork.DraftsServices.FindAll(x => x.AgencyId == (int)cmbAgency.SelectedValue
                                                            && x.Type == (int)(cmbType.SelectedValue))
                .OrderBy(x => x.Date)
                .Include(x => x.DepositCurrency)
                .Include(x => x.TypeCurrency)
                .Include(x => x.Customer)
                .ToList();

            var rowId = 1;
            var _RowedData = tmpData.Select(q => new DraftViewModels()
            {
                Radif = rowId++,
                Id = q.Id,
                Number = q.Number,
                OtherNumber = q.OtherNumber,
                Sender = q.Sender,
                Reciver = q.Reciver,
                FatherName = q.FatherName,
                PayPlace = q.PayPlace,
                Description = q.Description,
                TypeCurrency = q.TypeCurrency.Name,
                TypeCurrencyId = q.TypeCurrencyId,
                DraftAmount = q.DraftAmount,
                Rate = q.Rate,
                Rent = q.Rent,
                Type = q.Type,
                DepositAmount = q.DepositAmount,
                DepositCurrency = q.DepositCurrency?.Name,
                CustomerId = q.CustomerId,
                RemainAmount = 0,
                Customer = q.Customer?.FirstName + " " + q.Customer?.LastName,
                RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                Date = q.Date != null ? (DateTime.Parse(q.Date.ToString())).ToPersian() : "",
            }).ToList();


            _data = new List<DraftViewModels>();
            _dataSummery = new List<SummeryDraftViewModels>();

            var groupedw = _RowedData.GroupBy(x => x.TypeCurrency);

            foreach (var item in groupedw)
            {
                double totalRemainAmount = 0;
                double TotalRent = 0;
                string CurrenyName = "";

                foreach (var havale in item)
                {
                    CurrenyName = havale.TypeCurrency;
                    totalRemainAmount += havale.DraftAmount;
                    TotalRent += havale.Rent;
                    havale.RemainAmount = totalRemainAmount;
                    _data.Add(havale);
                }

                var cdata = new SummeryDraftViewModels();
                cdata.CurrenyName = CurrenyName;
                cdata.Total = totalRemainAmount;
                cdata.TotalRent = TotalRent;

                _dataSummery.Add(cdata);
            }


            _data = _data.OrderBy(x => x.Radif).ToList();
      
           var data = _data;
    

   
          var  data2 = _dataSummery;
         

            ////////////////////////////////////////////
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "DraftsListt.mrt");
            report.RegData("myData", data);
            report.RegData("myData2", data2);
            report.RegData("basedata", basedata);
            report.Render();
            report.Show();

        }

        private void gridDrafts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.gridDrafts.CurrentRow.Selected = true;
                e.Handled = true;

                var rowIndex = gridDrafts.SelectedRows[0].Index;
                var draft = _data.ElementAt(rowIndex);

                if (draft.Type == 0)
                {
                    var targetFrm = new shippingOrderFrm(draft.Id);
                    targetFrm.ShowDialog();
                    LoadData();
                }
                else
                {
                    var targetFrm = new WarrantsPayableFrm(draft.Id);
                    targetFrm.ShowDialog();
                    LoadData();

                }
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                this.gridDrafts.CurrentRow.Selected = true;
                e.Handled = true;

                var rowIndex = gridDrafts.SelectedRows[0].Index;
                var draft = _data.ElementAt(rowIndex);
                if (draft.CustomerId == AppSetting.NotRunnedDraftsId)
                {
                    var FrmBalance = new ExecuteDaraftFrm(draft.Id);
                    FrmBalance.ShowDialog();
                    LoadData();
                }
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}