using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PamirAccounting.Tools;

namespace PamirAccounting.UI.Forms.Agencies
{
    public partial class AgencyCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<ComboBoxModel> _Currencies;
        private Agency _agency;
        public AgencyCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public AgencyCreateUpdateFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void AgencyCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            initData();
            if (_Id != null)
            {
                loadBankData();
            }
        }

        private void loadBankData()
        {
            _agency = unitOfWork.Agencies.FindFirst(x => x.Id == _Id);

            txtPhone.Text = _agency.Phone;
            txtName.Text = _agency.Name;
            txtAddress.Text = _agency.Address;
            txtDesc.Text = _agency.Dsc;

            if (_agency.CurrenyId != null)
            {
                cmbCurrencies.SelectedValue = _agency.CurrenyId;
            }
        }

        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbCurrencies.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbCurrencies.AutoCompleteCustomSource = autoCurrencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Id != null)
                {
                    _agency.Name = txtName.Text;
                    _agency.Phone = txtPhone.Text;
                    _agency.Address = txtAddress.Text;
                    _agency.Dsc = txtDesc.Text;
                    _agency.CurrenyId = (int)cmbCurrencies.SelectedValue;
                    unitOfWork.AgencyServices.Update(_agency);
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ویرایش نمایندگی {txtName.Text}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    #endregion
                }
                else
                {
                    var newBank = new Agency()
                    {
                        Name = txtName.Text,
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text,
                        Dsc = txtDesc.Text,
                        CurrenyId = (int)cmbCurrencies.SelectedValue
                    };
                    unitOfWork.AgencyServices.Insert(newBank);
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ثبت نمایندگی {txtName.Text}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Insert);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log);
                
                    #endregion
                }
                unitOfWork.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذخییره تغییرات با شکست مواجه شد");
            }

        }

        private void btnexitbank_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AgencyCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnexitbank_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}