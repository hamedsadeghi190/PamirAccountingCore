using DevExpress.XtraEditors;
using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;
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

namespace PamirAccounting.Forms.Transactions
{
    public partial class editUnkownDepositFrm : DevExpress.XtraEditors.XtraForm
    {
   
        private UnitOfWork unitOfWork;
        private Domains.Transaction transaction;
        private int Id;
        public editUnkownDepositFrm(int id)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            Id = id;
        }
        private void editUnkownDepositFrm_Load(object sender, EventArgs e)
        {
            transaction = unitOfWork.Transactions.FindAll(x => x.Id == Id).Include(x => x.SourceCustomer).FirstOrDefault();
            if(transaction==null)
            {
                Close();

            }

            txtradif.Text = transaction.Id.ToString();
            txtAmount.Text = transaction.WithdrawAmount.Value.ToString();
            txtReceiptNumber.Text = transaction.ReceiptNumber;
            txtBranchCode.Text = transaction.BranchCode;
            txtBankName.Text = transaction.SourceCustomer.FirstName;
            txtDate.Text = (DateTime.Parse(transaction.Date.ToString())).ToShortPersianDateString();
            txtdesc.Text = transaction.Description;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}