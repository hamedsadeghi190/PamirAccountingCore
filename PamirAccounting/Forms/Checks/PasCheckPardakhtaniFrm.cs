using DevExpress.XtraEditors;
using PamirAccounting.Commons.Enums;
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

    public partial class PasCheckPardakhtaniFrm : DevExpress.XtraEditors.XtraForm
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
        public string DueDate;
        public string bankName; 
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        public PasCheckPardakhtaniFrm(long? chequeNumber, long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public PasCheckPardakhtaniFrm()
        {
            InitializeComponent();
        }

        private void PasCheckDaryaftaniFrm_KeyUp(object sender, KeyEventArgs e)
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

        private void PasCheckPardakhtaniFrm_Load(object sender, EventArgs e)
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
                txtDocumentID.Text = currentCheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                //string PDate = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
                txtDate.Text = currentCheque.RegisterDateTime.ToFarsiFormat();
                txtPassDate.Text = DateTime.Now.ToFarsiFormat();
                CreateDescription();
              
            }
        }

        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            prevCustomerId = currentCheque.CustomerId;
            orginalCustomerId = currentCheque.OrginalCustomerIde;
            PersianCalendar pc = new PersianCalendar();
            //string PasDateTime = pc.GetYear((DateTime)currentCheque.PassDate).ToString() + "/" + pc.GetMonth((DateTime)currentCheque.PassDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)currentCheque.PassDate).ToString();
           // string DateTime = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
            txtPassDate.Text = ((DateTime)currentCheque.PassDate).ToFarsiFormat();
            txtDate.Text = currentCheque.RegisterDateTime.ToFarsiFormat();
            txtDesc.Text = currentCheque.Description;
            txtDocumentID.Text = currentCheque.DocumentId.ToString();
            CreateDescription();
        }
        private void SaveNew()
        {
            if (txtDesc.Text.Length<0)
            {
                CreateDescription();
            }

            long totalWithDraw = 0, totalDeposit = 0, remaining = 0;
            //var balance = unitOfWork.BankServices.FindBalance(currentCheque.BankId);
            var tmpDataList = unitOfWork.TransactionServices.GetBalance(currentCheque.BankId);
            _dataList = new List<TransactionModel>();
            _GroupedDataList = new List<TransactionsGroupModel>();
            foreach (var item in tmpDataList)
            {
                totalWithDraw += item.WithdrawAmount.Value;
                totalDeposit += item.DepositAmount.Value;
            }
            remaining = totalDeposit - totalWithDraw;

            if ( currentCheque.Amount< (remaining*(-1)))
            {    
                PersianCalendar p = new PersianCalendar();
                var PassDate1 = txtPassDate.Text.Split('/');
                var PassDate = p.ToDateTime(int.Parse(PassDate1[0]), int.Parse(PassDate1[1]), int.Parse(PassDate1[2]), 0, 0, 0, 0);
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
                currentCheque.Status = (int)Settings.ChequeStatus.PassPardakhti;
                currentCheque.PassDate = PassDate;
                currentCheque.OrginalCustomerIde = orginalCustomerId;
                currentCheque.BankId = (int)currentCheque.BankId;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();
                //////Customr transaction
                var bankId = unitOfWork.Customers.FindFirstOrDefault(x => x.BankId == currentCheque.BankId).Id;
                var bankTransaction = new Domains.Transaction();
                bankTransaction.SourceCustomerId = bankId;
                bankTransaction.DestinitionCustomerId = AppSetting.SendDocumentCustomerId;
                bankTransaction.TransactionType = (int)TransaActionType.DepositDocument;
                bankTransaction.WithdrawAmount = 0;
                bankTransaction.DepositAmount = currentCheque.Amount;
                bankTransaction.Description = txtDesc.Text;
                bankTransaction.CurrenyId = AppSetting.TomanCurrencyID;
                bankTransaction.Date = DateTime.Now;
                bankTransaction.TransactionDateTime = DateTime.Now;
                bankTransaction.UserId = CurrentUser.UserID;
                bankTransaction.DocumentId = currentCheque.DocumentId;
                unitOfWork.TransactionServices.Insert(bankTransaction);
                unitOfWork.SaveChanges();
                //Customer transaction end///

                //PaymentDocuments transaction
                var receivedDocuments = new Domains.Transaction();
                receivedDocuments.DoubleTransactionId = bankTransaction.Id;
                receivedDocuments.WithdrawAmount = currentCheque.Amount;
                receivedDocuments.DepositAmount = 0;
                receivedDocuments.Description = txtDesc.Text;
                receivedDocuments.DestinitionCustomerId = orginalCustomerId;
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
                bankTransaction.DoubleTransactionId = receivedDocuments.Id;
                unitOfWork.TransactionServices.Update(receivedDocuments);
                unitOfWork.SaveChanges();
                //ReceivedDocuments transaction End
            }

            else
            {
                MessageBox.Show("مبلغ چک از موجودی بانک بیشتر است");
            }
        }
        private void CreateDescription()
        {
                txtDesc.Text = $"{Messages.PasCheck } شماره {currentCheque.ChequeNumber} تاریخ پاس {txtPassDate.Text} ";
        }

       

       
        private void SaveEdit()
        {
            if (txtDesc.Text.Length < 0)
            {
                CreateDescription();
            }
            PersianCalendar p = new PersianCalendar();
            var PasDate1 = txtPassDate.Text.Split('/');
            var PasDate = p.ToDateTime(int.Parse(PasDate1[0]), int.Parse(PasDate1[1]), int.Parse(PasDate1[2]), 0, 0, 0, 0);
            currentCheque.UserId = CurrentUser.UserID;
            currentCheque.IssueDate = currentCheque.IssueDate;
            currentCheque.DueDate = currentCheque.DueDate;
            currentCheque.BranchName = currentCheque.BranchName;
            currentCheque.ChequeNumber = currentCheque.ChequeNumber;
            currentCheque.DocumentId = currentCheque.DocumentId;
            currentCheque.Description = txtDesc.Text;
            currentCheque.Amount = currentCheque.Amount;
            currentCheque.BankId = currentCheque.BankId;
            currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
            currentCheque.CustomerId = (int)prevCustomerId;
            currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
            currentCheque.Type = currentCheque.Type;
            currentCheque.Status = currentCheque.Status;
            currentCheque.PassDate = PasDate;
            currentCheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(currentCheque);
            unitOfWork.SaveChanges();


        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CreateDescription();
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }

    
}
