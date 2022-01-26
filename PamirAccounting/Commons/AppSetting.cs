using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting
{
    public static class AppSetting
    {
       //آیدی حساب اسناد دریافتی
        public static int  RecivedDocumentCustomerId { get; set; }

        //آیدی حساب اسناد پرداختنی
        public static int  SendDocumentCustomerId { get; set; }

        //آیدی صندوق
        public static int  SandoghCustomerId { get; set; }
        public static string  ReportPath { get; set; }
    }
}
