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

namespace PamirAccounting.Forms.GeneralLedger
{
    public partial class TotalBalanceFrm : DevExpress.XtraEditors.XtraForm
    {
        public TotalBalanceFrm()
        {
            InitializeComponent();
        }

        

        private void TotalBalanceFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnStatusList_Click(object sender, EventArgs e)
        {
            var Frm = new StatusListFrm();
            Frm.ShowDialog();
        }

        private void TotalBalanceFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}