using Microsoft.EntityFrameworkCore;
using PamirAccounting.Models.ViewModels;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Drafts
{
    public partial class AgencyStatusFrm : DevExpress.XtraEditors.XtraForm
    {
        private int AgencyID { get; set; }
        private UnitOfWork unitOfWork;
        private List<DraftViewModels> _data;
        private List<SummeryDraftStatusViewModels> _dataSummery;


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
        }

        private void LoadData()
        {

            var tmpdata = unitOfWork.DraftsServices.FindAll(x => x.AgencyId == AgencyID)
                                    .Include(y => y.TypeCurrency)
                                    .Include(f => f.DepositCurrency)
                                    .Include(f => f.ConvertedCurrency)
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
                Rent = q.Rent,
                ConvertedRate = q.ConvertedRate,
                ConvertedAmount = q.ConvertedAmount,
                ConvertedCurrencyId = q.ConvertedCurrencyId,
                TypeCurrencyId = q.TypeCurrencyId,
                ConvertedCurrency = q.ConvertedCurrency != null ? q.ConvertedCurrency.Name : "",
                DepositAmount = q.DepositAmount,
                DepositCurrency = q.DepositCurrency.Name,
                CustomerId = q.CustomerId,
                Customer = q.Customer.FirstName + " " + q.Customer.LastName,
                RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                ConvertedDate = q.ConvertedDate != null ? (DateTime.Parse(q.ConvertedDate.ToString())).ToPersian() : "",
                Date = (DateTime.Parse(q.Date.ToString())).ToPersian(),

            }).ToList();


            _data = new List<DraftViewModels>();
            _dataSummery = new List<SummeryDraftStatusViewModels>();

            var _dataConverted1 = _RowedData.Where(x => x.ConvertedAmount.HasValue == true).ToList();
            var _dataNotConverted1 = _RowedData.Where(x => x.ConvertedAmount.HasValue == false).ToList();

            var groupedw = _dataConverted1.GroupBy(x => x.ConvertedCurrencyId);

            foreach (var item in groupedw)
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


            foreach (var item in _dataNotConverted1)
            {
                _RowedData.Add(item);
            }
            _data = _data.OrderBy(x => x.Index).ToList();
            gridDrafts.DataSource = null;
            gridDrafts.DataSource = _data;
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
                    CurrenyName = currentDrafts.TypeCurrency;

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
            grdTotals.Refresh();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridDrafts.Columns["btnConvert"].Index && e.RowIndex >= 0)
            {
                var draft = _data.ElementAt(e.RowIndex);

                var FrmBalance = new CurrencyExchangeFrm(draft.Id);
                FrmBalance.ShowDialog();
                LoadData();
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
    }
}