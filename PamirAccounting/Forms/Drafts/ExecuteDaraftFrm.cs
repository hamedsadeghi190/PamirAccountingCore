using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
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
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Drafts
{
    public partial class ExecuteDaraftFrm : DevExpress.XtraEditors.XtraForm
    {
        public long _draftId;
        public Domains.Draft Draft;
        private List<ComboBoxModel> _Customers;
        private List<CurrencyViewModel> _Currencies;
        private UnitOfWork unitOfWork;
        private Domains.Transaction customerTransaction;
        private long documentId;

        public ExecuteDaraftFrm(long draftId)
        {
            InitializeComponent();
            _draftId = draftId;
            unitOfWork = new UnitOfWork();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ExecuteDaraftFrm_Load(object sender, EventArgs e)
        {
            Draft = unitOfWork.DraftsServices.FindAll(x => x.Id == _draftId)
                .Include(x => x.TypeCurrency)
                .Include(x => x.DepositCurrency)
                .Include(x => x.Agency)
                .FirstOrDefault();

      

            groupBox1.Text += $" {_draftId} ";
            lbl_sender.Text = Draft.Sender;
            lbl_reciver.Text = Draft.Reciver;
            lbl_agencyName.Text = Draft.Agency.Name;
            lbl_currency.Text = Draft.TypeCurrency.Name;
            lbl_amount.Text = Draft.DraftAmount.ToString();
            lbl_palce.Text = Draft.PayPlace;



            _Currencies = unitOfWork.Currencies.FindAll().Select(x => new CurrencyViewModel() { Id = x.Id, Title = x.Name, Action = x.Action, BaseRate = x.BaseRate }).ToList();

            cmbSellCurrencies.DataSource = _Currencies;
            cmbSellCurrencies.ValueMember = "Id";
            cmbSellCurrencies.DisplayMember = "Title";

            _Customers = unitOfWork.CustomerServices.GetAllNotDefaults();
            cmbCustomers.DataSource = _Customers;
            cmbCustomers.ValueMember = "Id";
            cmbCustomers.DisplayMember = "Title";

            txtsellerprice.Text = Draft.DepositAmount.ToString();
            cmbSellCurrencies.SelectedValue = Draft.DepositCurrencyId;
            txtDate.Text = DateTime.Now.ToFarsiFormat();

            if (Draft.TransactionId.HasValue)
            {
                customerTransaction = unitOfWork.TransactionServices.FindFirstOrDefault(x => x.Id == Draft.TransactionId.Value);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {


                var dDate = txtDate.Text.Split('/');
                PersianCalendar p = new PersianCalendar();
                var draftDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);

                customerTransaction.SourceCustomerId = (int)cmbCustomers.SelectedValue;
                customerTransaction.TransactionType = (int)TransaActionType.HavaleAmad;
                customerTransaction.DocumentId = Draft.DocumentId.Value;
                customerTransaction.WithdrawAmount = 0;
                customerTransaction.DepositAmount = (String.IsNullOrEmpty(txtsellerprice.Text.Trim())) ? 0 : long.Parse(txtsellerprice.Text);

                customerTransaction.CurrenyId = (int)cmbSellCurrencies.SelectedValue;
                var TransactionDateTime = p.ToDateTime(int.Parse(dDate[0]), int.Parse(dDate[1]), int.Parse(dDate[2]), 0, 0, 0, 0);
                customerTransaction.Date = DateTime.Now;
                customerTransaction.TransactionDateTime = TransactionDateTime;
                customerTransaction.UserId = CurrentUser.UserID;
                customerTransaction.Description = customerTransaction.Description + $"به شماره تذکره  {txtTazkare.Text} به شماره تلفن {txtPhone.Text} , {txtdesc.Text}";
                unitOfWork.TransactionServices.Update(customerTransaction);
                unitOfWork.SaveChanges();

                Draft.CustomerId = (int)cmbCustomers.SelectedValue;
                Draft.PhoneNumber = txtPhone.Text;
                Draft.RunningDesc = txtdesc.Text;
                Draft.Tazkare = txtTazkare.Text;
                unitOfWork.DraftsServices.Update(Draft);
                unitOfWork.SaveChanges();

                MessageBox.Show(" تغییرات با موفقیت ثبت شد");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Saved !" + ex.Message);
            }

        }
    }
}