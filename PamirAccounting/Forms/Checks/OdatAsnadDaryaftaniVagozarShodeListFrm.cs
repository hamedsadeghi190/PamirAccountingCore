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
    public partial class OdatAsnadDaryaftaniVagozarShodeListFrm : DevExpress.XtraEditors.XtraForm
    {
        public OdatAsnadDaryaftaniVagozarShodeListFrm()
        {
            InitializeComponent();
        }

        private void OdatAsnadDaryaftaniVagozarShodeListFrm_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
        }

        private void OdatAsnadDaryaftaniVagozarShodeListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnodat_asnad_Click(object sender, EventArgs e)
        {
            var odat = new OdatCheckDaryaftaniFrm();
            odat.ShowDialog(); 
        }

        private void btnodat_asnad_ClientSizeChanged(object sender, EventArgs e)
        {

        }
    }
}