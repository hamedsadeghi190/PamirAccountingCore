using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting
{
    public static class AppSetting
    {

        public static bool DebugMode { get; set; }
        //آیدی حواله ای اجرا نشده
        public static int NotRunnedDraftsId { get; set; }
        //آیدی حساب اسناد دریافتی
        public static int  RecivedDocumentCustomerId { get; set; }
        //آیدی حساب اسناد پرداختنی
        public static int  SendDocumentCustomerId { get; set; }
        //آیدی حساب در جریان وصول
        public static int AsnadDarJaryanVoslId { get; set; }
        //آیدی صندوق
        public static int  TomanCurrencyID { get; set; }
        public static int  SandoghCustomerId { get; set; }
        public static string  ReportPath { get; set; }

        public static int[] DocumnetAndDraftsGroupID { get; set; }



        public static void SaveLog(string fromName, string actionName, Exception ex)
        {

        }
    }

    
}
