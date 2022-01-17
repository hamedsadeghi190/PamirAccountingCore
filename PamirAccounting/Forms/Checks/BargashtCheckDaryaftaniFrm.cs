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
    public partial class BargashtCheckDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
    {
        public BargashtCheckDaryaftaniFrm()
        {
            InitializeComponent();
        }

        private void BargashtCheckDaryaftaniFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}