
namespace PamirAccounting.Forms.Checks
{
    partial class DetailsPaymentCheckFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsPaymentCheckFrm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.BtnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNumberString = new System.Windows.Forms.Label();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.btnshowcustomer = new DevExpress.XtraEditors.SimpleButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBankAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtChequeNumber = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbRealBankId = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBranchName = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDueDate = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIssueDate = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Controls.Add(this.BtnClose);
            this.groupBox2.Location = new System.Drawing.Point(12, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 92);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSave.ImageOptions.SvgImage")));
            this.BtnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.BtnSave.Location = new System.Drawing.Point(7, 22);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnSave.Size = new System.Drawing.Size(110, 38);
            this.BtnSave.TabIndex = 89;
            this.BtnSave.Text = "ثبت";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.Appearance.Options.UseFont = true;
            this.BtnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnClose.ImageOptions.SvgImage")));
            this.BtnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.BtnClose.Location = new System.Drawing.Point(125, 22);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnClose.Size = new System.Drawing.Size(110, 38);
            this.BtnClose.TabIndex = 90;
            this.BtnClose.Text = "بازگشت";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNumberString);
            this.groupBox1.Controls.Add(this.cmbCustomers);
            this.groupBox1.Controls.Add(this.btnshowcustomer);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBankAccountNumber);
            this.groupBox1.Controls.Add(this.txtChequeNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbRealBankId);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBranchName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDueDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIssueDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 398);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت / ویرایش مشخصات چک  پرداختی";
            // 
            // lblNumberString
            // 
            this.lblNumberString.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumberString.Location = new System.Drawing.Point(81, 243);
            this.lblNumberString.Name = "lblNumberString";
            this.lblNumberString.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNumberString.Size = new System.Drawing.Size(254, 26);
            this.lblNumberString.TabIndex = 132;
            this.lblNumberString.Tag = "";
            this.lblNumberString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(341, 282);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(140, 34);
            this.cmbCustomers.TabIndex = 131;
            // 
            // btnshowcustomer
            // 
            this.btnshowcustomer.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnshowcustomer.Appearance.Options.UseFont = true;
            this.btnshowcustomer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnshowcustomer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnshowcustomer.ImageOptions.SvgImage")));
            this.btnshowcustomer.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnshowcustomer.Location = new System.Drawing.Point(296, 284);
            this.btnshowcustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnshowcustomer.Name = "btnshowcustomer";
            this.btnshowcustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnshowcustomer.Size = new System.Drawing.Size(38, 32);
            this.btnshowcustomer.TabIndex = 111;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(481, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 26);
            this.label12.TabIndex = 108;
            this.label12.Text = "گیرنده چک";
            // 
            // txtAmount
            // 
            this.txtAmount.EditValue = "0";
            this.txtAmount.Location = new System.Drawing.Point(341, 237);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.AutoHeight = false;
            this.txtAmount.Size = new System.Drawing.Size(140, 38);
            this.txtAmount.TabIndex = 103;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(479, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 26);
            this.label9.TabIndex = 106;
            this.label9.Text = "مبلغ چک";
            // 
            // txtBankAccountNumber
            // 
            this.txtBankAccountNumber.Location = new System.Drawing.Point(33, 114);
            this.txtBankAccountNumber.Name = "txtBankAccountNumber";
            this.txtBankAccountNumber.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBankAccountNumber.Properties.Appearance.Options.UseFont = true;
            this.txtBankAccountNumber.Properties.AutoHeight = false;
            this.txtBankAccountNumber.Size = new System.Drawing.Size(140, 38);
            this.txtBankAccountNumber.TabIndex = 102;
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Location = new System.Drawing.Point(341, 195);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtChequeNumber.Properties.Appearance.Options.UseFont = true;
            this.txtChequeNumber.Properties.AutoHeight = false;
            this.txtChequeNumber.Size = new System.Drawing.Size(140, 38);
            this.txtChequeNumber.TabIndex = 101;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(479, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 26);
            this.label11.TabIndex = 104;
            this.label11.Text = "شماره چک";
            // 
            // cmbRealBankId
            // 
            this.cmbRealBankId.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbRealBankId.FormattingEnabled = true;
            this.cmbRealBankId.Location = new System.Drawing.Point(341, 70);
            this.cmbRealBankId.Name = "cmbRealBankId";
            this.cmbRealBankId.Size = new System.Drawing.Size(140, 34);
            this.cmbRealBankId.TabIndex = 87;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(33, 321);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(448, 39);
            this.txtDescription.TabIndex = 88;
            this.txtDescription.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(481, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 26);
            this.label8.TabIndex = 100;
            this.label8.Text = "شرح";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(341, 110);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBranchName.Properties.Appearance.Options.UseFont = true;
            this.txtBranchName.Properties.AutoHeight = false;
            this.txtBranchName.Size = new System.Drawing.Size(140, 38);
            this.txtBranchName.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(481, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 26);
            this.label7.TabIndex = 99;
            this.label7.Text = "شعبه";
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(33, 70);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDueDate.Properties.Appearance.Options.UseFont = true;
            this.txtDueDate.Properties.AutoHeight = false;
            this.txtDueDate.Size = new System.Drawing.Size(140, 38);
            this.txtDueDate.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(171, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 26);
            this.label5.TabIndex = 97;
            this.label5.Text = "تاریخ سر رسید";
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Location = new System.Drawing.Point(341, 152);
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtIssueDate.Properties.Appearance.Options.UseFont = true;
            this.txtIssueDate.Properties.AutoHeight = false;
            this.txtIssueDate.Size = new System.Drawing.Size(140, 38);
            this.txtIssueDate.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(484, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 26);
            this.label3.TabIndex = 90;
            this.label3.Text = "بانک";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(479, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 26);
            this.label6.TabIndex = 95;
            this.label6.Text = "تاریخ صدور";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(171, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 26);
            this.label10.TabIndex = 105;
            this.label10.Text = "شماره حساب";
            // 
            // DetailsPaymentCheckFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "DetailsPaymentCheckFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DetailsPaymentCheckFrm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.SimpleButton BtnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnshowcustomer;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txtBankAccountNumber;
        private DevExpress.XtraEditors.TextEdit txtChequeNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbRealBankId;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtBranchName;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtDueDate;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtIssueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label lblNumberString;
    }
}