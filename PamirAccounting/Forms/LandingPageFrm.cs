using PamirAccounting.Forms.Checks;
using PamirAccounting.Forms.Currencies;
using PamirAccounting.Forms.Customers;
using PamirAccounting.Forms.Drafts;
using PamirAccounting.Forms.GeneralLedger;
using PamirAccounting.Forms.NewsPaper;
using PamirAccounting.Forms.Transactions;
using PamirAccounting.Forms.Users;
using PamirAccounting.Services;
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
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;


namespace PamirAccounting.Forms
{
    public partial class LandingPageFrm : Form
    {
        UnitOfWork unitOfWork;
        public LandingPageFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
            var _Settings = unitOfWork.Setting.FindFirstOrDefault();
            if (_Settings != null)
            {
                AppSetting.BackupPath = _Settings.BackupDirectory;
            }

         
            AppSetting.DebugMode = true;

            AppSetting.TransferdDraftsId = 23;
            AppSetting.NotRunnedDraftsId = 6;
            AppSetting.SandoghCustomerId = 4;
            AppSetting.RecivedDocumentCustomerId = 16;
            AppSetting.SendDocumentCustomerId = 17;
            AppSetting.AsnadDarJaryanVoslId = 18;
            AppSetting.TomanCurrencyID = 2;
            AppSetting.DocumnetAndDraftsGroupID = new int[] { 7, 8 };


