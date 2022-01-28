﻿using DevExpress.XtraEditors;
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
        public int? prevCustomerId;
        public Domains.Transaction receiveTransAction;
        public Domains.Transaction customerTransaction;
        public Domains.Cheque currentCheque;
        public SareHesabGozashtanFrm(long? chequeNumber)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            
        }
        public SareHesabGozashtanFrm()
        {
            InitializeComponent();
         
        }

       
     

        private void SareHesabGozashtanFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveNew();
            if (_ChequeNumber.HasValue)
            {
               //SaveEdit();
            }
            else
            {
                SaveNew();
            }
            Close();
        }

        private void SareHesabGozashtanFrm_Load(object sender, EventArgs e)
        {
            //if (_ChequeNumber.HasValue)
            //{
            //   ChequeActionInfo(_ChequeNumber);
            //}
            if(_ChequeNumber.HasValue)
                {
                currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                txtDocumentId.Text = currentCheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
                txtDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtAssignmentDate.Text = PDate2;
            }

        }

        private void ChequeActionInfo(long? _ChequeNumber)
        {
            //Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber.Value);
            ////customerTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == transActionId.Value);
            ////receiveTransAction = unitOfWork.TransactionServices.FindFirst(x => x.Id == customerTransaction.DoubleTransactionId);
            //prevCustomerId = Cheque.CustomerId;
            //PersianCalendar pc = new PersianCalendar();
            //string IssueDateDateTime = pc.GetYear(Cheque.IssueDate).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            //string DueDateDateTime = pc.GetYear(Cheque.DueDate).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            //txtIssueDate.Text = IssueDateDateTime;
            //txtDueDate.Text = DueDateDateTime;
            //txtBranchName.Text = Cheque.BranchName;
            //txtChequeNumber.Text = Cheque.ChequeNumber;
            //txtDocumentId.Text = Cheque.DocumentId.ToString();
            //txtDescription.Text = Cheque.Description;
            //txtAmount.Text = Cheque.Amount.ToString();
            //cmbRealBankId.SelectedValue = (int)Cheque.RealBankId;
            //cmbCustomers.SelectedValue = Cheque.CustomerId;
            //txtBankAccountNumber.Text = Cheque.BankAccountNumber;

            }


        private void SaveNew()
        {
           
    
            PersianCalendar p = new PersianCalendar();
            var AssignmentDate1 = txtAssignmentDate.Text.Split('/');
            var AssignmentDate = p.ToDateTime(int.Parse(AssignmentDate1[0]), int.Parse(AssignmentDate1[1]), int.Parse(AssignmentDate1[2]), 0, 0, 0, 0);
            currentCheque.UserId = CurrentUser.UserID;
            currentCheque.IssueDate = currentCheque.IssueDate;
            currentCheque.DueDate = currentCheque.DueDate;
            currentCheque.BranchName = currentCheque.BranchName;
            currentCheque.ChequeNumber = currentCheque.ChequeNumber;
            currentCheque.DocumentId = currentCheque.DocumentId;
            currentCheque.Description=(txtDesc.Text.Length > 0) ? txtDesc.Text : currentCheque.Description;
            currentCheque.Amount = currentCheque.Amount;
            currentCheque.RealBankId = currentCheque.RealBankId;
            currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
            currentCheque.CustomerId = AppSetting.AsnadDarJaryanVoslId;
            currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
            currentCheque.Type = currentCheque.Type;
            currentCheque.Status = (int)Settings.ChequeStatus.DarJaryanVosol;
            unitOfWork.ChequeServices.Update(currentCheque);
            unitOfWork.SaveChanges();
            ////////Customer transaction

            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId = AppSetting.AsnadDarJaryanVoslId;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = currentCheque.Amount;
            customerTransaction.DepositAmount = 0;
            customerTransaction.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.DepostitCheck + " به شماره چک -" + DocumentId;
            customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = DocumentId;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
            //customer transaction end///

            //ReceivedDocuments transaction
            var receivedDocuments = new Domains.Transaction();
            receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = 0;
            receivedDocuments.DepositAmount = currentCheque.Amount;
            receivedDocuments.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.DepostitCheck + " به شماره چک -" + DocumentId; ;
            receivedDocuments.DestinitionCustomerId = AppSetting.AsnadDarJaryanVoslId;
            receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
            receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
            receivedDocuments.Date = DateTime.Now;
            receivedDocuments.TransactionDateTime = DateTime.Now;
            receivedDocuments.UserId = CurrentUser.UserID;
            receivedDocuments.DocumentId = DocumentId;
            unitOfWork.TransactionServices.Insert(receivedDocuments);
            unitOfWork.SaveChanges();
            //ReceivedDocuments transaction End
            customerTransaction.DoubleTransactionId = receivedDocuments.Id;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();

        }

        //private void SaveEdit()
        //{

        //    var dIssueDate = txtIssueDate.Text.Split('/');
        //    PersianCalendar p = new PersianCalendar();
        //    var IssueDateDateTime = p.ToDateTime(int.Parse(dIssueDate[0]), int.Parse(dIssueDate[1]), int.Parse(dIssueDate[2]), 0, 0, 0, 0);
        //    var dDueDate = txtIssueDate.Text.Split('/');
        //    var DueDateDateTime = p.ToDateTime(int.Parse(dDueDate[0]), int.Parse(dDueDate[1]), int.Parse(dDueDate[2]), 0, 0, 0, 0);
        //    Cheque.UserId = CurrentUser.UserID;
        //    Cheque.IssueDate = IssueDateDateTime;
        //    Cheque.DueDate = DueDateDateTime;
        //    Cheque.BranchName = txtBranchName.Text;
        //    Cheque.ChequeNumber = txtChequeNumber.Text;
        //    Cheque.DocumentId = long.Parse(txtDocumentId.Text);
        //    Cheque.Description = txtDescription.Text;
        //    Cheque.Amount = long.Parse(txtAmount.Text);
        //    Cheque.RealBankId = (byte)(int)cmbRealBankId.SelectedValue;
        //    Cheque.RegisterDateTime = DateTime.Now;
        //    Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
        //    Cheque.BankAccountNumber = txtBankAccountNumber.Text;
        //    Cheque.Type = (int)DocumentType.RecivedDocument;
        //    Cheque.Status = (int)Settings.ChequeStatus.New;
        //    unitOfWork.ChequeServices.Update(Cheque);
        //    unitOfWork.SaveChanges();
        //    ////////Customer transaction

        //    var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == prevCustomerId);
        //    customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
        //    customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
        //    customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
        //    customerTransaction.WithdrawAmount = 0;
        //    customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
        //    customerTransaction.Description = (txtDescription.Text.Length > 0) ? txtDescription.Text : Messages.DepostitCheck + " به شماره چک -" + DocumentId;
        //    customerTransaction.CurrenyId = 2;
        //    customerTransaction.Date = DateTime.Now;
        //    customerTransaction.TransactionDateTime = DateTime.Now;
        //    customerTransaction.UserId = CurrentUser.UserID;
        //    customerTransaction.DocumentId = Cheque.DocumentId;
        //    unitOfWork.TransactionServices.Update(customerTransaction);
        //    unitOfWork.SaveChanges();
        //    //customer transaction end///

        //    //ReceivedDocuments transaction
        //    var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
        //    receivedDocuments.DoubleTransactionId = customerTransaction.Id;
        //    receivedDocuments.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
        //    receivedDocuments.DepositAmount = 0;
        //    receivedDocuments.Description = (txtDescription.Text.Length > 0) ? txtDescription.Text : Messages.WithdrawCheck + " به شماره چک -" + DocumentId;
        //    receivedDocuments.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
        //    receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
        //    receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
        //    receivedDocuments.CurrenyId = 2;
        //    receivedDocuments.Date = DateTime.Now;
        //    receivedDocuments.TransactionDateTime = DateTime.Now;
        //    receivedDocuments.UserId = CurrentUser.UserID;
        //    receivedDocuments.DocumentId = Cheque.DocumentId;
        //    unitOfWork.TransactionServices.Update(receivedDocuments);
        //    unitOfWork.SaveChanges();
        //    //ReceivedDocuments transaction End



        //}
        //private void createAccount(int SourceCustomerId, int CurrenyId)
        //{
        //    var newTransaction = new Domains.Transaction();
        //    newTransaction.SourceCustomerId = SourceCustomerId;
        //    newTransaction.TransactionType = 1;
        //    newTransaction.Description = Messages.CreateNewAcount;
        //    newTransaction.WithdrawAmount = 0;
        //    newTransaction.DepositAmount = 0;
        //    newTransaction.CurrenyId = CurrenyId;
        //    newTransaction.Date = DateTime.Now;
        //    newTransaction.TransactionDateTime = DateTime.Now;
        //    newTransaction.UserId = CurrentUser.UserID;
        //    newTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
        //    unitOfWork.TransactionServices.Insert(newTransaction);
        //    unitOfWork.SaveChanges();

        //}
    }
}