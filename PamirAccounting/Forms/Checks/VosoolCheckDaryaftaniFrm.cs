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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Checks
{
    public partial class VosoolCheckDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        long DocumentId;
        private List<ComboBoxModel> _RealBank, _Customers;
        public int? CustomerId;
        private long? _ChequeNumber;
        private long? _ChequeNumberEdit;
        public int? prevCustomerId;
        public int? orginalCustomerId;
        public int? Status;
        public Domains.Transaction receiveTransAction;
        public Domains.Transaction customerTransaction;
        public Domains.Cheque currentCheque;
     
        public VosoolCheckDaryaftaniFrm(long? chequeNumber, long? chequeNumberEdit)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;
            _ChequeNumberEdit = chequeNumberEdit;
        }
        public VosoolCheckDaryaftaniFrm()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
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

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }
        private void VosoolCheckDaryaftaniFrm_Load(object sender, EventArgs e)
        {
            SetComboBoxHeight(cmbCustomers.Handle, 25);
            cmbCustomers.Refresh();
            LoadData();
            if (_ChequeNumberEdit > 0)
            {
                ChequeActionInfo(_ChequeNumberEdit);
            }
            if (_ChequeNumber > 0)
            {
                currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                txtDocumentId.Text = currentCheque.DocumentId.ToString();
                orginalCustomerId = currentCheque.OrginalCustomerIde;
                Status = currentCheque.Status;
                PersianCalendar pc = new PersianCalendar();
               // string PDate = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
                txtDate.Text = (currentCheque.RegisterDateTime).ToFarsiFormat();
               // string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtVosoolDate.Text = DateTime.Now.ToFarsiFormat();
                CreateDescription();
            }
        }

        private void ChequeActionInfo(long? _ChequeNumberEdit)
        {
            currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumberEdit.Value);
            orginalCustomerId = currentCheque.OrginalCustomerIde;
            prevCustomerId = currentCheque.CustomerId;
            Status = currentCheque.Status;
            PersianCalendar pc = new PersianCalendar();
           // string VosoolDateTime = pc.GetYear((DateTime)Cheque.VosoolDate).ToString() + "/" + pc.GetMonth((DateTime)Cheque.VosoolDate).ToString() + "/" + pc.GetDayOfMonth((DateTime)Cheque.VosoolDate).ToString();
          //  string DateTime = pc.GetYear(Cheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(Cheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(Cheque.RegisterDateTime).ToString();
            txtVosoolDate.Text = ((DateTime)currentCheque.VosoolDate).ToFarsiFormat();
            txtDate.Text = currentCheque.RegisterDateTime.ToFarsiFormat();
            txtDesc.Text = currentCheque.Description;
            txtDocumentId.Text = currentCheque.DocumentId.ToString();
            cmbCustomers.SelectedValue = currentCheque.CustomerId;
            CreateDescription();
        }

        private void SaveNew()
        {
           
            ///////////////// //Check Status New/////////////
            if (Status == (int)Settings.ChequeStatus.New)
            {
                PersianCalendar p = new PersianCalendar();
                var VosoolDate1 = txtVosoolDate.Text.Split('/');
                var VosoolDate = p.ToDateTime(int.Parse(VosoolDate1[0]), int.Parse(VosoolDate1[1]), int.Parse(VosoolDate1[2]), 0, 0, 0, 0);
                currentCheque.UserId = CurrentUser.UserID;
                currentCheque.IssueDate = currentCheque.IssueDate;
                currentCheque.DueDate = currentCheque.DueDate;
                currentCheque.BranchName = currentCheque.BranchName;
                currentCheque.ChequeNumber = currentCheque.ChequeNumber;
                currentCheque.DocumentId = currentCheque.DocumentId;
                currentCheque.Description = txtDesc.Text;
                currentCheque.Amount = currentCheque.Amount;
                currentCheque.RealBankId = currentCheque.RealBankId;
                currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
                currentCheque.CustomerId = (int)cmbCustomers.SelectedValue;
                currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
                currentCheque.Type = currentCheque.Type;
                currentCheque.Status = (int)Settings.ChequeStatus.Vosol;
                currentCheque.OrginalCustomerIde = orginalCustomerId;
                currentCheque.VosoolDate = VosoolDate;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();

                ////////Customer transaction
                var customerTransaction = new Domains.Transaction();
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                customerTransaction.WithdrawAmount = currentCheque.Amount;
                customerTransaction.DepositAmount = 0;
                customerTransaction.Description = txtDesc.Text;
                customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = DateTime.Now;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.DocumentId = DocumentId;
                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();
                //customer transaction end///
                var DarJaryanVosool = new Domains.Transaction();
                DarJaryanVosool.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                DarJaryanVosool.DoubleTransactionId = customerTransaction.Id;
                DarJaryanVosool.WithdrawAmount = 0;
                DarJaryanVosool.DepositAmount = currentCheque.Amount;
                DarJaryanVosool.Description = txtDesc.Text;
                DarJaryanVosool.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                DarJaryanVosool.TransactionType = (int)TransaActionType.RecivedDocument;
                DarJaryanVosool.CurrenyId = AppSetting.TomanCurrencyID;
                DarJaryanVosool.Date = DateTime.Now;
                DarJaryanVosool.TransactionDateTime = DateTime.Now;
                DarJaryanVosool.UserId = CurrentUser.UserID;
                DarJaryanVosool.DocumentId = DocumentId;
                unitOfWork.TransactionServices.Insert(DarJaryanVosool);
                unitOfWork.SaveChanges();
                //ReceivedDocuments transaction End
                customerTransaction.DoubleTransactionId = DarJaryanVosool.Id;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();

            }
            ///////////////////Check Status New End/////////////
            ////////////////////Check Status DarJaryanVosol/////////////////
            if (Status == (int)Settings.ChequeStatus.DarJaryanVosol)
            {
                PersianCalendar p = new PersianCalendar();
                var VosoolDate1 = txtVosoolDate.Text.Split('/');
                var VosoolDate = p.ToDateTime(int.Parse(VosoolDate1[0]), int.Parse(VosoolDate1[1]), int.Parse(VosoolDate1[2]), 0, 0, 0, 0);
                currentCheque.UserId = CurrentUser.UserID;
                currentCheque.IssueDate = currentCheque.IssueDate;
                currentCheque.DueDate = currentCheque.DueDate;
                currentCheque.BranchName = currentCheque.BranchName;
                currentCheque.ChequeNumber = currentCheque.ChequeNumber;
                currentCheque.DocumentId = currentCheque.DocumentId;
                currentCheque.Description = txtDesc.Text;
                currentCheque.Amount = currentCheque.Amount;
                currentCheque.RealBankId = currentCheque.RealBankId;
                currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
                currentCheque.CustomerId = (int)cmbCustomers.SelectedValue;
                currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
                currentCheque.Type = currentCheque.Type;
                currentCheque.Status = (int)Settings.ChequeStatus.Vosol;
                currentCheque.OrginalCustomerIde = orginalCustomerId;
                currentCheque.VosoolDate = VosoolDate;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();

                ////////Customer transaction
                var customerTransaction = new Domains.Transaction();
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = AppSetting.AsnadDarJaryanVoslId;
                customerTransaction.TransactionType = (int)TransaActionType.RecivedDocument;
                customerTransaction.WithdrawAmount = currentCheque.Amount;
                customerTransaction.DepositAmount = 0;
                customerTransaction.Description = txtDesc.Text;
                customerTransaction.CurrenyId = AppSetting.TomanCurrencyID;
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = DateTime.Now;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.DocumentId = DocumentId;
                unitOfWork.TransactionServices.Insert(customerTransaction);
                unitOfWork.SaveChanges();
                //customer transaction end///

                //DarJaryanVosool transaction
                var DarJaryanVosool = new Domains.Transaction();
                DarJaryanVosool.SourceCustomerId = AppSetting.AsnadDarJaryanVoslId;
                DarJaryanVosool.DoubleTransactionId = customerTransaction.Id;
                DarJaryanVosool.WithdrawAmount = 0;
                DarJaryanVosool.DepositAmount = currentCheque.Amount;
                DarJaryanVosool.Description = txtDesc.Text;
                DarJaryanVosool.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                DarJaryanVosool.TransactionType = (int)TransaActionType.RecivedDocument;
                DarJaryanVosool.CurrenyId = AppSetting.TomanCurrencyID;
                DarJaryanVosool.Date = DateTime.Now;
                DarJaryanVosool.TransactionDateTime = DateTime.Now;
                DarJaryanVosool.UserId = CurrentUser.UserID;
                DarJaryanVosool.DocumentId = DocumentId;
                unitOfWork.TransactionServices.Insert(DarJaryanVosool);
                unitOfWork.SaveChanges();
                //ReceivedDocuments transaction End
                customerTransaction.DoubleTransactionId = DarJaryanVosool.Id;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();
            }
            ///////////////// //Check Status New DarJaryanVosol/////////////
        }
        private void SaveEdit()
        {
            ///////////////// //Check Status New/////////////
            if (Status == (int)Settings.ChequeStatus.New)
            {
                PersianCalendar p = new PersianCalendar();
                var Date = txtDate.Text.Split('/');
                var DateDateTime = p.ToDateTime(int.Parse(Date[0]), int.Parse(Date[1]), int.Parse(Date[2]), 0, 0, 0, 0);
                var VosoolDate1 = txtVosoolDate.Text.Split('/');
                var VosoolDate = p.ToDateTime(int.Parse(VosoolDate1[0]), int.Parse(VosoolDate1[1]), int.Parse(VosoolDate1[2]), 0, 0, 0, 0);
                currentCheque.UserId = CurrentUser.UserID;
                currentCheque.IssueDate = currentCheque.IssueDate;
                currentCheque.DueDate = currentCheque.DueDate;
                currentCheque.BranchName = currentCheque.BranchName;
                currentCheque.ChequeNumber = currentCheque.ChequeNumber;
                currentCheque.DocumentId = currentCheque.DocumentId;
                currentCheque.Description =txtDesc.Text;
                currentCheque.Amount = currentCheque.Amount;
                currentCheque.RealBankId = currentCheque.RealBankId;
                currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
                currentCheque.CustomerId = (int)cmbCustomers.SelectedValue;
                currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
                currentCheque.Type = currentCheque.Type;
                currentCheque.Status = currentCheque.Status;
                currentCheque.VosoolDate = VosoolDate;
                currentCheque.OrginalCustomerIde = orginalCustomerId;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();
                ////////Customer transaction
                var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == currentCheque.DocumentId && x.SourceCustomerId == prevCustomerId);
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = AppSetting.RecivedDocumentCustomerId;
                customerTransaction.TransactionType = customerTransaction.TransactionType;
                customerTransaction.WithdrawAmount = customerTransaction.WithdrawAmount;
                customerTransaction.DepositAmount = customerTransaction.DepositAmount;
                customerTransaction.Description = currentCheque.Description;
                customerTransaction.CurrenyId = customerTransaction.CurrenyId;
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = DateTime.Now;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.DocumentId = customerTransaction.DocumentId;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();
                //customer transaction end///

                //DarJaryanVosool transaction
                var DarJaryanVosool = unitOfWork.Transactions.FindFirst(x => x.DocumentId == currentCheque.DocumentId && x.SourceCustomerId == AppSetting.AsnadDarJaryanVoslId);
                DarJaryanVosool.DoubleTransactionId = customerTransaction.Id;
                DarJaryanVosool.WithdrawAmount = DarJaryanVosool.WithdrawAmount;
                DarJaryanVosool.DepositAmount = DarJaryanVosool.DepositAmount;
                DarJaryanVosool.Description = currentCheque.Description;
                DarJaryanVosool.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                DarJaryanVosool.SourceCustomerId = AppSetting.RecivedDocumentCustomerId;
                DarJaryanVosool.TransactionType = DarJaryanVosool.TransactionType;
                DarJaryanVosool.CurrenyId = DarJaryanVosool.CurrenyId;
                DarJaryanVosool.Date = DateTime.Now;
                DarJaryanVosool.TransactionDateTime = DateTime.Now;
                DarJaryanVosool.UserId = CurrentUser.UserID;
                DarJaryanVosool.DocumentId = DarJaryanVosool.DocumentId;
                unitOfWork.TransactionServices.Update(DarJaryanVosool);
                unitOfWork.SaveChanges();
                //DarJaryanVosool transaction
            }
            ///////////////////Check Status New End/////////////
            ////////////////////Check Status DarJaryanVosol/////////////////
            if (Status == (int)Settings.ChequeStatus.DarJaryanVosol)
            {
                PersianCalendar p = new PersianCalendar();
                var Date = txtDate.Text.Split('/');
                var DateDateTime = p.ToDateTime(int.Parse(Date[0]), int.Parse(Date[1]), int.Parse(Date[2]), 0, 0, 0, 0);
                var VosoolDate1 = txtVosoolDate.Text.Split('/');
                var VosoolDate = p.ToDateTime(int.Parse(VosoolDate1[0]), int.Parse(VosoolDate1[1]), int.Parse(VosoolDate1[2]), 0, 0, 0, 0);
                currentCheque.UserId = CurrentUser.UserID;
                currentCheque.IssueDate = currentCheque.IssueDate;
                currentCheque.DueDate = currentCheque.DueDate;
                currentCheque.BranchName = currentCheque.BranchName;
                currentCheque.ChequeNumber = currentCheque.ChequeNumber;
                currentCheque.DocumentId = currentCheque.DocumentId;
                currentCheque.Description = txtDesc.Text;
                currentCheque.Amount = currentCheque.Amount;
                currentCheque.RealBankId = currentCheque.RealBankId;
                currentCheque.RegisterDateTime = currentCheque.RegisterDateTime;
                currentCheque.CustomerId = (int)cmbCustomers.SelectedValue;
                currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
                currentCheque.Type = currentCheque.Type;
                currentCheque.Status = currentCheque.Status;
                currentCheque.OrginalCustomerIde = orginalCustomerId;
                currentCheque.VosoolDate = VosoolDate;
                unitOfWork.ChequeServices.Update(currentCheque);
                unitOfWork.SaveChanges();
                ////////Customer transaction
                var customerTransaction = unitOfWork.Transactions.FindFirst(x => x.DocumentId == currentCheque.DocumentId && x.SourceCustomerId == prevCustomerId);
                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.DestinitionCustomerId = customerTransaction.DestinitionCustomerId;
                customerTransaction.TransactionType = customerTransaction.TransactionType;
                customerTransaction.WithdrawAmount = customerTransaction.WithdrawAmount;
                customerTransaction.DepositAmount = customerTransaction.DepositAmount;
                customerTransaction.Description = currentCheque.Description;
                customerTransaction.CurrenyId = customerTransaction.CurrenyId;
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = DateTime.Now;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.DocumentId = customerTransaction.DocumentId;
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();
                //customer transaction end///

                //DarJaryanVosool transaction
                var DarJaryanVosool = unitOfWork.Transactions.FindFirst(x => x.DocumentId == currentCheque.DocumentId && x.SourceCustomerId == AppSetting.AsnadDarJaryanVoslId);
                DarJaryanVosool.DoubleTransactionId = customerTransaction.Id;
                DarJaryanVosool.WithdrawAmount = DarJaryanVosool.WithdrawAmount;
                DarJaryanVosool.DepositAmount = DarJaryanVosool.DepositAmount;
                DarJaryanVosool.Description = currentCheque.Description;
                DarJaryanVosool.DestinitionCustomerId = (int)cmbCustomers.SelectedValue;
                DarJaryanVosool.SourceCustomerId = DarJaryanVosool.SourceCustomerId;
                DarJaryanVosool.TransactionType = DarJaryanVosool.TransactionType;
                DarJaryanVosool.CurrenyId = DarJaryanVosool.CurrenyId;
                DarJaryanVosool.Date = DateTime.Now;
                DarJaryanVosool.TransactionDateTime = DateTime.Now;
                DarJaryanVosool.UserId = CurrentUser.UserID;
                DarJaryanVosool.DocumentId = DarJaryanVosool.DocumentId;
                unitOfWork.TransactionServices.Update(DarJaryanVosool);
                unitOfWork.SaveChanges();
                //DarJaryanVosool transaction

            }
            ///////////////// //Check Status New DarJaryanVosol/////////////

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDesc_KeyUp(object sender, KeyEventArgs e)
        {
        
        }

        private void cmbCustomers_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void txtVosoolDate_KeyUp(object sender, KeyEventArgs e)
        {
            CreateDescription();
        }

        private void VosoolCheckFrm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
       
        }

        private void btnshowcustomer_Click(object sender, EventArgs e)
        {
            var frm = new SearchAllCustomersFrm();
            frm.ShowDialog();
        }

        private void CreateDescription()
        {
            txtDesc.Text = $"{Messages.Vosool } چک به شماره {currentCheque.ChequeNumber} تاریخ پاس {DateTime.Parse(txtVosoolDate.Text).ToFarsiFormat()} ";
        }



    }
}