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
    public partial class OdatCheckDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
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
        public OdatCheckDaryaftaniFrm(long? chequeNumber, long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public OdatCheckDaryaftaniFrm()
        {
            InitializeComponent();

        }

        private void BtnClose_ClientSizeChanged(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OdatCheckDaryaftaniFrm_KeyUp(object sender, KeyEventArgs e)
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

        private void OdatCheckDaryaftaniFrm_Load(object sender, EventArgs e)
        {
            txtDesc.Select();
            txtDesc.Focus();
            if (_ChequeNumberEdit > 0)
            {
                ChequeActionInfo(_ChequeNumberEdit);
            }
            if (_ChequeNumber > 0)
            {
                Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                prevCustomerId = Cheque.CustomerId;
                orginalCustomerId = Cheque.OrginalCustomerIde;
                txtDocumentId.Text = Cheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
                txtDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtOdatDate.Text = PDate2;
            }
        }

        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            prevCustomerId = Cheque.CustomerId;
            orginalCustomerId = Cheque.OrginalCustomerIde;
            PersianCalendar pc = new PersianCalendar();
            string OdatDateTime = pc.GetYear((DateTime)Cheque.OdatDate).ToString() + "/" + pc.GetMonth((DateTime)Cheque.OdatDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)Cheque.OdatDate).ToString();
            string DateTime = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
            txtOdatDate.Text = OdatDateTime;
            txtDate.Text = DateTime;
            txtDesc.Text = Cheque.Description;
            txtDocumentId.Text = Cheque.DocumentId.ToString();

        }


        private void SaveNew()
        {
            PersianCalendar p = new PersianCalendar();
            var OdatDate1 = txtOdatDate.Text.Split('/');
            var OdatDate = p.ToDateTime(int.Parse(OdatDate1[0]), int.Parse(OdatDate1[1]), int.Parse(OdatDate1[2]), 0, 0, 0, 0);
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
            Cheque.CustomerId = (int)prevCustomerId;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.Status = (int)Settings.ChequeStatus.OdatDaryaftani;
            Cheque.OdatDate = OdatDate;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();
            ////////Customer transaction

            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId =(int)prevCustomerId;
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
            //Customer transaction end///

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

        private void txtOdatDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void SaveEdit()
        {
            PersianCalendar p = new PersianCalendar();
            var Date = txtDate.Text.Split('/');
            var DateDateTime = p.ToDateTime(int.Parse(Date[0]), int.Parse(Date[1]), int.Parse(Date[2]), 0, 0, 0, 0);
            var OdatDate1 = txtOdatDate.Text.Split('/');
            var OdatDate = p.ToDateTime(int.Parse(OdatDate1[0]), int.Parse(OdatDate1[1]), int.Parse(OdatDate1[2]), 0, 0, 0, 0);
            Cheque.UserId = CurrentUser.UserID;
            Cheque.IssueDate = Cheque.IssueDate;
            Cheque.DueDate = Cheque.DueDate;
            Cheque.BranchName = Cheque.BranchName;
            Cheque.ChequeNumber = Cheque.ChequeNumber;
            Cheque.DocumentId = Cheque.DocumentId;
            Cheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Cheque.Description; ;
            Cheque.Amount = Cheque.Amount;
            Cheque.RealBankId = Cheque.RealBankId;
            Cheque.RegisterDateTime = Cheque.RegisterDateTime;
            Cheque.CustomerId = Cheque.CustomerId;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.Status = Cheque.Status;
            Cheque.OdatDate = OdatDate;
            Cheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();

            ////////Customer transaction
            var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == prevCustomerId);
            customerTransaction.SourceCustomerId =(int) prevCustomerId;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = customerTransaction.WithdrawAmount;
            customerTransaction.DepositAmount = customerTransaction.DepositAmount;
            customerTransaction.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.DepostitCheck + " به شماره چک -" + customerTransaction.DocumentId;
            customerTransaction.CurrenyId = customerTransaction.CurrenyId;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = customerTransaction.DocumentId;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();
            //Customer transaction end///

            //ReceivedDocuments transaction
            var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
             receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = receivedDocuments.WithdrawAmount;
            receivedDocuments.DepositAmount = receivedDocuments.DepositAmount;
            receivedDocuments.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.WithdrawCheck + " به شماره چک -" + receivedDocuments.DocumentId;
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
            txtDesc.Text = $"{Messages.Odat }  چک به شماره   {Cheque.ChequeNumber}  به مبلغ {Cheque.Amount} {"تومان"}  تاریخ عودت  {txtOdatDate.Text} ";
        }
    }
}