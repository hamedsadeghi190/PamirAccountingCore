using Microsoft.EntityFrameworkCore;
using PamirAccounting.Forms.Transaction;
using PamirAccounting.Forms.Transactions;
using PamirAccounting.Models;
using PamirAccounting.Services;
using PamirAccounting.UI.Forms.Transaction;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.UI.Forms.Customers
{
    public partial class ViewCustomerAccountFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private Domains.Customer _Customer;
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        public ViewCustomerAccountFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public ViewCustomerAccountFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void drOperation_Click(object sender, EventArgs e)
        {

        }

        private void ViewCustomerAccountFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbActions.Handle, 25);
            cmbActions.Refresh();
            grdTransactions.AutoGenerateColumns = false;
            grdTotals.AutoGenerateColumns = false;
            InitForm();
            LoadData();
            initGrid();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void initGrid()
        {

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)grdTransactions.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)grdTransactions.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
            ////////***************/////////////////

            foreach (DataGridViewRow row in grdTransactions.Rows)
            {

                int RemainigAmount;
                if (int.TryParse(row.Cells["RemainigAmount"].Value.ToString(), out RemainigAmount))
                {
                    if (RemainigAmount > 0)
                    {
                        row.Cells["RemainigAmount"].Style.ForeColor = System.Drawing.Color.Red;
                        row.Cells["Status"].Style.ForeColor = System.Drawing.Color.Red;
                        row.Cells["DepositAmount"].Style.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void InitForm()
        {

            _Actions.Add(new ComboBoxModel() { Id = 1, Title = "ثبت حساب جدید " });
            _Actions.Add(new ComboBoxModel() { Id = 2, Title = "دریافت و پرداخت نقدی " });
            _Actions.Add(new ComboBoxModel() { Id = 3, Title = "دریافت و پرداخت بانکی " });
            _Actions.Add(new ComboBoxModel() { Id = 5, Title = "انتقال حساب به حساب " });
            _Actions.Add(new ComboBoxModel() { Id = 10, Title = "خرید و فروش ارز " });

            cmbActions.SelectedValueChanged -= new EventHandler(cmbActions_SelectedValueChanged);
            cmbActions.DataSource = _Actions;
            cmbActions.ValueMember = "Id";
            cmbActions.DisplayMember = "Title";
            cmbActions.SelectedValueChanged += new EventHandler(cmbActions_SelectedValueChanged);

            _Currencies.Clear();
            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbCurrencies.AutoCompleteCustomSource = autoCurrencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            cmbCurrencies.SelectedValueChanged += new EventHandler(cmbCurrencies_SelectedValueChanged);

            if (_Id != null)
            {
                _Customer = unitOfWork.Customers.FindFirst(x => x.Id == _Id);
                this.Text = "کارت حساب - " + $"{_Customer.FirstName} {_Customer.LastName}";
                groupBoxViewAccountCustomer.Text = "کارت حساب - " + $"{_Customer.FirstName} {_Customer.LastName}";
            }

        }

        private void BalanceBtn_Click(object sender, EventArgs e)
        {

        }

        private void cmbActions_SelectedValueChanged(object sender, EventArgs e)
        {
            switch ((int)cmbActions.SelectedValue)
            {
                case 1:
                    var FrmBalance = new CreateNewCustomerAccount(_Id.Value, null);
                    FrmBalance.ShowDialog();
                    LoadData();
                    break;
                case 2:
                    var frmCash = new PayAndReciveCashFrm(_Id.Value, null);
                    frmCash.ShowDialog();
                    LoadData();
                    break;
                case 3:
                    var frmbank = new PayAndReciveBankFrm(_Id.Value, null);
                    frmbank.ShowDialog();
                    LoadData();
                    break;
                case 5:
                    var frmtransfer = new TransferAccountFrm(_Id.Value, null);
                    frmtransfer.ShowDialog();
                    LoadData();
                    break;
                case 10:
                    var frmCellAndBuy = new BuyAndSellCurrencyFrm(_Id.Value, null);
                    frmCellAndBuy.ShowDialog();
                    LoadData();
                    break;
                default:
                    break;
            }
        }


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == grdTransactions.Columns["btnView"].Index && e.RowIndex >= 0)
            {
                //var destForm = new ViewCustomerAccountFrm(dataList.ElementAt(e.RowIndex).Id);
                //destForm.ShowDialog();
            }

            if (e.ColumnIndex == grdTransactions.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                //var frmCurrencies = new CustomerCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                //frmCurrencies.ShowDialog();
                //loadData();
            }


            if (e.ColumnIndex == grdTransactions.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        //var customer = unitOfWork.Customers.FindFirstOrDefault(x => x.Id == _dataList.ElementAt(e.RowIndex).Id);
                        //customer.IsDeleted = true;
                        //unitOfWork.CustomerServices.Update(customer);
                        //unitOfWork.SaveChanges();
                        LoadData();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void LoadData()
        {

            var tmpDataList = unitOfWork.TransactionServices.GetAll(_Id.Value, ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
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
                    if (item.RemainigAmount > 0)
                    {
                        item.Status = "طلبکار";
                    }
                    else if (item.RemainigAmount < 0)
                    {
                        item.Status = "بدهکار";
                    }
                    else
                    {
                        item.Status = "";
                    }

                    _dataList.Add(item);
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "طلبکار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
            grdTotals.AutoGenerateColumns = false;
            grdTotals.DataSource = _GroupedDataList;
            _dataList = _dataList.OrderBy(x => x.RowId).ToList();
            grdTransactions.AutoGenerateColumns = false;
            grdTransactions.DataSource = _dataList;
        }

        private void groupBoxViewAccountCustomer_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grdTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                _dataList = unitOfWork.TransactionServices.FindAll(x => x.Id == int.Parse(txtSearch.Text))
                       .Include(x => x.Curreny)
                     .Include(x => x.User)
                    .Select(x => new TransactionModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        DepositAmount = x.DepositAmount,
                        WithdrawAmount = x.WithdrawAmount,
                        Date = x.Date.ToString(),
                        TransactionDateTime = x.TransactionDateTime.ToString(),
                        CurrenyId = x.CurrenyId,
                        CurrenyName = x.Curreny.Name,
                        UserId = x.UserId,
                        UserName = x.User.UserName,

                    }).ToList();
                grdTransactions.DataSource = _dataList;
            }
            else
            {
                LoadData();
            }

        }

        private void grdTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == grdTransactions.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف مشتری", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var transaction = unitOfWork.Transactions.FindFirstOrDefault(x => x.Id == _dataList.ElementAt(e.RowIndex).Id);

                        if (transaction.DoubleTransactionId != null)
                        {

                            var doubleTransaction = unitOfWork.Transactions.FindFirstOrDefault(x => x.Id == transaction.DoubleTransactionId);


                            transaction.DoubleTransactionId = null;
                            unitOfWork.TransactionServices.Update(transaction);
                            unitOfWork.SaveChanges();


                            doubleTransaction.DoubleTransactionId = null;
                            unitOfWork.TransactionServices.Update(doubleTransaction);
                            unitOfWork.SaveChanges();

                            unitOfWork.TransactionServices.Delete(doubleTransaction);
                            unitOfWork.SaveChanges();
                        }

                        unitOfWork.TransactionServices.Delete(transaction);
                        unitOfWork.SaveChanges();

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }

            if (e.ColumnIndex == grdTransactions.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var tranaction = _dataList.ElementAt(e.RowIndex);

                openEditForm(tranaction);
            }
        }

        private void openEditForm(TransactionModel tranaction)
        {
            switch (tranaction.TransactionType)
            {
                case (int)TransaActionType.NewAccount:
                    var FrmBalance = new CreateNewCustomerAccount(_Id.Value, tranaction.Id);
                    FrmBalance.ShowDialog();
                    LoadData();
                    break;
                case (int)TransaActionType.PayAndReciveCash:
                    var frmCash = new PayAndReciveCashFrm(_Id.Value, tranaction.Id);
                    frmCash.ShowDialog();
                    LoadData();
                    break;

                case (int)TransaActionType.PayAndReciveBank:
                    var frmbank = new PayAndReciveBankFrm(_Id.Value, tranaction.Id);
                    frmbank.ShowDialog();
                    LoadData();
                    break;  
                
                case (int)TransaActionType.UnkwonReciveBank:
                    var frmbankunkown = new PayAndReciveBankFrm(_Id.Value, tranaction.Id);
                    frmbankunkown.ShowDialog();
                    LoadData();
                    break;

                case (int)TransaActionType.Transfer:
                    var transferFrm = new TransferAccountFrm(_Id.Value, tranaction.Id);
                    transferFrm.ShowDialog();
                    LoadData();
                    break;
                case (int)TransaActionType.SellAndBuy:
                    var frmCellAndBuy = new BuyAndSellCurrencyFrm(_Id.Value, tranaction.Id);
                    frmCellAndBuy.ShowDialog();
                    LoadData();
                    break;
                default:
                    break;
            }
        }

        private void btnsearchdate_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                _Customer = unitOfWork.Customers.FindFirst(x => x.Id == _Id);
                var name = _Customer.FirstName + " " + _Customer.LastName;
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Now;
                string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                var data = TotalPrint();
                var data2 = TotalSummeryPrint();
                //  var name = new UnitOfWork().TransactionServices.FindUserName(_Id.Value);
                var basedata = new reportbaseDAta() { Date = PersianDate, CustomerName = name };
                var report = StiReport.CreateNewReport();
                report.Load(AppSetting.ReportPath + "CustomerAccount2.mrt");
                report.RegData("myData", data);
                report.RegData("myData2", data2);
                report.RegData("basedata", basedata);
                // report.Design();
                report.Render();
                report.Show();
            }
            catch
            {
                MessageBox.Show("خطا در پرینت");
            }

        }


        private void grdTransactions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdTransactions.Columns[e.ColumnIndex].Name == "DepositAmount")
            {
                grdTransactions.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.AliceBlue;
            }
        }

        private void cmbCurrencies_TextChanged(object sender, EventArgs e)
        {






        }

        private void btnprintResid_Click(object sender, EventArgs e)
        {

            {

                var tmpDataList = unitOfWork.TransactionServices.GetAll(_Id.Value, ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
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
                    curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "طلبکار" : "بدهکار";
                    _GroupedDataList.Add(curenncySummery);
                }



                _Customer = unitOfWork.Customers.FindFirst(x => x.Id == _Id);
                var name = _Customer.FirstName + " " + _Customer.LastName;
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Now;
                string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                var data = _GroupedDataList;
                var basedata = new reportbaseDAta() { Date = PersianDate, CustomerName = name };
                var report = StiReport.CreateNewReport();
                report.Load(AppSetting.ReportPath + "RemainigAmount.mrt");
                report.RegData("myData", data);
                report.RegData("basedata", basedata);
                //report.Design();
                report.Render();
                report.Show();
            }
        }

        private void grdTransactions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter && grdTransactions.CurrentRow != null)
            {
                int i = grdTransactions.CurrentRow.Index;
                var tmpDataList = unitOfWork.TransactionServices.GetAll(_Id.Value, ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);

                tmpDataList = tmpDataList.Where(p => p.RowId == i).Select(x => new TransactionModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    DepositAmount = x.DepositAmount,
                    WithdrawAmount = x.WithdrawAmount,
                    Date = x.Date.ToString(),
                    TransactionDateTime = x.TransactionDateTime.ToString(),
                    CurrenyId = x.CurrenyId,
                    UserId = x.UserId,
                    TransactionType = x.TransactionType,
                    DocumentId = x.DocumentId,
                    CurrenyName = x.CurrenyName
                }).ToList();
                var Deposit = 0;
                var Withdraw = 0;
                foreach (var item in tmpDataList)
                {
                    Deposit = (int)(long)item.DepositAmount;
                    Withdraw = (int)(long)item.WithdrawAmount;
                }
                if (Deposit > 0)
                {
                    var data = tmpDataList;
                    _Customer = unitOfWork.Customers.FindFirst(x => x.Id == _Id);
                    var name = _Customer.FirstName + " " + _Customer.LastName;
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = DateTime.Now;
                    string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                    var basedata = new reportbaseDAta() { Date = PersianDate, CustomerName = name, Price = Deposit.ToString(), Status = "نزد برنامه طلبکار است" };
                    var report = StiReport.CreateNewReport();
                    report.Load(AppSetting.ReportPath + "Transaction.mrt");
                    report.RegData("myData", data);
                    report.RegData("basedata", basedata);
                    report.Render();
                    report.Show();
                }
                if (Withdraw > 0)
                {
                    var data = tmpDataList;
                    _Customer = unitOfWork.Customers.FindFirst(x => x.Id == _Id);
                    var name = _Customer.FirstName + " " + _Customer.LastName;
                    PersianCalendar pc = new PersianCalendar();
                    DateTime dt = DateTime.Now;
                    string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                    var basedata = new reportbaseDAta() { Date = PersianDate, CustomerName = name, Price = Withdraw.ToString(), Status = " نزد برنامه بدهکار است" };
                    var report = StiReport.CreateNewReport();
                    report.Load(AppSetting.ReportPath + "Transaction.mrt");
                    report.RegData("myData", data);
                    report.RegData("basedata", basedata);
                    report.Render();
                    report.Show();
                }


            }
        }

        public class reportbaseDAta
        {
            public string CustomerName { get; set; }
            public string Date { get; set; }
            public string Price { get; set; }
            public string Status { get; set; }
        }

        private void ViewCustomerAccountFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}
            if (e.KeyCode == Keys.F3)
            {
                btnprint_Click(null, null);
            }
            if (e.KeyCode == Keys.F4)
            {
                if (grdTransactions.SelectedRows.Count > 0)
                {
                    //var rowIndex = grdTransactions.SelectedRows[0].Index;
                    //var destForm = new ViewCustomerAccountFrm(_dataList.ElementAt(rowIndex).Id);
                    //destForm.ShowDialog();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private List<TransactionsGroupModel> TotalSummeryPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAll(_Id.Value, ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
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
                    if (item.RemainigAmount > 0)
                    {
                        item.Status = "طلبکار";
                    }
                    else if (item.RemainigAmount < 0)
                    {
                        item.Status = "بدهکار";
                    }
                    else
                    {
                        item.Status = "";
                    }

                    _dataList.Add(item);
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "طلبکار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }
            grdTotals.AutoGenerateColumns = false;
            return _GroupedDataList;

        }

        private List<TransactionModel> TotalPrint()
        {
            var tmpDataList = unitOfWork.TransactionServices.GetAll(_Id.Value, ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
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
                    if (item.RemainigAmount > 0)
                    {
                        item.Status = "طلبکار";
                    }
                    else if (item.RemainigAmount < 0)
                    {
                        item.Status = "بدهکار";
                    }
                    else
                    {
                        item.Status = "";
                    }

                    _dataList.Add(item);
                }
                curenncySummery.TotalDepositAmount = totalDeposit;
                curenncySummery.TotalWithdrawAmount = totalWithDraw;
                remaining = totalDeposit - totalWithDraw;
                curenncySummery.RemainigAmount = remaining;
                curenncySummery.Status = (remaining == 0) ? "" : (remaining > 0) ? "طلبکار" : "بدهکار";
                _GroupedDataList.Add(curenncySummery);

            }

            _dataList = _dataList.OrderBy(x => x.RowId).ToList();
            grdTransactions.AutoGenerateColumns = false;
            return _dataList;
        }

        private void grdTransactions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (this.grdTransactions.SelectedRows.Count > 0)
                {
                    this.grdTransactions.CurrentRow.Selected = true;
                    e.Handled = true;

                    var rowIndex = grdTransactions.SelectedRows[0].Index;
                    var tranaction = _dataList.ElementAt(rowIndex);
                    openEditForm(tranaction);
                }
            }
        }
    }
}
