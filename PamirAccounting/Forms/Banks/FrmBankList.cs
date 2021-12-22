using DevExpress.XtraEditors;
using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Banks
{
    public partial class FrmBankList : XtraForm
    {

        private UnitOfWork unitOfWork;
        private List<BanksModel> dataList;
        public FrmBankList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


        private void FrmBankList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            var frmCurrencies = new CreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }

        private void loadData()
        {
            dataList = unitOfWork.BankServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x=>new { x.Id,x.Name,x.BaseCurrencyName,x.CountryName}).ToList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id.Value);
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
                        unitOfWork.BankServices.Delete(new Bank() { Id = dataList.ElementAt(e.RowIndex).Id.Value });
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