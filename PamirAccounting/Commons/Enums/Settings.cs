using System.ComponentModel;

namespace PamirAccounting.Commons.Enums
{
    public class Settings
    {
        public enum ExchangeRate
        {
        }

        public enum DraftTypes
        {
            [Description("رفت")]
            Raft = 0,
            [Description("آمد")]
            Amad = 1,
        }
        public enum MappingActions
        {
            [Description("ضرب")]
            Multiplication = 1,
            [Description("تقسیم")]
            Division = 2,
            [Description("جمع")]
            Sum = 3,
        }
        public enum RoundLimit
        {
            Admin = 1,
            Users = 2,
        }

        public enum DepostType
        {
            [Description("نامعلوم")]
            Unkown = 1,
            [Description("معلوم")]
            known = 2,

        }

        public enum TransaActionType
        {
            [Description("حساب جدید")]
            NewAccount = 1,
            [Description("واریز و برداشت نقدی")]
            PayAndReciveCash = 2,
            [Description("واریز و برداشت بانکی")]
            PayAndReciveBank = 3,
            [Description("واریز نامعلوم بانکی")]
            UnkwonReciveBank = 4,
            [Description("انتقال حساب")]
            Transfer = 5,
            [Description("اسناد دریافتنی")]
            RecivedDocument = 6,
            [Description("اسناد پرداختنی")]
            DepositDocument = 7,
            [Description("حواله رفت")]
            HavaleRaft = 8,
            [Description("حواله آمد")]
            HavaleAmad = 9,
            [Description(" فروش ارز")]
            SellCurrency = 10,
            [Description("خرید ارز")]
            BuyCurrency = 11,
        }

        public enum DocumentType
        {
            [Description("اسناد دریافتنی")]
            RecivedDocument = 1,
            [Description("اسناد پرداختنی")]
            DepositDocument = 2,


        }

        public enum ChequeStatus
        {
            [Description(" جدید دریافتی")]
            New = 1,
            [Description("در جریان وصول")]
            DarJaryanVosol = 2,
            [Description("وصول شده")]
            Vosol = 3,
            [Description("واگذاری اسناد دریافتنی")]
            VagozariAsnadDaryaftani = 4,
            [Description(" عودت دریافتنی")]
            OdatDaryaftani = 5,
            [Description(" عودت سر حساب")]
            OdatSareHesab = 6,
            [Description(" برگشت چک")]
            Bargasht = 7,
            [Description("پاس پرداختی")]
            PassPardakhti = 8,
            [Description(" عودت پرداختنی")]
            OdatPayment = 9,
            [Description(" برگشت پرداختنی")]
            BargashtPayment = 10,
            [Description("جدید پرداختی")]
            NewPayment = 12,
            [Description("عودت واگذاری")]
            OdatVagozari = 13,
        }

        public enum ActionType
        {
            [Description("ثبت")]
            Insert = 1,
            [Description("ویرایش")]
            Update = 2,
            [Description("حذف")]
            Delete = 3,


        }


        public enum Permission
        {
            Admin=100,
            NewAccount = 1,
            PayAndReciveCash = 2,
            DeletePayAndReciveCash = 3,
            Transfer = 4,
            DeleteTransfer = 5,
            PayAndReciveBank = 6,
            DeletePayAndReciveBank = 7,
            ShippingOrder = 8,
            DeleteShippingOrder = 9,
            WarrantsPayable = 10,
            DeleteWarrantsPayable = 11,
            RecivedDocument = 12,
            DeleteRecivedDocument = 13,
            DepositDocument = 14,
            DeleteDepositDocument = 15,
            BuyCurrency = 16,
            DeleteBuyCurrency = 17,
            SellCurrency = 18,
            DeleteSellCurrency = 19,
            Customers = 20,
            DeleteCustomers = 21,
            ShowAccount = 22,
            UnkwonReciveBank = 23,
            DeleteUnkwonReciveBank = 24,
            OprationUnkwonReciveBank = 25,
            ExecuteDaraft = 26,
            Balance = 27,
            Rate = 28,
            SareHesab = 29,
            DeleteSareHesab = 30,
            VosolDaryafti=31,
            DeleteVosolDaryafti=32,
            VagozariAsnad=33,
            DeleteVagozariAsnad=34,
            OdatVagozarShode=35,
            DeleteOdatVogozarShode=36,
            BargashtDaryafti=37,
            DeleteBargashtDaryafti=38,
            OdatSareHesab=39,
            DeleteOdatSareHesab=40,
            OdatDaryaft=41,
            DeleteOdatDaryafti=42,
            PasPardakhti=43,
            DeletePasPardakhti=44,
            BargashtPardakhti=45,
            DeleteBargashtPardakhti=46,
            OdatPardakhti=47,
            DeleteOdatPardakhti=48,
            Contact=49,
            DeleteContact=50,
            Currency=51,
            DeleteCurrency=52,
            Group=53,
            DeleteGroup=54,
            Bank=55,
            DeleteBank=56,
            Agency=57,
            DeleteAgency=58,
            CurrencyAgencies=59,
            DeleteCurrencyAgencies=60,
            Header=61,
            Settings=62,
            Users=63,
            DeleteUsers=64,
         


        }
    }
}