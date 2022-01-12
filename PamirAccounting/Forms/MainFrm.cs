using PamirAccounting.Forms.Customers;
using PamirAccounting.Forms.Drafts;
using PamirAccounting.Forms.Transaction;
using PamirAccounting.Forms.Transactions;
using PamirAccounting.Forms.Users;
using PamirAccounting.UI.Forms.Agencies;
using PamirAccounting.UI.Forms.Banks;
using PamirAccounting.UI.Forms.Currencies;
using PamirAccounting.UI.Forms.CurrencyAgencies;
using PamirAccounting.UI.Forms.Customers;
using PamirAccounting.UI.Forms.GeneralLedger;
using PamirAccounting.UI.Forms.Groups;
using PamirAccounting.UI.Forms.Header;
using PamirAccounting.UI.Forms.Settings;
using PamirAccounting.UI.Forms.Transaction;
using PamirAccounting.UI.Forms.Users;
using System;
using System.Globalization;

namespace PamirAccounting.UI
{
    public partial class MainFrm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void BtnBanksMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmBanks = new CreateUpdateFrm();
            FrmBanks.ShowDialog();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

            barStaticItemUser.Caption = " کاربر جاری  : " + CurrentUser.FullName;
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = DateTime.Now;
            string DayName = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    DayName = " شنبه ";
                    break;
                case DayOfWeek.Sunday:
                    DayName = " یکشنبه ";
                    break;
                case DayOfWeek.Monday:
                    DayName = " دوشنبه ";
                    break;
                case DayOfWeek.Tuesday:
                    DayName = " سه شنبه ";
                    break;
                case DayOfWeek.Wednesday:
                    DayName = " چهارشنبه ";
                    break;
                case DayOfWeek.Thursday:
                    DayName = " پنج شنبه ";
                    break;
                case DayOfWeek.Friday:
                    DayName = " جمـــعه ";
                    break;
            }

            string PersianDate = string.Format("{0} {1}/{2}/{3}", DayName, pc.GetYear(dt), pc.GetMonth(dt), pc.GetDayOfMonth(dt));
            barStaticItemDate.Caption =PersianDate;
        }

        private void barButtonItemListCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCurrencies = new CurrencyListFrm();
            FrmCurrencies.ShowDialog();
        }

        private void barButtonItemNewCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCurrencies = new CurrencyCreateUpdateFrm();
            FrmCurrencies.ShowDialog();
        }

        private void barButtonItemGroupList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmGroups = new GroupListFrm();
            FrmGroups.ShowDialog();
        }

        private void barButtonItemNewGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmGroups = new GroupCreateUpdateFrm();
            FrmGroups.ShowDialog();

        }

        private void barButtonItemNewAgency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmAgency = new AgencyCreateUpdateFrm();
            FrmAgency.ShowDialog();
        }

        private void barButtonItemAgencyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmSetting = new SettingCreateUpdateFrm();
            FrmSetting.ShowDialog();
        }



        private void barButtonItemNewAgencyCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCurrencyAgencies = new CurrencyAgenciesCreateUpdateFrm();
            FrmCurrencyAgencies.ShowDialog();
        }

        private void barButtonItemCurrencyAgenciesList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItemHeader_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmHeader = new HeaderCreateUpdateFrm();
            FrmHeader.ShowDialog();
        }

        private void barButtonItemNewUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmUsers = new UsersCreateUpdateFrm();
            FrmUsers.ShowDialog();

        }

        private void barButtonItemUsersList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmUsers = new UsersListFrm();
            FrmUsers.ShowDialog();
        }

        private void barButtonItemCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmCustomerList();
            frm.ShowDialog();
        }

        private void barButtonItemNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCustomers = new CustomerCreateUpdateFrm();
            FrmCustomers.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCustomers = new ViewCustomerAccountFrm();
            FrmCustomers.ShowDialog();
        }

        private void barButtonItemNewTransaction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmNewTransaction = new CreateNewCustomerAccount();
            FrmNewTransaction.ShowDialog();
        }

        private void barBtnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCustomers = new CustomerCreateUpdateFrm();
            FrmCustomers.ShowDialog();
        }

        private void barBtnCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmCustomerList();
            frm.ShowDialog();
        }

        private void barBtnContacts_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmContacts = new ContactsListFrm();
            FrmContacts.ShowDialog();
        }

        private void barBtnDebit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmDebit = new DebitListFrm();
            FrmDebit.ShowDialog();
        }

        private void barBtnReceiveCash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmeRceiveCash = new PayAndReciveCashFrm();
            FrmeRceiveCash.ShowDialog();
        }

        private void barBntPayCash_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmPayCash = new PayAndReciveBankFrm();
            FrmPayCash.ShowDialog();
        }



        private void barBtnTransferAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmTransferAccount = new TransferAccountFrm();
            FrmTransferAccount.ShowDialog();
        }

        private void barBnBankDeposit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var FrmBankReceiveFrm = new PayAndReciveBankFrm();
            FrmBankReceiveFrm.ShowDialog();

        }

        private void barBtnBankPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmBankPayment = new PayAndReciveBankFrm();
            FrmBankPayment.ShowDialog();
        }

        private void barBtnCurencyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmCurrencies = new CurrencyListFrm();
            FrmCurrencies.ShowDialog();
        }

        private void barBtnGroupList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmGroups = new GroupListFrm();
            FrmGroups.ShowDialog();
        }

        private void barBtnBankList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmBanks = new FrmBankList();
            FrmBanks.ShowDialog();
        }

        private void barBtnAgencyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmAgency = new AgencyListFrm();
            FrmAgency.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var FrmAgency = new FrmCurrencyAgenciesList();
            FrmAgency.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmAgency = new HeaderCreateUpdateFrm();
            FrmAgency.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmSetting = new SettingCreateUpdateFrm();
            FrmSetting.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmUsers = new UsersListFrm();
            FrmUsers.ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barBtnCustomerList_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new FrmCustomerList();
            frm.ShowDialog();
        }

        private void barBtnshippingOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmshippingOrder = new shippingOrderFrm();
            FrmshippingOrder.ShowDialog();
        }

        private void barBtnWarrantsPayable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmWarrantsPayable = new WarrantsPayableFrm();
            FrmWarrantsPayable.ShowDialog();

        }

        private void btnRate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var RateListFrm = new RateListFrm();
            RateListFrm.ShowDialog();
        }

        private void btnDraftsList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var DraftsListFrm = new DraftsListFrm();
            DraftsListFrm.ShowDialog();
        }

        private void btnshippingOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmshippingOrder = new shippingOrderFrm();
            FrmshippingOrder.ShowDialog();
        }

        private void btnWarrantsPayable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var FrmWarrantsPayable = new WarrantsPayableFrm();
            FrmWarrantsPayable.ShowDialog();
        }

        private void barbtnNewTransaction_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var FrmCustomers = new ViewCustomerAccountFrm();
            FrmCustomers.ShowDialog();
        }



        private void barStaticItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            barStaticItemTime.Caption = DateTime.Now.ToShortTimeString();
        }

        private void barStaticItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var targetForm = new UnkwonDepositFrm();
            targetForm.ShowDialog();
        }
    }

}
