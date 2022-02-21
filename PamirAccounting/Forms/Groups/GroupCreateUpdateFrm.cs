using PamirAccounting.Domains;
using PamirAccounting.Services;
using System;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Groups
{
    public partial class GroupCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        CustomerGroup group;
        public GroupCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public GroupCreateUpdateFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
    

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupControlCreateUpdate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GroupCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            if (_Id != null)
            {
                group = unitOfWork.CustomerGroups.FindFirstOrDefault(x => x.Id == _Id.Value);
                txtName.Text = group.Name;
            }
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length <= 0)
                {
                    return;
                }

                if (_Id != null)
                {
                    group.Name = txtName.Text;
                    unitOfWork.CustomerGroupServices.Update(group);
                }
                else
                {
                    unitOfWork.CustomerGroupServices.Insert(new CustomerGroup() { Name = txtName.Text });
                }

                unitOfWork.SaveChanges();
            }
            catch 
            {

               
            }
            Close();
        }

        private void GroupCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
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