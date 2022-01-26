using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Services;
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
        private UnitOfWork unitOfWork;
        private Domains.Header header;
        long DocumentId;
        public DetailsReceiveCheckFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
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

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void DetailsReceiveCheckFrm_Load(object sender, EventArgs e)
        {
            DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
            txtDocumentId.Text = DocumentId.ToString();
        }
    }
}