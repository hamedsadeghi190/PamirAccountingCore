using DevExpress.XtraEditors;
using LinqKit;
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

namespace PamirAccounting.Forms.GeneralLedger
{
    public partial class TotalBalanceFrm : XtraForm
    {
        private UnitOfWork unitOfWork;
        public TotalBalanceFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void TotalBalanceFrm_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void LoadData()
        {
            var predicate = PredicateBuilder.New<Domains.Draft>(true);


            var drafts = unitOfWork.DraftsServices.FindAll()
                .OrderBy(x => x.Date)
                .Include(x => x.DepositCurrency)
                .Include(x => x.TypeCurrency)
                .Include(x => x.Customer)
                .ToList();

            var rowId = 1;
            var _RowedData = drafts.Select(q => new DraftViewModels()
            {
                Index = rowId++,
                Id = q.Id,
                Type = q.Type,
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
            }).ToList();



            var convertedDrafts = _RowedData.Where(x => x.ConvertedAmount.HasValue == true).ToList();
            var notConvertedDrafts = _RowedData.Where(x => x.ConvertedAmount.HasValue == false).ToList();

            var groupedConvertedDrafts = convertedDrafts.GroupBy(x => x.ConvertedCurrencyId);

            //foreach (var item in groupedConvertedDrafts)
            //{
            //    double totalRemainAmount = 0;
            //    double TotalRent = 0;
            //    string CurrenyName = "";

            //    foreach (var havale in item.OrderBy(x => x.Index).ToList())
            //    {

            //        if (havale.ConvertedAmount.HasValue == true)
            //        {
            //            CurrenyName = havale.DepositCurrency;
            //            if (havale.Type == 0)
            //            {
            //                totalRemainAmount += havale.ConvertedAmount.Value;
            //            }
            //            else
            //            {
            //                totalRemainAmount -= havale.ConvertedAmount.Value;
            //            }
            //        }

            //        TotalRent += havale.Rent;
            //        havale.RemainAmount = totalRemainAmount;

            //        if (totalRemainAmount > 0)
            //        {
            //            havale.Status = "طلبکار";
            //        }
            //        else if (totalRemainAmount < 0)
            //        {
            //            havale.Status = "بدهکار";
            //        }

            //        _data.Add(havale);
            //    }
            //}


            //foreach (var item in notConvertedDrafts)
            //{
            //    _data.Add(item);
            //}
            //_data = _data.OrderBy(x => x.Index).ToList();
        }

        private void btnStatusList_Click(object sender, EventArgs e)
        {
            var Frm = new StatusListFrm();
            Frm.ShowDialog();
        }

        private void TotalBalanceFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}