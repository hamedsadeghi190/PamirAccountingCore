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
    public partial class RateListFrm : DevExpress.XtraEditors.XtraForm
    {
        public RateListFrm()
        {
            InitializeComponent();
        
         
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var RateCreateUpdateFrm = new RateCreateUpdateFrm();
            RateCreateUpdateFrm.ShowDialog();
        }
    }
}