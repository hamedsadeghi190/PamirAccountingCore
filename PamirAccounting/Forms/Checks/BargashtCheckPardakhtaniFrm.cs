using DevExpress.XtraEditors;
using PamirAccounting.Commons.Enums;
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
    public partial class BargashtCheckPardakhtaniFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        long DocumentId;
        public Domains.RealBank Banks;
        public int? CustomerId;
        private long? _ChequeNumber;
        private long? _ChequeNumberEdit;
        public int? prevCustomerId;
        public int? orginalCustomerId;
        public Domains.Transaction receiveTransAction;
        public Domains.Transaction customerTransaction;
        public Domains.Cheque currentCheque;


        public BargashtCheckPardakhtaniFrm(long? chequeNumber, long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public BargashtCheckPardakhtaniFrm()
        {
            InitializeComponent();

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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BargashtCheckPardakhtaniFrm_Load(object sender, EventArgs e)
        {
            if (_ChequeNumberEdit > 0)
            {
                ChequeActionInfo(_ChequeNumberEdit);
            }
            if (_ChequeNumber > 0)
            {
                currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                prevCustomerId = currentCheque.CustomerId;
                orginalCustomerId = currentCheque.OrginalCustomerIde;
                txtDocumentId.Text = currentCheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
                txtDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtBargashtDate.Text = PDate2;
             
            }
        }
        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            prevCustomerId = currentCheque.CustomerId;
            orginalCustomerId = currentCheque.OrginalCustomerIde;
            PersianCalendar pc = new PersianCalendar();
            string BargashtDateTime = pc.GetYear((DateTime)currentCheque.BargashtDate).ToString() + "/" + pc.GetMonth((DateTime)currentCheque.BargashtDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)currentCheque.BargashtDate).ToString();
            string DateTime = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
            txtBargashtDate.Text = BargashtDateTime;
            txtDate.Text = DateTime;
            txtDesc.Text = currentCheque.Description;
            txtDocumentId.Text = currentCheque.DocumentId.ToString();

        }

        private void SaveNew()
        {
            if (txtDesc.Text == "")
            {
                CreateDescription();
            }
            PersianCalendar p = new PersianCalendar();
            var BargashtDate1 = txtBargashtDate.Text.Split('/');
            var BargashtDate = p.ToDateTime(int.Parse(BargashtDate1[0]), int.Parse(BargashtDate1[1]), int.Parse(BargashtDate1[2]), 0, 0, 0, 0);
            currentCheque.UserId = CurrentUser.UserID;
            currentCheque.IssueDate = currentCheque.IssueDate;
            currentCheque.DueDate = currentCheque.DueDate;
            currentCheque.BranchName = currentCheque.BranchName;
            currentCheque.ChequeNumber = currentCheque.ChequeNumber;
            currentCheque.DocumentId = currentCheque.DocumentId;
            currentCheque.Description = txtDesc.Text;
            currentCheque.Amount = currentCheque.Amount;
            currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
            currentCheque.CustomerId = (int)prevCustomerId;
            currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
            currentCheque.Type = currentCheque.Type;
            currentCheque.Status = (int)Settings.ChequeStatus.BargashtPayment;
            currentCheque.BargashtDate = BargashtDate;
            currentCheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(currentCheque);
            unitOfWork.SaveChanges();

            ////////Customer transaction
            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId = (int)prevCustomerId;
            customerTransaction.DestinitionCustomerId = AppSetting.SendDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.DepositDocument;
            customerTransaction.WithdrawAmount = 0;
            customerTransaction.DepositAmount = currentCheque.Amount;
            customerTransaction.Description = txtDesc.Text;
            customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = currentCheque.DocumentId;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
            //Customer transaction end///

            //PaymentDocuments transaction
            var receivedDocuments = new Domains.Transaction();
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = currentCheque.Amount;
            receivedDocuments.DepositAmount = 0;
            receivedDocuments.Description = txtDesc.Text;
            receivedDocuments.DestinitionCustomerId = prevCustomerId;
            receivedDocuments.SourceCustomerId = AppSetting.SendDocumentCustomerId;
            receivedDocuments.TransactionType = (int)TransaActionType.DepositDocument;
            receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
            receivedDocuments.Date = DateTime.Now;
            receivedDocuments.TransactionDateTime = DateTime.Now;
            receivedDocuments.UserId = CurrentUser.UserID;
            receivedDocuments.DocumentId = currentCheque.DocumentId;
            unitOfWork.TransactionServices.Insert(receivedDocuments);
            unitOfWork.SaveChanges();
            //ReceivedDocuments transaction End
            customerTransaction.DoubleTransactionId = receivedDocuments.Id;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();
            //ReceivedDocuments transaction End

        }

        private void SaveEdit()
        {
            PersianCalendar p = new PersianCalendar();
            var BargashtDate1 = txtBargashtDate.Text.Split('/');
            var BargashtDate = p.ToDateTime(int.Parse(BargashtDate1[0]), int.Parse(BargashtDate1[1]), int.Parse(BargashtDate1[2]), 0, 0, 0, 0);
            currentCheque.UserId = CurrentUser.UserID;
            currentCheque.IssueDate = currentCheque.IssueDate;
            currentCheque.DueDate = currentCheque.DueDate;
            currentCheque.BranchName = currentCheque.BranchName;
            currentCheque.ChequeNumber = currentCheque.ChequeNumber;
            currentCheque.DocumentId = currentCheque.DocumentId;
            currentCheque.Description = txtDesc.Text;
            currentCheque.Amount = currentCheque.Amount;
            currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
            currentCheque.CustomerId = (int)prevCustomerId;
            currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
            currentCheque.Type = currentCheque.Type;
            currentCheque.Status = currentCheque.Status;
            currentCheque.BargashtDate = BargashtDate;
            currentCheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(currentCheque);
            unitOfWork.SaveChanges();


        }
        private void CreateDescription()
        {
            txtDesc.Text = $"{Messages.BargashtPayment } شماره  {currentCheque.ChequeNumber}- تاریخ برگشت  {txtBargashtDate.Text} ";
        }
        private void txtBargashtDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BargashtCheckPardakhtaniFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        
        }
    }
}