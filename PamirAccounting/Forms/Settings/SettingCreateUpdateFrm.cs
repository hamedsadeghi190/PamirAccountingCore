using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

        private void SettingCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            initData();
            LoadData();
        }

        private void initData()
        {
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbBaseCurenccy.DataSource = _Currencies;
            cmbBaseCurenccy.ValueMember = "Id";
            cmbBaseCurenccy.DisplayMember = "Title";

            _CustomersCosts = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();


            cmbConstsAccount.DataSource = _CustomersCosts;
            cmbConstsAccount.ValueMember = "Id";
            cmbConstsAccount.DisplayMember = "Title";

            _CustomersHavaleha.AddRange(_CustomersCosts);
            CmbRemittanceAccount.DataSource = _CustomersHavaleha;
            CmbRemittanceAccount.ValueMember = "Id";
            CmbRemittanceAccount.DisplayMember = "Title";


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
                _Settings = new Domains.Setting()
                {
                    BackupDirectory = txtBackupPath.Text,
                    BaseCurencyId = (int)cmbBaseCurenccy.SelectedValue,
                    CostsAccountId = (int)cmbConstsAccount.SelectedValue,
                    NotRunnedRemittanceId = (int)CmbRemittanceAccount.SelectedValue,
                    DateCalenderType = byte.Parse(CmbCalenderType.SelectedValue.ToString()),
                    PasswordRequired = chkPassRequerid.Checked,
                    ProfitPercent = String.IsNullOrEmpty(txtProfitPercent.Text) ? 0 : double.Parse(txtProfitPercent.Text)
                };


                unitOfWork.SettingServices.Insert(_Settings);
            }
            else
            {

                _Settings.BackupDirectory = txtBackupPath.Text;
                _Settings.BaseCurencyId = (int)cmbBaseCurenccy.SelectedValue;
                _Settings.CostsAccountId = (int)cmbConstsAccount.SelectedValue;
                _Settings.NotRunnedRemittanceId = (int)CmbRemittanceAccount.SelectedValue;
                _Settings.DateCalenderType = byte.Parse(CmbCalenderType.SelectedValue.ToString());
                _Settings.PasswordRequired = chkPassRequerid.Checked;
                _Settings.ProfitPercent = String.IsNullOrEmpty(txtProfitPercent.Text) ? 0 : double.Parse(txtProfitPercent.Text);

                unitOfWork.SettingServices.Update(_Settings);
            }
            unitOfWork.SaveChanges();
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

            }
        }
    }
}