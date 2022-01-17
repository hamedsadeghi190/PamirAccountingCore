using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
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
    public partial class DetailsReceiveCheckFrm : DevExpress.XtraEditors.XtraForm
    {
        public DetailsReceiveCheckFrm()
        {
            InitializeComponent();
        }

        private void btnshowcustomer_Click(object sender, EventArgs e)
        {
        var AllCustomersFrm = new SearchAllCustomersFrm();
            AllCustomersFrm.ShowDialog();
        }

        private void btnshowcustomer2_Click(object sender, EventArgs e)
        {
            var AllCustomersFrm = new SearchAllCustomersFrm();
            AllCustomersFrm.ShowDialog();
        }
    }
}