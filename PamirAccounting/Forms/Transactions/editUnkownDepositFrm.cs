using DNTPersianUtils.Core;
using Microsoft.EntityFrameworkCore;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Transactions
{
    public partial class editUnkownDepositFrm : DevExpress.XtraEditors.XtraForm
    {

        private UnitOfWork unitOfWork;
        private Domains.Transaction transaction;
        private long Id;
        private List<TransactionsToCustomerModel> _dataList = new List<TransactionsToCustomerModel>();

        public editUnkownDepositFrm(long id)
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            Id = id;
            dataGridView1.AutoGenerateColumns = false;
        }
        private void editUnkownDepositFrm_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
   
          //  this.dataGridView1.DefaultCellStyle.Font = new Font("IRANSansMobile(FaNum)", 10, FontStyle.Bold);
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;

            transaction = unitOfWork.Transactions.FindAll(x => x.Id == Id).Include(y => y.SourceCustomer).FirstOrDefault();
            if (transaction == null)
            {
                Close();
                return;
            }

            txtradif.Text = transaction.Id.ToString();
            txtAmount.Text = transaction.WithdrawAmount.Value.ToString();
            txtReceiptNumber.Text = transaction.ReceiptNumber;
            txtBranchCode.Text = transaction.BranchCode;
            txtBankName.Text = transaction.SourceCustomer.FirstName;
            txtDate.Text = (DateTime.Parse(transaction.Date.ToString())).ToShortPersianDateString();
            txtdesc.Text = transaction.Description;
            txtradif.Text = transaction.DocumentId.ToString();
            dataGridView1.Focus();
        }


        private void createDeposit(int customerID, int currenyId, int destCustomerId, long amount, string description, DateTime dateTime)
        {

            var customerTransaction = new Domains.Transaction();
            customerTransaction.TransactionType = 3;
            customerTransaction.SourceCustomerId = customerID;
            customerTransaction.DestinitionCustomerId = destCustomerId;
            customerTransaction.Description = description;
            customerTransaction.DepositAmount = amount;
            customerTransaction.WithdrawAmount = 0;
            customerTransaction.DocumentId = transaction.DocumentId;
            customerTransaction.ReceiptNumber = txtReceiptNumber.Text;
            customerTransaction.BranchCode = txtBranchCode.Text;

            customerTransaction.CurrenyId = currenyId;
            customerTransaction.Date = dateTime;
            customerTransaction.TransactionDateTime = dateTime;
            customerTransaction.UserId = CurrentUser.UserID;

            unitOfWork.TransactionServices.Insert(customerTransaction);
            unitOfWork.SaveChanges();
        }

        private void CreateWithDraw(int customerID, int currenyId, int destCustomerId, long amount, string description, DateTime dateTime)
        {

            var bankTransaction = new Domains.Transaction();
            bankTransaction.DocumentId = transaction.DocumentId;
            bankTransaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
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
            unitOfWork.TransactionServices.Insert(bankTransaction);
            unitOfWork.SaveChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dataList.Sum(x => x.Amount) == transaction.WithdrawAmount.Value)
            {
                var bankDesc = "واریز به " + transaction.SourceCustomer.FirstName + "  کدشعبه " + transaction.BranchCode +
                       " شماره فیش :" + transaction.ReceiptNumber + " واریز مشترک : ";
                foreach (var item in _dataList)
                {
                    var desc = "واریز به " + transaction.SourceCustomer.FirstName + "  کدشعبه " + transaction.BranchCode +
                       " شماره فیش :" + transaction.ReceiptNumber + " توسط " + item.FullName;
                    bankDesc += $" {item.FullName} ";

                    createDeposit(item.CustomerId, transaction.CurrenyId.Value, transaction.SourceCustomerId, item.Amount.Value, desc, transaction.Date);
                   // CreateWithDraw(transaction.SourceCustomerId, transaction.CurrenyId.Value, item.CustomerId, item.Amount.Value, desc, transaction.Date);
                }

               
                transaction.TransactionType = (int)TransaActionType.PayAndReciveBank;
                transaction.Description = bankDesc;
                unitOfWork.Transactions.Update(transaction);
                unitOfWork.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("مبلغ معلوم از کل کمتر است");
            }
        }

        private void btnAddDipositer_Click(object sender, EventArgs e)
        {
            var frm = new addDepositCustomerFrm();
            frm.TotalAmount = long.Parse(txtAmount.Text);

            frm.RemaingAmount = frm.TotalAmount - _dataList.Sum(x => x.Amount);

            if (frm.RemaingAmount > 0)
                frm.ShowDialog();

            if (frm.Amount.HasValue)
            {
                var customer = _dataList.FirstOrDefault(x => x.CustomerId == frm.CustomerID.Value);
                if (customer != null)
                {

                    customer.Amount += frm.Amount;
                }
                else
                {

                    _dataList.Add(new TransactionsToCustomerModel()
                    {
                        CustomerId = frm.CustomerID.Value,
                        FullName = frm.FullName,
                        Amount = frm.Amount
                    });
                }

            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _dataList;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void editUnkownDepositFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}