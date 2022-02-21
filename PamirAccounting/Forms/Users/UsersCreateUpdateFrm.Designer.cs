
namespace PamirAccounting.UI.Forms.Users
{
    partial class UsersCreateUpdateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersCreateUpdateFrm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsave = new DevExpress.XtraEditors.SimpleButton();
            this.btnexit = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxAccess = new System.Windows.Forms.GroupBox();
            this.chkAccessLevel = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.txtPassRepeat = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.CmbSandogh = new System.Windows.Forms.ComboBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.cmbAgency = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAccessLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsave);
            this.groupBox2.Controls.Add(this.btnexit);
            this.groupBox2.Location = new System.Drawing.Point(10, 500);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 100);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsave.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsave.Appearance.Options.UseFont = true;
            this.btnsave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsave.ImageOptions.SvgImage")));
            this.btnsave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnsave.Location = new System.Drawing.Point(17, 33);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsave.Name = "btnsave";
            this.btnsave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnsave.Size = new System.Drawing.Size(110, 47);
            this.btnsave.TabIndex = 118;
            this.btnsave.Text = "ثبت";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnexit
            // 
            this.btnexit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnexit.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnexit.Appearance.Options.UseFont = true;
            this.btnexit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnexit.ImageOptions.SvgImage")));
            this.btnexit.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnexit.Location = new System.Drawing.Point(135, 33);
            this.btnexit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnexit.Name = "btnexit";
            this.btnexit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnexit.Size = new System.Drawing.Size(110, 47);
            this.btnexit.TabIndex = 119;
            this.btnexit.Text = "بازگشت";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.groupBoxAccess);
            this.groupBox1.Controls.Add(this.txtPassRepeat);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.CmbSandogh);
            this.groupBox1.Controls.Add(this.cmbCurrency);
            this.groupBox1.Controls.Add(this.cmbAgency);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 489);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت / ویرایش کاربران";
            // 
            // groupBoxAccess
            // 
            this.groupBoxAccess.Controls.Add(this.chkAccessLevel);
            this.groupBoxAccess.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxAccess.Location = new System.Drawing.Point(33, 72);
            this.groupBoxAccess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxAccess.Name = "groupBoxAccess";
            this.groupBoxAccess.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxAccess.Size = new System.Drawing.Size(289, 372);
            this.groupBoxAccess.TabIndex = 125;
            this.groupBoxAccess.TabStop = false;
            this.groupBoxAccess.Text = "دسترسی";
            // 
            // chkAccessLevel
            // 
            this.chkAccessLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkAccessLevel.Location = new System.Drawing.Point(8, 38);
            this.chkAccessLevel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkAccessLevel.Name = "chkAccessLevel";
            this.chkAccessLevel.Size = new System.Drawing.Size(273, 326);
            this.chkAccessLevel.TabIndex = 117;
            // 
            // txtPassRepeat
            // 
            this.txtPassRepeat.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPassRepeat.Location = new System.Drawing.Point(381, 268);
            this.txtPassRepeat.Name = "txtPassRepeat";
            this.txtPassRepeat.PasswordChar = '*';
            this.txtPassRepeat.Size = new System.Drawing.Size(226, 39);
            this.txtPassRepeat.TabIndex = 113;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtPass.Location = new System.Drawing.Point(381, 224);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(226, 39);
            this.txtPass.TabIndex = 112;
            // 
            // CmbSandogh
            // 
            this.CmbSandogh.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CmbSandogh.FormattingEnabled = true;
            this.CmbSandogh.Location = new System.Drawing.Point(382, 404);
            this.CmbSandogh.Name = "CmbSandogh";
            this.CmbSandogh.Size = new System.Drawing.Size(226, 40);
            this.CmbSandogh.TabIndex = 116;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(382, 357);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(226, 40);
            this.cmbCurrency.TabIndex = 115;
            // 
            // cmbAgency
            // 
            this.cmbAgency.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbAgency.FormattingEnabled = true;
            this.cmbAgency.Location = new System.Drawing.Point(382, 312);
            this.cmbAgency.Name = "cmbAgency";
            this.cmbAgency.Size = new System.Drawing.Size(226, 40);
            this.cmbAgency.TabIndex = 114;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(608, 404);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 32);
            this.label10.TabIndex = 119;
            this.label10.Text = "نام صندوق";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(607, 360);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 32);
            this.label9.TabIndex = 118;
            this.label9.Text = "نوع ارز";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(604, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 32);
            this.label5.TabIndex = 116;
            this.label5.Text = "رمز عبور";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(381, 180);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.AutoHeight = false;
            this.txtUserName.Size = new System.Drawing.Size(226, 38);
            this.txtUserName.TabIndex = 111;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(382, 136);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtLastName.Properties.Appearance.Options.UseFont = true;
            this.txtLastName.Properties.AutoHeight = false;
            this.txtLastName.Size = new System.Drawing.Size(226, 38);
            this.txtLastName.TabIndex = 110;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(606, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 32);
            this.label4.TabIndex = 113;
            this.label4.Text = "نام خانوادگی";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(607, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 32);
            this.label3.TabIndex = 111;
            this.label3.Text = "نمایندگی";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(609, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 32);
            this.label1.TabIndex = 110;
            this.label1.Text = "نام ";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(381, 92);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFirstName.Properties.Appearance.Options.UseFont = true;
            this.txtFirstName.Properties.AutoHeight = false;
            this.txtFirstName.Size = new System.Drawing.Size(226, 38);
            this.txtFirstName.TabIndex = 109;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(608, 271);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 32);
            this.label8.TabIndex = 117;
            this.label8.Text = "تکرار رمز عبور";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(606, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 32);
            this.label6.TabIndex = 115;
            this.label6.Text = "نام کاربری";
            // 
            // UsersCreateUpdateFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 613);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "UsersCreateUpdateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.UsersCreateUpdateFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UsersCreateUpdateFrm_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAccessLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnsave;
        private DevExpress.XtraEditors.SimpleButton btnexit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxAccess;
        private DevExpress.XtraEditors.CheckedListBoxControl chkAccessLevel;
        private System.Windows.Forms.TextBox txtPassRepeat;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.ComboBox CmbSandogh;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.ComboBox cmbAgency;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
    }
}