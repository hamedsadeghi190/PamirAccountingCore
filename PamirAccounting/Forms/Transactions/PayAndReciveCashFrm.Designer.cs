﻿
namespace PamirAccounting.Forms.Transactions
{
    partial class PayAndReciveCashFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayAndReciveCashFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.cmbRemainType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdesc = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.cmbCustomers);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.cmbRemainType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbCurrencies);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(10, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "دریافت و  پرداخت نقدی";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(137, 100);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.AutoHeight = false;
            this.txtAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtAmount.Properties.MaskSettings.Set("mask", "n0");
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(137, 38);
            this.txtAmount.TabIndex = 125;
            // 
            // cmbRemainType
            // 
            this.cmbRemainType.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRemainType.FormattingEnabled = true;
            this.cmbRemainType.Location = new System.Drawing.Point(22, 102);
            this.cmbRemainType.Name = "cmbRemainType";
            this.cmbRemainType.Size = new System.Drawing.Size(109, 36);
            this.cmbRemainType.TabIndex = 126;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(280, 67);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 123;
            this.label6.Text = "صاحب حساب :";
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(379, 104);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(138, 36);
            this.cmbCurrencies.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(280, 107);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(70, 23);
            this.label7.TabIndex = 127;
            this.label7.Text = "مانده از قبل:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(113, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(81, 38);
            this.btnClose.TabIndex = 128;
            this.btnClose.Text = "بازگشت";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(22, 59);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCustomers.Size = new System.Drawing.Size(252, 36);
            this.cmbCustomers.TabIndex = 124;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(379, 60);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.Size = new System.Drawing.Size(138, 38);
            this.txtDate.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(533, 174);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(39, 23);
            this.label2.TabIndex = 121;
            this.label2.Text = "شرح :";
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(32, 167);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtdesc.Properties.Appearance.Options.UseFont = true;
            this.txtdesc.Properties.AutoHeight = false;
            this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdesc.Size = new System.Drawing.Size(495, 38);
            this.txtdesc.TabIndex = 120;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(533, 130);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 118;
            this.label3.Text = "نوع ارز :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(533, 82);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 117;
            this.label1.Text = "تاریخ :";
            // 
            // btnsavebank
            // 
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnsavebank.Location = new System.Drawing.Point(26, 32);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnsavebank.Size = new System.Drawing.Size(80, 38);
            this.btnsavebank.TabIndex = 116;
            this.btnsavebank.Text = "ثبت";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsavebank);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Location = new System.Drawing.Point(10, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 91);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            // 
            // PayAndReciveCashFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 359);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "PayAndReciveCashFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "دریافت و پرداخت نقدی";
            this.Load += new System.EventHandler(this.PayAndReciveCashFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.ComboBox cmbRemainType;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtdesc;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}