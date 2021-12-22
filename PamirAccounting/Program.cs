using PamirAccounting.Forms;
using PamirAccounting.Forms.Users;
using PamirAccounting.UI;
using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainFrm = new SplashScreenFrm();
            mainFrm.ShowDialog();

            var loginFrm = new LoginFrm();
            loginFrm.ShowDialog();
            Application.Run(new MainFrm());
        }
    }
}
