using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms
{
    public partial class FrmConfirmExit : DevExpress.XtraEditors.XtraForm
    {
        public int ExitMode = 0;
        public FrmConfirmExit()
        {
            InitializeComponent();
        }

        private void FrmConfirmExit_Load(object sender, EventArgs e)
        {
           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExitMode = 0;
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExitMode = 1;
            Close();
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            ExitMode = 3;
            Close();
        }
    }
}