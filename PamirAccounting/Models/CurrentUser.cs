using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamirAccounting
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string UserName { get; set; }
        public static string FullName { get; set; }
    }
}
