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
    public partial class VagozariAsnadDaryaftaniListFrm : DevExpress.XtraEditors.XtraForm
    {
     
        private UnitOfWork unitOfWork;
        private List<ChequeModel> dataList;

        public VagozariAsnadDaryaftaniListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        private void LoadData()
        {
            dataList = unitOfWork.ChequeServices.GetAllVagozarAndOdat();
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
                x.RowId
            }).ToList();

        }


        private void VagozariAsnadDaryaftaniListFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadData();
       
        }

        private void btnvagozariasnad_daryafti_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                var vagozari = new VagozariAsnadDaryaftaniFrm(ChequeNumber, 0);
                vagozari.ShowDialog();
                LoadData();
            }
         

        }

        private void VagozariAsnadDaryaftaniListFrm_KeyUp(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Enter)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {


                    var rowCount = dataList.Count();
                    var rowIndex = dataGridView1.CurrentCell.OwningRow.Index;
                    if (rowIndex == rowCount - 1)
                    {
                        long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                        var vagozari = new VagozariAsnadDaryaftaniFrm(ChequeNumber, 0);
                        vagozari.ShowDialog();
                        LoadData();
                    }
                    if (rowIndex < rowCount - 1)
                    {
                        long ChequeNumber = (long)dataGridView1.SelectedRows[0].Cells[0].Value;
                        var vagozari = new VagozariAsnadDaryaftaniFrm(ChequeNumber, 0);
                        vagozari.ShowDialog();
                        LoadData();
                    }


                }
            }
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                PersianCalendar pc = new PersianCalendar();
                dataList = unitOfWork.ChequeServices.GetAllDaryaftani();
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
                    DueDatePersian = pc.GetYear(x.DueDate).ToString() + "/" + pc.GetMonth(x.DueDate).ToString() + "/" + pc.GetDayOfMonth(x.DueDate).ToString()

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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}