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
    public partial class CurrencyExchangeFrm : DevExpress.XtraEditors.XtraForm
    {
        public long DraftId { get; set; }
        public CurrencyExchangeFrm(long draftId)
        {
            InitializeComponent();
            DraftId = draftId;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}