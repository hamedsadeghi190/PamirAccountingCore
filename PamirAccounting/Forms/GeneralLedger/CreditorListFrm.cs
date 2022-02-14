using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Groups = new List<ComboBoxModel>();

        public CreditorListFrm()
        {
            
            InitializeComponent();
            unitOfWork = new UnitOfWork();
      
        }

        private void CreditorListFrm_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
            initGrid();
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

      

        private void InitForm()
        {
            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbCurrencies.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";
            cmbCurrencies.SelectedValueChanged += new EventHandler(cmbCurrencies_SelectedValueChanged);

            _Groups.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Groups.AddRange(unitOfWork.CustomerGroups.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbGroup.SelectedValueChanged -= new EventHandler(cmbGroup_SelectedValueChanged);
            cmbGroup.DataSource = _Groups;
            cmbGroup.ValueMember = "Id";
            cmbGroup.DisplayMember = "Title";
            cmbGroup.SelectedValueChanged += new EventHandler(cmbGroup_SelectedValueChanged);
        }

        

        private void cmbCurrencies_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {

            var tmpDataList = unitOfWork.TransactionServices.GetAllWithdraw( ((int)cmbCurrencies.SelectedValue != 0) ? (int)cmbCurrencies.SelectedValue : null);
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
            gridCreditor.AutoGenerateColumns = false;
            gridCreditor.DataSource = _dataList;

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var customer = unitOfWork.Customers.Find(txtSearch.Text).Id;
                _dataList = unitOfWork.TransactionServices.FindAll(x => x.SourceCustomerId == customer)
                       .Include(x => x.Curreny)
                    .Select(x => new TransactionModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        DepositAmount = x.DepositAmount,
                        WithdrawAmount = x.WithdrawAmount,
                        Phone = x.SourceCustomer.Phone,
                        Mobile = x.SourceCustomer.Mobile,
                        Date = x.Date.ToString(),
                        TransactionDateTime = x.TransactionDateTime.ToString(),
                        CurrenyId = x.CurrenyId,
                        CurrenyName = x.Curreny.Name,
                        FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,

                    }).ToList();
                gridCreditor.DataSource = _dataList;
            }
            else
            {
                LoadData();
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
                _dataList = unitOfWork.TransactionServices.GetAllWithdraw( null);
            }

            if ((int)cmbCurrencies.SelectedValue > 0)
            {
                _dataList = unitOfWork.TransactionServices.FindAll(x => x.Curreny.Name == (cmbCurrencies.Text) )
                      .Include(x => x.Curreny)

                       .Select(x => new TransactionModel
                       {
                           Id = x.Id,
                           Description = x.Description,
                           DepositAmount = x.DepositAmount,
                           WithdrawAmount = x.WithdrawAmount,
                           Phone = x.SourceCustomer.Phone,
                           Mobile = x.SourceCustomer.Mobile,
                           Date = x.Date.ToString(),
                           TransactionDateTime = x.TransactionDateTime.ToString(),
                           CurrenyId = x.CurrenyId,
                           CurrenyName = x.Curreny.Name,
                           FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       }).ToList();
                gridCreditor.DataSource = _dataList;
            }
            else
            {
                LoadData();
            }
        }

        private void cmbGroup_TextChanged(object sender, EventArgs e)
        {
            _Groups.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Groups.AddRange(unitOfWork.CustomerGroups.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList());
            cmbGroup.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            cmbGroup.DataSource = _Groups;
            cmbGroup.ValueMember = "Id";
            cmbGroup.DisplayMember = "Title";
            cmbGroup.SelectedValueChanged -= new EventHandler(cmbCurrencies_SelectedValueChanged);
            if ((int)cmbGroup.SelectedValue == 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllWithdraw(null);
            }

            if ((int)cmbGroup.SelectedValue > 0)
            {
                var groupId = unitOfWork.CustomerServices.FindFirst(p => p.GroupId == (int)cmbGroup.SelectedValue).Id;
                _dataList = unitOfWork.TransactionServices.FindAll(x => x.SourceCustomerId==groupId)
                      .Include(x => x.Curreny)
                       .Select(x => new TransactionModel
                       {
                           Id = x.Id,
                           Description = x.Description,
                           DepositAmount = x.DepositAmount,
                           WithdrawAmount = x.WithdrawAmount,
                           Phone = x.SourceCustomer.Phone,
                           Mobile = x.SourceCustomer.Mobile,
                           Date = x.Date.ToString(),
                           TransactionDateTime = x.TransactionDateTime.ToString(),
                           CurrenyId = x.CurrenyId,
                           CurrenyName = x.Curreny.Name,
                           FullName = x.SourceCustomer.FirstName + " " + x.SourceCustomer.LastName,
                       }).ToList();
                gridCreditor.DataSource = _dataList;
            }
            else
            {
                LoadData();
            }
        
        }

        private void cmbGroup_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}