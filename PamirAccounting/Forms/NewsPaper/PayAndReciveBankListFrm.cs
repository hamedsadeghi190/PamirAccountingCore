﻿using DevExpress.XtraEditors;
using PamirAccounting.Forms.Transactions;
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

namespace PamirAccounting.Forms.NewsPaper
{
    public partial class PayAndReciveBankListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private Domains.Customer _Customer;
        private List<ComboBoxModel> _Actions = new List<ComboBoxModel>();
        private List<TransactionModel> _dataList = new List<TransactionModel>();
        private List<TransactionModel> _GroupedDataList;
        private List<TransactionsGroupModel> _dataListTotal;
        private List<ComboBoxModel> _Currencies = new List<ComboBoxModel>();
        private List<ComboBoxModel> _Groups = new List<ComboBoxModel>();

        public PayAndReciveBankListFrm()
        {

            InitializeComponent();
            unitOfWork = new UnitOfWork();

        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight(IntPtr comboBoxHandle, Int32 comboBoxDesiredHeight)
        {
            SendMessage(comboBoxHandle, CB_SETITEMHEIGHT, -1, comboBoxDesiredHeight);
        }

        private void initGrid()
        {
          
        }



        private void InitForm()
        {
            SetComboBoxHeight(cmbBank.Handle, 25);
            cmbBank.Refresh();
            _Currencies.Add(new ComboBoxModel() { Id = 0, Title = "همه" });
            _Currencies.AddRange(unitOfWork.Customers.FindAll().Where(x=>x.GroupId==2).Select(x => new ComboBoxModel() { Id = x.Id, Title = x.FirstName }).ToList());
            cmbBank.SelectedValueChanged -= new EventHandler(cmbBank_SelectedValueChanged);
            cmbBank.TextChanged -= new EventHandler(cmbBank_TextChanged);
            cmbBank.DataSource = _Currencies;
            cmbBank.ValueMember = "Id";
            cmbBank.DisplayMember = "Title";
            cmbBank.SelectedValueChanged += new EventHandler(cmbBank_SelectedValueChanged);
            cmbBank.TextChanged += new EventHandler(cmbBank_TextChanged);
       

        }

        private void LoadData()
        {
             _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveBank(((int)cmbBank.SelectedValue != 0) ? (int)cmbBank.SelectedValue : null);
            GellAll(_dataList);
        }

        private void cmbBank_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBank_SelectedValueChanged(object sender, EventArgs e)
        {

            if ((int)cmbBank.SelectedValue > 0)
            {
                _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveBank((int)cmbBank.SelectedValue);
                GellAll(_dataList);
            }
            else
            {
                LoadData();
            }
        }

        private void PayAndReciveBankListFrm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F2)
            {
                cmbBank.Select();
                cmbBank.Focus();
            }
           


            if (e.KeyCode == Keys.F8)
            {
                //PersianCalendar pc = new PersianCalendar();
                //DateTime dt = DateTime.Now;
                //string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
                //var data = TotalPrint();
                //var data2 = TotalSummeryPrint();
                //var basedata = new reportbaseDAta() { Date = PersianDate };
                //var report = StiReport.CreateNewReport();
                //report.Load(AppSetting.ReportPath + "CreditorList.mrt");
                //report.RegData("myData", data);
                //report.RegData("myData2", data2);
                //report.RegData("basedata", basedata);
                //// report.Design();
                //report.Render();
                //report.Show();

            }
        }

        private void PayAndReciveBankListFrm_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
            initGrid();
            PersianCalendar pc = new PersianCalendar();
            string PDate = pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString();
            txtDate.Text = PDate;
        }

        private void GellAll(List<TransactionModel> _list)
        {
            var tmpDataList = _list;
          //  var grouped = tmpDataList.GroupBy(x => x.CurrenyId);
            //_dataList = new List<TransactionModel>();
            _GroupedDataList = new List<TransactionModel>();
            foreach (var item in tmpDataList)
            {
                var curenncySummery = new TransactionModel();

                curenncySummery.FullName = item.FullName;
                curenncySummery.BranchCode = item.BranchCode;
                curenncySummery.ReceiptNumber = item.ReceiptNumber;
                curenncySummery.TransactionDateTime = item.TransactionDateTime;
                curenncySummery.DepositAmount = item.DepositAmount;
                _GroupedDataList.Add(curenncySummery);

            }

            _GroupedDataList = _GroupedDataList.OrderBy(x => x.FullName).ToList();
            int row = 1;
            foreach (var item in _GroupedDataList)
            {
                item.RowId = row++;
            }
            gridPayAndReciveBank.AutoGenerateColumns = false;
            gridPayAndReciveBank.DataSource = tmpDataList;

        }

        private void grdTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridPayAndReciveBank.Columns["BtnEdit"].Index && e.RowIndex >= 0)
            {
                var tranactionId = _dataList.ElementAt(e.RowIndex).Id;
                var frmbankunkown = new PayAndReciveBankFrm(0, tranactionId);
                frmbankunkown.ShowDialog();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtDate.Text.Length > 0)
            {
                var dDate = txtDate.Text.Split('_');
                if (dDate[0].Length == 10)
                {
                    _dataList = unitOfWork.TransactionServices.GetAllPayAndReciveBank(txtDate.Text);
                    GellAll(_dataList);
                }
                else
                    return;
            }
            else
                LoadData();
        }
    }
}