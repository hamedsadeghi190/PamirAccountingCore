using DevExpress.XtraEditors;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Models;
using PamirAccounting.Services;
using Stimulsoft.Report;
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

namespace PamirAccounting.Forms.Checks
{
    public partial class BargashtCheckDaryaftiReportFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<ChequeModel> dataList;
        public BargashtCheckDaryaftiReportFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        private void LoadData()
        {
            dataList = unitOfWork.ChequeServices.GetAllBargashtShode();
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
                x.DueDate,
                x.RowId,
                x.DueDatePersian,
                x.IssueDatePersian,
                
            }).ToList();

        }
      

        private void BargashtCheckPardakhtaniReportFrm_Load(object sender, EventArgs e)
        {
            txtChequeNumber.Select();
            txtChequeNumber.Focus();
            dataGridView1.AutoGenerateColumns = false;
            LoadData();
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
            txtChequeNumber.Select();
            txtChequeNumber.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frm = new BargashtCheckDaryaftaniFrm(0, dataList.ElementAt(e.RowIndex).Id);
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

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var data = new UnitOfWork().ChequeServices.GetAllBargashtShode();
            var basedata = new reportbaseDAta() { Date = PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "ReceiveCheckBargashtList.mrt");
            report.RegData("myData", data);
            report.RegData("basedata", basedata);
           // report.Design();
            report.Render();
            report.Show();
        }

        private void txtAccountNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtAccountNumber.Text.Length > 0)
            {
                PersianCalendar pc = new PersianCalendar();
                dataList = unitOfWork.ChequeServices.GetAllBargashtShode();
                dataGridView1.DataSource = dataList.Select(x => new
                {
                    x.Id,
                    x.RowId,
                    x.IssueDate,
                    x.Description,
                    x.DocumentId,
                    x.ChequeNumber,
                    x.Amount,
                    x.BranchName,
                    x.BankAccountNumber,
                    x.CustomerName,
                    x.RealBankName,
                    x.DueDate,
                    IssueDatePersian = pc.GetYear(x.IssueDate).ToString() + "/" + pc.GetMonth(x.IssueDate).ToString() + "/" + pc.GetDayOfMonth(x.IssueDate).ToString(),
                    DueDatePersian = pc.GetYear(x.DueDate).ToString() + "/" + pc.GetMonth(x.DueDate).ToString() + "/" + pc.GetDayOfMonth(x.DueDate).ToString()

                }).Where(x => x.BankAccountNumber.Contains(txtAccountNumber.Text)).ToList();

            }
            else
            {
                LoadData();
            }

        }

        private void txtChequeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtChequeNumber.Text.Length > 0)
            {
                PersianCalendar pc = new PersianCalendar();
                dataList = unitOfWork.ChequeServices.GetAllBargashtShode();
                dataGridView1.DataSource = dataList.Select(x => new
                {
                    x.Id,
                    x.RowId,
                    x.IssueDate,
                    x.Description,
                    x.DocumentId,
                    x.ChequeNumber,
                    x.Amount,
                    x.BranchName,
                    x.BankAccountNumber,
                    x.CustomerName,
                    x.RealBankName,
                    x.DueDate,
                    IssueDatePersian = pc.GetYear(x.IssueDate).ToString() + "/" + pc.GetMonth(x.IssueDate).ToString() + "/" + pc.GetDayOfMonth(x.IssueDate).ToString(),
                    DueDatePersian = pc.GetYear(x.DueDate).ToString() + "/" + pc.GetMonth(x.DueDate).ToString() + "/" + pc.GetDayOfMonth(x.DueDate).ToString()

                }).Where(x => x.ChequeNumber.Contains( txtChequeNumber.Text)).ToList();

            }
            else
            {
                LoadData();
            }
        }

        private void BargashtCheckDaryaftiReportFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F3)
            {
                this.txtChequeNumber.Focus();
            }
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}


            if (e.KeyCode == Keys.F7)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    var frm = new BargashtCheckDaryaftaniFrm(0, dataList.ElementAt(rowIndex).Id);
                    frm.ShowDialog();
                    LoadData();
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف چک", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                          MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var cheque = unitOfWork.Cheque.FindFirstOrDefault(x => x.Id == dataList.ElementAt(rowIndex).Id);
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

            if (e.KeyCode == Keys.F8)
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Now;
                string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                var data = new UnitOfWork().ChequeServices.GetAllBargashtShode();
                var basedata = new reportbaseDAta() { Date = PersianDate };
                var report = StiReport.CreateNewReport();
                report.Load(AppSetting.ReportPath + "ReceiveCheckBargashtList.mrt");
                report.RegData("myData", data);
                report.RegData("basedata", basedata);
                //report.Design();
                report.Render();
                report.Show();

            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
    }
}