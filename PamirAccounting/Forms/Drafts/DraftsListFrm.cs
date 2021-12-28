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

namespace PamirAccounting.Forms.Drafts
{
    public partial class DraftsListFrm : DevExpress.XtraEditors.XtraForm
    {
        public DraftsListFrm()
        {
            InitializeComponent();
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 12, FontStyle.Bold);
            HeaderStyle.BackColor = Color.Red;
            for (int i = 0; i < 4; i++)
            {
                gridDrafts.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            foreach (DataGridViewColumn DataGridViewColumn1 in gridDrafts.Columns)
            {
                DataGridViewColumn1.DefaultCellStyle.Font = new Font("B Nazanin", 12);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            groupBoxSearch.Visible = true;
        }
    }
}