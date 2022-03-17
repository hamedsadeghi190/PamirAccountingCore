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
        private List<SummeryDraftViewModels> _dataSummery;


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

            int radif = 0;
            _data = null;
            _data = tmpdata
                 .Select(q => new DraftViewModels()
                 {
                     Index = ++radif,
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
                     ConvertedCurrency = q.ConvertedCurrency != null ? q.ConvertedCurrency.Name : "",
                     DepositAmount = q.DepositAmount,
                     DepositCurrency = q.DepositCurrency.Name,
                     CustomerId = q.CustomerId,
                     Customer = q.Customer.FirstName + " " + q.Customer.LastName,
                     RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                     ConvertedDate = q.ConvertedDate != null ? (DateTime.Parse(q.ConvertedDate.ToString())).ToPersian() : "",
                     Date = (DateTime.Parse(q.Date.ToString())).ToPersian(),

                 })
                .ToList();


            gridDrafts.RowsDefaultCellStyle.BackColor = Color.White;

            gridDrafts.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
            gridDrafts.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            gridDrafts.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            gridDrafts.DefaultCellStyle.SelectionForeColor = Color.White;

            gridDrafts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridDrafts.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridDrafts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


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
            _dataSummery.Add(cdata);

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
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

            }

        }
    }
}