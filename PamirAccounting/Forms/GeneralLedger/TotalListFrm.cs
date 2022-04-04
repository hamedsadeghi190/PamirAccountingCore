﻿using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Models;
using PamirAccounting.Services;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.GeneralLedger
{
    public partial class TotalListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        private List<TransactionsGroupModel> _dataListTotal;
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Groups = new List<ComboBoxModel>();
        private int? _CurrenyId;
        private int? _GroupId;

        public TotalListFrm()
        {

            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }


        public TotalListFrm(int? CurrenyId, int? GroupId)
        {
            _CurrenyId = CurrenyId;
            _GroupId = GroupId;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void LoadData()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw(_CurrenyId, _GroupId);
            GellAll(tmpDataList);
        }



        private void TotalLiatFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void TotalLiatFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void GellAll(List<TransactionModel> _list)
        {
            var tmpDataList = _list;
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => new { x.CurrenyId });
            _dataListTotal = new List<TransactionsGroupModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            int row = 1;
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0, WithDraw = 0, Deposit = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    WithDraw = item.WithdrawAmount.Value;
                    Deposit = item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.FullName = item.FullName;

                    curenncySummery.Phone = item.Phone;
                    curenncySummery.Mobile = item.Mobile;
                    item.RemainigAmount = Deposit - WithDraw;

                    _dataList.Add(item);
                }

                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "طلبکار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
            _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
            foreach (var item in _GroupedDataList)
            {
                item.RowId = row++;
            }
            gridCreditor.AutoGenerateColumns = false;
            gridCreditor.DataSource = _GroupedDataList;
            _GroupedDataList = new List<TransactionsGroupModel>();

            foreach (var currency in groupedCurrency)
            {
                var curenncySummery2 = new TransactionsGroupModel();
                long totalWithDraw2 = 0, totalDeposit2 = 0, remaining2 = 0;
                curenncySummery2.Description = "جمع";
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw2 += item.WithdrawAmount.Value;
                    totalDeposit2 += item.DepositAmount.Value;
                    curenncySummery2.CurrenyName = item.CurrenyName;
                    item.RemainigAmount = totalDeposit2 - totalWithDraw2;
                    _dataList.Add(item);
                }
                curenncySummery2.TotalDepositAmount = totalDeposit2;
                curenncySummery2.TotalWithdrawAmount = totalWithDraw2;
                remaining2 = totalDeposit2 - totalWithDraw2;
                curenncySummery2.RemainigAmount = remaining2;
                curenncySummery2.Status = (remaining2 == 0) ? "" : (remaining2 > 0) ? "طلبکار" : "بدهکار";
                _dataListTotal.Add(curenncySummery2);
            }
            _dataList = _dataList.OrderBy(x => x.RowId).ToList();
            grdTotals.AutoGenerateColumns = false;
            grdTotals.DataSource = _dataListTotal;

        }



        private List<TransactionsGroupModel> TotalPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllTotal(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => new { x.CurrenyId });
            _dataListTotal = new List<TransactionsGroupModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            int row = 1;
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0, WithDraw = 0, Deposit = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    WithDraw = item.WithdrawAmount.Value;
                    Deposit = item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.FullName = item.FullName;

                    curenncySummery.Phone = item.Phone;
                    curenncySummery.Mobile = item.Mobile;
                    item.RemainigAmount = Deposit - WithDraw;

                    _dataList.Add(item);
                }

                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "طلبکار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
            _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
            foreach (var item in _GroupedDataList)
            {
                item.RowId = row++;
            }

            return _GroupedDataList;
        }

        private List<TransactionsGroupModel> TotalSummeryPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllTotal(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            var groupedCurrency = tmpDataList.GroupBy(x => new { x.CurrenyId });
            _dataListTotal = new List<TransactionsGroupModel>();
            int row = 1;

            foreach (var currency in groupedCurrency)
            {
                var curenncySummery2 = new TransactionsGroupModel();
                long totalWithDraw2 = 0, totalDeposit2 = 0, remaining2 = 0;
                curenncySummery2.Description = "جمع";
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw2 += item.WithdrawAmount.Value;
                    totalDeposit2 += item.DepositAmount.Value;
                    curenncySummery2.CurrenyName = item.CurrenyName;
                    item.RemainigAmount = totalDeposit2 - totalWithDraw2;
                    _dataList.Add(item);
                }
                curenncySummery2.TotalDepositAmount = totalDeposit2;
                curenncySummery2.TotalWithdrawAmount = totalWithDraw2;
                remaining2 = totalDeposit2 - totalWithDraw2;
                curenncySummery2.RemainigAmount = remaining2;
                curenncySummery2.Status = (remaining2 == 0) ? "" : (remaining2 > 0) ? "طلبکار" : "بدهکار";
                _dataListTotal.Add(curenncySummery2);
            }
            _dataList = _dataList.OrderBy(x => x.RowId).ToList();
            return _dataListTotal;
        }


        private void groupBoxViewAccountCustomer_Enter(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var data = TotalPrint();
            var data2 = TotalSummeryPrint();
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "TotalList.mrt");
            report.RegData("myData", data);
            report.RegData("myData2", data2);
            report.RegData("basedata", basedata);
            //report.Design();
            report.Render();
            report.Show();
        }

        private void grdTotals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var tmpDataList = unitOfWork.TransactionServices.GetAllTotalCustomers(txtSearch.Text);
                GellAll(tmpDataList);
            }
            else
            {
                LoadData();
            }
        }
    }
}