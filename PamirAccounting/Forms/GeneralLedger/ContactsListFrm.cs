using DevExpress.Xpo;
using DevExpress.XtraEditors;
using PamirAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PamirAccounting.Domains;
using PamirAccounting.Services;
using UnitOfWork = PamirAccounting.Services.UnitOfWork;
using static PamirAccounting.Tools;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.UI.Forms.GeneralLedger
{
    public partial class ContactsListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ContactModel> dataList;
        public ContactsListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

      
        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
           
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
            dataList = unitOfWork.Contacts.FindAll().Select(x => new ContactModel { Id = x.Id, FirstName=x.FirstName,LastName=x.LastName,Phone=x.Phone,
            Mobile=x.Mobile
            }).ToList();
            dataGridView1.DataSource = dataList;
        }

        private void CreateContactsBtn_Click(object sender, EventArgs e)
        {
            var FrmContacts = new ContactsCreateUpdateFrm();
            FrmContacts.ShowDialog(); 
            loadData();
        }

        private void ContactsListFrm_Load(object sender, EventArgs e)
        {
            var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
            var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Contact && x.UserId == CurrentUser.UserID);
            if (roleId == null && adminRole == null)
            {
                CreateContactsBtn.Enabled = false;

            }
            loadData();

        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Contact && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    var frmContact = new ContactsCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id.Value);
                    frmContact.ShowDialog();
                    loadData();
                }
            }

            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف مخاطب", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                        var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.DeleteContact && x.UserId == CurrentUser.UserID);
                        if (roleId == null && adminRole == null)
                        {
                            MessageBox.Show(Messages.PermissionMsg);
                            return;

                        }
                        if (roleId != null || adminRole != null)
                        {
                            var contact = unitOfWork.Contacts.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id.Value);
                            unitOfWork.Contacts.Delete(contact.Id);
                            unitOfWork.SaveChanges();
                            #region Log
                            var log = new Domains.DailyOperation();
                            log.Date = DateTime.Parse(DateTime.Now.ToString());
                            log.Time = DateTime.Now.TimeOfDay;
                            log.UserId = CurrentUser.UserID;
                            log.UserName = CurrentUser.UserName;
                            log.Description = $"حذف مخاطب {contact.FirstName} {contact.LastName}";
                            log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                            log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                            unitOfWork.DailyOperationServices.Insert(log);
                            unitOfWork.SaveChanges();
                            #endregion
                            loadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                dataList = unitOfWork.Contacts.FindAll(y => y.FirstName.Contains(txtsearch.Text)).Select(x => new ContactModel { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, Phone = x.Phone, Mobile = x.Mobile }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void ContactsListFrm_KeyUp(object sender, KeyEventArgs e)
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

            if (e.KeyCode == Keys.F7)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                    var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Contact && x.UserId == CurrentUser.UserID);
                    if (roleId == null && adminRole == null)
                    {
                        MessageBox.Show(Messages.PermissionMsg);
                        return;

                    }
                    if (roleId != null || adminRole != null)
                    {
                        var rowIndex = dataGridView1.SelectedRows[0].Index;
                        var frmContact = new ContactsCreateUpdateFrm(dataList.ElementAt(rowIndex).Id.Value);
                        frmContact.ShowDialog();
                        loadData();
                    }
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف مخاطب", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                            var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.DeleteContact && x.UserId == CurrentUser.UserID);
                            if (roleId == null && adminRole == null)
                            {
                                MessageBox.Show(Messages.PermissionMsg);
                                return;

                            }
                            if (roleId != null || adminRole != null)
                            {
                                var contact = unitOfWork.Contacts.FindFirstOrDefault(x => x.Id == dataList.ElementAt(rowIndex).Id.Value);
                                unitOfWork.Contacts.Delete(contact.Id);
                                unitOfWork.SaveChanges();
                                #region Log
                                var log = new Domains.DailyOperation();
                                log.Date = DateTime.Parse(DateTime.Now.ToString());
                                log.Time = DateTime.Now.TimeOfDay;
                                log.UserId = CurrentUser.UserID;
                                log.UserName = CurrentUser.UserName;
                                log.Description = $"حذف مخاطب {contact.FirstName} {contact.LastName}";
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
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Contact && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    var FrmContacts = new ContactsCreateUpdateFrm();
                    FrmContacts.ShowDialog();
                    loadData();
                }

            }
        }
    }
}