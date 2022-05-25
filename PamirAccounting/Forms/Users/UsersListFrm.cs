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
using static PamirAccounting.Commons.Enums.Settings;
using static PamirAccounting.Tools;

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
            dataGridView1.DataSource = dataList;
        }
    

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            var form = new UsersCreateUpdateFrm();
            form.ShowDialog();
            loadData();
        }

    
  

        private void UsersListFrm_Load(object sender, EventArgs e)
        {
            var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
            var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Users && x.UserId == CurrentUser.UserID);
            if (roleId == null && adminRole == null)
            {
                BtnCreateNew.Enabled = false;

            }
           
                txtsearch.Select();
            txtsearch.Focus();
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


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Users && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    var frmCurrencies = new UsersCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف کاربر", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                        var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.DeleteUsers && x.UserId == CurrentUser.UserID);
                        if (roleId == null && adminRole == null)
                        {
                            MessageBox.Show(Messages.PermissionMsg);
                            return;

                        }
                        if (roleId != null || adminRole != null)
                        {
                            var user = unitOfWork.Users.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id);
                            user.IsDeleted = true;
                            unitOfWork.UserServices.Update(user);
                            unitOfWork.SaveChanges();
                            #region Log
                            var log = new Domains.DailyOperation();
                            log.Date = DateTime.Parse(DateTime.Now.ToString());
                            log.Time = DateTime.Now.TimeOfDay;
                            log.UserId = CurrentUser.UserID;
                            log.UserName = CurrentUser.UserName;
                            log.Description = $"حذف کاربر {user.FirstName} {user.LastName}";
                            log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                            log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                            unitOfWork.DailyOperationServices.Insert(log);
                            unitOfWork.SaveChanges();
                            #endregion
                            loadData();
                        }
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
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtsearch.Text.Length > 0)
            {
                dataList = unitOfWork.UserServices.Search(txtsearch.Text);
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
                    var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                    var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Users && x.UserId == CurrentUser.UserID);
                    if (roleId == null && adminRole == null)
                    {
                        MessageBox.Show(Messages.PermissionMsg);
                        return;

                    }
                    if (roleId != null || adminRole != null)
                    {
                        var rowIndex = dataGridView1.SelectedRows[0].Index;
                        var frmCurrencies = new UsersCreateUpdateFrm(dataList.ElementAt(rowIndex).Id);
                        frmCurrencies.ShowDialog();
                        loadData();
                    }
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;

                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف کاربر", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                            var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.DeleteUsers && x.UserId == CurrentUser.UserID);
                            if (roleId == null && adminRole == null)
                            {
                                MessageBox.Show(Messages.PermissionMsg);
                                return;

                            }
                            if (roleId != null || adminRole != null)
                            {
                                var user = unitOfWork.Users.FindFirstOrDefault(x => x.Id == dataList.ElementAt(rowIndex).Id);
                                user.IsDeleted = true;
                                unitOfWork.UserServices.Update(user);
                                unitOfWork.SaveChanges();
                                #region Log
                                var log = new Domains.DailyOperation();
                                log.Date = DateTime.Parse(DateTime.Now.ToString());
                                log.Time = DateTime.Now.TimeOfDay;
                                log.UserId = CurrentUser.UserID;
                                log.UserName = CurrentUser.UserName;
                                log.Description = $"حذف کاربر {user.FirstName} {user.LastName}";
                                log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                                log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                                unitOfWork.DailyOperationServices.Insert(log);
                                unitOfWork.SaveChanges();
                                #endregion
                                loadData();
                            }
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
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Users && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    var frmCurrencies = new UsersCreateUpdateFrm();
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}