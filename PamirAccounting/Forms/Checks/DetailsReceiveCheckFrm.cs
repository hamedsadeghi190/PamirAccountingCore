using DevExpress.XtraEditors;
using JntNum2Text;
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
    public partial class DetailsReceiveCheckFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        long DocumentId;
        private List<ComboBoxModel> _RealBank, _Customers;
        public Domains.Cheque Cheque;
        public int? CustomerId;
        private long? _ChequeNumber;
        public int? prevCustomerId;
        public int? orginalCustomerId;
        public Domains.Transaction receiveTransAction;
        public Domains.Transaction customerTransaction;
        long amount;
        public DetailsReceiveCheckFrm(long? chequeNumber)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
        }
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
            cmbCustomers.DisplayMember = "Title"; 

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

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void DetailsReceiveCheckFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCustomers.Handle, 25);
            cmbCustomers.Refresh(); 
            SetComboBoxHeight(cmbRealBankId.Handle, 25);
            cmbRealBankId.Refresh();
            LoadData();
            if (_ChequeNumber.HasValue)
            {
                ChequeActionInfo(_ChequeNumber);
            }
            else
            {
                DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
                txtDocumentId.Text = DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtIssueDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDueDate.Text = PDate2;

            }
        }
        private void ChequeActionInfo(long? _ChequeNumber)
        {
            Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber.Value);
            //customerTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == transActionId.Value);
            //receiveTransAction = unitOfWork.TransactionServices.FindFirst(x => x.Id == customerTransaction.DoubleTransactionId);
            prevCustomerId = Cheque.CustomerId;
            PersianCalendar pc = new PersianCalendar();
            string IssueDateDateTime = pc.GetYear(Cheque.IssueDate).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            string DueDateDateTime = pc.GetYear(Cheque.DueDate).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtIssueDate.Text = IssueDateDateTime;
            txtDueDate.Text = DueDateDateTime;
            txtBranchName.Text = Cheque.BranchName;
            txtChequeNumber.Text = Cheque.ChequeNumber;
            txtDocumentId.Text = Cheque.DocumentId.ToString();
            txtDescription.Text= Cheque.Description;
            txtAmount.Text = Cheque.Amount.ToString();
            cmbRealBankId.SelectedValue = (int)Cheque.RealBankId;
            cmbCustomers.SelectedValue = Cheque.CustomerId;
            txtBankAccountNumber.Text = Cheque.BankAccountNumber ;




        }
      
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (checkEntryData())
            {
                if (_ChequeNumber.HasValue)
                {
                    SaveEdit();
                    MessageBox.Show("عملیات با موفقیت ویزایش گردید", " ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    SaveNew();
                    MessageBox.Show("عملیات با موفقیت ثبت گردید", " ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("لطفا مقادیر ورودی را بررسی نمایید", "مقادیر ورودی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private bool checkEntryData()
        {
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
            if (txtAmount.Text.Trim().Length < 1 || amount < 1)
            {
                return false;
            }
            return true;
        }
        private void CleanForm()
        {
            txtBranchName.Text = "";
            txtChequeNumber.Text = "";
            txtDescription.Text = "";
            txtBankAccountNumber.Text = "";
            txtAmount.Text = "0";
            cmbRealBankId.Focus();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveNew()
        {
            if (txtDescription.Text == "")
            {
                CreateDescription();
            }
            amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
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
            Cheque.Description = txtDescription.Text; ;
            Cheque.Amount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            Cheque.RealBankId = (byte)(int)cmbRealBankId.SelectedValue;
            Cheque.RegisterDateTime = DateTime.Now;
            Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
            Cheque.BankAccountNumber = txtBankAccountNumber.Text;
            Cheque.Type = (int)DocumentType.RecivedDocument;
            Cheque.Status = (int)Settings.ChequeStatus.New;
            Cheque.OrginalCustomerIde = (int)cmbCustomers.SelectedValue;
            unitOfWork.ChequeServices.Insert(Cheque);
            unitOfWork.SaveChanges();
            ////////Customer transaction
    
            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = 0;
            customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            customerTransaction.Description = txtDescription.Text;

            customerTransaction.CurrenyId = 2;
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
            receivedDocuments.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            receivedDocuments.DepositAmount = 0;
            receivedDocuments.Description = txtDescription.Text;
            receivedDocuments.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
            receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
            receivedDocuments.CurrenyId = 2;
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
       
        private void SaveEdit()
        {
            
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
            Cheque.Amount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            Cheque.RealBankId = (byte)(int)cmbRealBankId.SelectedValue;
            Cheque.RegisterDateTime = DateTime.Now;
            Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
            Cheque.BankAccountNumber = txtBankAccountNumber.Text;
            Cheque.Type = (int)DocumentType.RecivedDocument;
            Cheque.Status = (int)Settings.ChequeStatus.New;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();
            ////////Customer transaction

            var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == prevCustomerId);
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = 0;
            customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            customerTransaction.Description = txtDescription.Text;
            customerTransaction.CurrenyId = 2;
            customerTransaction.Date = DateTime.Now;
            customerTransaction.TransactionDateTime = DateTime.Now;
            customerTransaction.UserId = CurrentUser.UserID;
            customerTransaction.DocumentId = Cheque.DocumentId;
            unitOfWork.TransactionServices.Update(customerTransaction);
            unitOfWork.SaveChanges();
            //customer transaction end///

            //ReceivedDocuments transaction
            var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.RecivedDocumentCustomerId);
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            receivedDocuments.DepositAmount = 0;
            receivedDocuments.Description = txtDescription.Text;
            receivedDocuments.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            receivedDocuments.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
            receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
            receivedDocuments.CurrenyId = 2;
            receivedDocuments.Date = DateTime.Now;
            receivedDocuments.TransactionDateTime = DateTime.Now;
            receivedDocuments.UserId = CurrentUser.UserID;
            receivedDocuments.DocumentId = Cheque.DocumentId; 
            unitOfWork.TransactionServices.Update(receivedDocuments);
            unitOfWork.SaveChanges();
            //ReceivedDocuments transaction End
       


        }

        private void DetailsReceiveCheckFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
         {
            if (e.KeyCode == Keys.Space)
            {
                txtAmount.Text += "000";
            }
            ShowChars();
            CreateDescription();
        }
        private void ShowChars()
        {
            if (txtAmount.Text.Length > 0)
            {

                lblNumberString.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtAmount.Text.Replace(",", ""))) } {"تومان"}";
            }
        }

      
        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }
        private void txtDueDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void CreateDescription()
        {
            txtDescription.Text = $"{Messages.DepostitCheck } از  {cmbCustomers.Text}  به مبلغ {txtAmount.Text} {"تومان"}  تاریخ سر رسید  {txtDueDate.Text} ";
        }

        private void btnshowcustomer_KeyUp(object sender, KeyEventArgs e)
        
        
        {
            if (e.KeyCode == Keys.Tab)
            {
                var AllCustomersFrm = new SearchAllCustomersFrm();
                AllCustomersFrm.ShowDialog();
                if (AllCustomersFrm.CustomerId.HasValue)
                {
                    cmbCustomers.SelectedValue = AllCustomersFrm.CustomerId;
                    cmbRealBankId.Select();
                    cmbRealBankId.Focus();
                }

            }
        }

        private void btnshowcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var AllCustomersFrm = new SearchAllCustomersFrm();
                AllCustomersFrm.ShowDialog();
                if (AllCustomersFrm.CustomerId.HasValue)
                {
                    cmbCustomers.SelectedValue = AllCustomersFrm.CustomerId;

                }

            }
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