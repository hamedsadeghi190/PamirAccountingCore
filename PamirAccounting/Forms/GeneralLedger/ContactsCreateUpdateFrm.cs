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
                }

                unitOfWork.SaveChanges();
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
    }
}