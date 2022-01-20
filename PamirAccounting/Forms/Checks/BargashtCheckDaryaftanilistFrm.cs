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
    public partial class BargashtCheckDaryaftanilistFrm : DevExpress.XtraEditors.XtraForm
    {
        public BargashtCheckDaryaftanilistFrm()
        {
            InitializeComponent();
        }

      

        private void BargashtCheckDaryaftanilistFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void BargashtCheckDaryaftanilistFrm_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
        }

        private void btnbargasht_Click(object sender, EventArgs e)
        {
            var bargasht = new BargashtCheckDaryaftaniFrm();
            bargasht.ShowDialog();
        }
    }
}