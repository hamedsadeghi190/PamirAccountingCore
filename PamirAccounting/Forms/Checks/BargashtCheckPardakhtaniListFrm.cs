using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
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

namespace PamirAccounting.Forms.Checks
{
    public partial class BargashtCheckPardakhtaniListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ChequeModel> dataList;
        public BargashtCheckPardakhtaniListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }
        private void LoadData()
        {
            PersianCalendar pc = new PersianCalendar();
            dataList = unitOfWork.ChequeServices.GetAllPayment();
            dataGridView1.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.IssueDate,
                x.Description,
                x.DocumentId,
                x.ChequeNumber,
                x.Amount,
                x.BranchName,
                x.BankAccountNumber,
                x.CustomerName,
                x.RealBankName,
                x.DueDate,
                IssueDatePersian = pc.GetYear(x.IssueDate).ToString() + "/" + pc.GetMonth(x.IssueDate).ToString() + "/" + pc.GetDayOfMonth(x.IssueDate).ToString(),
                DueDatePersian = pc.GetYear(x.DueDate).ToString() + "/" + pc.GetMonth(x.DueDate).ToString() + "/" + pc.GetDayOfMonth(x.DueDate).ToString(),
                x.RowId,
                x.BankName,
            }).ToList();

        }

        private void BargashtCheckPardakhtaniListFrm_Load(object sender, EventArgs e)
        {
            txtsearch.Select();
            txtsearch.Focus();
            dataGridView1.AutoGenerateColumns = false;
            LoadData();

        }

        private void BargashtCheckPardakhtaniListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F2)
            {
                txtsearch.Select();
                txtsearch.Focus();
            }
            if (e.KeyCode == Keys.Space)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {


                    var rowCount = dataList.Count();
                    var rowIndex = dataGridView1.CurrentCell.OwningRow.Index;
                    if (rowIndex == rowCount - 1)
                    {
                        long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                        var Pass = new BargashtCheckPardakhtaniFrm(ChequeNumber, 0);
                        Pass.ShowDialog();
                        LoadData();
                    }
                    if (rowIndex < rowCount - 1)
                    {
                        long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                        var Pass = new BargashtCheckPardakhtaniFrm(ChequeNumber, 0);
                        Pass.ShowDialog();
                        LoadData();
                    }


                }
            }
        }

        private void btnbargasht_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                var Pass = new BargashtCheckPardakhtaniFrm(ChequeNumber, 0);
                Pass.ShowDialog();
                LoadData();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtsearch.Text.Length > 0)
            {
                PersianCalendar pc = new PersianCalendar();
                dataList = unitOfWork.ChequeServices.GetAllPayment();
                dataGridView1.DataSource = dataList.Select(x => new
                {
                    x.Id,
                    x.RowId,
                    x.IssueDate,
                    x.Description,
                    x.DocumentId,
                    x.ChequeNumber,
                    x.Amount,
                    x.BranchName,
                    x.BankAccountNumber,
                    x.CustomerName,
                    x.RealBankName,
                    x.DueDate,
                    IssueDatePersian = pc.GetYear(x.IssueDate).ToString() + "/" + pc.GetMonth(x.IssueDate).ToString() + "/" + pc.GetDayOfMonth(x.IssueDate).ToString(),
                    DueDatePersian = pc.GetYear(x.DueDate).ToString() + "/" + pc.GetMonth(x.DueDate).ToString() + "/" + pc.GetDayOfMonth(x.DueDate).ToString(),
                    x.BankName,
                }).Where(x => x.ChequeNumber.Contains(txtsearch.Text)).ToList();

            }
            else
            {
                LoadData();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
     

        }

        private void groupBox4_Enter(object sender, EventArgs e)
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