
namespace PamirAccounting.Forms.Users
{
    partial class LoginFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.txtusername = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnexitbank = new DevExpress.XtraEditors.SimpleButton();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtusername
            // 
            this.txtusername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtusername.Location = new System.Drawing.Point(81, 41);
            this.txtusername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtusername.Name = "txtusername";
            this.txtusername.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtusername.Properties.Appearance.Options.UseFont = true;
            this.txtusername.Properties.AutoHeight = false;
            this.txtusername.Size = new System.Drawing.Size(223, 38);
            this.txtusername.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(341, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(65, 23);
            this.label4.TabIndex = 88;
            this.label4.Text = "نام کاربری :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(341, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 86;
            this.label1.Text = "کلمه عبور :";
            // 
            // btnexitbank
            // 
            this.btnexitbank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnexitbank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnexitbank.Appearance.Options.UseFont = true;
            this.btnexitbank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnexitbank.ImageOptions.SvgImage")));
            this.btnexitbank.Location = new System.Drawing.Point(81, 185);
            this.btnexitbank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnexitbank.Name = "btnexitbank";
            this.btnexitbank.Size = new System.Drawing.Size(140, 38);
            this.btnexitbank.TabIndex = 84;
            this.btnexitbank.Text = "خروج";
            this.btnexitbank.Click += new System.EventHandler(this.btnexitbank_Click);
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.Location = new System.Drawing.Point(229, 185);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.Size = new System.Drawing.Size(140, 38);
            this.btnsavebank.TabIndex = 83;
            this.btnsavebank.Text = "ورود";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(81, 102);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(226, 39);
            this.txtPassword.TabIndex = 92;
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 265);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnexitbank);
            this.Controls.Add(this.btnsavebank);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ورود به نرم افزار";
            ((System.ComponentModel.ISupportInitialize)(this.txtusername.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtusername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnexitbank;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private System.Windows.Forms.TextBox txtPassword;
    }
}