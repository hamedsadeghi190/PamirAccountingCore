
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
            this.grpAgency = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblConvetedAmount = new System.Windows.Forms.Label();
            this.lblConvertedCurrency = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDraftCurrency = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDraftAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrencyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRent = new System.Windows.Forms.TextBox();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.txtExteraDesc = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbConvertedCurrency = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.grpAgency.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAgency
            // 
            this.grpAgency.Controls.Add(this.label3);
            this.grpAgency.Controls.Add(this.label5);
            this.grpAgency.Controls.Add(this.lblConvetedAmount);
            this.grpAgency.Controls.Add(this.lblConvertedCurrency);
            this.grpAgency.Controls.Add(this.label12);
            this.grpAgency.Controls.Add(this.label10);
            this.grpAgency.Controls.Add(this.lblDraftCurrency);
            this.grpAgency.Controls.Add(this.label6);
            this.grpAgency.Controls.Add(this.lblDraftAmount);
            this.grpAgency.Controls.Add(this.label4);
            this.grpAgency.Controls.Add(this.lblCurrencyName);
            this.grpAgency.Controls.Add(this.label1);
            this.grpAgency.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpAgency.Location = new System.Drawing.Point(12, 11);
            this.grpAgency.Name = "grpAgency";
            this.grpAgency.Size = new System.Drawing.Size(441, 112);
            this.grpAgency.TabIndex = 24;
            this.grpAgency.TabStop = false;
            this.grpAgency.Text = "نمایندگی";
            this.grpAgency.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(156, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "0";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(215, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "کرایه :";
            // 
            // lblConvetedAmount
            // 
            this.lblConvetedAmount.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConvetedAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblConvetedAmount.Location = new System.Drawing.Point(253, 78);
            this.lblConvetedAmount.Name = "lblConvetedAmount";
            this.lblConvetedAmount.Size = new System.Drawing.Size(101, 24);
            this.lblConvetedAmount.TabIndex = 19;
            this.lblConvetedAmount.Text = "0";
            // 
            // lblConvertedCurrency
            // 
            this.lblConvertedCurrency.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConvertedCurrency.ForeColor = System.Drawing.Color.Blue;
            this.lblConvertedCurrency.Location = new System.Drawing.Point(8, 75);
            this.lblConvertedCurrency.Name = "lblConvertedCurrency";
            this.lblConvertedCurrency.Size = new System.Drawing.Size(69, 24);
            this.lblConvertedCurrency.TabIndex = 18;
            this.lblConvertedCurrency.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(78, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "ارز تبدیل :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(359, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = " مبلغ تبدیلی :";
            // 
            // lblDraftCurrency
            // 
            this.lblDraftCurrency.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDraftCurrency.Location = new System.Drawing.Point(10, 42);
            this.lblDraftCurrency.Name = "lblDraftCurrency";
            this.lblDraftCurrency.Size = new System.Drawing.Size(62, 24);
            this.lblDraftCurrency.TabIndex = 12;
            this.lblDraftCurrency.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(80, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "ارز حواله :";
            // 
            // lblDraftAmount
            // 
            this.lblDraftAmount.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDraftAmount.Location = new System.Drawing.Point(268, 43);
            this.lblDraftAmount.Name = "lblDraftAmount";
            this.lblDraftAmount.Size = new System.Drawing.Size(85, 24);
            this.lblDraftAmount.TabIndex = 10;
            this.lblDraftAmount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(359, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "مبلغ حواله :";
            // 
            // lblCurrencyName
            // 
            this.lblCurrencyName.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrencyName.Location = new System.Drawing.Point(106, 0);
            this.lblCurrencyName.Name = "lblCurrencyName";
            this.lblCurrencyName.Size = new System.Drawing.Size(68, 20);
            this.lblCurrencyName.TabIndex = 8;
            this.lblCurrencyName.Text = "دلار";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(177, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ارز معیار :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRent);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtExteraDesc);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbConvertedCurrency);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(441, 184);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تبدیل";
            // 
            // txtRent
            // 
            this.txtRent.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRent.Location = new System.Drawing.Point(207, 62);
            this.txtRent.Name = "txtRent";
            this.txtRent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRent.Size = new System.Drawing.Size(125, 31);
            this.txtRent.TabIndex = 2;
            this.txtRent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRent_KeyDown);
            this.txtRent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRent_KeyPress);
            // 
            // txtRate
            // 
            this.txtRate.EditValue = "0";
            this.txtRate.Location = new System.Drawing.Point(10, 26);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.AutoHeight = false;
            this.txtRate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtRate.Properties.MaskSettings.Set("mask", "f");
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(110, 32);
            this.txtRate.TabIndex = 1;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            this.txtRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyUp);
            // 
            // txtExteraDesc
            // 
            this.txtExteraDesc.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExteraDesc.Location = new System.Drawing.Point(10, 99);
            this.txtExteraDesc.Name = "txtExteraDesc";
            this.txtExteraDesc.Size = new System.Drawing.Size(322, 69);
            this.txtExteraDesc.TabIndex = 3;
            this.txtExteraDesc.Text = "";
            this.txtExteraDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExteraDesc_KeyUp);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(337, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 20);
            this.label17.TabIndex = 63;
            this.label17.Text = "توضیحات :";
            // 
            // cmbConvertedCurrency
            // 
            this.cmbConvertedCurrency.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbConvertedCurrency.FormattingEnabled = true;
            this.cmbConvertedCurrency.Location = new System.Drawing.Point(207, 27);
            this.cmbConvertedCurrency.Name = "cmbConvertedCurrency";
            this.cmbConvertedCurrency.Size = new System.Drawing.Size(125, 28);
            this.cmbConvertedCurrency.TabIndex = 0;
            this.cmbConvertedCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbConvertedCurrency_SelectedIndexChanged);
            this.cmbConvertedCurrency.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbConvertedCurrency_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(337, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 33;
            this.label15.Text = "نوع ارز دریافتی :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(343, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "کرایه :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(128, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "نرخ تبدیل :";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(12, 317);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(128, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "بازگشت";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CurrencyExchangeFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpAgency);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CurrencyExchangeFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CurrencyExchangeFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CurrencyExchangeFrm_KeyUp);
            this.grpAgency.ResumeLayout(false);
            this.grpAgency.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAgency;
        private System.Windows.Forms.Label lblCurrencyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDraftCurrency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDraftAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbConvertedCurrency;
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
        private DevExpress.XtraEditors.TextEdit txtRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRent;
    }
}