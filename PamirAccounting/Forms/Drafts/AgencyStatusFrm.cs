using Microsoft.EntityFrameworkCore;

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
using static PamirAccounting.Commons.Enums.Settings;
using static PamirAccounting.UI.Forms.Customers.ViewCustomerAccountFrm;

namespace PamirAccounting.Forms.Drafts
{
    public partial class AgencyStatusFrm : DevExpress.XtraEditors.XtraForm
    {
        private int AgencyID { get; set; }
        private UnitOfWork unitOfWork;
        private List<DraftViewModels> _data;
        private List<SummeryDraftStatusViewModels> _dataSummery;
        private List<Domains.Draft> tmpdata;
        private List<DraftViewModels> data;
        private List<SummeryDraftStatusViewModels> data2;
        public AgencyStatusFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        public AgencyStatusFrm(int agencyID)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            AgencyID = agencyID;

        }



        private void AgencyStatusFrm_Load(object sender, EventArgs e)
        {
            gridDrafts.AutoGenerateColumns = false;
            grdTotals.AutoGenerateColumns = false;

            var agency = unitOfWork.Agencies.FindAll(x => x.Id == AgencyID).Include(x => x.Curreny).FirstOrDefault();
            LblAgencyName.Text = agency.Name;
            LblCurrencyName.Text = agency.Curreny.Name;

            LoadData();
            gridDrafts.Focus();
        }

