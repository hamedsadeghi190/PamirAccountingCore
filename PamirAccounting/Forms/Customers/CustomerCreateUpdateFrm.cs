using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;
using static PamirAccounting.Tools;

namespace PamirAccounting.UI.Forms.Customers
{
    public partial class CustomerCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private Int64? _Id;
        private List<ComboBoxModel> _Groups;
        private List<ComboBoxModel> _Currencies;
        private Domains.Customer _Customer;
        public CustomerCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public CustomerCreateUpdateFrm(Int64 id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
          
        }

        private void CustomerCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            SetComboBoxHeight(cmbGroups.Handle, 25);
            cmbGroups.Refresh();
            initData();
            if (_Id != null)
            {
                LoadData();
            }
        }
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel()
            {
                Id = x.Id,
                Title = x.Name
            }).ToList();

            cmbCurrencies.DataSource = _Currencies;
            AutoCompleteStringCollection autoCurrencies = new AutoCompleteStringCollection();
            foreach (var item in _Currencies)
            {
                autoCurrencies.Add(item.Title);
            }
            cmbCurrencies.AutoCompleteCustomSource = autoCurrencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _Groups = unitOfWork.CustomerGroupServices.GetAll().Select(x => new ComboBoxModel()
            {
                Id = x.Id.Value,
                Title = x.Name
            }).ToList();

            cmbGroups.DataSource = _Groups;
            AutoCompleteStringCollection autoGroups = new AutoCompleteStringCollection();
            foreach (var item in _Groups)
            {
                autoGroups.Add(item.Title);
            }
            cmbGroups.AutoCompleteCustomSource = autoGroups;
            cmbGroups.ValueMember = "Id";
            cmbGroups.DisplayMember = "Title";
        }

        private void LoadData()
        {
            _Customer = unitOfWork.Customers.FindFirstOrDefault(x => x.Id == _Id);

            txtFirstname.Text = _Customer.FirstName;
            txtLastName.Text = _Customer.LastName;
            txtMobile.Text = _Customer.Mobile;
            txtPhone.Text = _Customer.Phone;
            cmbCurrencies.SelectedValue = _Customer.CreditCurrencyId;
            cmbGroups.SelectedValue = _Customer.GroupId;
            txtDesc.Text = _Customer.Dsc;
            txtCreditLimit.Text = _Customer.CreditLimit.ToString();

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fromValidation())
                {
                    MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید", "مقادیر ورودی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtFirstname.Focus();
                    return;
                }

                if (_Customer != null)
                {
                    _Customer.FirstName = txtFirstname.Text;
                    _Customer.LastName = txtLastName.Text;
                    _Customer.CreditLimit = String.IsNullOrEmpty(txtCreditLimit.Text.Trim()) ? 0 : int.Parse(txtCreditLimit.Text);
                    _Customer.Dsc = txtDesc.Text;
                    _Customer.Phone = txtPhone.Text;
                    _Customer.Mobile = txtMobile.Text;
                    _Customer.CreditCurrencyId = (int)cmbCurrencies.SelectedValue;
                    _Customer.GroupId = (int)cmbGroups.SelectedValue;
                    unitOfWork.CustomerServices.Update(_Customer);
                    unitOfWork.SaveChanges();
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ویرایش مشتری {_Customer.FirstName} {_Customer.LastName}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                else
                {
                    _Customer = new Domains.Customer();

                    _Customer.FirstName = txtFirstname.Text;
                    _Customer.LastName = txtLastName.Text;
                    _Customer.CreditLimit = String.IsNullOrEmpty(txtCreditLimit.Text.Trim()) ? 0 : int.Parse(txtCreditLimit.Text);
                    _Customer.Dsc = txtDesc.Text;
                    _Customer.Phone = txtPhone.Text;
                    _Customer.Mobile = txtMobile.Text;
                    _Customer.CreditCurrencyId = (int)cmbCurrencies.SelectedValue;
                    _Customer.GroupId = (int)cmbGroups.SelectedValue;
                    unitOfWork.CustomerServices.Insert(_Customer);
                    unitOfWork.SaveChanges();
                    #region Log
                    var log = new Domains.DailyOperation();
                    log.Date = DateTime.Parse(DateTime.Now.ToString());
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ثبت مشتری {_Customer.FirstName} {_Customer.LastName}";
                    log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Insert);
                    log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذخیره تغییرات با شکست مواجه شد");
            }

        }

        private bool fromValidation()
        {
            if (String.IsNullOrEmpty(txtFirstname.Text.Trim()))
            {
                return false;
            }
            return true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CustomerCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}