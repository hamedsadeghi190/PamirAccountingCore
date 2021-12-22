using DevExpress.XtraEditors;
using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using PamirAccounting.UI.Forms.Customers;
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
    public partial class FrmCustomerList : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<CustomerModel> dataList;
        private List<CustomerGroupModel> _Groups;
        public FrmCustomerList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            _Groups = unitOfWork.CustomerGroupServices.GetAll();
            cmbGroups.DataSource = _Groups;
            cmbGroups.ValueMember = "Id";
            cmbGroups.DisplayMember = "Name";

            dataList = unitOfWork.CustomerServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Phone,
                x.Mobile,
                x.GroupName
            }).ToList();

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnView"].Index && e.RowIndex >= 0)
            {

                var destForm = new ViewCustomerAccountFrm(dataList.ElementAt(e.RowIndex).Id);
                destForm.ShowDialog();
            }

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CustomerCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف مشتری", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var customer = unitOfWork.Customers.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id);
                        customer.IsDeleted = true;
                        unitOfWork.CustomerServices.Update(customer);
                        unitOfWork.SaveChanges();
                        loadData();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void CreatBankBtn_Click(object sender, EventArgs e)
        {
            var frmCurrencies = new CustomerCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }
    }
}