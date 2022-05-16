using PamirAccounting.Domains;
using PamirAccounting.Services;
using System;
using System.Windows.Forms;
using static PamirAccounting.Tools;

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
                    unitOfWork.SaveChanges();
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ویرایش گروه {txtName.Text}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                else
                {
                    unitOfWork.CustomerGroupServices.Insert(new CustomerGroup() { Name = txtName.Text });
                    unitOfWork.SaveChanges();
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ثبت گروه {txtName.Text}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Insert);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }


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