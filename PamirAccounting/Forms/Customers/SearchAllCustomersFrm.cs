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
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 2; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
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

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SearchAllCustomersFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
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
    }
}
