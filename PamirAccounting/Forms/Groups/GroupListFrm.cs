using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
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
            loadData();
        }
        private void loadData()
        {
            dataList = unitOfWork.CustomerGroups.FindAll().Select(x => new CustomerGroupModel { Id = x.Id, Name = x.Name }).ToList();
            dataGridView1.DataSource = dataList;
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
                        unitOfWork.CustomerGroups.Delete(new CustomerGroup() { Id = dataList.ElementAt(e.RowIndex).Id.Value });
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
                dataList = unitOfWork.CustomerGroups.FindAll(y => y.Name.Contains(txtSearch.Text)).Select(x => new CustomerGroupModel { Id = x.Id, Name = x.Name }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }
    }
}