using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Transactions
{
    public partial class editUnkownDepositFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private Domains.Transaction transaction;
        private int Id;
        private List<TransactionsToCustomerModel> _dataList = new List<TransactionsToCustomerModel>();

        public editUnkownDepositFrm(int id)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            Id = id;
            dataGridView1.AutoGenerateColumns = false;
        }
        private void editUnkownDepositFrm_Load(object sender, EventArgs e)
        {
            transaction = unitOfWork.Transactions.FindAll(x => x.Id == Id).Include(x => x.SourceCustomer).FirstOrDefault();
            if (transaction == null)
            {
                Close();
            }

            txtradif.Text = transaction.Id.ToString();
            txtAmount.Text = transaction.WithdrawAmount.Value.ToString();
            txtReceiptNumber.Text = transaction.ReceiptNumber;
            txtBranchCode.Text = transaction.BranchCode;
            txtBankName.Text = transaction.SourceCustomer.FirstName;
            txtDate.Text = (DateTime.Parse(transaction.Date.ToString())).ToShortPersianDateString();
            txtdesc.Text = transaction.Description;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_dataList.Sum(x => x.Amount) == transaction.WithdrawAmount.Value)
            {
                var firstTr = _dataList.First();
                transaction.DestinitionCustomerId = firstTr.CustomerId;
                transaction.TransactionType = 3;
                transaction.WithdrawAmount = firstTr.Amount ;
                transaction.Description = "واریز به " + transaction.SourceCustomer.FirstName + "  کدشعبه " + transaction.BranchCode +
                    " شماره فیش :" + transaction.ReceiptNumber + " توسط " + firstTr.FullName;
                unitOfWork.Transactions.Update(transaction);
                unitOfWork.SaveChanges();

                createDeposit(firstTr.CustomerId, transaction.CurrenyId.Value, transaction.SourceCustomerId, firstTr.Amount.Value, transaction.Description, transaction.Date);

                var otherTrs = _dataList.Where(x => x.CustomerId != firstTr.CustomerId).ToList();
                foreach (var item in otherTrs)
                {
                    createDeposit(item.CustomerId, transaction.CurrenyId.Value, transaction.SourceCustomerId, item.Amount.Value, transaction.Description, transaction.Date);
                    CreateWithDraw(transaction.SourceCustomerId, transaction.CurrenyId.Value, item.CustomerId, item.Amount.Value, transaction.Description, transaction.Date);
                }

                Close();
            }
            else
            {
                MessageBox.Show("مبلغ معلوم از کل کمتر است");
            }
        }

        private void createDeposit(int customerID,int currenyId,int destCustomerId,long amount , string description,DateTime dateTime)
        {
            var customerAccount = unitOfWork.TransactionServices.FindLastTransaction(customerID, 1, currenyId);
            if (customerAccount == null)
            {
                createAccount(customerID, currenyId);
            }
           var customerlastTransAction = unitOfWork.TransactionServices.FindLastTransaction(customerID, currenyId);

            var customerTransaction = new Domains.Transaction();
            customerTransaction.TransactionType = 3;
            customerTransaction.SourceCustomerId = customerID;
            customerTransaction.DestinitionCustomerId = destCustomerId;
            customerTransaction.Description = description;
            customerTransaction.DepositAmount = amount;
            customerTransaction.WithdrawAmount = 0;

            customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
            customerTransaction.BranchCode = txtBranchCode.Text;

            customerTransaction.CurrenyId = currenyId;
            customerTransaction.Date = dateTime;
            customerTransaction.TransactionDateTime = dateTime;
            customerTransaction.UserId = CurrentUser.UserID;
            var cRemainigAmount = (customerTransaction.DepositAmount.Value != 0) ? customerTransaction.DepositAmount.Value : customerTransaction.WithdrawAmount.Value * -1;
            customerTransaction.RemainigAmount = customerlastTransAction.RemainigAmount + cRemainigAmount;
            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
        }

        private void createAccount(int SourceCustomerId, int CurrenyId)
        {
            var newTransaction = new Domains.Transaction();
            newTransaction.SourceCustomerId = SourceCustomerId;
            newTransaction.TransactionType = 1;
            newTransaction.Description = "حساب جدید";
            newTransaction.WithdrawAmount = 0;
            newTransaction.DepositAmount = 0;
            newTransaction.RemainigAmount = 0;
            newTransaction.CurrenyId = CurrenyId;
            newTransaction.Date = DateTime.Now;
            newTransaction.TransactionDateTime = DateTime.Now;
            newTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(newTransaction);
            unitOfWork.SaveChanges();

        }


        private void CreateWithDraw(int customerID, int currenyId, int destCustomerId, long amount, string description, DateTime dateTime)
        {
            var customerAccount = unitOfWork.TransactionServices.FindLastTransaction(customerID, 1, currenyId);
            if (customerAccount == null)
            {
                createAccount(customerID, currenyId);
            }
            var banklastTransAction = unitOfWork.TransactionServices.FindLastTransaction(customerID, currenyId);


            
            var bankTransaction = new Domains.Transaction();

            bankTransaction.TransactionType = 3;
            bankTransaction.DestinitionCustomerId = destCustomerId;
            bankTransaction.SourceCustomerId = customerID;
            bankTransaction.Description = description;
            bankTransaction.DepositAmount = 0;
            bankTransaction.WithdrawAmount = amount;


            bankTransaction.CurrenyId = currenyId;
            var dDate = txtDate.Text.Split('/');

            PersianCalendar p = new PersianCalendar();
            var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
            bankTransaction.Date = DateTime.Now;
            bankTransaction.TransactionDateTime = TransactionDateTime;
            bankTransaction.UserId = CurrentUser.UserID;
            var RemainigAmount = (bankTransaction.DepositAmount.Value != 0) ? bankTransaction.DepositAmount.Value : bankTransaction.WithdrawAmount.Value * -1;
            bankTransaction.RemainigAmount = banklastTransAction.RemainigAmount + RemainigAmount;
            unitOfWork.TransactionServices.Insert(bankTransaction);
            unitOfWork.SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsavebank_Click(object sender, EventArgs e)
        {
            var frm = new addDepositCustomerFrm();
            frm.TotalAmount = long.Parse(txtAmount.Text);

            frm.RemaingAmount = frm.TotalAmount - _dataList.Sum(x => x.Amount);

            if (frm.RemaingAmount > 0)
                frm.ShowDialog();

            if (frm.Amount.HasValue)
            {
                _dataList.Add(new TransactionsToCustomerModel()
                {
                    CustomerId = frm.CustomerID.Value,
                    FullName = frm.FullName,
                    Amount = frm.Amount
                });
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _dataList;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frm = new addDepositCustomerFrm();
                frm.TotalAmount = long.Parse(txtAmount.Text);
                frm.RemaingAmount = frm.TotalAmount - _dataList.Sum(x => x.Amount);
                frm.CustomerID = _dataList.ElementAt(e.RowIndex).CustomerId;
                frm.Amount = _dataList.ElementAt(e.RowIndex).Amount;
                frm.ShowDialog();
                
                var tmp = _dataList.Where(x => x.CustomerId == frm.CustomerID.Value).First();

                tmp.CustomerId = frm.CustomerID.Value;
                tmp.FullName = frm.FullName;
                tmp.Amount = frm.Amount;
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _dataList;
                dataGridView1.Update();
                dataGridView1.Refresh();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        _dataList = _dataList.Where(x => x.CustomerId != _dataList.ElementAt(e.RowIndex).CustomerId).ToList();

        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = _dataList;
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                    }
                    catch
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }
                }
            }
        }
    }
}