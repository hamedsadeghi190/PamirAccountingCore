using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

        private void AgencyCreateUpdateFrm_Load(object sender, EventArgs e)
        {
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
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

        }

        private void btnsavebank_Click_1(object sender, EventArgs e)
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
    }
}