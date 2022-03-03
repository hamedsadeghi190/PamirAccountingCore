using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.UI.Forms.Transaction
{
    public partial class TransferAccountFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private int? _Id;
        private long? _TransActionId;
        private Domains.Transaction sourceTransaction, destinationTransaction;
        private List<ComboBoxModel> _Currencies, _SourceCustomers, _destCustomers;


        public TransferAccountFrm(int Id, long? transActionId)
        {
            _Id = Id;
            _TransActionId = transActionId;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        public TransferAccountFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }
        private void TransferAccountFrm_Load(object sender, EventArgs e)
        {
            LoadData();

            if (_TransActionId.HasValue)
            {
                loadTransferInfo();
            }
            else
            {
                PersianCalendar pc = new PersianCalendar();
                string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
                txtDate.Text = PDate;
            }
            this.CmbSource.SelectedIndexChanged += new System.EventHandler(this.CmbSource_SelectedIndexChanged);
            this.cmbDestiniation.SelectedIndexChanged += new System.EventHandler(this.cmbDestiniation_SelectedIndexChanged);
            this.cmbCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
        }

        private void loadTransferInfo()
        {
            sourceTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == _TransActionId.Value);
            destinationTransaction = unitOfWork.TransactionServices.FindFirst(x => x.Id == sourceTransaction.DoubleTransactionId);

            if (sourceTransaction.WithdrawAmount.Value != 0)
            {
                txtAmount.Text = sourceTransaction.WithdrawAmount.Value.ToString();
            }
            else
            {
                txtAmount.Text = sourceTransaction.DepositAmount.Value.ToString();
            }

            txtDesc.Text = sourceTransaction.Description;

            cmbCurrencies.SelectedValue = sourceTransaction.CurrenyId;

            CmbSource.SelectedValue = sourceTransaction.SourceCustomerId;

            cmbDestiniation.SelectedValue = sourceTransaction.DestinitionCustomerId;

            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(sourceTransaction.TransactionDateTime).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDate.Text = PDate;
        }

        private void LoadData()
        {

            this.CmbSource.SelectedIndexChanged -= new System.EventHandler(this.CmbSource_SelectedIndexChanged); 
            this.cmbDestiniation.SelectedIndexChanged -= new System.EventHandler(this.cmbDestiniation_SelectedIndexChanged);
            this.cmbCurrencies.SelectedIndexChanged -= new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new ComboBoxModel() { Id = x.Id, Title = x.Name }).ToList();

            cmbCurrencies.DataSource = _Currencies;
            cmbCurrencies.ValueMember = "Id";
            cmbCurrencies.DisplayMember = "Title";

            _SourceCustomers = unitOfWork.CustomerServices.GetAllNotDefaults();

            CmbSource.DataSource = _SourceCustomers;
            CmbSource.ValueMember = "Id";
            CmbSource.DisplayMember = "Title";

            _destCustomers = new List<ComboBoxModel>();
            _destCustomers.AddRange(_SourceCustomers);
            cmbDestiniation.DataSource = _destCustomers;
            cmbDestiniation.ValueMember = "Id";
            cmbDestiniation.DisplayMember = "Title";

            if (_Id != null)
            {
                CmbSource.SelectedValue = _Id;
            }
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            if(_TransActionId.HasValue)
            {
                SaveEdit();
            }
            else
            {
                CreateTransfer();
            }
            
            Close();
        }

        private void SaveEdit()
        {
          
            sourceTransaction.TransactionType = (int)TransaActionType.Transfer;
            sourceTransaction.DestinitionCustomerId = (int)cmbDestiniation.SelectedValue;
            sourceTransaction.SourceCustomerId = (int)CmbSource.SelectedValue;
            sourceTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            sourceTransaction.DepositAmount = 0;
            sourceTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            sourceTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            sourceTransaction.Date = DateTime.Now;
            sourceTransaction.TransactionDateTime = TransactionDateTime;
            sourceTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Update(sourceTransaction);
            unitOfWork.SaveChanges();


            destinationTransaction = new Domains.Transaction();
            destinationTransaction.SourceCustomerId = (int)cmbDestiniation.SelectedValue;
            destinationTransaction.DestinitionCustomerId = (int)CmbSource.SelectedValue;
            destinationTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            destinationTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            destinationTransaction.WithdrawAmount = 0;
            destinationTransaction.TransactionType = (int)TransaActionType.Transfer;
            destinationTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;

            var cDate = txtDate.Text.Split('/');
            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            destinationTransaction.Date = DateTime.Now;
            destinationTransaction.TransactionDateTime = TransactionDateTime;
            destinationTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Update(destinationTransaction);
            unitOfWork.SaveChanges();

        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }

        private void CmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }


        private void cmbDestiniation_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }


        private void CreateDescription()
        {
            txtDesc.Text = $"انتقال وجه از  {CmbSource.Text} به {cmbDestiniation.Text} به مبلغ {txtAmount.Text} {cmbCurrencies.Text}";
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CreateDescription();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TransferAccountFrm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateTransfer()
        {
            sourceTransaction = new Domains.Transaction();
            sourceTransaction.DocumentId = unitOfWork.TransactionServices.GetNewDocumentId();
            sourceTransaction.TransactionType = (int)TransaActionType.Transfer;
            sourceTransaction.DestinitionCustomerId = (int)cmbDestiniation.SelectedValue;
            sourceTransaction.SourceCustomerId = (int)CmbSource.SelectedValue;
            sourceTransaction.Description = txtDesc.Text.Length > 0 ? txtDesc.Text : " انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            sourceTransaction.DepositAmount = 0;
            sourceTransaction.WithdrawAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            sourceTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            sourceTransaction.Date = DateTime.Now;
            sourceTransaction.TransactionDateTime = TransactionDateTime;
            sourceTransaction.UserId = CurrentUser.UserID;
            unitOfWork.TransactionServices.Insert(sourceTransaction);
            unitOfWork.SaveChanges();


             destinationTransaction = new Domains.Transaction();
            destinationTransaction.DoubleTransactionId = sourceTransaction.Id;
            destinationTransaction.DocumentId = sourceTransaction.DocumentId;
            destinationTransaction.SourceCustomerId = (int)cmbDestiniation.SelectedValue;
            destinationTransaction.DestinitionCustomerId = (int)CmbSource.SelectedValue;
            destinationTransaction.Description = txtDesc.Text.Length>0 ? txtDesc.Text :" انتقال از حساب " + CmbSource.Text + " به " + cmbDestiniation.Text;
            destinationTransaction.DepositAmount = (String.IsNullOrEmpty(txtAmount.Text.Trim())) ? 0 : long.Parse(txtAmount.Text);
            destinationTransaction.WithdrawAmount = 0;
            destinationTransaction.TransactionType = (int)TransaActionType.Transfer;
            destinationTransaction.CurrenyId = (int)cmbCurrencies.SelectedValue;

            var cDate = txtDate.Text.Split('/');
            PersianCalendar pc = new PersianCalendar();
            TransactionDateTime = p.ToDateTime(int.Parse(cDate[0]), int.Parse(cDate[1]), int.Parse(cDate[2]), 0, 0, 0, 0);
            destinationTransaction.Date = DateTime.Now;
            destinationTransaction.TransactionDateTime = TransactionDateTime;
            destinationTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(destinationTransaction);
            unitOfWork.SaveChanges();

            sourceTransaction.DoubleTransactionId = destinationTransaction.Id;
            unitOfWork.TransactionServices.Update(sourceTransaction);
            unitOfWork.SaveChanges();
        }
       
    }
}