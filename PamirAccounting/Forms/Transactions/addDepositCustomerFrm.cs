﻿using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PamirAccounting.Forms.Transactions
{
    public partial class addDepositCustomerFrm : DevExpress.XtraEditors.XtraForm
    {
        public long? Amount { get; set; }
        public long? TotalAmount { get; set; }
        public long? RemaingAmount { get; set; }
        public int? CustomerID { get; set; }
        public string FullName { get; set; }

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
            if (txtAmount.Text.Length > 0)
            {
                if (CustomerID.HasValue )
                {
                    var newRemain = RemaingAmount + Amount;
                    if (  long.Parse(txtAmount.Text) > newRemain)
                    {
                        MessageBox.Show("مقدار از باقی مانده بیشتر است");
                        return;
                    }
                }
                else 
                {
                    if ( long.Parse(txtAmount.Text) > RemaingAmount)
                    {
                        MessageBox.Show("مقدار از باقی مانده بیشتر است");
                        return;
                    }
                }

                this.Amount = long.Parse(txtAmount.Text);
                this.FullName = cmb_customer.Text.ToString();
                this.CustomerID = (int)cmb_customer.SelectedValue;
                Close();
            }
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
            else
            {
                txtAmount.Text = RemaingAmount.Value.ToString();
            }


        }
    }
}