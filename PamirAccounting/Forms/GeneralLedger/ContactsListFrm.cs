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
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
            HeaderStyle.BackColor = Color.Red;
            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
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
            loadData();
     
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmContact = new ContactsCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id.Value);
                frmContact.ShowDialog();
                loadData();
            }

            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف مخاطب", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        unitOfWork.Contacts.Delete(new Contact() { Id = dataList.ElementAt(e.RowIndex).Id.Value });
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
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F2)
            {
                txtsearch.Select();
                txtsearch.Focus();
            }
        }
    }
}