        private void LoadData()
        {
            tmpdata = null;
            unitOfWork = new UnitOfWork();

            tmpdata = unitOfWork.DraftsServices.FindAll(x => x.AgencyId == AgencyID)
                                  .Include(y => y.TypeCurrency)
                                  .Include(f => f.DepositCurrency)
                                  .Include(f => f.ConvertedCurrency)
                                  .Include(f => f.RelatedDraft)
                                  .ThenInclude(x => x.Agency)
                                  .Include(f => f.Customer)
                                  .ToList();

            var rowId = 1;
            var _RowedData = tmpdata.Select(q => new DraftViewModels()
            {
                Index = rowId++,
                Id = q.Id,
                Type = q.Type,
                Number = q.Number,
                OtherNumber = q.OtherNumber,
                Sender = q.Sender,
                Reciver = q.Reciver,
                FatherName = q.FatherName,
                PayPlace = q.PayPlace,
                Description = q.Description,
                ExtraDescription = q.ExtraDescription,
                TypeCurrency = q.TypeCurrency.Name,
                DraftAmount = q.DraftAmount,
                Rate = q.Rate,
                Rent = (double)q.AgencyRent,
                ConvertedRate = q.ConvertedRate,
                ConvertedAmount = q.ConvertedAmount,
                ConvertedCurrencyId = q.ConvertedCurrencyId,
                TypeCurrencyId = q.TypeCurrencyId,
                ConvertedCurrency = q.ConvertedCurrency != null ? q.ConvertedCurrency.Name : "",
                DepositAmount = q.DepositAmount,
                DepositCurrency = q.DepositCurrency.Name,
                CustomerId = q.CustomerId,
                Customer = (q.CustomerId != null) ? q.Customer.FirstName + " " + q.Customer.LastName : q.RelatedDraft.Agency.Name,
                RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                ConvertedDate = q.ConvertedDate != null ? (DateTime.Parse(q.ConvertedDate.ToString())).ToPersian() : "",
                Date = (DateTime.Parse(q.Date.ToString())).ToPersian(),

            }).ToList();


            _data = new List<DraftViewModels>();
            _dataSummery = new List<SummeryDraftStatusViewModels>();

            var convertedDrafts = _RowedData.Where(x => x.ConvertedAmount.HasValue == true).ToList();
            var notConvertedDrafts = _RowedData.Where(x => x.ConvertedAmount.HasValue == false).ToList();

            var groupedConvertedDrafts = convertedDrafts.GroupBy(x => x.ConvertedCurrencyId);

            foreach (var item in groupedConvertedDrafts)
            {
                double totalRemainAmount = 0;
                double TotalRent = 0;
                string CurrenyName = "";

                foreach (var havale in item.OrderBy(x => x.Index).ToList())
                {

                    if (havale.ConvertedAmount.HasValue == true)
                    {
                        CurrenyName = havale.DepositCurrency;
                        if (havale.Type == 0)
                        {
                            totalRemainAmount += havale.ConvertedAmount.Value;
                        }
                        else
                        {
                            totalRemainAmount -= havale.ConvertedAmount.Value;
                        }
                    }

                    TotalRent += havale.Rent;
                    havale.RemainAmount = totalRemainAmount;

                    if (totalRemainAmount > 0)
                    {
                        havale.Status = "طلبکار";
                    }
                    else if (totalRemainAmount < 0)
                    {
                        havale.Status = "بدهکار";
                    }

                    _data.Add(havale);
                }
            }


            foreach (var item in notConvertedDrafts)
            {
                _data.Add(item);
            }
            _data = _data.OrderBy(x => x.Index).ToList();


            gridDrafts.DataSource = null;
            gridDrafts.Update();
            gridDrafts.Refresh();

            gridDrafts.DataSource = _data;
            data = _data;
            gridDrafts.Update();
            gridDrafts.Refresh();

            var _dataConverted = _data.Where(x => x.ConvertedAmount.HasValue == true).ToList();
            var _dataNotConverted = _data.Where(x => x.ConvertedAmount.HasValue == false).ToList();

            _dataSummery = new List<SummeryDraftStatusViewModels>();

            var groupedConverted = _dataConverted.GroupBy(x => x.ConvertedCurrencyId);

            foreach (var item in groupedConverted)
            {
                double TotalDiposit = 0;
                double TotalWithdraw = 0;
                string CurrenyName = "";

                foreach (var currentDrafts in item)
                {
                    CurrenyName = currentDrafts.ConvertedCurrency;

                    if (currentDrafts.Type == 0)
                    {
                        TotalDiposit += currentDrafts.ConvertedAmount.Value;
                    }
                    else
                    {
                        TotalWithdraw += currentDrafts.ConvertedAmount.Value;
                    }
                }

                var cdata = new SummeryDraftStatusViewModels();
                cdata.CurrenyName = CurrenyName;
                cdata.TotalDiposit = TotalDiposit;
                cdata.TotalWithdraw = TotalWithdraw;
                cdata.RemainAmount = TotalDiposit - TotalWithdraw;

                if (cdata.RemainAmount > 0)
                {
                    cdata.Status = "طلبکار";
                }
                else if (cdata.RemainAmount < 0)
                {
                    cdata.Status = "بدهکار";
                }
                _dataSummery.Add(cdata);
            }

            var groupedNotConverted = _dataNotConverted.GroupBy(x => x.TypeCurrencyId);

            foreach (var item in groupedNotConverted)
            {
                double TotalDiposit = 0;
                double TotalWithdraw = 0;
                string CurrenyName = "";

                foreach (var currentDrafts in item)
                {
                    CurrenyName = currentDrafts.TypeCurrency + " - نرخ نشده";

                    if (currentDrafts.Type == 0)
                    {
                        TotalDiposit += currentDrafts.DraftAmount;
                    }
                    else
                    {
                        TotalWithdraw += currentDrafts.DraftAmount;
                    }
                }
                SummeryDraftStatusViewModels cdata;

                var tmpSummery = _dataSummery.FirstOrDefault(x => x.CurrenyId == item.Key);

                if (tmpSummery == null)
                {
                    cdata = new SummeryDraftStatusViewModels();
                    cdata.CurrenyName = CurrenyName;
                    cdata.TotalDiposit = TotalDiposit;
                    cdata.TotalWithdraw = TotalWithdraw;
                    cdata.RemainAmount = TotalDiposit - TotalWithdraw;

                    if (cdata.RemainAmount > 0)
                    {
                        cdata.Status = "طلبکار";
                    }
                    else if (cdata.RemainAmount < 0)
                    {
                        cdata.Status = "بدهکار";
                    }
                    _dataSummery.Add(cdata);
                }
                else
                {

                    tmpSummery.CurrenyName = CurrenyName;
                    tmpSummery.TotalDiposit += TotalDiposit;
                    tmpSummery.TotalWithdraw += TotalWithdraw;
                    tmpSummery.RemainAmount = tmpSummery.TotalDiposit - tmpSummery.TotalWithdraw;

                    if (tmpSummery.RemainAmount > 0)
                    {
                        tmpSummery.Status = "طلبکار";
                    }
                    else if (tmpSummery.RemainAmount < 0)
                    {
                        tmpSummery.Status = "بدهکار";
                    }
                }

            }

            grdTotals.DataSource = null;
            grdTotals.DataSource = _dataSummery;
            data2 = _dataSummery;
            grdTotals.Refresh();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridDrafts.Columns["Verify"].Index && e.RowIndex >= 0)
            {
                _data.ElementAt(e.RowIndex).Verify = !_data.ElementAt(e.RowIndex).Verify;
            }

        }

        private void gridDrafts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in gridDrafts.Rows)
            {
                if (Convert.ToDouble(row.Cells["ConvertedAmount"].Value) <= 0)
                {
                    row.Cells["ConvertedAmount"].Style.BackColor = Color.Red;
                }
                var data = _data.ElementAt(row.Index);
                if (data.Type == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            LoadData(); var agency = unitOfWork.Agencies.FindAll(x => x.Id == AgencyID).Include(x => x.Curreny).FirstOrDefault();
            LblAgencyName.Text = agency.Name;
            LblCurrencyName.Text = agency.Curreny.Name;
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var basedata = new reportbaseDAta() { Date = PersianDate ,CurrencyName=agency.Curreny.Name,AgencyName=agency.Name };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "AgencyStatusList.mrt");
            report.RegData("myData", data);
            report.RegData("myData2", data2);
            report.RegData("basedata", basedata);
            report.Render();
            report.Show();
           // report.Design();
        }

        private void gridDrafts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var RoleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Balance && x.UserId == CurrentUser.UserID);
                if (RoleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;
                }
                this.gridDrafts.CurrentRow.Selected = true;
                e.Handled = true;

                var rowIndex = gridDrafts.SelectedRows[0].Index;
                var draft = _data.ElementAt(rowIndex);
                if (RoleId != null || adminRole != null)
                {
                    var FrmBalance = new CurrencyExchangeFrm(draft.Id);
                    FrmBalance.ShowDialog();
                    LoadData();
                }
            }
        }
    }
}