using DevExpress.XtraEditors;
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

namespace PamirAccounting.Forms.Transactions
{
    public partial class UnkwonDepositFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<UnKownTransactionModel> _dataList;

        public UnkwonDepositFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
           
        }
        public void LoadData()
        {
            _dataList = unitOfWork.TransactionServices.GetAllUnkowns();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _dataList;
        }

        private void UnkwonDepositFrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                var destForm = new editUnkownDepositFrm(_dataList.ElementAt(e.RowIndex).Id);
                destForm.ShowDialog();
            }

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                //var frmCurrencies = new CustomerCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                //frmCurrencies.ShowDialog();
                //loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                //DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                //    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                //if (dialogResult == DialogResult.Yes)
                //{
                //    try
                //    {
                //        //var customer = unitOfWork.Customers.FindFirstOrDefault(x => x.Id == _dataList.ElementAt(e.RowIndex).Id);
                //        //customer.IsDeleted = true;
                //        //unitOfWork.CustomerServices.Update(customer);
                //        //unitOfWork.SaveChanges();
                //        LoadData();
                //    }
                //    catch
                //    {
                //        MessageBox.Show("حذف امکانپذیر نمیباشد");
                //    }
                //}
            }
        }

    }
}