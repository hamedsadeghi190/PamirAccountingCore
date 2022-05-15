using DevExpress.XtraEditors;
using PamirAccounting.Domains;
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
using static PamirAccounting.Tools;


namespace PamirAccounting.UI.Forms.GeneralLedger
{
    public partial class ContactsCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        Contact contact;

        public ContactsCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public ContactsCreateUpdateFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
      

        private void insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text.Length <= 0)
                {
                    return;
                }

                if (_Id != null)
                {
                    contact.FirstName = txtFirstName.Text;
                    contact.LastName = txtLastName.Text;
                    contact.FatherName = txtFatherName.Text;
                    contact.Address = txtAddress.Text;
                    contact.Dsc = txtDsc.Text;
                    contact.Phone = txtphone.Text;
                    contact.Mobile = txtMobile.Text;
                    unitOfWork.Contacts.Update(contact);
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ویرایش مخاطب {contact.FirstName} {contact.LastName}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                else
                {
                    unitOfWork.Contacts.Insert(new Contact() {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    FatherName = txtFatherName.Text,
                    Address = txtAddress.Text,
                    Dsc = txtDsc.Text,
                    Phone = txtphone.Text,
                    Mobile = txtMobile.Text,
                    
                });
                    #region Log
                    var log1 = new Domains.DailyOperation();
                    log1.Date = DateTime.Parse(DateTime.Now.ToString());
                    log1.Time = DateTime.Now.TimeOfDay;
                    log1.UserId = CurrentUser.UserID;
                    log1.UserName = CurrentUser.UserName;
                    log1.Description = $"ثبت مخاطب {txtFirstName.Text} {txtLastName.Text}";
                    log1.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Insert);
                    log1.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log1);
                    unitOfWork.SaveChanges();
                    #endregion
                }

             
             
            }
            catch
            {


            }
            Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ContactsCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            if (_Id != null)
            {
                contact = unitOfWork.Contacts.FindFirstOrDefault(x => x.Id == _Id.Value);
                txtFirstName.Text = contact.FirstName;
                txtAddress.Text = contact.Address;
                txtDsc.Text = contact.Dsc;
                txtFatherName.Text = contact.FatherName;
                txtLastName.Text = contact.LastName;
                txtMobile.Text = contact.Mobile;
                txtphone.Text = contact.Phone;

            }
        }

        private void ContactsCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
        {
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