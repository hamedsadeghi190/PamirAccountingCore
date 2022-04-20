using DevExpress.XtraEditors;
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

            if (e.KeyCode == Keys.F2)
            {
                txtSearch.Select();
                txtSearch.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();




            if (e.KeyCode == Keys.F5)
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
                // report.Design();
                report.Render();
                report.Show();

            }
        }

        private void GellAll(List<TransactionModel> _list)
        {
            var tmpDataList = _list;
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => x.CurrenyId);
            _dataListTotal = new List<TransactionsGroupModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0, WithDraw = 0, Deposit = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.FullName = item.FullName;
                    curenncySummery.RowId = item.RowId;
                    curenncySummery.Phone = item.Phone;
                    curenncySummery.Mobile = item.Mobile;
                    curenncySummery.CurrenyId = item.CurrenyId;
                    item.RemainigAmount = Deposit - WithDraw;
                    curenncySummery.WithdrawAmount = item.WithdrawAmount;
                    curenncySummery.DepositAmount = item.DepositAmount;


                }

                remaining = totalDeposit - totalWithDraw;
                if (remaining > 0)
                {
                    curenncySummery.Status = "طلبکار";
                }

                else if (remaining < 0)
                {
                    curenncySummery.Status = "بدهکار";
                }

                else
                {
                    curenncySummery.Status = "";
                }
                curenncySummery.Status = curenncySummery.Status;
                curenncySummery.RemainigAmount = remaining;
                _GroupedDataList.Add(curenncySummery);


            }

            _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
            int row = 1;
            foreach (var item in _GroupedDataList)
            {
                item.RowId = row++;
            }
            gridCreditor.AutoGenerateColumns = false;
            gridCreditor.DataSource = _GroupedDataList;
            var tmpGroup = _GroupedDataList.GroupBy(x => x.CurrenyId);
            //////////////////////////////////////////////////////
            var xx = _GroupedDataList.GroupBy(x => x.CurrenyId);
            foreach (var currency in xx)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0,remaining = 0;

                foreach (var item in currency)
                {
                    remaining += item.RemainigAmount;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    if (item.RemainigAmount < 0)
                    {
                        totalWithDraw += item.RemainigAmount;
                    }
                    if (item.RemainigAmount > 0)
                    {
                        totalDeposit += item.RemainigAmount;
                    }
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                if (remaining > 0)
                {
                    curenncySummery.Status = "طلبکار";
                }

                else if (remaining < 0)
                {
                    curenncySummery.Status = "بدهکار";
                }

                else
                {
                    curenncySummery.Status = "";
                }

                // curenncySummery.TotalDepositAmount = remaining;
                _dataListTotal.Add(curenncySummery);


            }



            grdTotals.AutoGenerateColumns = false;
            grdTotals.DataSource = _dataListTotal;

        }



        private List<TransactionsGroupModel> TotalPrint()
        {

            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw(_CurrenyId, _GroupId);
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => x.CurrenyId);
            _dataListTotal = new List<TransactionsGroupModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0, WithDraw = 0, Deposit = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.FullName = item.FullName;
                    curenncySummery.RowId = item.RowId;
                    curenncySummery.Phone = item.Phone;
                    curenncySummery.Mobile = item.Mobile;
                    curenncySummery.CurrenyId = item.CurrenyId;
                    item.RemainigAmount = Deposit - WithDraw;
                    curenncySummery.WithdrawAmount = item.WithdrawAmount;
                    curenncySummery.DepositAmount = item.DepositAmount;


                }

                remaining = totalDeposit - totalWithDraw;
                if (remaining > 0)
                {
                    curenncySummery.Status = "طلبکار";
                }

                else if (remaining < 0)
                {
                    curenncySummery.Status = "بدهکار";
                }

                else
                {
                    curenncySummery.Status = "";
                }
                curenncySummery.Status = curenncySummery.Status;
                curenncySummery.RemainigAmount = remaining;
                _GroupedDataList.Add(curenncySummery);


            }

            _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
            int row = 1;
            foreach (var item in _GroupedDataList)
            {
                item.RowId = row++;
            }
            return _GroupedDataList;
        }

        private List<TransactionsGroupModel> TotalSummeryPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw(_CurrenyId, _GroupId);
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => x.CurrenyId);
            _dataListTotal = new List<TransactionsGroupModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0, WithDraw = 0, Deposit = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.FullName = item.FullName;
                    curenncySummery.RowId = item.RowId;
                    curenncySummery.Phone = item.Phone;
                    curenncySummery.Mobile = item.Mobile;
                    curenncySummery.CurrenyId = item.CurrenyId;
                    item.RemainigAmount = Deposit - WithDraw;
                    curenncySummery.WithdrawAmount = item.WithdrawAmount;
                    curenncySummery.DepositAmount = item.DepositAmount;


                }

                remaining = totalDeposit - totalWithDraw;
                if (remaining > 0)
                {
                    curenncySummery.Status = "طلبکار";
                }

                else if (remaining < 0)
                {
                    curenncySummery.Status = "بدهکار";
                }

                else
                {
                    curenncySummery.Status = "";
                }
                curenncySummery.Status = curenncySummery.Status;
                curenncySummery.RemainigAmount = remaining;
                _GroupedDataList.Add(curenncySummery);


            }

            _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
            int row = 1;
            foreach (var item in _GroupedDataList)
            {
                item.RowId = row++;
            }
            gridCreditor.AutoGenerateColumns = false;
            gridCreditor.DataSource = _GroupedDataList;
            var tmpGroup = _GroupedDataList.GroupBy(x => x.CurrenyId);
            //////////////////////////////////////////////////////
            var xx = _GroupedDataList.GroupBy(x => x.CurrenyId);
            foreach (var currency in xx)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0;

                foreach (var item in currency)
                {
                    remaining += item.RemainigAmount;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    if (item.RemainigAmount < 0)
                    {
                        totalWithDraw += item.RemainigAmount;
                    }
                    if (item.RemainigAmount > 0)
                    {
                        totalDeposit += item.RemainigAmount;
                    }
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                if (remaining > 0)
                {
                    curenncySummery.Status = "طلبکار";
                }

                else if (remaining < 0)
                {
                    curenncySummery.Status = "بدهکار";
                }

                else
                {
                    curenncySummery.Status = "";
                }

                _dataListTotal.Add(curenncySummery);


            }

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
                var tmpDataList = unitOfWork.TransactionServices.GetAllWithdrawCustomers(txtSearch.Text, _CurrenyId, _GroupId);
                var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
                var groupedCurrency = tmpDataList.GroupBy(x => x.CurrenyId);
                _dataListTotal = new List<TransactionsGroupModel>();
                _GroupedDataList = new List<TransactionsGroupModel>();
                foreach (var currency in grouped)
                {
                    var curenncySummery = new TransactionsGroupModel();
                    curenncySummery.Description = "جمع";
                    long totalWithDraw = 0, totalDeposit = 0, remaining = 0, WithDraw = 0, Deposit = 0;
                    foreach (var item in currency.OrderBy(x => x.Id).ToList())
                    {
                        totalWithDraw += item.WithdrawAmount.Value;
                        totalDeposit += item.DepositAmount.Value;
                        curenncySummery.CurrenyName = item.CurrenyName;
                        curenncySummery.FullName = item.FullName;
                        curenncySummery.RowId = item.RowId;
                        curenncySummery.Phone = item.Phone;
                        curenncySummery.Mobile = item.Mobile;
                        curenncySummery.CurrenyId = item.CurrenyId;
                        item.RemainigAmount = Deposit - WithDraw;
                        curenncySummery.WithdrawAmount = item.WithdrawAmount;
                        curenncySummery.DepositAmount = item.DepositAmount;


                    }

                    remaining = totalDeposit - totalWithDraw;
                    if (remaining > 0)
                    {
                        curenncySummery.Status = "طلبکار";
                    }

                    else if (remaining < 0)
                    {
                        curenncySummery.Status = "بدهکار";
                    }

                    else
                    {
                        curenncySummery.Status = "";
                    }
                    curenncySummery.Status = curenncySummery.Status;
                    curenncySummery.RemainigAmount = remaining;
                    _GroupedDataList.Add(curenncySummery);


                }

                _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
                int row = 1;
                foreach (var item in _GroupedDataList)
                {
                    item.RowId = row++;
                }
                gridCreditor.AutoGenerateColumns = false;
                gridCreditor.DataSource = _GroupedDataList;
                var tmpGroup = _GroupedDataList.GroupBy(x => x.CurrenyId);
                //////////////////////////////////////////////////////
                var xx = _GroupedDataList.GroupBy(x => x.CurrenyId);
                foreach (var currency in xx)
                {
                    var curenncySummery = new TransactionsGroupModel();
                    curenncySummery.Description = "جمع";
                    long totalWithDraw = 0, totalDeposit = 0, remaining = 0;

                    foreach (var item in currency)
                    {
                        remaining += item.RemainigAmount;
                        curenncySummery.CurrenyName = item.CurrenyName;
                        if (item.RemainigAmount < 0)
                        {
                            totalWithDraw += item.RemainigAmount;
                        }
                        if (item.RemainigAmount > 0)
                        {
                            totalDeposit += item.RemainigAmount;
                        }
                    }
                    curenncySummery.TotalDepositAmount = totalDeposit;
                    curenncySummery.TotalWithdrawAmount = totalWithDraw;
                    curenncySummery.RemainigAmount = remaining;
                    if (remaining > 0)
                    {
                        curenncySummery.Status = "طلبکار";
                    }

                    else if (remaining < 0)
                    {
                        curenncySummery.Status = "بدهکار";
                    }

                    else
                    {
                        curenncySummery.Status = "";
                    }

                    // curenncySummery.TotalDepositAmount = remaining;
                    _dataListTotal.Add(curenncySummery);


                }



                grdTotals.AutoGenerateColumns = false;
                grdTotals.DataSource = _dataListTotal;
            }
            else
            {
                LoadData();
            }
        }
    }
}