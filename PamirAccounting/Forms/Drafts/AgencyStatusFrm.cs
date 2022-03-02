using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Models.ViewModels;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btncurrencyexchange_Click(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var AgencyStatusSearchFrm = new AgencyStatusSearchFrm();
            AgencyStatusSearchFrm.ShowDialog();
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
        }

        private void AgencyStatusFrm_Load(object sender, EventArgs e)
        {
            gridDrafts.AutoGenerateColumns = false;
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
            _data = tmpdata
                 .Select(q => new DraftViewModels()
                 {
                     Id = q.Id,
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
                     ConvertedCurrency =q.ConvertedCurrency !=null ? q.ConvertedCurrency.Name:"",
                     DepositAmount = q.DepositAmount,
                     DepositCurrency = q.DepositCurrency.Name,
                     Customer = q.Customer.FirstName + " " + q.Customer.LastName,
                     RunningDate = q.RunningDate != null ? (DateTime.Parse(q.RunningDate.ToString())).ToPersian() : "",
                     ConvertedDate = q.ConvertedDate != null ? (DateTime.Parse(q.ConvertedDate.ToString())).ToPersian() : "",
                     Date = (DateTime.Parse(q.Date.ToString())).ToPersian(),

                 })
                .ToList();

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
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }
    }
}