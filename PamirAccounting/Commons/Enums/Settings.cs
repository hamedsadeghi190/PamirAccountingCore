using System.ComponentModel;

namespace PamirAccounting.Commons.Enums
{
    public class Settings
    {
        public enum ExchangeRate
        {
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
    }
}