using DevExpress.XtraEditors;
using PamirAccounting.Forms.Checks;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Customers
{
    public partial class SearchAllCustomersFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<CustomerModel> dataList;
        private List<CustomerGroupModel> _Groups;
        public int? CustomerId;
        public SearchAllCustomersFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        private void loadData()
        {
            dataList = unitOfWork.CustomerServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.FullName,
            }).ToList();

        }
        private void SearchAllCustomersFrm_Load(object sender, EventArgs e)
        {
            loadData();
            txtsearch.Focus();


        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                dataList = unitOfWork.Customers.FindAll(y => y.FirstName.Contains(txtsearch.Text) || y.LastName.Contains(txtsearch.Text)).Select(x => new CustomerModel { Id = x.Id, FullName = x.FirstName + " " + x.LastName }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    CustomerId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    int x = 0;
                }
                Close();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SearchAllCustomersFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close(); if (e.KeyCode == Keys.F2)
            {
                txtsearch.Select();
                txtsearch.Focus();
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.CurrentRow !=null )
                {
                    CustomerId =(int) dataGridView1.CurrentRow.Cells[0].Value;
                    int x = 0;
                }
                Close();
            }
        }

        private void txtsearch_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
