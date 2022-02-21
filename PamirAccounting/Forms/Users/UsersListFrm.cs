using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using PamirAccounting.UI.Forms.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Users
{
    public partial class UsersListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<UserModel> dataList;
        public UsersListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void loadData()
        {
            dataList = unitOfWork.UserServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new { x.Id,x.FirstName, x.LastName, x.UserName }).ToList();
        }
    

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            var form = new UsersCreateUpdateFrm();
            form.ShowDialog();
            loadData();
        }

    
  

        private void UsersListFrm_Load(object sender, EventArgs e)
        {
            loadData();
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
        }


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new UsersCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ارز", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var user = unitOfWork.Users.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id);
                        user.IsDeleted = true;
                        unitOfWork.UserServices.Update(user);
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

     

        private void BtnCreateNew_Click_(object sender, EventArgs e)
        {
            var frmCurrencies = new UsersCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                dataList = unitOfWork.Users.FindAll(y => y.FirstName.Contains(txtsearch.Text)).Select(x => new UserModel { Id = x.Id, FirstName = x.FirstName }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void UsersListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtsearch.Select();
                txtsearch.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}