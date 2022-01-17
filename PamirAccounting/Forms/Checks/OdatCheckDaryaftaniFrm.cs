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
    public partial class OdatCheckDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
    {
        public OdatCheckDaryaftaniFrm()
        {
            InitializeComponent();
        }

        private void BtnClose_ClientSizeChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OdatCheckDaryaftaniFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void OdatCheckDaryaftaniFrm_Load(object sender, EventArgs e)
        {

        }
    }
}