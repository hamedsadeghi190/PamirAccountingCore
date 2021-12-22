using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using PamirAccounting.UI.Forms.Users;
using System;
using System.Collections.Generic;
using System.Data;
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


        private void FrmBankList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            var form = new UsersCreateUpdateFrm();
            form.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            dataList = unitOfWork.UserServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x=> new {x.FirstName,x.LastName,x.UserName }).ToList();
        }
  

        private void UsersListFrm_Load(object sender, EventArgs e)
        {
            loadData();
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

        private void BtnCreateNew_Click_1(object sender, EventArgs e)
        {
            var frmCurrencies = new UsersCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }
    }
}