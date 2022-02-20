using DevExpress.XtraEditors;
using PamirAccounting.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Users
{
    public partial class LoginFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        public LoginFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        //private void btnsavebank_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtPassword.Text))
        //    {

        //        MessageBox.Show("تمامی اطلاعات را وارد نمایید", "ورود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
        //             MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //    }
        //    else
        //    {
        //        var user = unitOfWork.Users.FindFirstOrDefault(x => x.UserName == txtusername.Text && x.Password == Base64Encode(txtPassword.Text));
        //        if (user != null)
        //        {
        //            CurrentUser.UserID = user.Id;
        //            CurrentUser.UserName = user.UserName;
        //            CurrentUser.FullName = $"{user.FirstName} {user.LastName}";
        //            Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("کلمه کاربری یا کلمه عبور اشتباه است", "ورود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
        //        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        //        }
        //    }
        //}

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private void btnexitbank_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtusername_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnexitbank_Click_1(object sender, EventArgs e)
        {

        }

        private void btnsavebank_Click_1(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {

                MessageBox.Show("تمامی اطلاعات را وارد نمایید", "ورود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                var user = unitOfWork.Users.FindFirstOrDefault(x => x.UserName == txtusername.Text && x.Password == Base64Encode(txtPassword.Text));
                if (user != null)
                {
                    CurrentUser.UserID = user.Id;
                    CurrentUser.UserName = user.UserName;
                    CurrentUser.FullName = $"{user.FirstName} {user.LastName}";
                    Close();
                }
                else
                {
                    MessageBox.Show("کلمه کاربری یا کلمه عبور اشتباه است", "ورود", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}