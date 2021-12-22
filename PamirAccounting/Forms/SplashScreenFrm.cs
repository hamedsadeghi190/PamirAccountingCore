using DevExpress.XtraSplashScreen;
using PamirAccounting.Domains;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PamirAccounting.Forms
{
    public partial class SplashScreenFrm : SplashScreen
    {
        public SplashScreenFrm()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 1998-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void SplashScreenFrm_Load(object sender, EventArgs e)
        {
            Thread workerThread = new Thread(new ThreadStart(CheckConnection));
            // Start secondary thread  
            workerThread.Start();
        }

        public void CheckConnection()
        {
            var pamirContext = new PamirContext();
            if (pamirContext.Database.CanConnect())
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Close(); }));
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                Application.ExitThread();
            }
        }
    }
}