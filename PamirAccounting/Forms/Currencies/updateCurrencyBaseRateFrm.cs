using PamirAccounting.Models;
using PamirAccounting.Models.ViewModels;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace PamirAccounting.Forms.Currencies
{
    public partial class updateCurrencyBaseRateFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<ComboBoxModel> _ActionType;
        private List<CurrenciesViewModel> dataList;
        private UnitOfWork unitOfWork;
        private Domains.Currency selectedCurrency;

        public updateCurrencyBaseRateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void updateCurrencyBaseRateFrm_Load(object sender, EventArgs e)
        {
            this.cmbAction.SelectedIndexChanged -= new System.EventHandler(this.cmbVarizType_SelectedIndexChanged);
            _ActionType = new List<ComboBoxModel>();
            _ActionType.Add(new ComboBoxModel() { Id = 1, Title = " ضرب" });
            _ActionType.Add(new ComboBoxModel() { Id = 2, Title = "تقسیم" });

            cmbAction.DataSource = _ActionType;
            cmbAction.ValueMember = "Id";
            cmbAction.DisplayMember = "Title";
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbVarizType_SelectedIndexChanged);
            loadData();
        }


        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataList = unitOfWork.Currencies.FindAll().Select(x => new CurrenciesViewModel { Id = x.Id, Name = x.Name, BaseRate = x.BaseRate, Action =x.Action }).ToList();
            dataGridView1.DataSource = dataList;
        }
        private void cmbVarizType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                showEdit(e.RowIndex);
            }
        }

        private void showEdit(int index )
        {
             var curreny = dataList.ElementAt(index);
            
            selectedCurrency = unitOfWork.CurrencyServices.FindFirst(x => x.Id == curreny.Id);
            
            lblRate.Visible = true;
            lblAction.Visible = true;
            cmbAction.Visible = true;
            lblArz.Visible = true;
            lblCurrenyName.Visible = true;
            btnSave.Visible = true;
            txtRate.Visible = true;

            txtRate.Text = curreny.BaseRate.HasValue ? curreny.BaseRate.Value.ToString() : "0";
            cmbAction.SelectedValue = curreny.Action.HasValue ? curreny.Action.Value : 1;
            lblCurrenyName.Text = curreny.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRate.Text.Length > 0)
            {
                selectedCurrency.Action = byte.Parse(cmbAction.SelectedValue.ToString());
                selectedCurrency.BaseRate = Double.Parse(txtRate.Text.Replace(',', '.'), CultureInfo.InvariantCulture) ;
                unitOfWork.CurrencyServices.Update(selectedCurrency);
                unitOfWork.SaveChanges();
                MessageBox.Show("نرخ بروز رسانی شد");
                loadData();
            }
            else
            {
                MessageBox.Show("نرخ را وارد نمایید");
            }
        }
    }
}