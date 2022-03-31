using DevExpress.XtraEditors;
using PamirAccounting.Commons.Enums;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Checks
{
    public partial class VagozariAsnadDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        long DocumentId;
        private List<ComboBoxModel> _RealBank, _Customers;
        public int? CustomerId;
        private long? _ChequeNumber;
        private long? _ChequeNumberEdit;
        public int? prevCustomerId;
        public int? orginalCustomerId;
        public Domains.Transaction receiveTransAction;
        public Domains.Transaction customerTransaction;
        public Domains.Cheque Cheque;
        string customerName;
        public VagozariAsnadDaryaftaniFrm(long? chequeNumber, long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public VagozariAsnadDaryaftaniFrm()
        {
            InitializeComponent();

        }
       
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VagozariAsnadFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_ChequeNumber > 0)
            {
                SaveNew();
            }
            if (_ChequeNumberEdit > 0)
            {
                SaveEdit();
            }
            Close();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void VagozariAsnadDaryaftaniFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCustomers.Handle, 25);
            cmbCustomers.Refresh();

            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";
            if (_ChequeNumberEdit > 0)
            {
                ChequeActionInfo(_ChequeNumberEdit);
            }
            if (_ChequeNumber > 0)
            {
               Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                orginalCustomerId = Cheque.OrginalCustomerIde;
                txtDocumentId.Text = Cheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
                txtDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtAssignmentDate.Text = PDate2;
            }

        }

        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            orginalCustomerId = Cheque.OrginalCustomerIde;
            prevCustomerId = Cheque.CustomerId;
            PersianCalendar pc = new PersianCalendar();
            string AssignmentDateTime = pc.GetYear((DateTime)Cheque.AssignmentDate).ToString() + "/" + pc.GetMonth((DateTime)Cheque.AssignmentDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)Cheque.AssignmentDate).ToString();
            string DateTime = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
            txtAssignmentDate.Text = AssignmentDateTime;
            txtDate.Text = DateTime;
            txtDesc.Text = Cheque.Description;
            txtDocumentId.Text = Cheque.DocumentId.ToString();
            cmbCustomers.SelectedValue = Cheque.CustomerId;
        }


        private void SaveNew()
        {
            customerName = cmbCustomers.Text;
            if (txtDesc.Text == "")
            {
                CreateDescription();
            }
           
            PersianCalendar p = new PersianCalendar();
            var AssignmentDate1 = txtAssignmentDate.Text.Split('/');
            var AssignmentDate = p.ToDateTime(int.Parse(AssignmentDate1[0]), int.Parse(AssignmentDate1[1]), int.Parse(AssignmentDate1[2]), 0, 0, 0, 0);
            Cheque.UserId = CurrentUser.UserID;
            Cheque.IssueDate = Cheque.IssueDate;
            Cheque.DueDate = Cheque.DueDate;
            Cheque.BranchName = Cheque.BranchName;
            Cheque.ChequeNumber = Cheque.ChequeNumber;
            Cheque.DocumentId = Cheque.DocumentId;
            Cheque.Description = txtDesc.Text;
            Cheque.Amount = Cheque.Amount;
            Cheque.RealBankId = Cheque.RealBankId;
            Cheque.RegisterDateTime = Cheque.RegisterDateTime;
            Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.Status = (int)Settings.ChequeStatus.VagozariAsnadDaryaftani;
            Cheque.AssignmentDate = AssignmentDate;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();


            ////////Customer transaction
            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId =(int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = Cheque.Amount;
            customerTransaction.DepositAmount = 0;
            customerTransaction.Description = txtDesc.Text;
            customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = Cheque.DocumentId;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
            ////Customer transaction end///

            //ReceivedDocuments transaction
            var receivedDocuments = new Domains.Transaction();
            receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = 0;
            receivedDocuments.DepositAmount = Cheque.Amount;
            receivedDocuments.Description = txtDesc.Text;
            receivedDocuments.DestinitionCustomerId = AppSetting.AsnadDarJaryanVoslId;
            receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
            receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
            receivedDocuments.Date = DateTime.Now;
            receivedDocuments.TransactionDateTime = DateTime.Now;
            receivedDocuments.UserId = CurrentUser.UserID;
            receivedDocuments.DocumentId = Cheque.DocumentId;
            unitOfWork.TransactionServices.Insert(receivedDocuments);
            unitOfWork.SaveChanges();
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();

        }

        private void SaveEdit()
        {
            customerName = cmbCustomers.Text;
            PersianCalendar p = new PersianCalendar();
            var Date = txtDate.Text.Split('/');
            var DateDateTime = p.ToDateTime(int.Parse(Date[0]), int.Parse(Date[1]), int.Parse(Date[2]), 0, 0, 0, 0);
            var AssignmentDate1 = txtAssignmentDate.Text.Split('/');
            var AssignmentDate = p.ToDateTime(int.Parse(AssignmentDate1[0]), int.Parse(AssignmentDate1[1]), int.Parse(AssignmentDate1[2]), 0, 0, 0, 0);
            Cheque.UserId = CurrentUser.UserID;
            Cheque.IssueDate = Cheque.IssueDate;
            Cheque.DueDate = Cheque.DueDate;
            Cheque.BranchName = Cheque.BranchName;
            Cheque.ChequeNumber = Cheque.ChequeNumber;
            Cheque.DocumentId = Cheque.DocumentId;
            Cheque.Description = txtDesc.Text;
            Cheque.Amount = Cheque.Amount;
            Cheque.RealBankId = Cheque.RealBankId;
            Cheque.RegisterDateTime = Cheque.RegisterDateTime;
            Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.Status = Cheque.Status;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            Cheque.AssignmentDate = AssignmentDate;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();

            ////////Customer transaction
            var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == prevCustomerId);
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = Cheque.Amount;
            customerTransaction.DepositAmount = 0;
            customerTransaction.Description = txtDesc.Text;
            customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = Cheque.DocumentId;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();
            //Customer transaction end///

            //ReceivedDocuments transaction
            var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
            receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = 0;
            receivedDocuments.DepositAmount = Cheque.Amount;
            receivedDocuments.Description = txtDesc.Text;
            receivedDocuments.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
            receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
            receivedDocuments.Date = DateTime.Now;
            receivedDocuments.TransactionDateTime = DateTime.Now;
            receivedDocuments.UserId = CurrentUser.UserID;
            receivedDocuments.DocumentId = Cheque.DocumentId;
            unitOfWork.TransactionServices.Update(receivedDocuments);
            unitOfWork.SaveChanges();
            //ReceivedDocuments transaction End



        }

        private void btnshowcustomer_Click(object sender, EventArgs e)
        {
            var frm = new SearchAllCustomersFrm();
            frm.ShowDialog();
        }

        private void CreateDescription()
        {
            txtDesc.Text = $"{Messages.Vagozari}چک به شماره {Cheque.ChequeNumber} به {customerName} تاریخ واگذاری {txtAssignmentDate.Text} ";
        }

    }
}