using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
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

      
        private void initGrid()
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
            for (int i = 0; i < 7; i++)
            {
                gridPayAndReciveCash.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.gridPayAndReciveCash.DefaultCellStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
            ////////***************/////////////////
            DataGridViewCellStyle HeaderStyle1 = new DataGridViewCellStyle();
            HeaderStyle1.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
            for (int i = 0; i < 6; i++)
            {
                grdTotals.Columns[i].HeaderCell.Style = HeaderStyle1;
            }
            this.grdTotals.DefaultCellStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);

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
        }

        private void PayAndReciveCashListFrm_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
            initGrid(); 
            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDate.Text = PDate;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDate.Text.Length > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveCashDate(txtDate.Text);
        
            }
            else
                LoadData();
        }
    }
}