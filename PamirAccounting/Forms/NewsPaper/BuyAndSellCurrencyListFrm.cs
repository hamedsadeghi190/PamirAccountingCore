using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Forms.Transactions;
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
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.NewsPaper
{
    public partial class BuyAndSellCurrencyListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private int? _Id;
        private Domains.Customer _Customer;
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        private List<TransactionsGroupModel> _dataListTotal;
        private List<ComboBoxModel> _Groups = new List<ComboBoxModel>();
        public BuyAndSellCurrencyListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void BuyAndSellCurrencyListFrm_Load(object sender, EventArgs e)
        {
            cmbCurrencies.Select();
            cmbCurrencies.Focus();
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            InitForm();
            txtDate.Text = DateTime.Now.ToFarsiFormat();
        }

        private void InitForm()
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.TextChanged -= new EventHandler(cmbCurrencies_TextChanged);
            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            cmbCurrencies.SelectedValueChanged += new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.TextChanged += new EventHandler(cmbCurrencies_TextChanged);

            LoadData();

        }

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((int)cmbCurrencies.SelectedValue == 0)
            {
                var tmpDataList = unitOfWork.TransactionServices.GetAllSellAndBuyCurrency_Currency(0);
                GellAll(tmpDataList);
          
            }
           else if ((int)cmbCurrencies.SelectedValue > 0)
            {
                var tmpDataList = unitOfWork.TransactionServices.GetAllSellAndBuyCurrency_Currency((int)cmbCurrencies.SelectedValue);
                GellAll(tmpDataList);
        
            }
            else
            {
                LoadData();
            }
        }

        private void cmbCurrencies_TextChanged(object sender, EventArgs e)
        {


           

        }

        private void BuyAndSellCurrencyListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}

            if (e.KeyCode == Keys.F2)
            {
                cmbCurrencies.Select();
                cmbCurrencies.Focus();
            }

           


            if (e.KeyCode == Keys.F8)
            {
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = DateTime.Now;
                    string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                    var data = TotalPrint();
                    var data2 = TotalSummeryPrint();
                    var basedata = new reportbaseDAta() { Date = PersianDate };
                    var report = StiReport.CreateNewReport();
                    report.Load(AppSetting.ReportPath + "BuyAndSellCurrencyList.mrt");
                    report.RegData("myData", data);
                    report.RegData("myData2", data2);
                    report.RegData("basedata", basedata);
                    //report.Design();
                    report.Render();
                    report.Show();
                }
        }

        private void LoadData()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllSellAndBuyCurrency();
            GellAll(tmpDataList);
        }

        private void GellAll(List<TransactionModel> _list)
        {
            var tmpDataList = _list;
            var grouped = tmpDataList.GroupBy(x => x.CurrenyId);
            _dataList = new List<TransactionModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    item.RemainigAmount = totalDeposit - totalWithDraw;
                    _dataList.Add(item);
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "بستانگار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
            grdTotals.AutoGenerateColumns = false;
            grdTotals.DataSource = _GroupedDataList;
            _dataList = _dataList.OrderBy(x => x.RowId).ToList();
            gridPayAndReciveCash.AutoGenerateColumns = false;
            gridPayAndReciveCash.DataSource = _dataList;

        }

        private void grdTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridPayAndReciveCash.Columns["btnEdit"].Index && e.RowIndex >= 0)
            {
                var tranactionId = _dataList.ElementAt(e.RowIndex).Id;
                var tranaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == tranactionId);
                if (tranaction.TransactionType == (int)TransaActionType.SellCurrency)
                {
                    var frmbankunkown = new SellCurrencyFrm(0, tranactionId);
                    frmbankunkown.ShowDialog();
                }
                else if (tranaction.TransactionType == (int)TransaActionType.BuyCurrency)
                {
                    var frmbankunkown = new BuyCurrencyFrm(0, tranactionId);
                    frmbankunkown.ShowDialog();
                }

            }
        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridPayAndReciveCash.Select();
                gridPayAndReciveCash.Focus();
            }
            if (txtDate.Text.Length > 0)
            {
                var dDate = txtDate.Text.Split('_');
                if (dDate[0].Length == 10)
                {
                    _dataList = unitOfWork.TransactionServices.GetAllSellAndBuyCurrency_SearchDate(txtDate.Text);
                    GellAll(_dataList);
             
                }
                else
                    return;
            }
            else
                LoadData();
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
            report.Load(AppSetting.ReportPath + "BuyAndSellCurrencyList.mrt");
            report.RegData("myData", data);
            report.RegData("myData2", data2);
            report.RegData("basedata", basedata);
            //report.Design();
            report.Render();
            report.Show();
        }

        private List<TransactionModel> TotalPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllSellAndBuyCurrency();
            var grouped = tmpDataList.GroupBy(x => x.CurrenyId);
            _dataList = new List<TransactionModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    item.RemainigAmount = totalDeposit - totalWithDraw;
                    _dataList.Add(item);
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "بستانگار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
          
            _dataList = _dataList.OrderBy(x => x.RowId).ToList();
            gridPayAndReciveCash.AutoGenerateColumns = false;
            return _dataList;


        }

        private List<TransactionsGroupModel> TotalSummeryPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllSellAndBuyCurrency();
            var grouped = tmpDataList.GroupBy(x => x.CurrenyId);
            _dataList = new List<TransactionModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in grouped)
            {
                var curenncySummery = new TransactionsGroupModel();
                curenncySummery.Description = "جمع";
                long totalWithDraw = 0, totalDeposit = 0, remaining = 0;
                foreach (var item in currency.OrderBy(x => x.Id).ToList())
                {
                    totalWithDraw += item.WithdrawAmount.Value;
                    totalDeposit += item.DepositAmount.Value;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    item.RemainigAmount = totalDeposit - totalWithDraw;
                    _dataList.Add(item);
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "بستانگار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
            grdTotals.AutoGenerateColumns = false;
            return _GroupedDataList;
         

        }

        private void gridPayAndReciveCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void cmbCurrencies_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridPayAndReciveCash.Select();
                gridPayAndReciveCash.Focus();
            }
        }

        private void gridPayAndReciveCash_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (gridPayAndReciveCash.SelectedRows.Count > 0)
                {
                    var rowCount = _dataList.Count();
                    var rowIndex = gridPayAndReciveCash.CurrentCell.OwningRow.Index;


                    var tranactionId = (_dataList.ElementAt(rowIndex).Id);
                    var tranaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == tranactionId);
                    if (tranaction.TransactionType == (int)TransaActionType.SellCurrency && rowIndex <= rowCount - 1)
                    {
                        var frmbankunkown = new SellCurrencyFrm(0, tranactionId);
                        frmbankunkown.ShowDialog();
                    }
                    else if (tranaction.TransactionType == (int)TransaActionType.BuyCurrency)
                    {
                        var frmbankunkown = new BuyCurrencyFrm(0, tranactionId);
                        frmbankunkown.ShowDialog();
                    }
                }
            }
        }
    }
}