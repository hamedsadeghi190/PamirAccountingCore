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
    public partial class ExecuteDaraftFrm : DevExpress.XtraEditors.XtraForm
    {
        public long _draftId ;
        public ExecuteDaraftFrm(long draftId)
        {
            InitializeComponent();
            _draftId = draftId;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ExecuteDaraftFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}