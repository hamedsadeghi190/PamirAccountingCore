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
    public partial class VosoolCheckDaryaftaniFrm : DevExpress.XtraEditors.XtraForm
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
        public VosoolCheckDaryaftaniFrm(long? chequeNumber)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            _ChequeNumber = chequeNumber;

        }
        public VosoolCheckDaryaftaniFrm()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            _Customers = unitOfWork.CustomerServices.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = $"{x.FirstName} {x.LastName}" }).ToList();
            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
           
            if (_ChequeNumber.HasValue)
            {
                SaveNew();
            }
            //else
            //{
            //    SaveNew();
            //}
            Close();
        }

        private void VosoolCheckDaryaftaniFrm_Load(object sender, EventArgs e)
        {
            LoadData();
            if (_ChequeNumber.HasValue)
            {
                currentCheque = unitOfWork.ChequeServices.FindFirst(x => x.Id == _ChequeNumber);
                txtDocumentId.Text = currentCheque.DocumentId.ToString();
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetMonth(currentCheque.RegisterDateTime).ToString() + "/" + pc.GetDayOfMonth(currentCheque.RegisterDateTime).ToString();
                txtDate.Text = PDate;
                string PDate2 = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtVosoolDate.Text = PDate2;
            }
        }
        private void SaveNew()
        {


            PersianCalendar p = new PersianCalendar();
            var VosoolDate1 = txtVosoolDate.Text.Split('/');
            var AssignmentDate = p.ToDateTime(int.Parse(VosoolDate1[0]), int.Parse(VosoolDate1[1]), int.Parse(VosoolDate1[2]), 0, 0, 0, 0);
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
            currentCheque.CustomerId = (int)cmbCustomers.SelectedValue;
            currentCheque.BankAccountNumber = currentCheque.BankAccountNumber;
            currentCheque.Type = currentCheque.Type;
            currentCheque.Status = (int)Settings.ChequeStatus.Vosol;
            unitOfWork.ChequeServices.Update(currentCheque);
            unitOfWork.SaveChanges();
            ////////Customer transaction

            var customerTransaction = new Domains.Transaction();
            customerTransaction.SourceCustomerId =(int)cmbCustomers.SelectedValue;
            customerTransaction.DestinitionCustomerId = AppSetting.AsnadDarJaryanVoslId;
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

            //DarJaryanVosool transaction
            var DarJaryanVosool = new Domains.Transaction();
            DarJaryanVosool.SourceCustomerId = AppSetting.AsnadDarJaryanVoslId;
            DarJaryanVosool.DoubleTransactionId = customerTransaction.Id;
            DarJaryanVosool.WithdrawAmount = 0;
            DarJaryanVosool.DepositAmount = currentCheque.Amount;
            DarJaryanVosool.Description = (txtDesc.Text.Length > 0) ? txtDesc.Text : Messages.DepostitCheck + " به شماره چک -" + DocumentId; ;
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
        private void VosoolCheckFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }



    }
}