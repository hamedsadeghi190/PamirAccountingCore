using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Users
{
    public partial class UsersCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private User _user;
        private List<ComboBoxModel> _agencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Customers = new List<ComboBoxModel>();

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

        private void UsersCreateUpdateFrm_Load(object sender, EventArgs e)
        {
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
            cmbCurrency.ValueMember = "Id";
            cmbCurrency.DisplayMember = "Title";

            _agencies = unitOfWork.Agencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            cmbAgency.DataSource = _agencies;
            cmbAgency.ValueMember = "Id";
            cmbAgency.DisplayMember = "Title";

            _Customers = unitOfWork.Customers.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName} " }).ToList();
            CmbSandogh.DataSource = _Customers;
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
            }
            else
            {
                _user = new User();

                _user.FirstName = txtFirstName.Text;
                _user.LastName = txtLastName.Text;
                _user.UserName = txtUserName.Text;
                _user.Password = Base64Encode(txtPass.Text);
                _user.AgentId = (int)cmbAgency.SelectedValue;
                _user.CurrenyId = (int)cmbCurrency.SelectedValue;
                _user.CustomerId = (int)CmbSandogh.SelectedValue;

                unitOfWork.UserServices.Insert(_user);
            }

            unitOfWork.SaveChanges();
            Close();

        }



    }
}