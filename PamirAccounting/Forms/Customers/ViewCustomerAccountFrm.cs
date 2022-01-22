using Microsoft.EntityFrameworkCore;
using PamirAccounting.Forms.Customers;
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
            InitForm();
            LoadData();
            initGrid();
        }
        private void initGrid()
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            for (int i = 0; i < 12; i++)
            {
                grdTransactions.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.grdTransactions.DefaultCellStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)grdTransactions.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)grdTransactions.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
            ////////***************/////////////////
            DataGridViewCellStyle HeaderStyle1 = new DataGridViewCellStyle();
            HeaderStyle1.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 6; i++)
            {
                grdTotals.Columns[i].HeaderCell.Style = HeaderStyle1;
            }
            this.grdTotals.DefaultCellStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);


            foreach (DataGridViewRow row in grdTransactions.Rows)
            {

                int quantity;
                if (int.TryParse(row.Cells[5].Value.ToString(), out quantity))
                {
                    if (quantity > 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            row.Cells[i].Style.BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                    }
                }
                //if (int.TryParse(row.Cells[5].Value.ToString(), out quantity))
                //{
                //    if (quantity > 0)
                //    {
                //        for (int i = 0; i < 10; i++)
                //        {
                //            row.Cells[i].Style.BackColor = System.Drawing.Color.LightSteelBlue;
                //        }
                //    }
                //}
            }

            foreach (DataGridViewRow row in grdTotals.Rows)
            {

                int quantity1;
                if (int.TryParse(row.Cells[1].Value.ToString(), out quantity1))
                {
                    if (quantity1 > 0)
                        row.Cells[1].Style.BackColor = System.Drawing.Color.Lavender;

                }
                if (int.TryParse(row.Cells[2].Value.ToString(), out quantity1))
                {
                    if (quantity1 > 0)
                        row.Cells[2].Style.BackColor = System.Drawing.Color.WhiteSmoke;

                }
            }



        }

        private void InitForm()
        {
            _Actions.Add(new ComboBoxModel() { Id = 1, Title = "ثبت حساب جدید " });
            _Actions.Add(new ComboBoxModel() { Id = 2, Title = "دریافت و پرداخت نقدی " });
            _Actions.Add(new ComboBoxModel() { Id = 3, Title = "دریافت و پرداخت بانکی " });
            _Actions.Add(new ComboBoxModel() { Id = 4, Title = "انتقال حساب به حساب " });

            cmbActions.SelectedValueChanged -= new EventHandler(cmbActions_SelectedValueChanged);
            cmbActions.DataSource = _Actions;
            cmbActions.ValueMember = "Id";
            cmbActions.DisplayMember = "Title";
            cmbActions.SelectedValueChanged += new EventHandler(cmbActions_SelectedValueChanged);

            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());

            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.DataSource = _Currencies;
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
            var FrmBalance = new BalanceFrm();
            FrmBalance.ShowDialog();
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
                case 4:
                    var frmtransfer = new TransferAccountFrm(_Id.Value);
                    frmtransfer.ShowDialog();
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
            grdTransactions.AutoGenerateColumns = false;
            grdTransactions.DataSource = _dataList;
        }

        private void groupBoxViewAccountCustomer_Enter(object sender, EventArgs e)
        {

        }

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {
            
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
                        unitOfWork.TransactionServices.Delete(transaction);
                        unitOfWork.SaveChanges();
                        LoadData();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }

            if (e.ColumnIndex == grdTransactions.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var tranaction = _dataList.ElementAt(e.RowIndex);

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
                    default:
                        break;
                }
            }
        }

        private void btnsearchdate_Click(object sender, EventArgs e)
        {
            var SearchDateFrm1 = new SearchDateFrm();
            SearchDateFrm1.ShowDialog();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var data = new UnitOfWork().TransactionServices.GetAllReport(_Id.Value, ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
            //  var name = new UnitOfWork().TransactionServices.FindUserName(_Id.Value);
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "CustomerAccount.mrt");
            report.RegData("myData", data);
            report.RegData("basedata", basedata);
            //report.Design();
            report.Render();
            report.Show();
        }
        public class reportbaseDAta
        {
            public string CustomerName { get; set; }
            public string Date { get; set; }
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

            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            if ((int)cmbCurrencies.SelectedValue == 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAll(_Id.Value, null);
            }

            if ((int)cmbCurrencies.SelectedValue > 0)
            {
                _dataList = unitOfWork.TransactionServices.FindAll(x => x.Curreny.Name == (cmbCurrencies.Text) && x.SourceCustomerId == _Id)
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
            foreach (DataGridViewRow row in grdTransactions.Rows)
            {
                int quantity;
                if (int.TryParse(row.Cells[5].Value.ToString(), out quantity))
                {
                    if (quantity > 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            row.Cells[i].Style.BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                    }
                }
            }
            foreach (DataGridViewRow row in grdTotals.Rows)
            {

                int quantity1;
                if (int.TryParse(row.Cells[1].Value.ToString(), out quantity1))
                {
                    if (quantity1 > 0)
                        row.Cells[1].Style.BackColor = System.Drawing.Color.Lavender;

                }
                if (int.TryParse(row.Cells[2].Value.ToString(), out quantity1))
                {
                    if (quantity1 > 0)
                        row.Cells[2].Style.BackColor = System.Drawing.Color.WhiteSmoke;

                }
            }



        }


    }
}