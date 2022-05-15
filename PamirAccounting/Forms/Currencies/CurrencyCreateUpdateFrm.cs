using PamirAccounting.Domains;
using PamirAccounting.Services;
using System;
using System.Windows.Forms;
using static PamirAccounting.Tools;

namespace PamirAccounting.UI.Forms.Currencies
{
    public partial class CurrencyCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        Currency currency;
        public CurrencyCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public CurrencyCreateUpdateFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            try
            {
               if(txtName.Text.Length<=0)
                {
                    return;
                }

                if (_Id != null)
                {
                    currency.Name = txtName.Text;
                    unitOfWork.CurrencyServices.Update(currency);
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ویرایش ارز {currency.Name}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                else
                {
                    unitOfWork.CurrencyServices.Insert(new Currency() { Name = txtName.Text });
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $" ثبت ارز {txtName.Text}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Insert);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }

                unitOfWork.SaveChanges();
                Close();
            }
            catch 
            {
                MessageBox.Show("ذخییره تغییرات با شکست مواجه شد");
            }
           
        }

        private void CurrencyCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            if(_Id!=null)
            {
                currency = unitOfWork.CurrencyServices.FindFirstOrDefault(x => x.Id == _Id.Value);
                txtName.Text = currency.Name;
            }
        }

        private void CurrencyCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
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