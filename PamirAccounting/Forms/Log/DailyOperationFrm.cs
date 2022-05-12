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
            gridLog.AutoGenerateColumns = false;
            LoadData();
        }
    }
}