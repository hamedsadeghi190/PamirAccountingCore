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
using static PamirAccounting.Tools;

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
                Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                prevCustomerId = Cheque.CustomerId;
                orginalCustomerId = Cheque.OrginalCustomerIde;
                txtDocumentId.Text = Cheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                // string PDate = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
                txtDate.Text = Cheque.RegisterDateTime.ToFarsiFormat();
                // string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtBargashtDate.Text = (DateTime.Now).ToFarsiFormat();
                CreateDescription();
            }

        }


        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            prevCustomerId = Cheque.CustomerId;
            orginalCustomerId = Cheque.OrginalCustomerIde;
            PersianCalendar pc = new PersianCalendar();
            // string BargashtDateTime = pc.GetYear((DateTime)Cheque.BargashtDate).ToString() + "/" + pc.GetMonth((DateTime)Cheque.BargashtDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)Cheque.BargashtDate).ToString();
            //string DateTime = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
            txtBargashtDate.Text = ((DateTime)Cheque.BargashtDate).ToFarsiFormat();
            txtDate.Text = Cheque.RegisterDateTime.ToFarsiFormat();
            txtDesc.Text = Cheque.Description;
            txtDocumentId.Text = Cheque.DocumentId.ToString();
            CreateDescription();

        }


        private void SaveNew()
        {
            try
            {

                var dDate = DateTime.Now.ToShortDateString();
                var log = new Domains.DailyOperation();
                if (txtDesc.Text == "")
                {
                    CreateDescription();
                }
                if (Cheque.Status == (int)Settings.ChequeStatus.New)
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
                    Cheque.Description = txtDesc.Text;
                    Cheque.Amount = Cheque.Amount;
                    Cheque.RealBankId = Cheque.RealBankId;
                    Cheque.RegisterDateTime = Cheque.RegisterDateTime;
                    Cheque.CustomerId = (int)prevCustomerId;
                    Cheque.BankAccountNumber = Cheque.BankAccountNumber;
                    Cheque.Type = Cheque.Type;
                    Cheque.Status = (int)Settings.ChequeStatus.Bargasht;
                    Cheque.BargashtDate = BargashtDate;
                    Cheque.OrginalCustomerIde = orginalCustomerId;
                    unitOfWork.ChequeServices.Update(Cheque);
                    unitOfWork.SaveChanges();

                    ////////Customer transaction
                    var customerTransaction = new Domains.Transaction();
                    customerTransaction.SourceCustomerId = (int)prevCustomerId;
                    customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                    customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                    customerTransaction.WithdrawAmount = Cheque.Amount;
                    customerTransaction.DepositAmount = 0;
                    customerTransaction.Description = txtDesc.Text;
                    customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
                    customerTransaction.Date = DateTime.Now;
                    customerTransaction.TransactionDateTime = DateTime.Parse(dDate); ;
                    customerTransaction.UserId = CurrentUser.UserID;
                    customerTransaction.DocumentId = DocumentId;
                    unitOfWork.TransactionServices.Insert(customerTransaction);
                    unitOfWork.SaveChanges();
                    //customer transaction end///

                    //ReceivedDocuments transaction
                    var receivedDocuments = new Domains.Transaction();
                    receivedDocuments.DoubleTransactionId = customerTransaction.Id;
                    receivedDocuments.WithdrawAmount = 0;
                    receivedDocuments.DepositAmount = Cheque.Amount;
                    receivedDocuments.Description = txtDesc.Text;
                    receivedDocuments.DestinitionCustomerId = (int)prevCustomerId;
                    receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                    receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
                    receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
                    receivedDocuments.Date = DateTime.Now;
                    receivedDocuments.TransactionDateTime = DateTime.Parse(dDate);
                    receivedDocuments.UserId = CurrentUser.UserID;
                    receivedDocuments.DocumentId = DocumentId;
                    unitOfWork.TransactionServices.Insert(receivedDocuments);
                    unitOfWork.SaveChanges();
                    customerTransaction.DoubleTransactionId = receivedDocuments.Id;
                    unitOfWork.TransactionServices.Update(customerTransaction);
                    unitOfWork.SaveChanges();
                    //ReceivedDocuments transaction End


                }
                if (Cheque.Status == (int)Settings.ChequeStatus.DarJaryanVosol)
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
                    Cheque.Description = txtDesc.Text;
                    Cheque.Amount = Cheque.Amount;
                    Cheque.RealBankId = Cheque.RealBankId;
                    Cheque.RegisterDateTime = Cheque.RegisterDateTime;
                    Cheque.CustomerId = (int)prevCustomerId;
                    Cheque.BankAccountNumber = Cheque.BankAccountNumber;
                    Cheque.Type = Cheque.Type;
                    Cheque.Status = (int)Settings.ChequeStatus.Bargasht;
                    Cheque.BargashtDate = BargashtDate;
                    unitOfWork.ChequeServices.Update(Cheque);
                    unitOfWork.SaveChanges();

                    ////////AsnadDarJaryanVos transaction
                    var customerTransaction = new Domains.Transaction();
                    customerTransaction.SourceCustomerId = (int)prevCustomerId;
                    customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                    customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                    customerTransaction.WithdrawAmount = 0;
                    customerTransaction.DepositAmount = Cheque.Amount;
                    customerTransaction.Description = txtDesc.Text;
                    customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
                    customerTransaction.Date = DateTime.Now;
                    customerTransaction.TransactionDateTime = DateTime.Parse(dDate);
                    customerTransaction.UserId = CurrentUser.UserID;
                    customerTransaction.DocumentId = Cheque.DocumentId;
                    unitOfWork.TransactionServices.Insert(customerTransaction);
                    unitOfWork.SaveChanges();
                    //AsnadDarJaryanVos transaction end///

                    //ReceivedDocuments transaction
                    var receivedDocuments = new Domains.Transaction();
                    receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                    receivedDocuments.DoubleTransactionId = customerTransaction.Id;
                    receivedDocuments.WithdrawAmount = Cheque.Amount;
                    receivedDocuments.DepositAmount = 0;
                    receivedDocuments.Description = txtDesc.Text; ;
                    receivedDocuments.DestinitionCustomerId = (int)prevCustomerId;
                    receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
                    receivedDocuments.CurrenyId = AppSetting.TomanCurrencyID;
                    receivedDocuments.Date = DateTime.Now;
                    receivedDocuments.TransactionDateTime = DateTime.Parse(dDate);
                    receivedDocuments.UserId = CurrentUser.UserID;
                    receivedDocuments.DocumentId = Cheque.DocumentId;
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
                    customerTransaction2.WithdrawAmount = Cheque.Amount;
                    customerTransaction2.DepositAmount = 0;
                    customerTransaction2.Description = txtDesc.Text;
                    customerTransaction2.CurrenyId = AppSetting.TomanCurrencyID;
                    customerTransaction2.Date = DateTime.Now;
                    customerTransaction2.TransactionDateTime = DateTime.Parse(dDate);
                    customerTransaction2.UserId = CurrentUser.UserID;
                    customerTransaction2.DocumentId = Cheque.DocumentId;
                    unitOfWork.TransactionServices.Insert(customerTransaction2);
                    unitOfWork.SaveChanges();
                    //customer transaction end///

                    //ReceivedDocuments transaction
                    var receivedDocuments2 = new Domains.Transaction();
                    receivedDocuments2.DoubleTransactionId = customerTransaction2.Id;
                    receivedDocuments2.WithdrawAmount = 0;
                    receivedDocuments2.DepositAmount = Cheque.Amount;
                    receivedDocuments2.Description = txtDesc.Text;
                    receivedDocuments2.DestinitionCustomerId = (int)orginalCustomerId;
                    receivedDocuments2.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                    receivedDocuments2.TransactionType = (int)TransaActionType.RecivedDocument;
                    receivedDocuments2.CurrenyId = AppSetting.TomanCurrencyID;
                    receivedDocuments2.Date = DateTime.Now;
                    receivedDocuments2.TransactionDateTime = DateTime.Parse(dDate);
                    receivedDocuments2.UserId = CurrentUser.UserID;
                    receivedDocuments2.DocumentId = Cheque.DocumentId;
                    unitOfWork.TransactionServices.Insert(receivedDocuments2);
                    unitOfWork.SaveChanges();
                    customerTransaction2.DoubleTransactionId = receivedDocuments2.Id;
                    unitOfWork.TransactionServices.Update(customerTransaction);
                    unitOfWork.SaveChanges();

                }


                #region Log
                log.Date = DateTime.Parse(dDate);
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.DocumentId = Cheque.DocumentId;
                log.Description = CreateDescription();
                log.ActionText = GetEnumDescription(Settings.ActionType.Insert);
                log.ActionType = (int)Settings.ActionType.Insert;
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در عملیات");

            }
        }

        private void SaveEdit()
        {
            try
            {
                var dDate = DateTime.Now.ToShortDateString();
                PersianCalendar p = new PersianCalendar();
                var BargashtDate1 = txtBargashtDate.Text.Split('/');
                var BargashtDate = p.ToDateTime(int.Parse(BargashtDate1[0]), int.Parse(BargashtDate1[1]), int.Parse(BargashtDate1[2]), 0, 0, 0, 0);
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
                Cheque.Status = Cheque.Status;
                Cheque.BargashtDate = BargashtDate;
                unitOfWork.ChequeServices.Update(Cheque);
                unitOfWork.SaveChanges();

                #region Log
                var log = new Domains.DailyOperation();
                log.Date = DateTime.Parse(dDate);
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.DocumentId = Cheque.DocumentId;
                log.Description = CreateDescription();
                log.ActionText = GetEnumDescription(Settings.ActionType.Update);
                log.ActionType = (int)Settings.ActionType.Update;
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion


            }

            catch (Exception ex)
            {
                MessageBox.Show("خطا در عملیات");

            }


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

        private string CreateDescription()
        {
            txtDesc.Text = $"{Messages.Bargasht } چک به شماره {Cheque.ChequeNumber} تاریخ برگشت {txtBargashtDate.Text} ";
            return txtDesc.Text;
        }

    }
}