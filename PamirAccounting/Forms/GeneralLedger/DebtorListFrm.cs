using DevExpress.XtraEditors;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.GeneralLedger
{
 
    public partial class DebtorListFrm : DevExpress.XtraEditors.XtraForm
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
        public DebtorListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }

        private void DebtorListFrm_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
            initGrid();
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
            var tmpDataList = unitOfWork.TransactionServices.GetAllDeposit(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            GellAll(tmpDataList);
        }
        private void initGrid()
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            for (int i = 0; i < 7; i++)
            {
                gridCreditor.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.gridCreditor.DefaultCellStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            ////////***************/////////////////
            DataGridViewCellStyle HeaderStyle1 = new DataGridViewCellStyle();
            HeaderStyle1.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 3; i++)
            {
                grdTotals.Columns[i].HeaderCell.Style = HeaderStyle1;
            }
            this.grdTotals.DefaultCellStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);

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
                _dataList = unitOfWork.TransactionServices.GetAllDeposit(null);
            }

            if ((int)cmbCurrencies.SelectedValue > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllDeposit((int)cmbCurrencies.SelectedValue);
                GellAll(_dataList);
            }
            else
            {
                LoadData();
            }
        }

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var tmpDataList = unitOfWork.TransactionServices.GetAllDepositCustomers(txtSearch.Text);
                GellAll(tmpDataList);
            }
            else
            {
                LoadData();
            }
        }

        private void DebtorListFrm_KeyUp(object sender, KeyEventArgs e)
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
            gridCreditor.DataSource = _GroupedDataList;
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
            grdTotals.DataSource = _dataListTotal;

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var data = TotalPrint();
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "DebtorListFrm.mrt");
            report.RegData("myData", data);
            report.RegData("basedata", basedata);
            report.Design();
            //report.Render();
            //report.Show();
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
    }
}