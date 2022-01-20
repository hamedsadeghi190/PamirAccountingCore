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
    public partial class OdatCheckDaryaftaniListFrm : DevExpress.XtraEditors.XtraForm
    {
        public OdatCheckDaryaftaniListFrm()
        {
            InitializeComponent();
        }

        private void OdatCheckDaryaftaniListFrm_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
        }

        private void btnodat_daryaftani_Click(object sender, EventArgs e)
        {
            var OdatCheckDaryaftani = new OdatCheckDaryaftaniFrm();
            OdatCheckDaryaftani.ShowDialog();
        }

        private void OdatCheckDaryaftaniListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnodat_daryaftani_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnprint.Focus();
            }

        }

        private void btnprint_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnhelp.Focus();
            }
        }

        private void btnhelp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsearch.Focus();
            }

        }
    }
}