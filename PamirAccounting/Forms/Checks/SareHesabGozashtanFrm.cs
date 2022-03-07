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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Checks
{
    public partial class SareHesabGozashtanFrm : DevExpress.XtraEditors.XtraForm
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
        public SareHesabGozashtanFrm(long? chequeNumber,long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public SareHesabGozashtanFrm()
        {
            InitializeComponent();
         
        }

       
     

        private void SareHesabGozashtanFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
         
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
           
            if (_ChequeNumber>0)
            {
                SaveNew();
            }
            if(_ChequeNumberEdit>0)
            {
                SaveEdit();
            }
            Close();
        }

        private void SareHesabGozashtanFrm_Load(object sender, EventArgs e)
        {
            if (_ChequeNumberEdit > 0)
            {
                ChequeActionInfo(_ChequeNumberEdit);
            }
            if (_ChequeNumber>0)
                {
                Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                txtDocumentId.Text = Cheque.DocumentId.ToString();
                orginalCustomerId = Cheque.OrginalCustomerIde;
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
            //customerTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == transActionId.Value);
            //receiveTransAction = unitOfWork.TransactionServices.FindFirst(x => x.Id == customerTransaction.DoubleTransactionId);
            prevCustomerId = Cheque.CustomerId;
            orginalCustomerId = Cheque.OrginalCustomerIde;
            PersianCalendar pc = new PersianCalendar();
            string AssignmentDateTime = pc.GetYear((DateTime)Cheque.AssignmentDate).ToString() + "/" + pc.GetMonth((DateTime)Cheque.AssignmentDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)Cheque.AssignmentDate).ToString();
            string DateTime = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
            txtAssignmentDate.Text = AssignmentDateTime;
            txtDate.Text = DateTime;
            txtDesc.Text = Cheque.Description;
            txtDocumentId.Text = Cheque.DocumentId.ToString();
            
        }


        private void SaveNew()
        {
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
            Cheque.Description = txtDesc.Text ;
            Cheque.Amount = Cheque.Amount;
            Cheque.RealBankId = Cheque.RealBankId;
            Cheque.RegisterDateTime = Cheque.RegisterDateTime;
            Cheque.CustomerId = AppSetting.AsnadDarJaryanVoslId;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            Cheque.Status = (int)Settings.ChequeStatus.DarJaryanVosol;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            //currentCheque
            Cheque.AssignmentDate = AssignmentDate;  
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();
            ////////AsnadDarJaryanVos transaction

            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId = AppSetting.AsnadDarJaryanVoslId;
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
            //AsnadDarJaryanVos transaction end///

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
            //ReceivedDocuments transaction End
            customerTransaction.DoubleTransactionId = receivedDocuments.Id;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();

        }

        private void SaveEdit()
        {

      
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
            Cheque.CustomerId = Cheque.CustomerId;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.Status = Cheque.Status;
            Cheque.AssignmentDate = AssignmentDate;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();

            ////////AsnadDarJaryanVos transaction
            var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId ==(int) AppSetting.AsnadDarJaryanVoslId);
            customerTransaction.SourceCustomerId = (int)AppSetting.AsnadDarJaryanVoslId;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount =customerTransaction.WithdrawAmount;
            customerTransaction.DepositAmount = customerTransaction.DepositAmount;
            customerTransaction.Description = txtDesc.Text;
            customerTransaction.CurrenyId = customerTransaction.CurrenyId;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = customerTransaction.DocumentId;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();
            //AsnadDarJaryanVos transaction end///

            //ReceivedDocuments transaction
            var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = receivedDocuments.WithdrawAmount;
            receivedDocuments.DepositAmount = receivedDocuments.DepositAmount;
            receivedDocuments.Description = txtDesc.Text;
            receivedDocuments.DestinitionCustomerId = receivedDocuments.DestinitionCustomerId;
            receivedDocuments.SourceCustomerId = receivedDocuments.SourceCustomerId;
            receivedDocuments.TransactionType = receivedDocuments.TransactionType;
            receivedDocuments.CurrenyId = receivedDocuments.CurrenyId;
            receivedDocuments.Date = DateTime.Now;
            receivedDocuments.TransactionDateTime = DateTime.Now;
            receivedDocuments.UserId = CurrentUser.UserID;
            receivedDocuments.DocumentId = receivedDocuments.DocumentId;
            unitOfWork.TransactionServices.Update(receivedDocuments);
            unitOfWork.SaveChanges();
            //ReceivedDocuments transaction End



        }

        private void CreateDescription()
        {
            txtDesc.Text = $"{Messages.SareHesab } -چک به شماره   {Cheque.ChequeNumber}   -به مبلغ {Cheque.Amount} {"تومان"} - تاریخ واگذاری  {txtAssignmentDate.Text} ";
        }

        private void txtAssignmentDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void SareHesabGozashtanFrm_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void createAccount(int SourceCustomerId, int CurrenyId)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = SourceCustomerId;
            newTransaction.TransactionType = 1;
            newTransaction.Description = Messages.CreateNewAcount;
            newTransaction.WithdrawAmount = 0;
            newTransaction.DepositAmount = 0;
            newTransaction.CurrenyId = CurrenyId;
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = DateTime.Now;
            newTransaction.UserId = CurrentUser.UserID;
            newTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
            unitOfWork.TransactionServices.Insert(newTransaction);
            unitOfWork.SaveChanges();

        }
    }
}