using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;

namespace PamirAccounting.Forms.Transactions
{
    public partial class addDepositCustomerFrm : DevExpress.XtraEditors.XtraForm
    {
        public double? Amount { get; set; }
        public double? TotalAmount { get; set; }
        public double? RemaingAmount { get; set; }
        public int? CustomerID { get; set; }
        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<CustomerModel> _Customers;
        public addDepositCustomerFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Amount = double.Parse(txtAmount.Text);
            this.CustomerID = (int)cmb_customer.SelectedValue;
            Close();
        }

        private void addDepositCustomerFrm_Load(object sender, EventArgs e)
        {
            _Customers = unitOfWork.CustomerServices.GetAll();
            cmb_customer.DataSource = _Customers;
            cmb_customer.DisplayMember = "FullName";
            cmb_customer.ValueMember = "Id";

            if (CustomerID.HasValue)
            {
                cmb_customer.SelectedValue = CustomerID.Value;
                txtAmount.Text = Amount.Value.ToString();
            }



        }
    }
}