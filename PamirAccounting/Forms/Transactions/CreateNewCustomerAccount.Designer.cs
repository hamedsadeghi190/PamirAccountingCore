
namespace PamirAccounting.Forms.Transaction
{
    partial class CreateNewCustomerAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewCustomerAccount));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNumberString = new System.Windows.Forms.Label();
            this.cmbRemainType = new System.Windows.Forms.ComboBox();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtdesc = new DevExpress.XtraEditors.TextEdit();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNumberString);
            this.groupBox1.Controls.Add(this.cmbRemainType);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtdesc);
            this.groupBox1.Controls.Add(this.cmbCurrencies);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(724, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت حساب جدید";
            // 
            // lblNumberString
            // 
            this.lblNumberString.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNumberString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblNumberString.Location = new System.Drawing.Point(27, 160);
            this.lblNumberString.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberString.Name = "lblNumberString";
            this.lblNumberString.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNumberString.Size = new System.Drawing.Size(590, 32);
            this.lblNumberString.TabIndex = 110;
            this.lblNumberString.Tag = "";
            this.lblNumberString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRemainType
            // 
            this.cmbRemainType.Font = new System.Drawing.Font("B Nazanin", 12.45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbRemainType.FormattingEnabled = true;
            this.cmbRemainType.Location = new System.Drawing.Point(253, 106);
            this.cmbRemainType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbRemainType.Name = "cmbRemainType";
            this.cmbRemainType.Size = new System.Drawing.Size(163, 41);
            this.cmbRemainType.TabIndex = 4;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(419, 48);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(198, 47);
            this.txtDate.TabIndex = 1;
            // 
            // txtAmount
            // 
            this.txtAmount.EditValue = "0";
            this.txtAmount.Location = new System.Drawing.Point(419, 105);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.AutoHeight = false;
            this.txtAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtAmount.Properties.MaskSettings.Set("mask", "n0");
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(200, 43);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(14, 48);
            this.txtdesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtdesc.Properties.Appearance.Options.UseFont = true;
            this.txtdesc.Properties.AutoHeight = false;
            this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdesc.Size = new System.Drawing.Size(346, 47);
            this.txtdesc.TabIndex = 2;
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrencies.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(20, 107);
            this.cmbCurrencies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(163, 40);
            this.cmbCurrencies.TabIndex = 5;
            this.cmbCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(185, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 103;
            this.label3.Text = "نوع ارز :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(361, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(55, 32);
            this.label2.TabIndex = 106;
            this.label2.Text = "شرح :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(621, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(59, 32);
            this.label1.TabIndex = 102;
            this.label1.Text = "تاریخ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(616, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(99, 32);
            this.label6.TabIndex = 109;
            this.label6.Text = "مانده از قبل:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnsavebank.Location = new System.Drawing.Point(10, 18);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnsavebank.Size = new System.Drawing.Size(110, 38);
            this.btnsavebank.TabIndex = 6;
            this.btnsavebank.Text = "ثبت";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnsavebank);
            this.groupBox2.Location = new System.Drawing.Point(8, 231);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(724, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(129, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "بازگشت";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CreateNewCustomerAccount
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 309);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "CreateNewCustomerAccount";
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CreateNewCustomerAccount_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CreateNewCustomerAccount_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbRemainType;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtdesc;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.Label lblNumberString;
    }
}