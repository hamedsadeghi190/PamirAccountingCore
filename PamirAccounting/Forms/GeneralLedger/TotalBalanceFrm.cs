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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.GeneralLedger
{
    public partial class TotalBalanceFrm : XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<DraftSummeryForBalanceViewModels> _data = new List<DraftSummeryForBalanceViewModels>();
        private List<DraftSummeryForBalanceViewModels> _dataRated = new List<DraftSummeryForBalanceViewModels>();
        public TotalBalanceFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            txtDate.Text = DateTime.Now.ToFarsiFormat();
        }


        private void TotalBalanceFrm_Load(object sender, EventArgs e)
        {
            LoadData(null);
        }

        private void LoadData(DateTime? date)
        {
            var predicate = PredicateBuilder.New<Domains.Draft>(true);
            var transactionPredicate = PredicateBuilder.New<Domains.Transaction>(true);

            if (date != null)
            {
                predicate = predicate.And(x => x.Date <= date);
            }

            var drafts = unitOfWork.DraftsServices.FindAll(predicate)
                .OrderBy(x => x.Date)
                .Include(x => x.DepositCurrency)
                .Include(x => x.TypeCurrency)
                .Include(x => x.Customer)
                .Include(x => x.Agency)
                .ToList();

            var rowId = 1;
            var _RowedData = drafts.Select(q => new DraftForBalanceViewModels()
            {
                Index = rowId++,
                Id = q.Id,
                AgencyId = q.AgencyId,
                AgencyName = q.Agency.Name,
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


            var groupedDraftsByAgency = _RowedData.GroupBy(x => x.AgencyId);

            foreach (var agencyDrafts in groupedDraftsByAgency)
            {


                var convertedDrafts = agencyDrafts.OrderBy(x => x.Index).ToList().Where(x => x.ConvertedAmount.HasValue == true).ToList();
                var groupedDraftsByCurrencyId = convertedDrafts.GroupBy(x => x.ConvertedCurrencyId);

                foreach (var gdrafts in groupedDraftsByCurrencyId)
                {
                    double bedehi = 0;
                    double talakbari = 0;
                    string CurrenyName = "";
                    int CurrenyId = 0;
                    string AgencyName = "";


                    foreach (var havale in gdrafts)
                    {

                        if (havale.ConvertedAmount.HasValue == true)
                        {
                            CurrenyName = havale.ConvertedCurrency;
                            CurrenyId = havale.ConvertedCurrencyId.Value;
                            AgencyName = havale.AgencyName;

                            if (havale.Type == 0)
                            {
                                talakbari += havale.ConvertedAmount.Value;
                            }
                            else
                            {
                                bedehi += havale.ConvertedAmount.Value;
                            }
                        }
                    }

                    var newBedehi = new DraftSummeryForBalanceViewModels();
                    var newTalabkari = new DraftSummeryForBalanceViewModels();
                    newBedehi.CurrenyName = CurrenyName;
                    newTalabkari.CurrenyName = CurrenyName;
                    newTalabkari.CurrenyId = CurrenyId;
                    newBedehi.CurrenyId = CurrenyId;

                    if (talakbari > 0)
                    {

                        newTalabkari.Description = "طلبکاری" + " نمایندگی " + AgencyName;
                        newTalabkari.Talabkari = talakbari;
                        _data.Add(newTalabkari);
                    }
                    if (bedehi > 0)
                    {
                        newBedehi.Description = "بدهکاری" + " نمایندگی " + AgencyName;
                        newBedehi.Bedehi = bedehi * (-1);
                        _data.Add(newBedehi);
                    }

                }
            }
            if (date != null)
            {
                transactionPredicate = transactionPredicate.And(x => x.Date <= date);
            }

            var alltransactions = unitOfWork.Transactions.FindAll(transactionPredicate).Include(x => x.Curreny).ToList();
            var groupedTransaction = alltransactions.GroupBy(x => x.CurrenyId);

            foreach (var currenyTransactions in groupedTransaction)

            {
                double bedehi = 0;
                double talakbari = 0;
                string CurrenyName = "";
                int CurrenyId = 0;
                foreach (var transaction in currenyTransactions)
                {
                    CurrenyName = transaction.Curreny.Name;
                    CurrenyId = transaction.CurrenyId.Value;


                    if (transaction.DepositAmount.HasValue)
                    {
                        talakbari += transaction.DepositAmount.Value;

                    }

                    if (transaction.WithdrawAmount.HasValue)
                    {
                        bedehi += transaction.WithdrawAmount.Value;
                    }
                }

                var newBedehi = new DraftSummeryForBalanceViewModels();
                var newTalabkari = new DraftSummeryForBalanceViewModels();
                newBedehi.CurrenyName = CurrenyName;
                newTalabkari.CurrenyName = CurrenyName;
                newBedehi.CurrenyId = CurrenyId;
                newTalabkari.CurrenyId = CurrenyId;

                if (talakbari > 0)
                {

                    newTalabkari.Description = "جمع طلبکاری" + " - " + CurrenyName;
                    newTalabkari.Talabkari = talakbari;
                    _data.Add(newTalabkari);
                }
                if (bedehi > 0)
                {
                    newBedehi.Description = "جمع بدهکاری" + " - " + CurrenyName;
                    newBedehi.Bedehi = bedehi * (-1);
                    _data.Add(newBedehi);
                }
            }
            double ramainDollar = 0;
            double tomanRate = 0;

            var groupedData = _data.GroupBy(x => x.CurrenyId);
            foreach (var currenyGroup in groupedData)
            {
                var newSummery = new DraftSummeryForBalanceViewModels();
                double bedehi = 0;
                double talakbari = 0;

                foreach (var item in currenyGroup)
                {
                    newSummery.CurrenyId = item.CurrenyId;
                    newSummery.CurrenyName = item.CurrenyName;
                    newSummery.Description = "جمع";
                    bedehi += item.Bedehi;
                    talakbari += item.Talabkari;
                }
                newSummery.Talabkari = talakbari;
                newSummery.Bedehi = bedehi;
                newSummery.Remain = talakbari - (bedehi * -1);

                var curreny = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == newSummery.CurrenyId);
                if (curreny != null)
                {
                    if (curreny.Name == "تومان")
                    {
                        tomanRate = curreny.BaseRate.Value;
                    }
                    if (curreny.Action == 1)
                    {
                        newSummery.RemainConverted = newSummery.Remain * curreny.BaseRate.Value;
                    }
                    else
                    {
                        newSummery.RemainConverted = newSummery.Remain / curreny.BaseRate.Value;
                    }
                    ramainDollar += newSummery.RemainConverted;
                }

                _dataRated.Add(newSummery);
            }
            _dataRated.Add(new DraftSummeryForBalanceViewModels()
            {
                Talabkari = 0,
                Bedehi = 0,
                RemainConverted = 0

            });

            _dataRated.Add(new DraftSummeryForBalanceViewModels()
            {
                Talabkari = 0,
                Bedehi = 0,
                RemainConverted = ramainDollar,
                CurrenyName = ramainDollar > 0 ? "مثبت" : "منفی",
                Description = "باقیمانده دلار"
            });

            _dataRated.Add(new DraftSummeryForBalanceViewModels()
            {
                Talabkari = 0,
                Bedehi = 0,
                RemainConverted = ramainDollar * tomanRate,
                CurrenyName = ramainDollar > 0 ? "مثبت" : "منفی",
                Description = "باقیمانده "
            });

            grdTotals.AutoGenerateColumns = false;
            grdTotals.DataSource = _dataRated;
            grdTotals.Refresh();

            gridBlance.AutoGenerateColumns = false;
            gridBlance.DataSource = _data;
            gridBlance.Refresh();
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

        private void txtDate_Leave(object sender, EventArgs e)
        {
            Tools.CheckDate(txtDate);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PersianCalendar p = new PersianCalendar();
            var dDate1 = txtDate.Text.Replace("_", "").Split('/');
            var startDate = p.ToDateTime(int.Parse(dDate1[0]), int.Parse(dDate1[1]), int.Parse(dDate1[2]), 0, 0, 0, 0);
            LoadData(startDate);
        }
    }
}