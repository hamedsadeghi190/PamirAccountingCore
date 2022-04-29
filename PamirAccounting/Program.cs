using PamirAccounting.Forms;
using PamirAccounting.Forms.Users;
using PamirAccounting.UI;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PamirAccounting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppSetting.ConnectionString = "Server=.;Database=PamirAccounting;Trusted_Connection=True;";
            // Seteamos la cultura a Español Argentina
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainFrm = new SplashScreenFrm();
            mainFrm.ShowDialog();

            var loginFrm = new LoginFrm();
            loginFrm.ShowDialog();
            Application.Run(new LandingPageFrm());
        }
    }
}
