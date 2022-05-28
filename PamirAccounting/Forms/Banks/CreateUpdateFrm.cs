using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.UI.Forms.Banks
{
    public partial class CreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<ComboBoxModel> _Countries;
        private List<ComboBoxModel> _Currencies;
        private Bank _bank;
        public CreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public CreateUpdateFrm(int id)
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

        private void CreateUpdateFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCurrencies.Handle, 25);
            cmbCurrencies.Refresh();
            SetComboBoxHeight(cmbCountries.Handle, 25);
            cmbCountries.Refresh();
            initData();
            if (_Id != null)
            {
                loadBankData();
            }

        }

        private void loadBankData()
        {
            _bank = unitOfWork.Banks.FindFirst(x => x.Id == _Id);

            txtbalance.Text = _bank.Balance.ToString();
            txtBankName.Text = _bank.Name;
            txtAccountNumber.Text = _bank.AccountNumber;
            txtbranch.Text = _bank.BranchName;
            if (_bank.CountryId != null)
            {

                cmbCountries.SelectedValue = _bank.CountryId;
            }

            if (_bank.BaseCurrencyId != null)
            {
                cmbCurrencies.SelectedValue = _bank.BaseCurrencyId;
            }
        }

        private void initData()
        {
            _Countries = unitOfWork.Countries.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.NameFa }).ToList();
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbCountries.DataSource = _Countries;
            AutoCompleteStringCollection autoCountries = new AutoCompleteStringCollection();
            foreach (var item in _Countries)
            {
                autoCountries.Add(item.Title);
            }
            cmbCountries.AutoCompleteCustomSource = autoCountries;
            cmbCountries.ValueMember = "Id";
            cmbCountries.DisplayMember = "Title";

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
                var dDate = DateTime.Now.ToShortDateString();
                var log = new Domains.DailyOperation();
                if (txtbalance.Text.Length == 0)
                {
                    txtbalance.Text = "0";
                }

                if (_Id != null)
                {
                    _bank.Name = txtBankName.Text;
                    _bank.Balance = long.Parse(txtbalance.Text);
                    _bank.BaseCurrencyId = (int)cmbCurrencies.SelectedValue;
                    _bank.CountryId = (int)cmbCountries.SelectedValue;
                    _bank.AccountNumber = txtAccountNumber.Text;
                    _bank.BranchName = txtbranch.Text;


                    var customer = unitOfWork.Customers.FindFirstOrDefault(x => x.BankId == _bank.Id);

                    if (customer == null)
                    {
                        var bankGroup = unitOfWork.CustomerGroups.FindFirstOrDefault(x => x.Name.Contains("بانک"));
                        var newCustomer = new Customer()
                        {
                            FirstName = txtBankName.Text,
                            CreditCurrencyId = (int)cmbCurrencies.SelectedValue,
                            CountryId = (int)cmbCountries.SelectedValue,
                            GroupId = bankGroup.Id,
                            BankId = _bank.Id,
                            CreditLimit = 1,


                        };

                        unitOfWork.CustomerServices.Insert(newCustomer);
                    }
                    else
                    {
                        customer.FirstName = txtBankName.Text;
                        customer.CreditCurrencyId = (int)cmbCurrencies.SelectedValue;
                        customer.CountryId = (int)cmbCountries.SelectedValue;
                        unitOfWork.CustomerServices.Update(customer);
                    }
                    unitOfWork.BankServices.Update(_bank);
                    unitOfWork.SaveChanges();
                    #region Log
                 
                    log.Date = DateTime.Parse(dDate);
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ویرایش بانک {_bank.Name}";
                    log.ActionText = Tools.GetEnumDescription(ActionType.Update);
                    log.ActionType = (int)ActionType.Update;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                }
                else
                {
                    var newBank = new Bank()
                    {
                        Name = txtBankName.Text,
                        Balance = long.Parse(txtbalance.Text),
                        BaseCurrencyId = (int)cmbCurrencies.SelectedValue,
                        CountryId = (int)cmbCountries.SelectedValue,
                        AccountNumber = txtAccountNumber.Text,
                        BranchName = txtbranch.Text,
                    };

                    unitOfWork.BankServices.Insert(newBank);
                    unitOfWork.SaveChanges();
                    #region Log
                    log.Date = DateTime.Parse(dDate);
                    log.Time = DateTime.Now.TimeOfDay;
                    log.UserId = CurrentUser.UserID;
                    log.UserName = CurrentUser.UserName;
                    log.Description = $"ثبت بانک {txtBankName.Text}";
                    log.ActionText = Tools.GetEnumDescription(ActionType.Insert);
                    log.ActionType = (int)ActionType.Insert;
                    unitOfWork.DailyOperationServices.Insert(log);
                    unitOfWork.SaveChanges();
                    #endregion
                    var bankGroup = unitOfWork.CustomerGroups.FindFirstOrDefault(x => x.Name.Contains("بانک"));

                    if (bankGroup != null)
                    {
                        var newCustomer = new Customer()
                        {
                            FirstName = txtBankName.Text,
                            CreditCurrencyId = (int)cmbCurrencies.SelectedValue,
                            CountryId = (int)cmbCountries.SelectedValue,
                            GroupId = bankGroup.Id,
                            BankId = newBank.Id,
                        };

                        unitOfWork.CustomerServices.Insert(newCustomer);
                        unitOfWork.SaveChanges();
                    }

                 
                }
                Close();
            }
            catch
            {
                MessageBox.Show("ذخیره تغییرات با شکست مواجه شد");
            }
        }

        private void btnexitbank_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtbalance_KeyUp(object sender, KeyEventArgs e)
        {
           //if (e.KeyCode == Keys.Space)
           // {
           //     txtbalance.Text += "000";
           // }
            //txtbalance.Select(txtbalance.Text.Length, 0);

        }
    }

    }
