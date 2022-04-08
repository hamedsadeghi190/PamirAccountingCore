using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.CurrencyAgencies
{
    public partial class FrmCurrencyAgenciesList : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<AgencyCurencyModel> dataList;
        public FrmCurrencyAgenciesList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }



        private void FrmCurrencyAgenciesList_Load(object sender, EventArgs e)
        {
              loadData();
           
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {

            var frmCurrencie = new CurrencyAgenciesCreateUpdateFrm();
            frmCurrencie.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            dataList = unitOfWork.CurrenciesMappingServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new { x.Id, x.SourceCurrenyName, x.DestiniationCurrenyName,x.ActionName , x.ExchangeRateShow, x.RoundLimitShow }).ToList();
        }


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

      

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CurrencyAgenciesCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف عملیات ارز نمایندگی", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        unitOfWork.CurrenciesMappingServices.Delete(new CurrenciesMapping() { Id = dataList.ElementAt(e.RowIndex).Id });
                        unitOfWork.SaveChanges();
                        loadData();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                dataList = unitOfWork.CurrenciesMappingServices.Search(txtSearch.Text);
                dataGridView1.DataSource = dataList.Select(x => new { x.Id, x.SourceCurrenyName, x.DestiniationCurrenyName, x.ActionName, x.ExchangeRateShow, x.RoundLimitShow }).ToList();
            }
            else
            {
                loadData();
            }
        }

        private void FrmCurrencyAgenciesList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtSearch.Select();
                txtSearch.Focus();
            }
        
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F7)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    var frmCurrencies = new CurrencyAgenciesCreateUpdateFrm(dataList.ElementAt(rowIndex).Id);
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف عملیات ارز نمایندگی", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            unitOfWork.CurrenciesMappingServices.Delete(new CurrenciesMapping() { Id = dataList.ElementAt(rowIndex).Id });
                            unitOfWork.SaveChanges();
                            loadData();
                        }
                        catch
                        {
                            MessageBox.Show("حذف امکانپذیر نمیباشد");
                        }

                    }

                }
            }

            if (e.KeyCode == Keys.F6)
            {
                var frmCurrencie = new CurrencyAgenciesCreateUpdateFrm();
                frmCurrencie.ShowDialog();
                loadData();

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}