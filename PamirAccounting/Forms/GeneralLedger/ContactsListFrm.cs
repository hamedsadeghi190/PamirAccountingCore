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

namespace PamirAccounting.UI.Forms.GeneralLedger
{
    public partial class ContactsListFrm : DevExpress.XtraEditors.XtraForm
    {
        public ContactsListFrm()
        {
            InitializeComponent();
        }

        private void CreateContactsBtn_Click(object sender, EventArgs e)
        {
            var FrmContacts = new ContactsCreateUpdateFrm();
            FrmContacts.ShowDialog();
        }
    }
}