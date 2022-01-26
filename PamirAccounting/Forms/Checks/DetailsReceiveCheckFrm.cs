using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private List<ComboBoxModel> _RealBank, _Customers;
        public Domains.Cheque Cheque;
        public int? CustomerId;
        public DetailsReceiveCheckFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void LoadData()
        {
            _RealBank = unitOfWork.RealBankServices.FindAll(x => x.Id > 0).Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.Name}" }).ToList();
            cmbRealBankId.DataSource = _RealBank;
            cmbRealBankId.ValueMember = "Id";
            cmbRealBankId.DisplayMember = "Title";
            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title"; ;

        }

        private void btnshowcustomer_Click(object sender, EventArgs e)
        {
            var AllCustomersFrm = new SearchAllCustomersFrm();
            AllCustomersFrm.ShowDialog();
            if (AllCustomersFrm.CustomerId.HasValue)
            {
                cmbCustomers.SelectedValue = AllCustomersFrm.CustomerId;

            }
        }



        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void DetailsReceiveCheckFrm_Load(object sender, EventArgs e)
        {
            LoadData();
            DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
            txtDocumentId.Text = DocumentId.ToString();

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtIssueDate.Text = PDate;
            string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDueDate.Text = PDate2;
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    txtAmount.Text += "000";
                }
                lblNumberString.Text = NumberUtility.GetString(txtAmount.Text.Replace(",", ""));
            }
            catch (Exception EX)
            {

                throw;
            }


        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            SaveEdit();


            Close();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveEdit()
        {
            Cheque = new Domains.Cheque();
            var dIssueDate = txtIssueDate.Text.Split('/');
            PersianCalendar p = new PersianCalendar();
            var IssueDateDateTime = p.ToDateTime(int.Parse(dIssueDate[0]), int.Parse(dIssueDate[1]), int.Parse(dIssueDate[2]), 0, 0, 0, 0);
            var dDueDate = txtIssueDate.Text.Split('/');
            var DueDateDateTime = p.ToDateTime(int.Parse(dDueDate[0]), int.Parse(dDueDate[1]), int.Parse(dDueDate[2]), 0, 0, 0, 0);
            Cheque.UserId = CurrentUser.UserID;
            Cheque.IssueDate = IssueDateDateTime;
            Cheque.DueDate = DueDateDateTime;
            Cheque.BranchName = txtBranchName.Text;
            Cheque.ChequeNumber = txtChequeNumber.Text;
            Cheque.DocumentId = long.Parse(txtDocumentId.Text);
            Cheque.Description = txtDescription.Text;
            Cheque.Amount = long.Parse(txtAmount.Text);
            Cheque.RealBankId = (byte)(int)cmbRealBankId.SelectedValue;
            Cheque.RegisterDateTime = DateTime.Now;
            Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
            Cheque.BankAccountNumber = txtBankAccountNumber.Text;
            unitOfWork.ChequeServices.Insert(Cheque);
            unitOfWork.SaveChanges();
        }
    }
}