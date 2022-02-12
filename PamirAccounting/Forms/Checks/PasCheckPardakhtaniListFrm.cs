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
    public partial class PasCheckPardakhtaniListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ChequeModel> dataList;
        public PasCheckPardakhtaniListFrm()
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
                x.RowId
            }).ToList();

        }
        private void btnpascheck_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                var Pass = new PasCheckPardakhtaniFrm(ChequeNumber, 0);
                Pass.ShowDialog();
                LoadData();
            }
           
        }

        private void PasCheckPardakhtaniListFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadData();
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
        }

        private void PasCheckPardakhtaniListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                txtsearch.Select();
                txtsearch.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtsearch.Text.Length > 0)
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
                    DueDatePersian = pc.GetYear(x.DueDate).ToString() + "/" + pc.GetMonth(x.DueDate).ToString() + "/" + pc.GetDayOfMonth(x.DueDate).ToString()

                }).Where(x => x.ChequeNumber == txtsearch.Text).ToList();

            }
            else
            {
                LoadData();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                var Pass = new PasCheckPardakhtaniFrm(ChequeNumber, 0);
                Pass.ShowDialog();
                LoadData();
            }

        }
    }
}