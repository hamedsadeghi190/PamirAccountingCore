using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static PamirAccounting.Commons.Enums.Settings;
using static PamirAccounting.Tools;


namespace PamirAccounting.UI.Forms.CurrencyAgencies
{
    public partial class FrmCurrencyAgenciesList : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<AgencyCurencyModel> dataList;
        public FrmCurrencyAgenciesList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }



        private void FrmCurrencyAgenciesList_Load(object sender, EventArgs e)
        {
            var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
            var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.CurrencyAgencies && x.UserId == CurrentUser.UserID);
            if (roleId == null && adminRole == null)
            {
                BtnCreateNew.Enabled = false;

            }
          
                txtSearch.Select();
            txtSearch.Focus();
            dataGridView1.AutoGenerateColumns = false;
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

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {

            var frmCurrencie = new CurrencyAgenciesCreateUpdateFrm();
            frmCurrencie.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            dataList = unitOfWork.CurrenciesMappingServices.GetAll();
            dataGridView1.DataSource = dataList;
        }


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.CurrencyAgencies && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    var frmCurrencies = new CurrencyAgenciesCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                    frmCurrencies.ShowDialog();
                    loadData();
                }
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف عملیات ارز نمایندگی", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                        var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.DeleteCurrencyAgencies && x.UserId == CurrentUser.UserID);
                        if (roleId == null && adminRole == null)
                        {
                            MessageBox.Show(Messages.PermissionMsg);
                            return;

                        }
                        if (roleId != null || adminRole != null)
                        {
                            var currency = unitOfWork.CurrenciesMappings.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id);
                            var sourceCurrenyName = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == currency.SourceCurrenyId).Name;
                            var destiniationCurrenyName = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == currency.DestiniationCurrenyId).Name;
                            unitOfWork.CurrenciesMappingServices.Delete(currency.Id);
                            unitOfWork.SaveChanges();
                            #region Log
                            var log = new Domains.DailyOperation();
                            log.Date = DateTime.Parse(DateTime.Now.ToString());
                            log.Time = DateTime.Now.TimeOfDay;
                            log.UserId = CurrentUser.UserID;
                            log.UserName = CurrentUser.UserName;
                            log.Description = $"حذف عملیات رمز ارز حواله {sourceCurrenyName}، ارز دریافتی {destiniationCurrenyName}";
                            log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                            log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                            unitOfWork.DailyOperationServices.Insert(log);
                            unitOfWork.SaveChanges();
                            #endregion
                            loadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Select();
                dataGridView1.Focus();
            }
            if (txtSearch.Text.Length > 0)
            {
                dataList = unitOfWork.CurrenciesMappingServices.Search(txtSearch.Text);
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void FrmCurrencyAgenciesList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                txtSearch.Select();
                txtSearch.Focus();
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
                    var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                    var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.CurrencyAgencies && x.UserId == CurrentUser.UserID);
                    if (roleId == null && adminRole == null)
                    {
                        MessageBox.Show(Messages.PermissionMsg);
                        return;

                    }
                    if (roleId != null || adminRole != null)
                    {
                        var rowIndex = dataGridView1.SelectedRows[0].Index;
                        var frmCurrencies = new CurrencyAgenciesCreateUpdateFrm(dataList.ElementAt(rowIndex).Id);
                        frmCurrencies.ShowDialog();
                        loadData();
                    }
                }
            }


            if (e.KeyCode == Keys.F5)
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var rowIndex = dataGridView1.SelectedRows[0].Index;
                    DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف عملیات ارز نمایندگی", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                            var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.DeleteCurrencyAgencies && x.UserId == CurrentUser.UserID);
                            if (roleId == null && adminRole == null)
                            {
                                MessageBox.Show(Messages.PermissionMsg);
                                return;

                            }
                            if (roleId != null || adminRole != null)
                            {
                                var currency = unitOfWork.CurrenciesMappings.FindFirstOrDefault(x => x.Id == dataList.ElementAt(rowIndex).Id);
                                var sourceCurrenyName = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == currency.SourceCurrenyId).Name;
                                var destiniationCurrenyName = unitOfWork.Currencies.FindFirstOrDefault(x => x.Id == currency.DestiniationCurrenyId).Name;
                                unitOfWork.CurrenciesMappingServices.Delete(currency.Id);
                                unitOfWork.SaveChanges();
                                #region Log
                                var log = new Domains.DailyOperation();
                                log.Date = DateTime.Parse(DateTime.Now.ToString());
                                log.Time = DateTime.Now.TimeOfDay;
                                log.UserId = CurrentUser.UserID;
                                log.UserName = CurrentUser.UserName;
                                log.Description = $"حذف عملیات رمز ارز حواله {sourceCurrenyName}، ارز دریافتی {destiniationCurrenyName}";
                                log.ActionText = GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Delete);
                                log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Delete;
                                unitOfWork.DailyOperationServices.Insert(log);
                                unitOfWork.SaveChanges();
                                #endregion
                                loadData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("حذف امکانپذیر نمیباشد");
                        }

                    }

                }
            }

            if (e.KeyCode == Keys.F6)
            {
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.CurrencyAgencies && x.UserId == CurrentUser.UserID);
                if (roleId == null && adminRole == null)
                {
                    MessageBox.Show(Messages.PermissionMsg);
                    return;

                }
                if (roleId != null || adminRole != null)
                {
                    var frmCurrencie = new CurrencyAgenciesCreateUpdateFrm();
                    frmCurrencie.ShowDialog();
                    loadData();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}