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

namespace PamirAccounting.UI.Forms.Users
{
    public partial class UsersCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private User _user;
        private UserInRole _userInRole;
        private List<ComboBoxModel> _agencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Customers = new List<ComboBoxModel>();
        private List<Role> _role = new List<Role>();

        public UsersCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public UsersCreateUpdateFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void groupControlCreateUpdateUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void UsersCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            var _list = new List<RoleModel>();
          //  var role = new List<RoleModel>();
            var role = unitOfWork.RolesServices.GetAll();
            foreach (var item in role)
            {
                chkAccessLevel.Items.Add(item.Name);

            }
        

            SetComboBoxHeight(cmbAgency.Handle, 25);
            cmbAgency.Refresh();
            SetComboBoxHeight(cmbCurrency.Handle, 25);
            cmbCurrency.Refresh();
            SetComboBoxHeight(CmbSandogh.Handle, 25);
            CmbSandogh.Refresh();
            initData();

            if (_Id != null)
            {
                loadEditData();
            }
        }

        private void loadEditData()
        {
            _user = unitOfWork.Users.FindFirstOrDefault(x => x.Id == _Id);

            if (_user != null)
            {
                txtFirstName.Text = _user.FirstName;
                txtLastName.Text = _user.LastName;
                txtUserName.Text = _user.UserName;
                txtPass.Text = Base64Decode(_user.Password);
                txtPassRepeat.Text = Base64Decode(_user.Password);
                cmbAgency.SelectedValue = _user.AgentId;
                cmbCurrency.SelectedValue = _user.CurrenyId;
                CmbSandogh.SelectedValue = _user.CustomerId;
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            cmbCurrency.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbCurrency.AutoCompleteCustomSource = autoCurrencies;
            cmbCurrency.ValueMember = "Id";
            cmbCurrency.DisplayMember = "Title";

            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbAgency.DataSource = _agencies;
            AutoCompleteStringCollection autoAgencies = new AutoCompleteStringCollection();
            foreach (var item in _agencies)
            {
                autoAgencies.Add(item.Title);
            }
            cmbAgency.AutoCompleteCustomSource = autoAgencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";

            _Customers = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName} " }).ToList();
            CmbSandogh.DataSource = _Customers;
            AutoCompleteStringCollection autoCustomers = new AutoCompleteStringCollection();
            foreach (var item in _Customers)
            {
                autoCustomers.Add(item.Title);
            }
            CmbSandogh.AutoCompleteCustomSource = autoCustomers;
            CmbSandogh.ValueMember = "Id";
            CmbSandogh.DisplayMember = "Title";
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (_user != null)
            {
                _user.FirstName = txtFirstName.Text;
                _user.LastName = txtLastName.Text;
                _user.UserName = txtUserName.Text;
                _user.Password = Base64Encode(txtPass.Text);
                _user.AgentId = (int)cmbAgency.SelectedValue;
                _user.CurrenyId = (int)cmbCurrency.SelectedValue;
                _user.CustomerId = (int)CmbSandogh.SelectedValue;
                unitOfWork.UserServices.Update(_user);
                unitOfWork.SaveChanges();
                #region Log
                var log = new Domains.DailyOperation();
                log.Date = DateTime.Parse(DateTime.Now.ToString());
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.Description = $"ویرایش اطلاعات کاربر {_user.FirstName} {_user.LastName}";
                log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion
            }
            else
            {

                _user = new User();
                _userInRole = new UserInRole();
                _user.FirstName = txtFirstName.Text;
                _user.LastName = txtLastName.Text;
                _user.UserName = txtUserName.Text;
                _user.Password = Base64Encode(txtPass.Text);
                _user.AgentId = (int)cmbAgency.SelectedValue;
                _user.CurrenyId = (int)cmbCurrency.SelectedValue;
                _user.CustomerId = (int)CmbSandogh.SelectedValue;
                unitOfWork.UserServices.Insert(_user);
                unitOfWork.SaveChanges();
                for (int i = 0; i < chkAccessLevel.ItemCount; i++)
                {
                    _userInRole.UserId = _user.Id;
                    _userInRole.RoleId = unitOfWork.Role.FindFirstOrDefault(x => x.Name == chkAccessLevel.CheckedItems[i].ToString()).Id;
                    unitOfWork.UserInRole.Insert(_userInRole);
                    unitOfWork.SaveChanges();
                }

              
                #region Log
                var log = new Domains.DailyOperation();
                log.Date = DateTime.Parse(DateTime.Now.ToString());
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.Description = $"ثبت کاربر {_user.FirstName} {_user.LastName}";
                log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Insert);
                log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Insert;
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion
            }


            Close();

        }

        private void UsersCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
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