using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting
{
    public static class AppSetting
    {
        public static int  RecivedDocumentCustomerId { get; set; }
        public static int  SendDocumentCustomerId { get; set; }
        public static int  SandoghCustomerId { get; set; }
        public static string  ReportPath { get; set; }
    }
}
