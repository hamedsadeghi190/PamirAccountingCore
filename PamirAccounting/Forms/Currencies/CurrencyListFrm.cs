using PamirAccounting.Domains;
using PamirAccounting.Models.ViewModels;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static PamirAccounting.Tools;


namespace PamirAccounting.UI.Forms.Currencies
{
    public partial class CurrencyListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<CurrenciesViewModel> dataList;
        public CurrencyListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }



        private void CurrencyListFrm_Load(object sender, EventArgs e)
        {
            txtsearch.Select();
            txtsearch.Focus();
            loadData();

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CurrencyCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id.Value);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ارز", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                       var Currency = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id.Value);
                        unitOfWork.CurrencyServices.Delete(Currency.Id);
                        #region Log
                        var log = new Domains.DailyOperation();
                        log.Date = DateTime.Parse(DateTime.Now.ToString());
                        log.Time = DateTime.Now.TimeOfDay;
                        log.UserId = CurrentUser.UserID;
                        log.UserName = CurrentUser.UserName;
                        log.Description = $"حذف ارز {Currency.Name}";
                        log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                        log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                        unitOfWork.DailyOperationServices.Insert(log);
                        unitOfWork.SaveChanges();
                        #endregion
                        loadData();
                    }
                    catch
                    {
                        MessageBox.Show("ارز انتخابی در نرم افزار استفاده شده است ، حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void loadData()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataList = unitOfWork.Currencies.FindAll().Select(x => new CurrenciesViewModel { Id = x.Id, Name = x.Name }).ToList();
            int row = 1;
            var tmpdataList = dataList.Select(x => new CurrenciesViewModel
            {
                rowId = row++,
                Id = x.Id,
                Name = x.Name


            }).ToList();
            dataGridView1.DataSource = tmpdataList;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {


        }


        private void CreateNewCurrencyBtn_Click(object sender, EventArgs e)
        {
            var frmCurrencies = new CurrencyCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtsearch.Text.Length > 0)
            {
                dataList = unitOfWork.Currencies.FindAll(y => y.Name.Contains(txtsearch.Text)).Select(x => new CurrenciesViewModel { Id = x.Id, Name = x.Name }).ToList();
                int row = 1;
                var tmpdataList = dataList.Select(x => new CurrenciesViewModel
                {
                    rowId = row++,
                    Id = x.Id,
                    Name = x.Name


                }).ToList();
                dataGridView1.DataSource = tmpdataList;
            }
            else
            {
                loadData();
            }
        }

        private void CurrencyListFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtsearch.Select();
                txtsearch.Focus();
            }
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //    e.Handled = true;
            //}
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F7)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    var frmCurrencies = new CurrencyCreateUpdateFrm(dataList.ElementAt(rowIndex).Id.Value);
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;

                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف ارز", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var Currency = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == dataList.ElementAt(rowIndex).Id.Value);
                            unitOfWork.CurrencyServices.Delete(Currency.Id);
                            #region Log
                            var log = new Domains.DailyOperation();
                            log.Date = DateTime.Parse(DateTime.Now.ToString());
                            log.Time = DateTime.Now.TimeOfDay;
                            log.UserId = CurrentUser.UserID;
                            log.UserName = CurrentUser.UserName;
                            log.Description = $"حذف ارز {Currency.Name}";
                            log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                            log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                            unitOfWork.DailyOperationServices.Insert(log);
                            unitOfWork.SaveChanges();
                            #endregion
                            loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ارز انتخابی در نرم افزار استفاده شده است ، حذف امکانپذیر نمیباشد");
                        }

                    }
                }
            }

            if (e.KeyCode == Keys.F6)
            {
                var frmCurrencies = new CurrencyCreateUpdateFrm();
                frmCurrencies.ShowDialog();
                loadData();

            }
        }
    }
}
