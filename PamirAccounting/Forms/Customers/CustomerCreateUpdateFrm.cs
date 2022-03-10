﻿using DevExpress.XtraEditors;
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
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _Groups = unitOfWork.CustomerGroupServices.GetAll().Select(x => new ComboBoxModel()
            {
                Id = x.Id.Value,
                Title = x.Name
            }).ToList();

            cmbGroups.DataSource = _Groups;
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
                if(!fromValidation())
                {
                    MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید", "مقادیر ورودی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtFirstname.Focus();
                    return;
                }

                if (_Customer != null)
                {
                    _Customer.FirstName = txtFirstname.Text;
                    _Customer.LastName = txtLastName.Text;
                    _Customer.CreditLimit = String.IsNullOrEmpty(txtCreditLimit.Text.Trim()) ?  0: int.Parse(txtCreditLimit.Text);
                    _Customer.Dsc = txtDesc.Text;
                    _Customer.Phone = txtPhone.Text;
                    _Customer.Mobile = txtMobile.Text;
                    _Customer.CreditCurrencyId = (int)cmbCurrencies.SelectedValue;
                    _Customer.GroupId = (int)cmbGroups.SelectedValue;

                    unitOfWork.CustomerServices.Update(_Customer);
                    unitOfWork.SaveChanges();
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
            throw new NotImplementedException();
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