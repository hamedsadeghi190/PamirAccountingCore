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
    public partial class AgencyStatusFrm : DevExpress.XtraEditors.XtraForm
    {
        public AgencyStatusFrm()
        {
            InitializeComponent();
        }

        private void btncurrencyexchange_Click(object sender, EventArgs e)
        {
            var CurrencyExchangeFrm = new CurrencyExchangeFrm();
            CurrencyExchangeFrm.ShowDialog(); 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var AgencyStatusSearchFrm = new AgencyStatusSearchFrm();
            AgencyStatusSearchFrm.ShowDialog(); 
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            var BalanceFrm = new BalanceListFrm();
            BalanceFrm.ShowDialog(); 
        }
    }
}