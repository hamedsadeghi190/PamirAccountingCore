using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Documents;
using System.Windows.Forms;

namespace PamirAccounting.Forms.GeneralLedger
{
    public partial class CreditorListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private Domains.Customer _Customer;
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        private List<TransactionsGroupModel> _dataListTotal;
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Groups = new List<ComboBoxModel>();

        public CreditorListFrm()
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
        private void CreditorListFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            InitForm();
            LoadData();

        }




        private void InitForm()
        {

            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.TextChanged -= new EventHandler(cmbCurrencies_TextChanged);
            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            cmbCurrencies.SelectedValueChanged += new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.TextChanged += new EventHandler(cmbCurrencies_TextChanged);
            _Groups.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Groups.AddRange(unitOfWork.CustomerGroups.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());

        }

        private void LoadData()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            GellAll(tmpDataList);
        }

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {

        }





        private void cmbCurrencies_TextChanged(object sender, EventArgs e)
        {
            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            if ((int)cmbCurrencies.SelectedValue == 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllWithdraw(null);
            }

            if ((int)cmbCurrencies.SelectedValue > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllWithdraw((int)cmbCurrencies.SelectedValue);
                GellAll(_dataList);
            }
            else
            {
                LoadData();
            }
        }



        private void cmbGroup_SelectedValueChanged(object sender, EventArgs e)
        {

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
                    //   _dataList.Add(item);


                }

                remaining = totalDeposit - totalWithDraw;
                if (remaining < 0)
                {
                    curenncySummery.RemainigAmount = remaining;
                    _GroupedDataList.Add(curenncySummery);

                }


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

                }

                curenncySummery.RemainigAmount = remaining;
                curenncySummery.TotalWithdrawAmount = remaining;
                _dataListTotal.Add(curenncySummery);


            }



            grdTotals.AutoGenerateColumns = false;
            grdTotals.DataSource = _dataListTotal;

        }





        private void CreditorListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var tmpDataList = unitOfWork.TransactionServices.GetAllWithdrawCustomers(txtSearch.Text);
                GellAll(tmpDataList);
            }
            else
            {
                LoadData();
            }
        }

        private void groupBoxViewAccountCustomer_Enter(object sender, EventArgs e)
        {

        }
        private List<TransactionsGroupModel> TotalPrint()
        {

            _GroupedDataList = new List<TransactionsGroupModel>();
            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => new { x.CurrenyId });
            _dataListTotal = new List<TransactionsGroupModel>();
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
                    curenncySummery.RowId = item.RowId;
                    curenncySummery.Phone = item.Phone;
                    curenncySummery.Mobile = item.Mobile;
                    item.RemainigAmount = Deposit - WithDraw;
                    _dataList.Add(item);
                }

                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
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
            return (_GroupedDataList);
        }
        private List<TransactionsGroupModel> TotalSummeryPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            var grouped = tmpDataList.GroupBy(x => new { x.CurrenyId, x.SourceCustomerId });
            var groupedCurrency = tmpDataList.GroupBy(x => new { x.CurrenyId });
            _dataListTotal = new List<TransactionsGroupModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var currency in groupedCurrency)
            {
                var curenncySummery2 = new TransactionsGroupModel();
                long totalWithDraw2 = 0, totalDeposit2 = 0, remaining2 = 0;
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
                _dataListTotal.Add(curenncySummery2);

            }
            grdTotals.AutoGenerateColumns = false;
            return (_dataListTotal);
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
            report.Load(AppSetting.ReportPath + "CreditorList.mrt");
            report.RegData("myData", data);
            report.RegData("myData2", data2);
            report.RegData("basedata", basedata);
            //report.Design();
            report.Render();
            report.Show();
        }
    }
}