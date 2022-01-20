using DevExpress.XtraEditors;
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
    public partial class SareHesabGozashtanListFrm : DevExpress.XtraEditors.XtraForm
    {
        public SareHesabGozashtanListFrm()
        {
            InitializeComponent();
        }

        private void SareHesabGozashtanFrm_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SareHesabGozashtanListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnsarehesab_Click(object sender, EventArgs e)
        {
             var SareHesabGozashtan = new SareHesabGozashtanFrm();
            SareHesabGozashtan.ShowDialog();
        }
    }
}