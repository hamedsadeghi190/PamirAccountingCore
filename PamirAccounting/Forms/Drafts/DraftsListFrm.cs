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
            //DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();

            //HeaderStyle.BackColor = Color.Red;
            //for (int i = 0; i < 4; i++)
            //{
            //    gridDrafts.Columns[i].HeaderCell.Style = HeaderStyle;
            //}
            //foreach (DataGridViewColumn DataGridViewColumn1 in gridDrafts.Columns)
            //{
            //    DataGridViewColumn1.DefaultCellStyle.Font = new Font("IRANSansMobile(FaNum)", 12);
            //}
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
            var tmpData = unitOfWork.DraftsServices.FindAll(x => x.AgencyId == (int)cmbAgency.SelectedValue
                                                            && x.Type == (int)(cmbType.SelectedValue))
                .OrderBy(x => x.Date)
                .Include(x => x.DepositCurrency)
                .Include(x => x.TypeCurrency)
                .Include(x => x.Customer)
                .ToList();

            var rowId = 0;
            _data = tmpData.Select(q => new DraftViewModels()
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
                DraftAmount = q.DraftAmount,
                Rate = q.Rate,
                Rent = q.Rent,
                DepositAmount = q.DepositAmount,
                DepositCurrency = q.DepositCurrency?.Name,
                CustomerId = q.CustomerId,
                Customer = q.Customer.FirstName + " " + q.Customer.LastName,
                RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                Date = q.Date != null ? (DateTime.Parse(q.Date.ToString())).ToPersian() : "",
            }).ToList();


            gridDrafts.DataSource = null;
            gridDrafts.DataSource = _data;
            gridDrafts.Refresh();

            _dataSummery = new List<SummeryDraftViewModels>();
            var cdata = new SummeryDraftViewModels();
            foreach (var item in _data)
            {
                cdata.CurrenyName = item.DepositCurrency;
                cdata.Total += (item.DepositAmount.HasValue) ? item.DepositAmount.Value : 0;
                cdata.TotalRent += item.Rent;
            }

            grdTotals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _dataSummery.Add(cdata);
            grdTotals.DataSource = null;
            grdTotals.DataSource = _dataSummery;

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
            if (e.ColumnIndex == gridDrafts.Columns["btnExecute"].Index && e.RowIndex >= 0)
            {
                var draft = _data.ElementAt(e.RowIndex);
                if (draft.CustomerId == AppSetting.NotRunnedDraftsId)
                {
                    var FrmBalance = new ExecuteDaraftFrm(draft.Id);
                    FrmBalance.ShowDialog();
                    LoadData();
                }
                else
                {
                    // MessageBox.Show("حواله قبلا اجرا شده است.");
                }
            }


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
            var tmpData = unitOfWork.DraftsServices.FindAll(x => x.AgencyId == (int)cmbAgency.SelectedValue
              && x.Type == (int)(cmbType.SelectedValue))
              .OrderBy(x => x.Date)
              .Include(x => x.DepositCurrency)
              .Include(x => x.TypeCurrency)
              .Include(x => x.Customer)
              .ToList();
            var rowId = 0;
            _data = tmpData.Select(q => new DraftViewModels()
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
                DraftAmount = q.DraftAmount,
                Rate = q.Rate,
                Rent = q.Rent,
                DepositAmount = q.DepositAmount,
                DepositCurrency = q.DepositCurrency?.Name,
                CustomerId = q.CustomerId,
                Customer = q.Customer.FirstName + " " + q.Customer.LastName,
                RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                Date = q.Date != null ? (DateTime.Parse(q.Date.ToString())).ToPersian() : "",
            }).ToList();
            var data = _data;

            /////////////////////////////////
            _dataSummery = new List<SummeryDraftViewModels>();
            var cdata = new SummeryDraftViewModels();
            foreach (var item in _data)
            {
                cdata.CurrenyName = item.DepositCurrency;
                cdata.Total += (item.DepositAmount.HasValue) ? item.DepositAmount.Value : 0;
                cdata.TotalRent += item.Rent;
            }
            grdTotals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataSummery.Add(cdata);
            var data2 = _dataSummery;
            ////////////////////////////////////////////
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "DraftsListt.mrt");
            report.RegData("myData", data);
            report.RegData("myData2", data2);
            report.RegData("basedata", basedata);
            report.Design();
            report.Render();
            report.Show();
        }

      
    }
}