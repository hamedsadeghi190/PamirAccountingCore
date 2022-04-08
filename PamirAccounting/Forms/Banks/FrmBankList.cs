using DevExpress.XtraEditors;
using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Banks
{
    public partial class FrmBankList : XtraForm
    {

        private UnitOfWork unitOfWork;
        private List<BanksModel> dataList;
        public FrmBankList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void FrmBankList_Load(object sender, EventArgs e)
        {
            loadData();
            dataGridView1.AutoGenerateColumns = false;
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
            var frmCurrencies = new CreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            dataList = unitOfWork.BankServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x=>new {x.RowId, x.Id,x.Name,x.BaseCurrencyName,x.CountryName}).ToList();
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id.Value);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف بانک", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var customer = unitOfWork.Customers.FindFirst(x => x.BankId == dataList.ElementAt(e.RowIndex).Id.Value);
                        unitOfWork.CustomerServices.Delete(customer);
                        unitOfWork.SaveChanges();
                        var bank = unitOfWork.BankServices.FindFirst(x => x.Id == dataList.ElementAt(e.RowIndex).Id.Value);
                        unitOfWork.BankServices.Delete(bank);
                        unitOfWork.SaveChanges();
                        loadData();
                    }
                    catch (Exception ex)
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
                dataList = unitOfWork.BankServices.Search(txtSearch.Text);
                dataGridView1.DataSource = dataList.Select(x => new { x.RowId, x.Id, x.Name, x.BaseCurrencyName, x.CountryName }).ToList();
            }
            else
            {
                loadData();
            }
        }

        private void FrmBankList_KeyUp(object sender, KeyEventArgs e)
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
                    var frmCurrencies = new CreateUpdateFrm(dataList.ElementAt(rowIndex).Id.Value);
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف بانک", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var bank = unitOfWork.BankServices.FindFirst(x => x.Id == dataList.ElementAt(rowIndex).Id.Value);
                            unitOfWork.BankServices.Delete(bank);
                            unitOfWork.SaveChanges();
                            loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("حذف امکانپذیر نمیباشد");
                        }

                    }

                }
            }

            if (e.KeyCode == Keys.F6)
            {
                var frmCurrencies = new CreateUpdateFrm();
                frmCurrencies.ShowDialog();
                loadData();
            }
        }
    }
}