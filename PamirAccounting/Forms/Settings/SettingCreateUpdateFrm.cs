using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;
using static PamirAccounting.Tools;

namespace PamirAccounting.UI.Forms.Settings
{
    public partial class SettingCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private Domains.Setting _Settings;
        private List<ComboBoxModel> _CustomersCosts, _Currencies;
        private List<ComboBoxModel> _CalenderType = new List<ComboBoxModel>();
        private List<ComboBoxModel> _CustomersHavaleha = new List<ComboBoxModel>();

        public SettingCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void SettingCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbBaseCurenccy.Handle, 25);
            cmbBaseCurenccy.Refresh();
            SetComboBoxHeight(cmbConstsAccount.Handle, 25);
            cmbConstsAccount.Refresh();
            SetComboBoxHeight(CmbCalenderType.Handle, 25);
            CmbCalenderType.Refresh();
            SetComboBoxHeight(CmbRemittanceAccount.Handle, 25);
            CmbRemittanceAccount.Refresh();
            SetComboBoxHeight(comboBox4.Handle, 25);
            comboBox4.Refresh();
            initData();
            LoadData();
        }

        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbBaseCurenccy.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbBaseCurenccy.AutoCompleteCustomSource = autoCurrencies;
            cmbBaseCurenccy.ValueMember = "Id";
            cmbBaseCurenccy.DisplayMember = "Title";
            ////////////////////////////////////////////////
            _CustomersCosts = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            cmbConstsAccount.DataSource = _CustomersCosts;
            AutoCompleteStringCollection autoCustomersCosts = new AutoCompleteStringCollection();
            foreach (var item in _CustomersCosts)
            {
                autoCustomersCosts.Add(item.Title);
            }
            cmbConstsAccount.AutoCompleteCustomSource = autoCustomersCosts;
            cmbConstsAccount.ValueMember = "Id";
            cmbConstsAccount.DisplayMember = "Title";
            ///////////////////////////////////////////////
            _CustomersHavaleha.AddRange(_CustomersCosts);
            CmbRemittanceAccount.DataSource = _CustomersHavaleha;
            AutoCompleteStringCollection auto_CustomersCosts = new AutoCompleteStringCollection();
            foreach (var item in _CustomersCosts)
            {
                auto_CustomersCosts.Add(item.Title);
            }
            CmbRemittanceAccount.AutoCompleteCustomSource = auto_CustomersCosts;
            CmbRemittanceAccount.ValueMember = "Id";
            CmbRemittanceAccount.DisplayMember = "Title";
            //////////////////////////////////////////////////

            _CalenderType.Add(new ComboBoxModel() { Id = 1, Title = "شمسی" });
            _CalenderType.Add(new ComboBoxModel() { Id = 2, Title = "میلادی" });
            CmbCalenderType.DataSource = _CalenderType;
            CmbCalenderType.ValueMember = "Id";
            CmbCalenderType.DisplayMember = "Title";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var result = BackupFBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBackupPath.Text = BackupFBD.SelectedPath;
            }
        }



        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (_Settings == null)
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Settings && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    _Settings = new Domains.Setting()
                    {
                        BackupDirectory = txtBackupPath.Text,
                        FlashBackupDirectory = txtFlashBackupPath.Text,
                        BaseCurencyId = (int)cmbBaseCurenccy.SelectedValue,
                        CostsAccountId = (int)cmbConstsAccount.SelectedValue,
                        NotRunnedRemittanceId = (int)CmbRemittanceAccount.SelectedValue,
                        DateCalenderType = byte.Parse(CmbCalenderType.SelectedValue.ToString()),
                        PasswordRequired = chkPassRequerid.Checked,
                        ProfitPercent = String.IsNullOrEmpty(txtProfitPercent.Text) ? 0 : double.Parse(txtProfitPercent.Text)
                    };
                    unitOfWork.SettingServices.Insert(_Settings);
                    unitOfWork.SaveChanges();
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = "ثبت تنظیمات اصلی برنامه";
                    log.ActionText = GetEnumDescription(Commons.Enums.Settings.ActionType.Insert);
                    log.ActionType = (int)Commons.Enums.Settings.ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                }
            else
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Settings && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    _Settings.FlashBackupDirectory = txtFlashBackupPath.Text;
                    _Settings.BackupDirectory = txtBackupPath.Text;
                    _Settings.BaseCurencyId = (int)cmbBaseCurenccy.SelectedValue;
                    _Settings.CostsAccountId = (int)cmbConstsAccount.SelectedValue;
                    _Settings.NotRunnedRemittanceId = (int)CmbRemittanceAccount.SelectedValue;
                    _Settings.DateCalenderType = byte.Parse(CmbCalenderType.SelectedValue.ToString());
                    _Settings.PasswordRequired = chkPassRequerid.Checked;
                    _Settings.ProfitPercent = String.IsNullOrEmpty(txtProfitPercent.Text) ? 0 : double.Parse(txtProfitPercent.Text);
                    unitOfWork.SettingServices.Update(_Settings);
                    unitOfWork.SaveChanges();
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = "ویرایش تنظیمات اصلی برنامه";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
            }

            Close();
        }

        private void btnexit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSelectFlashBackupPath_Click(object sender, EventArgs e)
        {
            var result = BackupFBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFlashBackupPath.Text = BackupFBD.SelectedPath;
            }
        }

        private void LoadData()
        {
            _Settings = unitOfWork.Setting.FindFirstOrDefault();
            if (_Settings != null)
            {
                txtBackupPath.Text = _Settings.BackupDirectory;
                cmbBaseCurenccy.SelectedValue = _Settings.BaseCurencyId;
                cmbConstsAccount.SelectedValue = _Settings.CostsAccountId;
                CmbRemittanceAccount.SelectedValue = _Settings.NotRunnedRemittanceId;
                CmbCalenderType.SelectedValue = (int)_Settings.DateCalenderType;
                chkPassRequerid.Checked = _Settings.PasswordRequired;
                txtProfitPercent.Text = _Settings.ProfitPercent.ToString();
                txtFlashBackupPath.Text = _Settings.FlashBackupDirectory;
            }
        }
    }
}