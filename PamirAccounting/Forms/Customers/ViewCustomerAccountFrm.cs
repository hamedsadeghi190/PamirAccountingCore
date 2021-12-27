using DevExpress.XtraEditors;
using PamirAccounting.Forms.Transaction;
using PamirAccounting.Forms.Transactions;
using PamirAccounting.Models;
using PamirAccounting.Services;
using PamirAccounting.UI.Forms.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Customers
{
    public partial class ViewCustomerAccountFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private Domains.Customer _Customer;
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<TransactionModel> _dataList;
        private List<TransactionsGroupModel> _GroupedDataList;
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
        }

        private void InitForm()
        {
            _Actions.Add(new ComboBoxModel() { Id = 1, Title = "ثبت حساب جدید " });
            _Actions.Add(new ComboBoxModel() { Id = 2, Title = "دریافت و پرداخت نقدی " });
            _Actions.Add(new ComboBoxModel() { Id = 3, Title = "دریافت و پرداخت بانکی " });
            _Actions.Add(new ComboBoxModel() { Id = 3, Title = "انتقال حساب به حساب " });

            cmbActions.SelectedValueChanged -= new System.EventHandler(cmbActions_SelectedValueChanged);
            cmbActions.DataSource = _Actions;
            cmbActions.ValueMember = "Id";
            cmbActions.DisplayMember = "Title";
            cmbActions.SelectedValueChanged += new System.EventHandler(cmbActions_SelectedValueChanged);

            if (_Id != null)
            {
              _Customer =  unitOfWork.Customers.FindFirst(x => x.Id == _Id);
                this.Text = "نمایش حساب - " + $"{_Customer.FirstName} {_Customer.LastName}";
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
                    var FrmBalance = new CreateNewCustomerAccount(_Id.Value);
                    FrmBalance.ShowDialog();
                    LoadData();
                    break;
                case 2:
                    var frmCash = new PayAndReciveCashFrm(_Id.Value);
                    frmCash.ShowDialog();
                    LoadData();
                    break;     
                case 3:
                    var frmbank = new PayAndReciveBankFrm(_Id.Value);
                    frmbank.ShowDialog();
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
            _dataList = unitOfWork.TransactionServices.GetAll(_Id.Value);
            grdTransactions.AutoGenerateColumns = false;
            grdTransactions.DataSource = _dataList;

            var grouped = _dataList.GroupBy(x => x.CurrenyId);
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
        }

        private void groupBoxViewAccountCustomer_Enter(object sender, EventArgs e)
        {

        }

        private void grdTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}