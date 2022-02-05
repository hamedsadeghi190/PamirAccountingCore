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
        public Domains.Cheque Cheque;
        public string DueDate;
        public string bankName;
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
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_ChequeNumber > 0)
            {
                SaveNew();
            }
            //if (_ChequeNumberEdit > 0)
            //{
            //    SaveEdit();
            //}
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
                Banks = unitOfWork.RealBankServices.FindFirstOrDefault(x => x.Id == currentCheque.RealBankId);
                bankName = Banks.Name;
                txtDocumentID.Text = currentCheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
                txtDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtPassDate.Text = PDate2;
                txtDesc.Text = Messages.PasCheck + "به شماره چک" + currentCheque.ChequeNumber + " -ازحساب " + bankName;
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
            txtPassDate.Text = BargashtDateTime;
            txtDate.Text = DateTime;
            txtDesc.Text = Cheque.Description;
            txtDocumentID.Text = Cheque.DocumentId.ToString();

        }
        private void SaveNew()
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
            currentCheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.PasCheck + "به شماره چک" + currentCheque.ChequeNumber + " -ازحساب " + bankName;
            currentCheque.Amount = currentCheque.Amount;
            currentCheque.RealBankId = currentCheque.RealBankId;
            currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
            currentCheque.CustomerId = (int)prevCustomerId;
            currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
            currentCheque.Type = currentCheque.Type;
            currentCheque.Status = (int)Settings.ChequeStatus.PassPardakhti;
            currentCheque.PassDate = PassDate;
            currentCheque.OrginalCustomerIde = orginalCustomerId;
            unitOfWork.ChequeServices.Update(currentCheque);
            unitOfWork.SaveChanges();

            ////////Customer transaction
            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId = (int)orginalCustomerId;
            customerTransaction.DestinitionCustomerId = AppSetting.SendDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = 0;
            customerTransaction.DepositAmount = currentCheque.Amount;
            customerTransaction.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.PasCheck + "به شماره چک" + currentCheque.ChequeNumber + " -ازحساب " + bankName;
            customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = currentCheque.DocumentId;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
            //customer transaction end///

            //PaymentDocuments transaction
            var receivedDocuments = new Domains.Transaction();
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = currentCheque.Amount;
            receivedDocuments.DepositAmount = 0;
            receivedDocuments.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.PasCheck + "به شماره چک" + currentCheque.ChequeNumber + " -ازحساب " + bankName;
            receivedDocuments.DestinitionCustomerId = orginalCustomerId;
            receivedDocuments.SourceCustomerId = AppSetting.SendDocumentCustomerId;
            receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
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

    }

    //private void SaveEdit()
    //{

    //    PersianCalendar p = new PersianCalendar();
    //    var BargashtDate1 = txtBargashtDate.Text.Split('/');
    //    var BargashtDate = p.ToDateTime(int.Parse(BargashtDate1[0]), int.Parse(BargashtDate1[1]), int.Parse(BargashtDate1[2]), 0, 0, 0, 0);
    //    Cheque.UserId = CurrentUser.UserID;
    //    Cheque.IssueDate = Cheque.IssueDate;
    //    Cheque.DueDate = Cheque.DueDate;
    //    Cheque.BranchName = Cheque.BranchName;
    //    Cheque.ChequeNumber = Cheque.ChequeNumber;
    //    Cheque.DocumentId = Cheque.DocumentId;
    //    Cheque.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : currentCheque.Description;
    //    Cheque.Amount = Cheque.Amount;
    //    Cheque.RealBankId = Cheque.RealBankId;
    //    Cheque.RegisterDateTime = Cheque.RegisterDateTime;
    //    Cheque.CustomerId = (int)prevCustomerId;
    //    Cheque.BankAccountNumber = Cheque.BankAccountNumber;
    //    Cheque.Type = Cheque.Type;
    //    Cheque.Status = Cheque.Status;
    //    Cheque.BargashtDate = BargashtDate;
    //    unitOfWork.ChequeServices.Update(Cheque);
    //    unitOfWork.SaveChanges();


    //}
}
