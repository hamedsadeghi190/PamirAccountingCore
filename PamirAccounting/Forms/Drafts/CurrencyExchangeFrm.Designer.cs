﻿
namespace PamirAccounting.Forms.Drafts
{
    partial class CurrencyExchangeFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyExchangeFrm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblConvetedAmount = new System.Windows.Forms.Label();
            this.lblConvertedCurrency = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDraftCurrency = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDraftAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExteraDesc = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cmbConvertedCurrency = new System.Windows.Forms.ComboBox();
            this.txtRent = new System.Windows.Forms.TextBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblConvetedAmount);
            this.groupBox2.Controls.Add(this.lblConvertedCurrency);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblDraftCurrency);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblDraftAmount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(14, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(514, 162);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نمایندگی مزار";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lblConvetedAmount
            // 
            this.lblConvetedAmount.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConvetedAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblConvetedAmount.Location = new System.Drawing.Point(162, 97);
            this.lblConvetedAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConvetedAmount.Name = "lblConvetedAmount";
            this.lblConvetedAmount.Size = new System.Drawing.Size(118, 30);
            this.lblConvetedAmount.TabIndex = 19;
            this.lblConvetedAmount.Text = "0";
            // 
            // lblConvertedCurrency
            // 
            this.lblConvertedCurrency.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConvertedCurrency.ForeColor = System.Drawing.Color.Blue;
            this.lblConvertedCurrency.Location = new System.Drawing.Point(7, 97);
            this.lblConvertedCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConvertedCurrency.Name = "lblConvertedCurrency";
            this.lblConvertedCurrency.Size = new System.Drawing.Size(72, 30);
            this.lblConvertedCurrency.TabIndex = 18;
            this.lblConvertedCurrency.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(79, 97);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 29);
            this.label12.TabIndex = 17;
            this.label12.Text = "ارز تبدیل :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(276, 97);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 29);
            this.label10.TabIndex = 15;
            this.label10.Text = " مبلغ تبدیلی :";
            // 
            // lblDraftCurrency
            // 
            this.lblDraftCurrency.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDraftCurrency.Location = new System.Drawing.Point(7, 53);
            this.lblDraftCurrency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDraftCurrency.Name = "lblDraftCurrency";
            this.lblDraftCurrency.Size = new System.Drawing.Size(72, 30);
            this.lblDraftCurrency.TabIndex = 12;
            this.lblDraftCurrency.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(79, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "ارز حواله :";
            // 
            // lblDraftAmount
            // 
            this.lblDraftAmount.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDraftAmount.Location = new System.Drawing.Point(159, 53);
            this.lblDraftAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDraftAmount.Name = "lblDraftAmount";
            this.lblDraftAmount.Size = new System.Drawing.Size(121, 30);
            this.lblDraftAmount.TabIndex = 10;
            this.lblDraftAmount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(284, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "مبلغ حواله :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(390, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "دلار";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(424, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "ارز معیار :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExteraDesc);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.cmbConvertedCurrency);
            this.groupBox1.Controls.Add(this.txtRent);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(14, 182);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBox1.Size = new System.Drawing.Size(514, 372);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تبدیل";
            // 
            // txtExteraDesc
            // 
            this.txtExteraDesc.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExteraDesc.Location = new System.Drawing.Point(55, 191);
            this.txtExteraDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExteraDesc.Name = "txtExteraDesc";
            this.txtExteraDesc.Size = new System.Drawing.Size(308, 84);
            this.txtExteraDesc.TabIndex = 35;
            this.txtExteraDesc.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(370, 197);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 27);
            this.label17.TabIndex = 63;
            this.label17.Text = "توضیحات :";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(55, 294);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(173, 294);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "بازگشت";
            // 
            // cmbConvertedCurrency
            // 
            this.cmbConvertedCurrency.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbConvertedCurrency.FormattingEnabled = true;
            this.cmbConvertedCurrency.Location = new System.Drawing.Point(55, 63);
            this.cmbConvertedCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbConvertedCurrency.Name = "cmbConvertedCurrency";
            this.cmbConvertedCurrency.Size = new System.Drawing.Size(308, 34);
            this.cmbConvertedCurrency.TabIndex = 32;
            this.cmbConvertedCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbConvertedCurrency_SelectedIndexChanged);
            // 
            // txtRent
            // 
            this.txtRent.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRent.Location = new System.Drawing.Point(55, 148);
            this.txtRent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRent.Name = "txtRent";
            this.txtRent.Size = new System.Drawing.Size(308, 35);
            this.txtRent.TabIndex = 34;
            this.txtRent.TextChanged += new System.EventHandler(this.txtRent_TextChanged);
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRate.Location = new System.Drawing.Point(55, 105);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(308, 35);
            this.txtRate.TabIndex = 33;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(370, 65);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 27);
            this.label15.TabIndex = 33;
            this.label15.Text = "نوع ارز دریافتی :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(371, 151);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 27);
            this.label8.TabIndex = 30;
            this.label8.Text = "کرایه :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(371, 106);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 27);
            this.label9.TabIndex = 28;
            this.label9.Text = "نرخ تبدیل :";
            // 
            // CurrencyExchangeFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.Name = "CurrencyExchangeFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تبدیل";
            this.Load += new System.EventHandler(this.CurrencyExchangeFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CurrencyExchangeFrm_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDraftCurrency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDraftAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbConvertedCurrency;
        private System.Windows.Forms.TextBox txtRent;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.RichTextBox txtExteraDesc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblConvetedAmount;
        private System.Windows.Forms.Label lblConvertedCurrency;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
    }
}