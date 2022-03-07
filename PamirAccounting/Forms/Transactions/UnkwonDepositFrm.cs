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
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("IRANSansMobile(FaNum)", 11, FontStyle.Bold);
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn f= (DataGridViewButtonColumn)dataGridView1.Columns["btnAction"];
            f.FlatStyle = FlatStyle.Standard;
            f.DefaultCellStyle.ForeColor = Color.SteelBlue;
            f.DefaultCellStyle.BackColor = Color.Lavender;
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["btnAction"].Index && e.RowIndex >= 0)
            {
                var destForm = new editUnkownDepositFrm(_dataList.ElementAt(e.RowIndex).Id);
                destForm.ShowDialog();
                LoadData();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UnkwonDepositFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}