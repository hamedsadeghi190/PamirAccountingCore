using DevExpress.XtraEditors;
using PamirAccounting.Models;
using PamirAccounting.Services;
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

namespace PamirAccounting.Forms.Log
{
    public partial class DailyOperationFrm : DevExpress.XtraEditors.XtraForm
    {
        private List<DailyOperationModel> _dataList = new List<DailyOperationModel>();
        private UnitOfWork unitOfWork;
        private List<DailyOperationModel> dataList;

        public DailyOperationFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        private void LoadData()
        {
            PersianCalendar pc = new PersianCalendar();
            dataList = unitOfWork.DailyOperationServices.GetAll();
            gridLog.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.RowId,
                x.Description,
                x.DocumentId,
                x.DatePersian,
                x.Time,
                x.UserName,
                x.ActionText,
                x.TimePersian
            }).ToList();

        }

        private void DailyOperationFrm_Load(object sender, EventArgs e)
        {
            txtDate1.TextChanged -= new EventHandler(txtDate1_TextChanged);
            txtDate2.TextChanged -= new EventHandler(txtDate2_TextChanged);
            PersianCalendar p = new PersianCalendar();
            var year = DateTime.Now.Year;
            var date1 = DateTime.Parse(year + "/03/21");
            txtDate1.Text = (date1).ToFarsiFormat();
            txtDate2.Text = DateTime.Now.ToFarsiFormat();
            txtDate1.TextChanged += new EventHandler(txtDate1_TextChanged);
            txtDate2.TextChanged += new EventHandler(txtDate2_TextChanged);
            gridLog.AutoGenerateColumns = false;
            LoadData();
        }

        private void txtDate1_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void txtDate2_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        [Obsolete]
        private void FilterData()
        {
            DateTime startDate, endDate;
            List<DailyOperationModel> tmpDataList;

            try
            {
                PersianCalendar p = new PersianCalendar();
                var dDate1 = txtDate1.Text.Replace("_", "").Split('/');
                startDate = p.ToDateTime(int.Parse(dDate1[0]), int.Parse(dDate1[1]), int.Parse(dDate1[2]), 0, 0, 0, 0);
                var dDate2 = txtDate2.Text.Replace("_", "").Split('/');
                endDate = p.ToDateTime(int.Parse(dDate2[0]), int.Parse(dDate2[1]), int.Parse(dDate2[2]), 0, 0, 0, 0);
                tmpDataList = unitOfWork.DailyOperationServices.Filterd(startDate,endDate);


            }
            catch (Exception ex)
            {
                tmpDataList = unitOfWork.DailyOperationServices.Filterd(null, null);

            }

            var daily = new DailyOperationModel();
            //var grouped = tmpDataList.GroupBy(x => x.Date);
            dataList.Clear();
            foreach (var item in tmpDataList)
            {
                daily.Id = item.Id;
                daily.Time = item.Time;
                daily.Date = item.Date;
                daily.DatePersian = item.DatePersian;
                daily.TimePersian = item.TimePersian;
                daily.RowId = item.RowId;
                daily.UserName = item.UserName;
                daily.Description = item.Description;
                daily.ActionText = item.ActionText;
                dataList.Add(daily);
            }
            
            
            gridLog.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.RowId,
                x.Description,
                x.DocumentId,
                x.DatePersian,
                x.Time,
                x.UserName,
                x.ActionText,
                x.TimePersian
            }).ToList();


        }
    }
}