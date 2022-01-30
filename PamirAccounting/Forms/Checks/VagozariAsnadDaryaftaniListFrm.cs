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
            dataList = unitOfWork.ChequeServices.GetAllDaryaftani();
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
                x.DueDate
            }).ToList();

        }


        private void VagozariAsnadDaryaftaniListFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadData();
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 9; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
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
        }
    }
}