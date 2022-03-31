using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.GeneralLedger
{
    public partial class CreditorGroupListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private Domains.Customer _Customer;
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        private List<TransactionsGroupModel> _dataListTotal;
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Groups = new List<ComboBoxModel>();

        public CreditorGroupListFrm()
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
        private void CreditorGroupListFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            SetComboBoxHeight(cmbGroup.Handle, 25);
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
            var tmpDataList = unitOfWork.TransactionServices.GetAllWGroupList();
            GellAll(tmpDataList);
        }

        private void CreditorGroupListFrm_KeyUp(object sender, KeyEventArgs e)
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
            var grouped = tmpDataList.GroupBy(x=>new { x.GroupId,x.CurrenyId });
            _GroupedDataList = new List<TransactionsGroupModel>();
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
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.GroupName = item.GroupName;
                    curenncySummery.RowId = item.RowId;
                    curenncySummery.CurrenyId = item.CurrenyId;
                    item.RemainigAmount = Deposit - WithDraw;
                    curenncySummery.WithdrawAmount = item.WithdrawAmount;
                    curenncySummery.DepositAmount = item.DepositAmount;
                    curenncySummery.GroupId = item.GroupId;
                    curenncySummery.SourceCustomerId = item.SourceCustomerId;
                    // _dataList.Add(item);
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

            var xx = _GroupedDataList.GroupBy(x=>new { x.CurrenyId,x.GroupId});

            foreach (var currency in xx)
            {
              
                var curenncySummery = new TransactionsGroupModel();
                long remaining = 0;

                foreach (var item in currency)
                {
                    remaining += item.RemainigAmount;
                    curenncySummery.CurrenyName = item.CurrenyName;
                    curenncySummery.GroupName = item.GroupName;
                    curenncySummery.RowId = item.RowId;
                    curenncySummery.CurrenyId = item.CurrenyId;
                    curenncySummery.GroupId = item.GroupId;
                    curenncySummery.SourceCustomerId = item.SourceCustomerId;

                }

                curenncySummery.RemainigAmount = remaining;
                curenncySummery.TotalWithdrawAmount = remaining;
                _dataListTotal.Add(curenncySummery);

            }
            gridCreditor.AutoGenerateColumns = false;
            gridCreditor.DataSource = _dataListTotal;

        }

        private void gridCreditor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridCreditor.Columns["btnRowShow"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CreditorListFrm(_dataListTotal.ElementAt(e.RowIndex).CurrenyId, _dataListTotal.ElementAt(e.RowIndex).GroupId);
                frmCurrencies.ShowDialog();
           
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void cmbGroup_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurrencies_TextChanged(object sender, EventArgs e)
        {

        }
    }
}