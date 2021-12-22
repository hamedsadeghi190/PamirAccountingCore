using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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
              loadData();
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {

            var frmCurrencies = new CurrencyAgenciesCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            dataList = unitOfWork.CurrencyAgenciesServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new { x.Id, x.AgencyName, x.SourceCurrenyName, x.DestiniationCurrenyName,x.ActionName , x.ExchangeRateShow, x.RoundLimitShow }).ToList();
        }


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CurrencyAgenciesCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
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
                        unitOfWork.CurrencyAgenciesServices.Delete(new CurrencyAgency() { Id = dataList.ElementAt(e.RowIndex).Id });
                        unitOfWork.SaveChanges();
                        loadData();
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