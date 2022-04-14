using DevExpress.XtraEditors;
using PamirAccounting.Forms.Transactions;
using PamirAccounting.Models;
using PamirAccounting.Services;
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

namespace PamirAccounting.Forms.NewsPaper
{
    public partial class PayAndReciveCashListFrm : DevExpress.XtraEditors.XtraForm
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

        public PayAndReciveCashListFrm()
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
            _Groups.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Groups.AddRange(unitOfWork.CustomerGroups.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());

        }

        private void LoadData()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAllPayAndReciveCash(((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            GellAll(tmpDataList);
        }
        private void grdTotals_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveCash(null);
            }

            if ((int)cmbCurrencies.SelectedValue > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveCash((int)cmbCurrencies.SelectedValue);
                GellAll(_dataList);
            }
            else
            {
                LoadData();
            }

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
        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {

        }



        private void PayAndReciveCashListFrm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }

            if (e.KeyCode == Keys.F2)
            {
                cmbCurrencies.Select();
                cmbCurrencies.Focus();
            }
         

            if (e.KeyCode == Keys.F8)
            {
                //PersianCalendar pc = new PersianCalendar();
                //DateTime dt = DateTime.Now;
                //string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                //var data = TotalPrint();
                //var data2 = TotalSummeryPrint();
                //var basedata = new reportbaseDAta() { Date = PersianDate };
                //var report = StiReport.CreateNewReport();
                //report.Load(AppSetting.ReportPath + "CreditorList.mrt");
                //report.RegData("myData", data);
                //report.RegData("myData2", data2);
                //report.RegData("basedata", basedata);
                //// report.Design();
                //report.Render();
                //report.Show();

            }
        }

        private void PayAndReciveCashListFrm_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
            PersianCalendar pc = new PersianCalendar();
            txtDate.Text = DateTime.Now.ToFarsiFormat();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDate.Text.Length > 0)
            {
                var dDate = txtDate.Text.Split('_');
                if (dDate[0].Length ==10)
                {
                    _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveCashDate(txtDate.Text);
                    GellAll(_dataList);
                }
                else
                    return;
            }
            else
                LoadData();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == gridPayAndReciveCash.Columns["BtnEdit"].Index && e.RowIndex >= 0)
            {
                var frmCash = new PayAndReciveCashFrm(0, _dataList.ElementAt(e.RowIndex).Id);
                frmCash.ShowDialog();
                LoadData();
            }

        }

        private void groupBoxViewAccountCustomer_Enter(object sender, EventArgs e)
        {

        }
    }
}