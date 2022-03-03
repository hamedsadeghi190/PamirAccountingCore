using DevExpress.XtraEditors;
using PamirAccounting.Domains;
using PamirAccounting.Models;
using PamirAccounting.Services;
using PamirAccounting.UI.Forms.Customers;
using Stimulsoft.Report;
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
    public partial class FrmCustomerList : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private List<CustomerModel> dataList;
        private List<CustomerGroupModel> _Groups;
        public FrmCustomerList()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            loadData();
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();
            HeaderStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style = HeaderStyle;
            }
            this.dataGridView1.DefaultCellStyle.Font = new Font("B Nazanin", 11, FontStyle.Bold);
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowEdit"];
            c.FlatStyle = FlatStyle.Standard;
            c.DefaultCellStyle.ForeColor = Color.SteelBlue;
            c.DefaultCellStyle.BackColor = Color.Lavender;
            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dataGridView1.Columns["btnRowDelete"];
            d.FlatStyle = FlatStyle.Standard;
            d.DefaultCellStyle.ForeColor = Color.SteelBlue;
            d.DefaultCellStyle.BackColor = Color.Lavender;
        }

        private void loadData()
        {
            _Groups = unitOfWork.CustomerGroupServices.GetAll();
            cmbGroupsSearch.DataSource = _Groups;
            cmbGroupsSearch.ValueMember = "Id";
            cmbGroupsSearch.DisplayMember = "Name";

            dataList = unitOfWork.CustomerServices.GetAll();
            dataGridView1.DataSource = dataList.Select(x => new
            {
                x.Id,
                x.FullName,
                x.Phone,
                x.Mobile,
                x.GroupName
            }).ToList();

        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["btnView"].Index && e.RowIndex >= 0)
            {

                var destForm = new ViewCustomerAccountFrm(dataList.ElementAt(e.RowIndex).Id);
                destForm.ShowDialog();
            }

            if (e.ColumnIndex == dataGridView1.Columns["btnRowEdit"].Index && e.RowIndex >= 0)
            {
                var frmCurrencies = new CustomerCreateUpdateFrm(dataList.ElementAt(e.RowIndex).Id);
                frmCurrencies.ShowDialog();
                loadData();
            }


            if (e.ColumnIndex == dataGridView1.Columns["btnRowDelete"].Index && e.RowIndex >= 0)
            {

                DialogResult dialogResult = MessageBox.Show("آیا مطمئن هستید", "حذف مشتری", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var customer = unitOfWork.Customers.FindFirstOrDefault(x => x.Id == dataList.ElementAt(e.RowIndex).Id);
                        customer.IsDeleted = true;
                        unitOfWork.CustomerServices.Update(customer);
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

        private void CreatBankBtn_Click(object sender, EventArgs e)
        {
            var frmCurrencies = new CustomerCreateUpdateFrm();
            frmCurrencies.ShowDialog();
            loadData();
        }

        private void txtphoneSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNameSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNameSearch.Text.Length > 0)
            {
                dataList = unitOfWork.Customers.FindAll(y => y.FirstName.Contains(txtNameSearch.Text) || y.LastName.Contains(txtNameSearch.Text)).Select(x => new CustomerModel { Id = x.Id, FullName = x.FirstName + " " + x.LastName, Phone = x.Phone, Mobile = x.Mobile, GroupName = x.Group.Name }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void cmbGroupsSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbGroupsSearch.Text.Length > 0)
            {
                dataList = unitOfWork.Customers.FindAll(y => y.Group.Name.Contains(cmbGroupsSearch.Text)).Select(x => new CustomerModel { Id = x.Id, FullName = x.FirstName + " " + x.LastName, Phone = x.Phone, Mobile = x.Mobile, GroupName = x.Group.Name }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void txtNumberSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtNumberSearch.Text.Length > 0)
            {
                dataList = unitOfWork.Customers.FindAll(y => y.Id == int.Parse(txtNumberSearch.Text)).Select(x => new CustomerModel { Id = x.Id, FullName = x.FirstName + " " + x.LastName, Phone = x.Phone, Mobile = x.Mobile, GroupName = x.Group.Name }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void txtphoneSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtphoneSearch.Text.Length > 0)
            {
                dataList = unitOfWork.Customers.FindAll(y => y.Phone.Contains(txtphoneSearch.Text)).Select(x => new CustomerModel { Id = x.Id, FullName = x.FirstName + " " + x.LastName, Phone = x.Phone, Mobile = x.Mobile, GroupName = x.Group.Name }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }
        }

        private void cmbGroupsSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbGroupsSearch.Text.Length > 0)
            {
                dataList = unitOfWork.Customers.FindAll(y => y.Group.Name.Contains(cmbGroupsSearch.Text)).Select(x => new CustomerModel { Id = x.Id, FullName = x.FirstName + " " + x.LastName, Phone = x.Phone, Mobile = x.Mobile, GroupName = x.Group.Name }).ToList();
                dataGridView1.DataSource = dataList;
            }
            else
            {
                loadData();
            }

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string PersianDate = string.Format("{0}/{1}/{2}", pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            var data = new UnitOfWork().CustomerServices.GetAllReport();
            var basedata = new reportbaseDAta() { Date=PersianDate };
            var report = StiReport.CreateNewReport();
            report.Load(AppSetting.ReportPath + "Customers.mrt");
            report.RegData("myData", data);
            report.RegData("basedata", basedata);
            // report.Design();
            report.Render();
            report.Show();
        }

        private void FrmCustomerList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
    }
}

public class reportbaseDAta
{
    public string Date { get; set; }

}