            if (AppSetting.DebugMode == true)
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                AppSetting.ReportPath = $"{currentDirectory}\\Reports\\";
            }
            else
            {
                AppSetting.ReportPath = "D:\\Pamirsoft\\Reports\\";
                //AppSetting.ReportPath = "D:\\PamirAccountingCore\\PamirAccounting\\Reports\\";
                //AppSetting.ReportPath = "E:\\Projects\\PamirAccounting\\PamirAccounting\\Reports\\";
                AppSetting.ReportPath = "D:\\fixed\\PamirAccountingCore\\PamirAccounting\\Reports\\";
            }

        }

        private void AccountActionMnu_Cash_Click(object sender, EventArgs e)
        {
            var FrmeRceiveCash = new PayAndReciveCashFrm();
            FrmeRceiveCash.ShowDialog();
        }

        private void AccountActionMnu_Transfer_Click(object sender, EventArgs e)
        {
            var FrmTransferAccount = new TransferAccountFrm();
            FrmTransferAccount.ShowDialog();
        }

        private void AccountActionMnu_Bank_Click(object sender, EventArgs e)
        {
            var FrmBankPayment = new PayAndReciveBankFrm();
            FrmBankPayment.ShowDialog();
        }

        private void AccountActionMnu_ShippingOrder_Click(object sender, EventArgs e)
        {
            var FrmshippingOrder = new shippingOrderFrm();
            FrmshippingOrder.ShowDialog();
        }

        private void AccountActionMnu_WarrantsPayable_Click(object sender, EventArgs e)
        {
            var FrmWarrantsPayable = new WarrantsPayableFrm();
            FrmWarrantsPayable.ShowDialog();
        }

        private void AccountActionMnu_ReceiveCheque_Click(object sender, EventArgs e)
        {
            var ReceiveCheck = new DetailsReceiveCheckFrm();
            ReceiveCheck.ShowDialog();
        }

        private void AccountActionMnu_PaymentCheque_Click(object sender, EventArgs e)
        {
            var checklist1 = new DetailsPaymentCheckFrm();
            checklist1.ShowDialog();

        }

        private void AccountActionMnu_BuyAndSellCurrency_Click(object sender, EventArgs e)
        {
            var BuyAndSellCurrency = new SellCurrencyFrm();
            BuyAndSellCurrency.ShowDialog();
        }

        private void CustomerMenu_UnkwonDeposit_Click(object sender, EventArgs e)
        {
            var targetForm = new UnkwonDepositFrm();
            targetForm.ShowDialog();
        }

        private void CustomerMenu_New_Click(object sender, EventArgs e)
        {
            var FrmCustomers = new CustomerCreateUpdateFrm();
            FrmCustomers.ShowDialog();
        }

        private void DraftMenu_ShippingOrder_Click(object sender, EventArgs e)
        {
            var FrmshippingOrder = new shippingOrderFrm();
            FrmshippingOrder.ShowDialog();
        }

        private void DraftMenu_WarrantsPayable_Click(object sender, EventArgs e)
        {
            var FrmWarrantsPayable = new WarrantsPayableFrm();
            FrmWarrantsPayable.ShowDialog();
        }

        private void DraftMenu_List_Click(object sender, EventArgs e)
        {
            var DraftsListFrm = new DraftsListFrm();
            DraftsListFrm.ShowDialog();
        }

        private void DraftMenu_Rate_Click(object sender, EventArgs e)
        {
            var RateListFrm = new updateCurrencyBaseRateFrm();
            RateListFrm.ShowDialog();
        }

        private void DraftMenu_Harm_Click(object sender, EventArgs e)
        {

        }

        private void ChequeMenu_SareHesabGozashtan_Click(object sender, EventArgs e)
        {
            var SareHesabGozashtan = new SareHesabGozashtanListFrm();
            SareHesabGozashtan.ShowDialog();
        }

        private void ChequeMenu_VosoolDaryaftani_Click(object sender, EventArgs e)
        {
            var vosool = new VosoolCheckDaryaftaniListFrm();
            vosool.ShowDialog();
        }

        private void ChequeMenu_VagozariAsnad_Click(object sender, EventArgs e)
        {
            var VagozariAsnadDaryaftani = new VagozariAsnadDaryaftaniListFrm();
            VagozariAsnadDaryaftani.ShowDialog();
        }

        private void ChequeMenu_OdatVagozarShode_Click(object sender, EventArgs e)
        {
            var Vagozari = new OdatAsnadDaryaftaniVagozarShodeListFrm();
            Vagozari.ShowDialog();
        }

        private void ChequeMenu_BargashtDaryaftani_DisplayStyleChanged(object sender, EventArgs e)
        {

        }

        private void ChequeMenu_BargashtDaryaftani_Click(object sender, EventArgs e)
        {
            var bargasht = new BargashtCheckDaryaftanilistFrm();
            bargasht.ShowDialog();
        }

        private void ChequeMenu_OdatSareHesab_Click(object sender, EventArgs e)
        {
            var odatsarehesab = new OdatCheckSareHesabListFrm();
            odatsarehesab.ShowDialog();
        }

        private void ChequeMenu_OdatDaryaftani9_Click(object sender, EventArgs e)
        {
            var Odat = new OdatCheckDaryaftaniListFrm();
            Odat.ShowDialog();
        }

        private void ChequeMenu_PassPardakhtani_Click(object sender, EventArgs e)
        {
            var pas1 = new PasCheckPardakhtaniListFrm();
            pas1.ShowDialog();
        }

        private void ChequeMenu_BargashtPardakhti_Click(object sender, EventArgs e)
        {

            var bargasht = new BargashtCheckPardakhtaniListFrm();
            bargasht.ShowDialog();
        }

        private void ChequeMenu_OdatPardakhti_Click(object sender, EventArgs e)
        {
            var odat = new OdatCheckPardakhtaniListFrm();
            odat.ShowDialog();
        }

        private void ReceiveChequeList_Click(object sender, EventArgs e)
        {
            var checklist = new ReceiveCheckListFrm();
            checklist.ShowDialog();
        }

        private void ChequePaymentList_Click(object sender, EventArgs e)
        {
            var checklist = new PaymentCheckList();
            checklist.ShowDialog();
        }

        private void SettingsMenu_CurrencyLis_Click(object sender, EventArgs e)
        {
            var FrmCurrencies = new CurrencyListFrm();
            FrmCurrencies.ShowDialog();
        }

        private void SettingsMenu_GroupList_Click(object sender, EventArgs e)
        {
            var FrmGroups = new GroupListFrm();
            FrmGroups.ShowDialog();
        }

        private void SettingsMenu_BankList_Click(object sender, EventArgs e)
        {
            var FrmBanks = new FrmBankList();
            FrmBanks.ShowDialog();
        }

        private void SettingsMenu_Agency_Click(object sender, EventArgs e)
        {
            var FrmAgency = new AgencyListFrm();
            FrmAgency.ShowDialog();
        }

        private void SettingsMenu_CurrencyAgency_Click(object sender, EventArgs e)
        {
            var FrmAgency = new FrmCurrencyAgenciesList();
            FrmAgency.ShowDialog();
        }

        private void SettingsMenu_Header_Click(object sender, EventArgs e)
        {
            var FrmHader = new HeaderCreateUpdateFrm();
            FrmHader.ShowDialog();
        }

        private void SettingsMenu_Setting_Click(object sender, EventArgs e)
        {
            var FrmSetting = new SettingCreateUpdateFrm();
            FrmSetting.ShowDialog();
        }

        private void SettingsMenu_Users_Click(object sender, EventArgs e)
        {
            var FrmUsers = new UsersListFrm();
            FrmUsers.ShowDialog();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimee.Text = DateTime.Now.ToShortTimeString();
        }

        private void LandingPageFrm_Load(object sender, EventArgs e)
        {
            lblUser.Text = " کاربر جاری  : " + CurrentUser.FullName;
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
            lblTime.Text = PersianDate;
        }

        private void ChequeMenu_SareHesabList_Click(object sender, EventArgs e)
        {
            var Frm = new SareHesabGozashtanReportFrm();
            Frm.ShowDialog();
        }

        private void CustomerMenu_Lis_Click(object sender, EventArgs e)
        {
            var frm = new FrmCustomerList();
            frm.ShowDialog();
        }

        private void ChequeMenu_VosoolShode_Click(object sender, EventArgs e)
        {
            var frm = new VosoolCheckDaryaftaniReportFrm();
            frm.ShowDialog();

        }

        private void ChequeMenu_Vagozari_Click(object sender, EventArgs e)
        {
            var frm = new VagozariAsnadDaryaftaniReportFrm();
            frm.ShowDialog();

        }

        private void ChequeMenu_ReceveOdat_Click(object sender, EventArgs e)
        {
            var frm = new OdatCheckDaryaftaniReportFrm();
            frm.ShowDialog();

        }

        private void ChequeMenu_OdatSare_Click(object sender, EventArgs e)
        {
            var frm = new OdatCheckSareHesabReportFrm();
            frm.ShowDialog();
        }

        private void ChequeMenu_Bargasht_Click(object sender, EventArgs e)
        {
            var frm = new BargashtCheckDaryaftiReportFrm();
            frm.ShowDialog();
        }

        private void ChequeMenu_Pas_Click(object sender, EventArgs e)
        {
            var frm = new PasCheckPardakhtaniReportFrm();
            frm.ShowDialog();
        }

        private void ListOdatPayment_Click(object sender, EventArgs e)
        {
            var frm = new OdatCheckPardakhtaniReportFrm();
            frm.ShowDialog();
        }

        private void ListBargashtPayment_Click(object sender, EventArgs e)
        {
            var frm = new BargashtCheckPardakhtiReportFrm();
            frm.ShowDialog();
        }

        private void CreditorList_Click(object sender, EventArgs e)
        {
            var frm = new CreditorGroupListFrm();
            frm.ShowDialog();
        }

        private void DepositList_Click(object sender, EventArgs e)
        {
            var frm = new DebtorGroupListFrm();
            frm.ShowDialog();
        }

        private void btn_Deposit_Click(object sender, EventArgs e)
        {
            var frm = new DebtorGroupListFrm();
            frm.ShowDialog();
        }

        private void btn_CreditorList_Click(object sender, EventArgs e)
        {
            var frm = new CreditorGroupListFrm();
            frm.ShowDialog();

        }

        private void phone_Click(object sender, EventArgs e)
        {
            var frm = new ContactsListFrm();
            frm.ShowDialog();
        }

        private void TotalList_Click(object sender, EventArgs e)
        {
            var frm = new TotalGroupListFrm();
            frm.ShowDialog();
        }

        private void Newspaper_Click(object sender, EventArgs e)
        {
            var frm = new PayAndReciveCashListFrm();
            frm.ShowDialog();

        }

        private void PayAndReciveCash_Click(object sender, EventArgs e)
        {
            var FrmeRceiveCash = new PayAndReciveCashFrm();
            FrmeRceiveCash.ShowDialog();
        }

        private void PayAndReciveBank_Click(object sender, EventArgs e)
        {
            var FrmBankPayment = new PayAndReciveBankFrm();
            FrmBankPayment.ShowDialog();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            var FrmTransferAccount = new TransferAccountFrm();
            FrmTransferAccount.ShowDialog();
        }

        private void PayAndReciveBankList_Click(object sender, EventArgs e)
        {
            var FrmTransferAccount = new PayAndReciveBankListFrm();
            FrmTransferAccount.ShowDialog();
        }

        private void CustomersList_Click(object sender, EventArgs e)
        {
            var frm = new FrmCustomerList();
            frm.ShowDialog();
        }

        private void btnshippingOrder_Click(object sender, EventArgs e)
        {
            var frm = new shippingOrderFrm();
            frm.ShowDialog();
        }

        private void btnWarrantsPayableFrm_Click(object sender, EventArgs e)
        {
            var frm = new WarrantsPayableFrm();
            frm.ShowDialog();
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            var frm = new CustomerCreateUpdateFrm();
            frm.ShowDialog();
        }

        private void btnbank_Click(object sender, EventArgs e)
        {
            var FrmBankPayment = new PayAndReciveBankFrm();
            FrmBankPayment.ShowDialog();
        }

        private void btnAgency_Click(object sender, EventArgs e)
        {
            var FrmAgency = new FrmCurrencyAgenciesList();
            FrmAgency.ShowDialog();
        }

        private void TotalBlance_Click(object sender, EventArgs e)
        {
            var Frm = new TotalBalanceFrm();
            Frm.ShowDialog();
        }

        private void btnNewAccount_Click_1(object sender, EventArgs e)
        {
            var FrmCustomers = new CustomerCreateUpdateFrm();
            FrmCustomers.ShowDialog();
        }

        private void btnBank_Click_1(object sender, EventArgs e)
        {
            var FrmBankPayment = new PayAndReciveBankFrm();
            FrmBankPayment.ShowDialog();
        }

        private void btnWarrantsPayable_Click(object sender, EventArgs e)
        {
            var FrmWarrantsPayable = new WarrantsPayableFrm();
            FrmWarrantsPayable.ShowDialog();
        }

        private void btnShippingOrder_Click_1(object sender, EventArgs e)
        {
            var FrmshippingOrder = new shippingOrderFrm();
            FrmshippingOrder.ShowDialog();
        }

        private void btnCurrencyAgency_Click(object sender, EventArgs e)
        {
            var FrmAgency = new FrmCurrencyAgenciesList();
            FrmAgency.ShowDialog();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void BuyAndSellCurrencyList_Click(object sender, EventArgs e)
        {
            var frm = new BuyAndSellCurrencyListFrm();
            frm.ShowDialog();
        }

        private void OdatVagozariList_Click(object sender, EventArgs e)
        {
            var frm = new OdatAsnadDaryaftaniVagozarShodeReportFrm();
            frm.ShowDialog();
        }

        private void BuyCurrencyMenuItem_Click(object sender, EventArgs e)
        {
            var BuyCurrency = new BuyCurrencyFrm();
            BuyCurrency.ShowDialog();
        }

        private void LandingPageFrm_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("asdas");
        }

        private void btnCustomerlist_Click(object sender, EventArgs e)
        {
            var frm = new FrmCustomerList();
            frm.ShowDialog();

        }

        private void CreateBackupMenu_Click(object sender, EventArgs e)
        {
            var _Settings = unitOfWork.Setting.FindFirstOrDefault();
            if (_Settings != null)
            {
                AppSetting.BackupPath = _Settings.BackupDirectory;
            }

            var backservice = new BackupService();
            var dateTime = DateTime.Now.ToFarsiSerialFormat();
            var backupFileName = $"pamirbackup{dateTime}.bak";

            var result = backservice.Backup("PamirAccounting", $"{AppSetting.BackupPath}\\{backupFileName}");


            if (result)
            {
                MessageBox.Show("فایل پشتیبان ذخبره شد");
            }
            else
            {
                MessageBox.Show("فایل پشتیبان ذخبره نشد");
            }
        }

        private void SettingsMenu_Recovery_Click(object sender, EventArgs e)
        {
            var result = backupFileSelector.ShowDialog();
            if (result == DialogResult.OK)
            {

                var filename = backupFileSelector.FileName;
                var recoveryReuslt = new BackupService().Restore(filename);


                if (recoveryReuslt)
                {
                    MessageBox.Show("بازیابی اطلاعات با موفقیت انجام شد");
                }
                else
                {
                    MessageBox.Show("بازیابی اطلاعات با شکست مواجه شد");
                }
            }

        }
    }
}
