using PamirAccounting.Models;
using PamirAccounting.Models.ViewModels;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using FontStyle = System.Drawing.FontStyle;
using MessageBox = System.Windows.Forms.MessageBox;
using static PamirAccounting.Tools;


namespace PamirAccounting.Forms.Currencies
{
    public partial class updateCurrencyBaseRateFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<ComboBoxModel> _ActionType;
        private List<CurrenciesViewModel> dataList;
        private UnitOfWork unitOfWork;
        private Domains.Currency selectedCurrency;

        public updateCurrencyBaseRateFrm()
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
        private void updateCurrencyBaseRateFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            SetComboBoxHeight(cmbAction.Handle, 25);
            cmbAction.Refresh();
    
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
        
            this.cmbAction.SelectedIndexChanged -= new System.EventHandler(this.cmbVarizType_SelectedIndexChanged);
            _ActionType = new List<ComboBoxModel>();
            _ActionType.Add(new ComboBoxModel() { Id = 1, Title = " ضرب" });
            _ActionType.Add(new ComboBoxModel() { Id = 2, Title = "تقسیم" });

            cmbAction.DataSource = _ActionType;
            cmbAction.ValueMember = "Id";
            cmbAction.DisplayMember = "Title";
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbVarizType_SelectedIndexChanged);
            loadData();
        }


        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataList = unitOfWork.Currencies.FindAll().Select(x => new CurrenciesViewModel { Id = x.Id, Name = x.Name, BaseRate = x.BaseRate, Action =x.Action }).ToList();
            dataGridView1.DataSource = dataList;
        }
        private void cmbVarizType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                showEdit(e.RowIndex);
            }
        }

        private void showEdit(int index )
        {
             var curreny = dataList.ElementAt(index);
            
            selectedCurrency = unitOfWork.CurrencyServices.FindFirst(x => x.Id == curreny.Id);
            
            lblRate.Visible = true;
            lblAction.Visible = true;
            cmbAction.Visible = true;
            lblArz.Visible = true;
            lblCurrenyName.Visible = true;
            btnSave.Visible = true;
            txtRate.Visible = true;

            txtRate.Text = curreny.BaseRate.HasValue ? curreny.BaseRate.Value.ToString() : "0";
            cmbAction.SelectedValue = curreny.Action.HasValue ? curreny.Action.Value : 1;
            lblCurrenyName.Text = curreny.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRate.Text.Length > 0)
            {
                selectedCurrency.Action = byte.Parse(cmbAction.SelectedValue.ToString());
                selectedCurrency.BaseRate = Double.Parse(txtRate.Text.Replace(',', '.'), CultureInfo.InvariantCulture) ;
                unitOfWork.CurrencyServices.Update(selectedCurrency);
                unitOfWork.SaveChanges();
                #region Log
                var log = new Domains.DailyOperation();
                log.Date = DateTime.Parse(DateTime.Now.ToString());
                log.Time = DateTime.Now.TimeOfDay;
                log.UserId = CurrentUser.UserID;
                log.UserName = CurrentUser.UserName;
                log.Description = $"ویرایش نرخ معیار {selectedCurrency.Name}";
                log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                unitOfWork.DailyOperationServices.Insert(log);
                unitOfWork.SaveChanges();
                #endregion
                MessageBox.Show("نرخ بروز رسانی شد");
                loadData();
            }
            else
            {
                MessageBox.Show("نرخ را وارد نمایید");
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateCurrencyBaseRateFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}