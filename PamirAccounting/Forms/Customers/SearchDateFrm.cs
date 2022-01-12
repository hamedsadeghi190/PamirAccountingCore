using DevExpress.XtraEditors;
using PamirAccounting.Domains;
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

namespace PamirAccounting.Forms.Customers
{
    public partial class SearchDateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private List<TransactionModel> _dataList;
        //  Transaction contact;



        public SearchDateFrm()
           {
            InitializeComponent(); 
            unitOfWork = new UnitOfWork();
            }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SearchDateFrm_Load(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            txtDate1.Text = PersianDate;
            txtDate2.Text = PersianDate; 
          
       
        }

        private void txtDate1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
           
         
            // select* from visitkonnadeh WHERE Datev Between '1394-07-05' AND '1395-06-07'
        }
    }
}