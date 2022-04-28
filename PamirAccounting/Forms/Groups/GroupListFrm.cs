using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Groups
{
    public partial class GroupListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<CustomerGroupModel> dataList;
        public GroupListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void GroupListFrm_Load(object sender, EventArgs e)
        {
            txtSearch.Select();
            txtSearch.Focus();
            dataGridView1.AutoGenerateColumns = false;
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
        private void loadData()
        {
            dataList = unitOfWork.CustomerGroups.FindAll().Select(x => new CustomerGroupModel { Id = x.Id, Name = x.Name }).ToList();
            int row = 1;
            var tmpdataList = dataList.Select(x => new CustomerGroupModel
            {
                rowId = row++,
                Id = x.Id,
                Name = x.Name


            }).ToList();
            dataGridView1.DataSource = tmpdataList;
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            var frmGroups = new GroupCreateUpdateFrm();
            frmGroups.ShowDialog();
            loadData();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new GroupCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id.Value);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف گروه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var id=unitOfWork.CustomerGroups.Find(dataList.ElementAt(e.RowIndex).Id.Value);
                        
                        unitOfWork.CustomerGroups.Delete(id);
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

           
        }

        private void groupBoxSearch_Enter(object sender, EventArgs e)
        {

        }

        private void GroupListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtSearch.Select();
                txtSearch.Focus();
            }

            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.F7)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    var frmCurrencies = new GroupCreateUpdateFrm(dataList.ElementAt(rowIndex).Id.Value);
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف گروه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
               MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var id = unitOfWork.CustomerGroups.Find(dataList.ElementAt(rowIndex).Id.Value);
                            unitOfWork.CustomerGroups.Delete(id);
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
                var frmGroups = new GroupCreateUpdateFrm();
                frmGroups.ShowDialog();
                loadData();
            }
        }

        private void txtSearch_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtSearch.Text.Length > 0)
            {
                dataList = unitOfWork.CustomerGroups.FindAll(y => y.Name.Contains(txtSearch.Text)).Select(x => new CustomerGroupModel { Id = x.Id, Name = x.Name }).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new CustomerGroupModel
                {
                    rowId = row++,
                    Id = x.Id,
                    Name = x.Name


                }).ToList();
                dataGridView1.DataSource = tmpdataList;
            }
            else
            {
                loadData();
            }
        }
    }
}