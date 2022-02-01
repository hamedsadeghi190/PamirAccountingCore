﻿using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Checks
{
    public partial class PaymentCheckList : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ChequeModel> dataList;


        public PaymentCheckList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        private void LoadData()
        {
            dataList = unitOfWork.ChequeServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.IssueDate,
                x.Description,
                x.DocumentId,
                x.ChequeNumber,
                x.Amount,
                x.BranchName,
                x.BankAccountNumber,
                x.CustomerName,
                x.RealBankName,



            }).ToList();

        }
        private void PaymentCheckList_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            LoadData();
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            for (int i = 0; i < 12; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frm = new DetailsPaymentCheckFrm(dataList.ElementAt(e.RowIndex).Id);
                frm.ShowDialog();
                LoadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف چک", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var cheque = unitOfWork.Cheque.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id);
                        unitOfWork.ChequeServices.Delete(cheque);
                        var transactions = unitOfWork.Transactions.FindAll(x => x.DocumentId == cheque.DocumentId).ToList();
                        foreach (var item in transactions)
                        {
                            item.DoubleTransactionId = null;
                            unitOfWork.TransactionServices.Update(item);
                            unitOfWork.SaveChanges();
                        }

                        foreach (var item in transactions)
                        {
                            unitOfWork.TransactionServices.Delete(item);
                            unitOfWork.SaveChanges();
                        }

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }
    }
}