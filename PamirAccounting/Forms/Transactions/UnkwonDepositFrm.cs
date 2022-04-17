using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Models;
using PamirAccounting.Services;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            txtDate.Text = DateTime.Now.ToFarsiFormat();
            LoadData();
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn f = (DataGridViewButtonColumn)dataGridView1.Columns["btnAction"];
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
                var frmbankunkown = new PayAndReciveBankFrm(0, _dataList.ElementAt(e.RowIndex).Id);
                frmbankunkown.ShowDialog();
                LoadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var transaction = unitOfWork.TransactionServices.FindFirstOrDefault(x => x.Id == _dataList.ElementAt(e.RowIndex).Id);
                        unitOfWork.CustomerServices.Delete(transaction);
                        unitOfWork.SaveChanges();
                        LoadData();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UnkwonDepositFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtDate.Select();
                txtDate.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();


            if (e.KeyCode == Keys.Enter)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {

                    var size = _dataList.ElementAt(_dataList.Count() - 1);
                    var rowCount = _dataList.Count();
                    var rowIndex = dataGridView1.CurrentCell.OwningRow.Index;
                    if (rowIndex == rowCount - 1)
                    {
                        var destForm = new editUnkownDepositFrm(_dataList.ElementAt(rowIndex).Id);
                        destForm.ShowDialog();
              
                        return;
                    }
                    if (rowIndex < rowCount - 1)
                    {
                        var destForm = new editUnkownDepositFrm(_dataList.ElementAt(rowIndex).Id);
                        destForm.ShowDialog();
                     
                    }


                }
            }


            if (e.KeyCode == Keys.F8)
            {
               var rowIndex = dataGridView1.SelectedRows[0].Index;
                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var transaction = unitOfWork.TransactionServices.FindFirstOrDefault(x => x.Id == _dataList.ElementAt(rowIndex).Id);
                        unitOfWork.CustomerServices.Delete(transaction);
                        unitOfWork.SaveChanges();
                        LoadData();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }
                }
            }

            if (e.KeyCode == Keys.F7)
            {
                var rowIndex = dataGridView1.SelectedRows[0].Index;
                var frmbankunkown = new PayAndReciveBankFrm(0, _dataList.ElementAt(rowIndex).Id);
                frmbankunkown.ShowDialog();
                LoadData();
            }
            if (e.KeyCode == Keys.F5)
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Now;
                string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                var data = unitOfWork.TransactionServices.GetAllUnkowns();
                var basedata = new reportbaseDAta() { Date = PersianDate };
                var report = StiReport.CreateNewReport();
                report.Load(AppSetting.ReportPath + "UnkwonDepositList.mrt");
                report.RegData("myData", data);
                report.RegData("basedata", basedata);
                //report.Design();
                report.Render();
                report.Show();
            }
        }

      

        private void txtBranchCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBranchCode.Text.Length > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllUnkowns_Search(txtDate.Text, txtBranchCode.Text, txtNumber.Text);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _dataList;

            }
            else
                LoadData();
        }

        private void txtNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumber.Text.Length > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllUnkowns_Search(txtDate.Text, txtBranchCode.Text, txtNumber.Text);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _dataList;

            }
            else
                LoadData();
        }

        private void txtDate_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (txtDate.Text.Length > 0)
            {
                var dDate = txtDate.Text.Split('_');
                if (dDate[0].Length == 10)
                {
                    _dataList = unitOfWork.TransactionServices.GetAllUnkowns_Search(txtDate.Text, txtBranchCode.Text, txtNumber.Text);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = _dataList;
                }
                else
                    return;
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var data = unitOfWork.TransactionServices.GetAllUnkowns();
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "UnkwonDepositList.mrt");
            report.RegData("myData", data);
            report.RegData("basedata", basedata);
           // report.Design();
            report.Render();
            report.Show();
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