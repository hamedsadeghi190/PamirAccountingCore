﻿using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Agencies
{
    public partial class AgencyListFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<AgencyModel> dataList;
        public AgencyListFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }


   
        private void CreateAgencyBtn_Click(object sender, EventArgs e)
        {
            var frmGroups = new AgencyCreateUpdateFrm();
            frmGroups.ShowDialog();
        }

        private void AgencyListFrm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            dataList = unitOfWork.AgencyServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new { x.Id, x.Name, x.CurrenyName, x.Phone }).ToList();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {



            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new AgencyCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
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
                        unitOfWork.AgencyServices.Delete(new Agency() { Id = dataList.ElementAt(e.RowIndex).Id });
                        unitOfWork.SaveChanges();
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("حذف امکانپذیر نمیباشد");
                    }

                }
            }
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            var frmCurrencies = new AgencyCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }
    }
}