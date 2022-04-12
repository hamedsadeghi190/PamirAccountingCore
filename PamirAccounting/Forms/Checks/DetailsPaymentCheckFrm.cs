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
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Checks
{
    public partial class DetailsPaymentCheckFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        long DocumentId;
        private List<ComboBoxModel> _Banks, _Customers;
        public Domains.Cheque Cheque;
        public int? CustomerId;
        private long? _ChequeNumber;
        public int? prevCustomerId;
        public Domains.Transaction receiveTransAction;
        public Domains.Transaction customerTransaction;
        public string customerName;
        long amount;
        string accountNumber;
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionsGroupModel> _GroupedDataList;
        public DetailsPaymentCheckFrm(long? chequeNumber)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
        }

        private void DetailsPaymentCheckFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbRealBankId.Handle, 25);
            cmbRealBankId.Refresh();
            SetComboBoxHeight(cmbCustomers.Handle, 25);
            cmbCustomers.Refresh();
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
               // string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtIssueDate.Text = DateTime.Now.ToFarsiFormat(); ;
                //string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDueDate.Text = DateTime.Now.ToFarsiFormat(); ;
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        public DetailsPaymentCheckFrm()
        {

            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }
        private void LoadData()
        {
            _Banks = unitOfWork.Banks.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();
            this.cmbRealBankId.SelectedValueChanged -= new System.EventHandler(this.cmbRealBankId_SelectedValueChanged);
            cmbRealBankId.ValueMember = "Id";
            cmbRealBankId.DisplayMember = "Title";
            cmbRealBankId.DataSource = _Banks;
            AutoCompleteStringCollection autoBanks = new AutoCompleteStringCollection();
            foreach (var item in _Banks)
            {
                autoBanks.Add(item.Title);
            }
            cmbRealBankId.AutoCompleteCustomSource = autoBanks;
            this.cmbRealBankId.SelectedValueChanged += new System.EventHandler(this.cmbRealBankId_SelectedValueChanged);

            txtBankAccountNumber.Text = unitOfWork.BankServices.GetAccountNumber((int)cmbRealBankId.SelectedValue);
            txtBranchName.Text = unitOfWork.BankServices.GetAccountBranch((int)cmbRealBankId.SelectedValue);
            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            cmbCustomers.DataSource = _Customers;
            AutoCompleteStringCollection autoCustomers = new AutoCompleteStringCollection();
            foreach (var item in _Customers)
            {
                autoCustomers.Add(item.Title);
            }
            cmbCustomers.AutoCompleteCustomSource = autoCustomers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }






        private void ChequeActionInfo(long? _ChequeNumber)
        {
            Cheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber.Value);
            prevCustomerId = Cheque.CustomerId;
            PersianCalendar pc = new PersianCalendar();
          //  string IssueDateDateTime = pc.GetYear(Cheque.IssueDate).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            //string DueDateDateTime = pc.GetYear(Cheque.DueDate).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtIssueDate.Text = Cheque.IssueDate.ToFarsiFormat();
            txtDueDate.Text = Cheque.DueDate.ToFarsiFormat();
            txtBranchName.Text = Cheque.BranchName;
            txtChequeNumber.Text = Cheque.ChequeNumber;
            txtDescription.Text = Cheque.Description;
            txtAmount.Text = Cheque.Amount.ToString();
            cmbRealBankId.SelectedValue = (int)Cheque.BankId;
            cmbCustomers.SelectedValue = Cheque.CustomerId;
            txtBankAccountNumber.Text = Cheque.BankAccountNumber;
            lblNumberString.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtAmount.Text.Replace(",", ""))) } {"تومان"}";



        }


        private void ShowChars()
        {
            if (txtAmount.Text.Length > 0)
            {

                lblNumberString.Text = $"{ Num2Text.ToFarsi(Convert.ToInt64(txtAmount.Text.Replace(",", ""))) } {"تومان"}";
            }
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

            if (txtBankAccountNumber.Text == "")
            {
                return false;
            }

            if (txtChequeNumber.Text == "")
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
            lblNumberString.Text = "";
            txtDescription.Text = "";
            var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
            txtDocumentId.Text = documentId.ToString();
            LoadData();
            cmbRealBankId.Focus();
        }
        private void SaveNew()
        {
           
                var documentId = unitOfWork.TransactionServices.GetNewDocumentId();
                if (txtDescription.Text == "")
                {
                    CreateDescription();
                }
                amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));
                customerName = cmbCustomers.Text;
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
                Cheque.DocumentId = documentId;
                Cheque.Description = txtDescription.Text;
                Cheque.Amount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
                Cheque.BankId = (int)cmbRealBankId.SelectedValue;
                Cheque.RegisterDateTime = DateTime.Now;
                Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
                Cheque.BankAccountNumber = txtBankAccountNumber.Text;
                Cheque.Type = (int)DocumentType.DepositDocument;
                Cheque.Status = (int)Settings.ChequeStatus.NewPayment;
                Cheque.BankName = cmbRealBankId.Text;
                Cheque.OrginalCustomerIde = (int)cmbCustomers.SelectedValue;
                unitOfWork.ChequeServices.Insert(Cheque);
                unitOfWork.SaveChanges();
                ////////Customer transaction

                var customerTransaction = new Domains.Transaction();
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = AppSetting.SendDocumentCustomerId;
                customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount; ;
                customerTransaction.DepositAmount = 0;
                customerTransaction.Description = txtDescription.Text;
                customerTransaction.CurrenyId = 2;
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = DateTime.Now;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.DocumentId = documentId;
                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();
                //customer transaction end///



                //PaymentDocuments transaction
                var receivedDocuments = new Domains.Transaction();
                receivedDocuments.DoubleTransactionId = customerTransaction.Id;
                receivedDocuments.WithdrawAmount = 0;
                receivedDocuments.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount; ;
                receivedDocuments.Description = txtDescription.Text;
                receivedDocuments.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                receivedDocuments.SourceCustomerId = AppSetting.SendDocumentCustomerId;
                receivedDocuments.TransactionType = (int)TransaActionType.RecivedDocument;
                receivedDocuments.CurrenyId = 2;
                receivedDocuments.Date = DateTime.Now;
                receivedDocuments.TransactionDateTime = DateTime.Now;
                receivedDocuments.UserId = CurrentUser.UserID;
                receivedDocuments.DocumentId = documentId;
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
            Cheque.DocumentId = Cheque.DocumentId;
            Cheque.Description = txtDescription.Text;
            Cheque.Amount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            Cheque.BankId = (int)cmbRealBankId.SelectedValue;
            Cheque.RegisterDateTime = DateTime.Now;
            Cheque.CustomerId = (int)cmbCustomers.SelectedValue;
            Cheque.BankAccountNumber = txtBankAccountNumber.Text;
            Cheque.Type = (int)DocumentType.DepositDocument;
            Cheque.BankName = cmbRealBankId.Text;
            Cheque.Status = (int)Settings.ChequeStatus.NewPayment;
            unitOfWork.ChequeServices.Update(Cheque);
            unitOfWork.SaveChanges();
            ////////Customer transaction

            var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == prevCustomerId);
            customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.SendDocumentCustomerId;
            customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
            customerTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            customerTransaction.DepositAmount = 0;
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
            var receivedDocuments = unitOfWork.Transactions.FindFirst(x => x.DocumentId == Cheque.DocumentId && x.SourceCustomerId == AppSetting.SendDocumentCustomerId);
            receivedDocuments.DoubleTransactionId = customerTransaction.Id;
            receivedDocuments.WithdrawAmount = 0;
            receivedDocuments.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : amount;
            receivedDocuments.Description = txtDescription.Text;
            receivedDocuments.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
            receivedDocuments.SourceCustomerId = AppSetting.SendDocumentCustomerId;
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }
        private void CreateDescription()
        {
            txtDescription.Text = $"{Messages.WithdrawCheck } به {cmbCustomers.Text} تاریخ سر رسید {txtDueDate.Text} ";
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

        private void txtDueDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void cmbRealBankId_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }



        private void btnshowcustomer_Click(object sender, EventArgs e)
        {
            var AllCustomersFrm = new SearchAllCustomersFrm();
            AllCustomersFrm.ShowDialog();
            if (AllCustomersFrm.CustomerId.HasValue)
            {
                cmbCustomers.SelectedValue = AllCustomersFrm.CustomerId;
                txtDueDate.Select();
                txtDueDate.Focus();

            }
        }



        private void DetailsPaymentCheckFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void cmbRealBankId_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBankAccountNumber.Text = unitOfWork.BankServices.GetAccountNumber((int)cmbRealBankId.SelectedValue);
            txtBranchName.Text= unitOfWork.BankServices.GetAccountBranch((int)cmbRealBankId.SelectedValue);

        }

        private void btnshowcustomer_Click_1(object sender, EventArgs e)
        {
            var frm = new SearchAllCustomersFrm();
            frm.ShowDialog();
        }

        private void txtIssueDate_KeyUp(object sender, KeyEventArgs e)
        {

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
                    {
                        cmbCustomers.SelectedValue = AllCustomersFrm.CustomerId;
                        txtDueDate.Select();
                        txtDueDate.Focus();
                    }

                }
            }




        }


   
    }
}