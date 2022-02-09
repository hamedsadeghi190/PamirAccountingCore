﻿using DevExpress.XtraEditors;
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
    public partial class BargashtCheckDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
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
        public Domains.Cheque currentCheque;
        public Domains.Cheque Cheque;
        public BargashtCheckDaryaftaniFrm(long? chequeNumber, long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public BargashtCheckDaryaftaniFrm()
        {
            InitializeComponent();
        }

        private void BargashtCheckDaryaftaniFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
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

        private void BargashtCheckDaryaftaniFrm_Load(object sender, EventArgs e)
        {
            txtDesc.Select();
            txtDesc.Focus();
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
                txtDesc.Text = currentCheque.Description;
            }

        }


        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            prevCustomerId = Cheque.CustomerId;
            orginalCustomerId = Cheque.OrginalCustomerIde;
            PersianCalendar pc = new PersianCalendar();
            string BargashtDateTime = pc.GetYear((DateTime)Cheque.BargashtDate).ToString() + "/" + pc.GetMonth((DateTime)Cheque.BargashtDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)Cheque.BargashtDate).ToString();
            string DateTime = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
            txtBargashtDate.Text = BargashtDateTime;
            txtDate.Text = DateTime;
            txtDesc.Text = Cheque.Description;
            txtDocumentId.Text = Cheque.DocumentId.ToString();

        }


        private void SaveNew()
        {
            if (currentCheque.Status == (int)Settings.ChequeStatus.New)
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
                currentCheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : currentCheque.Description;
                currentCheque.Amount = currentCheque.Amount;
                currentCheque.RealBankId = currentCheque.RealBankId;
                currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
                currentCheque.CustomerId =(int)prevCustomerId;
                currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
                currentCheque.Type = currentCheque.Type;
                currentCheque.Status = (int)Settings.ChequeStatus.Bargasht;
                currentCheque.BargashtDate = BargashtDate;
                currentCheque.OrginalCustomerIde = orginalCustomerId;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();

                ////////Customer transaction
                var customerTransaction = new Domains.Transaction();
                customerTransaction.SourceCustomerId = (int)prevCustomerId;
                customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                customerTransaction.WithdrawAmount = currentCheque.Amount;
                customerTransaction.DepositAmount =0;
                customerTransaction.Description =txtDesc.Text;
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
                receivedDocuments.DoubleTransactionId = customerTransaction.Id;
                receivedDocuments.WithdrawAmount = 0;
                receivedDocuments.DepositAmount = currentCheque.Amount;
                receivedDocuments.Description =txtDesc.Text;
                receivedDocuments.DestinitionCustomerId = (int)prevCustomerId;
                receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
                receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
                receivedDocuments.Date = DateTime.Now;
                receivedDocuments.TransactionDateTime = DateTime.Now;
                receivedDocuments.UserId = CurrentUser.UserID;
                receivedDocuments.DocumentId = DocumentId;
                unitOfWork.TransactionServices.Insert(receivedDocuments);
                unitOfWork.SaveChanges();
                customerTransaction.DoubleTransactionId = receivedDocuments.Id;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();
                //ReceivedDocuments transaction End

            }
            if (currentCheque.Status == (int)Settings.ChequeStatus.DarJaryanVosol)
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
                currentCheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : currentCheque.Description;
                currentCheque.Amount = currentCheque.Amount;
                currentCheque.RealBankId = currentCheque.RealBankId;
                currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
                currentCheque.CustomerId =(int) prevCustomerId;
                currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
                currentCheque.Type = currentCheque.Type;
                currentCheque.Status = (int)Settings.ChequeStatus.Bargasht;
                currentCheque.BargashtDate = BargashtDate;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();

                ////////AsnadDarJaryanVos transaction
                var customerTransaction = new Domains.Transaction();
                customerTransaction.SourceCustomerId =(int)prevCustomerId;
                customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.DepositAmount = currentCheque.Amount;
                customerTransaction.Description =txtDesc.Text;
                customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = DateTime.Now;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.DocumentId = currentCheque.DocumentId;
                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();
                //AsnadDarJaryanVos transaction end///

                //ReceivedDocuments transaction
                var receivedDocuments = new Domains.Transaction();
                receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                receivedDocuments.DoubleTransactionId = customerTransaction.Id;
                receivedDocuments.WithdrawAmount = currentCheque.Amount;
                receivedDocuments.DepositAmount = 0;
                receivedDocuments.Description =txtDesc.Text; ;
                receivedDocuments.DestinitionCustomerId = (int)prevCustomerId;
                receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
                receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
                receivedDocuments.Date = DateTime.Now;
                receivedDocuments.TransactionDateTime = DateTime.Now;
                receivedDocuments.UserId = CurrentUser.UserID;
                receivedDocuments.DocumentId = currentCheque.DocumentId;
                unitOfWork.TransactionServices.Insert(receivedDocuments);
                unitOfWork.SaveChanges();
                customerTransaction.DoubleTransactionId = receivedDocuments.Id;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();
                //ReceivedDocuments transaction End


                ////////Customer transaction
                var customerTransaction2 = new Domains.Transaction();
                customerTransaction2.SourceCustomerId = (int)orginalCustomerId;
                customerTransaction2.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                customerTransaction2.TransactionType = (int)TransaActionType.RecivedDocument;
                customerTransaction2.WithdrawAmount = currentCheque.Amount;
                customerTransaction2.DepositAmount = 0;
                customerTransaction2.Description =txtDesc.Text;
                customerTransaction2.CurrenyId = AppSetting.TomanCurrencyID;
                customerTransaction2.Date = DateTime.Now;
                customerTransaction2.TransactionDateTime = DateTime.Now;
                customerTransaction2.UserId = CurrentUser.UserID;
                customerTransaction2.DocumentId = currentCheque.DocumentId;
                unitOfWork.TransactionServices.Insert(customerTransaction2);
                unitOfWork.SaveChanges();
                //customer transaction end///

                //ReceivedDocuments transaction
                var receivedDocuments2 = new Domains.Transaction();
                receivedDocuments2.DoubleTransactionId = customerTransaction2.Id;
                receivedDocuments2.WithdrawAmount = 0;
                receivedDocuments2.DepositAmount = currentCheque.Amount;
                receivedDocuments2.Description = txtDesc.Text;
                receivedDocuments2.DestinitionCustomerId = (int)orginalCustomerId;
                receivedDocuments2.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                receivedDocuments2.TransactionType = (int)TransaActionType.RecivedDocument;
                receivedDocuments2.CurrenyId = AppSetting.TomanCurrencyID;
                receivedDocuments2.Date = DateTime.Now;
                receivedDocuments2.TransactionDateTime = DateTime.Now;
                receivedDocuments2.UserId = CurrentUser.UserID;
                receivedDocuments2.DocumentId = currentCheque.DocumentId;
                unitOfWork.TransactionServices.Insert(receivedDocuments2);
                unitOfWork.SaveChanges();
                customerTransaction2.DoubleTransactionId = receivedDocuments2.Id;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();
            }
        }

        private void SaveEdit()
        {
           
            PersianCalendar p = new PersianCalendar();
            var BargashtDate1 = txtBargashtDate.Text.Split('/');
            var BargashtDate = p.ToDateTime(int.Parse(BargashtDate1[0]), int.Parse(BargashtDate1[1]), int.Parse(BargashtDate1[2]), 0, 0, 0, 0);
            Cheque.UserId = CurrentUser.UserID;
            Cheque.IssueDate = Cheque.IssueDate;
            Cheque.DueDate = Cheque.DueDate;
            Cheque.BranchName = Cheque.BranchName;
            Cheque.ChequeNumber = Cheque.ChequeNumber;
            Cheque.DocumentId = Cheque.DocumentId;
            Cheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : currentCheque.Description;
            Cheque.Amount = Cheque.Amount;
            Cheque.RealBankId = Cheque.RealBankId;
            Cheque.RegisterDateTime = Cheque.RegisterDateTime;
            Cheque.CustomerId = (int)prevCustomerId;
            Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            Cheque.Type = Cheque.Type;
            Cheque.Status = Cheque.Status;
            Cheque.BargashtDate = BargashtDate;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();
            //if (Cheque.Status == (int)Settings.ChequeStatus.New)
            //{
            //    PersianCalendar p = new PersianCalendar();
            //    var Date = txtDate.Text.Split('/');
            //    var BargashtDate1 = txtBargashtDate.Text.Split('/');
            //    var BargashtDate = p.ToDateTime(int.Parse(BargashtDate1[0]), int.Parse(BargashtDate1[1]), int.Parse(BargashtDate1[2]), 0, 0, 0, 0);
            //    Cheque.UserId = CurrentUser.UserID;
            //    Cheque.IssueDate = Cheque.IssueDate;
            //    Cheque.DueDate = Cheque.DueDate;
            //    Cheque.BranchName = Cheque.BranchName;
            //    Cheque.ChequeNumber = Cheque.ChequeNumber;
            //    Cheque.DocumentId = Cheque.DocumentId;
            //    Cheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Cheque.Description; ;
            //    Cheque.Amount = Cheque.Amount;
            //    Cheque.RealBankId = Cheque.RealBankId;
            //    Cheque.RegisterDateTime = Cheque.RegisterDateTime;
            //    Cheque.CustomerId = Cheque.CustomerId;
            //    Cheque.BankAccountNumber = Cheque.BankAccountNumber;
            //    Cheque.Type = Cheque.Type;
            //    Cheque.Status = Cheque.Status;
            //    Cheque.BargashtDate = BargashtDate;
            //    Cheque.OrginalCustomerIde = orginalCustomerId;
            //    unitOfWork.ChequeServices.Update(Cheque);
            //    unitOfWork.SaveChanges();
            //    //customer Transaction
            //    var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId ==orginalCustomerId );
            //    customerTransaction.SourceCustomerId = (int)prevCustomerId;
            //    customerTransaction.DestinitionCustomerId = orginalCustomerId;
            //    customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            //    customerTransaction.WithdrawAmount = 0;
            //    customerTransaction.DepositAmount = currentCheque.Amount;
            //    customerTransaction.Description =txtDesc.Text;
            //    customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            //    customerTransaction.Date = DateTime.Now;
            //    customerTransaction.TransactionDateTime = DateTime.Now;
            //    customerTransaction.UserId = CurrentUser.UserID;
            //    customerTransaction.DocumentId = DocumentId;
            //    unitOfWork.TransactionServices.Update(customerTransaction);
            //    unitOfWork.SaveChanges();
            //    //customer Transaction End

            //    //ReceivedDocuments transaction
            //    var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
            //    receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            //    receivedDocuments.WithdrawAmount = 0;
            //    receivedDocuments.DepositAmount = currentCheque.Amount;
            //    receivedDocuments.Description =txtDesc.Text;
            //    receivedDocuments.DestinitionCustomerId =orginalCustomerId;
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




            //////////AsnadDarJaryanVos transaction
            //var customerTransaction= unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == (int)AppSetting.AsnadDarJaryanVoslId);
            //customerTransaction.SourceCustomerId = (int)AppSetting.AsnadDarJaryanVoslId;
            //customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            //customerTransaction.TransactionType = customerTransaction.TransactionType;
            //customerTransaction.WithdrawAmount = customerTransaction.WithdrawAmount;
            //customerTransaction.DepositAmount = Cheque.Amount;
            //customerTransaction.Description =txtDesc.Text;
            //customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            //customerTransaction.Date = DateTime.Now;
            //customerTransaction.TransactionDateTime = DateTime.Now;
            //customerTransaction.UserId = CurrentUser.UserID;
            //customerTransaction.DocumentId = customerTransaction.DocumentId;
            //unitOfWork.TransactionServices.Insert(customerTransaction);
            //unitOfWork.SaveChanges();
            ////AsnadDarJaryanVos transaction end///

            ////ReceivedDocuments transaction
            //var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
            //receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            //receivedDocuments.SourceCustomerId = receivedDocuments.SourceCustomerId;
            //receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            //receivedDocuments.WithdrawAmount = Cheque.Amount;
            //receivedDocuments.DepositAmount = receivedDocuments.DepositAmount;
            //receivedDocuments.Description =txtDesc.Text; ;
            //receivedDocuments.DestinitionCustomerId = receivedDocuments.DestinitionCustomerId;
            //receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
            //receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
            //receivedDocuments.Date = DateTime.Now;
            //receivedDocuments.TransactionDateTime = DateTime.Now;
            //receivedDocuments.UserId = CurrentUser.UserID;
            //receivedDocuments.DocumentId = receivedDocuments.DocumentId;
            //unitOfWork.TransactionServices.Insert(receivedDocuments);
            //unitOfWork.SaveChanges();
            //customerTransaction.DoubleTransactionId = receivedDocuments.Id;
            //unitOfWork.TransactionServices.Update(customerTransaction);
            //unitOfWork.SaveChanges();
            ////ReceivedDocuments transaction End


            //////////Customer transaction
            //var customerTransaction2 = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == orginalCustomerId);
            //customerTransaction2.SourceCustomerId = customerTransaction2.SourceCustomerId;
            //customerTransaction2.DestinitionCustomerId = customerTransaction2.DestinitionCustomerId;
            //customerTransaction2.TransactionType = customerTransaction2.TransactionType;
            //customerTransaction2.WithdrawAmount = Cheque.Amount;
            //customerTransaction2.DepositAmount = customerTransaction2.DepositAmount;
            //customerTransaction2.Description =txtDesc.Text;
            //customerTransaction2.CurrenyId = AppSetting.TomanCurrencyID;
            //customerTransaction2.Date = DateTime.Now;
            //customerTransaction2.TransactionDateTime = DateTime.Now;
            //customerTransaction2.UserId = CurrentUser.UserID;
            //customerTransaction2.DocumentId = customerTransaction2.DocumentId;
            //unitOfWork.TransactionServices.Update(customerTransaction2);
            //unitOfWork.SaveChanges();
            ////customer transaction end///

            ////ReceivedDocuments transaction
            //var receivedDocuments2= unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
            //receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            //receivedDocuments.WithdrawAmount = receivedDocuments2.WithdrawAmount;
            //receivedDocuments.DepositAmount = Cheque.Amount;
            //receivedDocuments.Description =txtDesc.Text;
            //receivedDocuments.DestinitionCustomerId = receivedDocuments2.DestinitionCustomerId;
            //receivedDocuments.SourceCustomerId = receivedDocuments2.SourceCustomerId;
            //receivedDocuments.TransactionType = receivedDocuments2.TransactionType;
            //receivedDocuments.CurrenyId = receivedDocuments2.CurrenyId;
            //receivedDocuments.Date = DateTime.Now;
            //receivedDocuments.TransactionDateTime = DateTime.Now;
            //receivedDocuments.UserId = CurrentUser.UserID;
            //receivedDocuments.DocumentId = receivedDocuments2.DocumentId;
            //unitOfWork.TransactionServices.Update(receivedDocuments);
            //unitOfWork.SaveChanges();






        }

        private void txtBargashtDate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBargashtDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void CreateDescription()
        {
            txtDesc.Text = $"{Messages.SareHesab } -چک به شماره   {currentCheque.ChequeNumber}   -به مبلغ {currentCheque.Amount} {"-تومان"} - تاریخ برگشت  {txtBargashtDate.Text} ";
        }

    }
}