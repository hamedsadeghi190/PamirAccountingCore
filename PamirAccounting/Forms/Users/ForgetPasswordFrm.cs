using DevExpress.XtraEditors;
using PamirAccounting.Domains;
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
using static PamirAccounting.Commons.Enums.Settings;

namespace PamirAccounting.Forms.Users
{
    public partial class ForgetPasswordFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private int? _Id;
        private User _user;
        public ForgetPasswordFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }
        public ForgetPasswordFrm(int id)
        {
            _Id = id;
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            //var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
            //if (adminRole != null)
            //{
            //    //var currentPasswor = unitOfWork.UserServices.Find(_Id);
            //    txtCurrentPassword.Visible = false;
            //    label1.Visible = false;
            //}
            //else
            //{
            //    txtCurrentPassword.Text = "";
            //}

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                //if (adminRole != null)
                //{

                //    if (txtNewPassword.Text.Length == 0)
                //    {
                //        MessageBox.Show("رمز عبور جدید را وارد کنید");
                //        return;
                //    }
                //    if (txtNewPassRepeat.Text.Length == 0)
                //    {
                //        MessageBox.Show("تکرار رمز عبور جدید را وارد کنید ");
                //        return;
                //    }
                //    if (txtNewPassword.Text == txtNewPassRepeat.Text)
                //    {
                //        _user = unitOfWork.Users.FindFirstOrDefault(x => x.Id == CurrentUser.UserID);
                //        if (_user != null)
                //        {
                //            _user.Password = Base64Encode(txtNewPassword.Text);
                //            unitOfWork.Users.Update(_user);
                //            unitOfWork.SaveChanges();
                //            #region Log
                //            var log = new Domains.DailyOperation();
                //            log.Date = DateTime.Parse(DateTime.Now.ToString());
                //            log.Time = DateTime.Now.TimeOfDay;
                //            log.UserId = CurrentUser.UserID;
                //            log.UserName = CurrentUser.UserName;
                //            log.Description = $"تغییر رمز عبور کاربر {_user.FirstName} {_user.LastName}";
                //            log.ActionText = Tools.GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                //            log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                //            unitOfWork.DailyOperationServices.Insert(log);
                //            unitOfWork.SaveChanges();
                //            #endregion
                //            MessageBox.Show("عملیات با موفقیت ثبت گردید");
                //            Close();
                //            return;
                //        }
                //    }
                //    if (txtNewPassword.Text != txtNewPassRepeat.Text)
                //    {
                //        MessageBox.Show("رمز عبور وارد شده با تکرار رمز عبور یکسان نمی باشد");
                //        return;
                //    }

                //}
                var adminRole = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.Admin && x.UserId == CurrentUser.UserID);
                _user = unitOfWork.Users.FindFirstOrDefault(x => x.Id ==CurrentUser.UserID );
                var roleId = unitOfWork.UserInRoleServices.FindFirstOrDefault(x => x.Role.Code == (int)Permission.ChangePassword && x.UserId == CurrentUser.UserID);
                if (roleId != null || adminRole!=null)
                {
                    if (txtCurrentPassword.Text.Length == 0)
                    {
                        MessageBox.Show("رمز عبور فعلی را وارد کنید");
                    }
                    if (txtNewPassword.Text.Length == 0)
                    {
                        MessageBox.Show("رمز عبور جدید را وارد کنید");
                        return;
                    }
                    if (txtNewPassRepeat.Text.Length == 0)
                    {
                        MessageBox.Show("تکرار رمز عبور جدید را وارد کنید ");
                        return;
                    }
                    if (_user.Password != Base64Encode(txtCurrentPassword.Text))
                    {
                        MessageBox.Show("رمز عبور فعلی اشتباه است");
                        return;
                    }
                    if (txtNewPassword.Text != txtNewPassRepeat.Text)
                    {
                        MessageBox.Show("رمز عبور وارد شده با تکرار رمز عبور یکسان نمی باشد");
                        return;
                    }
                    if (txtNewPassword.Text == txtNewPassRepeat.Text)
                    {
                        
                        if (_user != null)
                        {
                            _user.Password = Base64Encode(txtNewPassword.Text);
                            unitOfWork.Users.Update(_user);
                            unitOfWork.SaveChanges();
                            #region Log
                            var log = new Domains.DailyOperation();
                            log.Date = DateTime.Parse(DateTime.Now.ToString());
                            log.Time = DateTime.Now.TimeOfDay;
                            log.UserId = CurrentUser.UserID;
                            log.UserName = CurrentUser.UserName;
                            log.Description = $"تغییر رمز عبور کاربر {_user.FirstName} {_user.LastName}";
                            log.ActionText = Tools.GetEnumDescription(PamirAccounting.Commons.Enums.Settings.ActionType.Update);
                            log.ActionType = (int)PamirAccounting.Commons.Enums.Settings.ActionType.Update;
                            unitOfWork.DailyOperationServices.Insert(log);
                            unitOfWork.SaveChanges();
                            #endregion
                            MessageBox.Show("عملیات با موفقیت ثبت گردید");
                            Close();

                        }
                    }
                

                }
            }
            catch (Exception ex)
            {

            }
         
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void ForgetPasswordFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}