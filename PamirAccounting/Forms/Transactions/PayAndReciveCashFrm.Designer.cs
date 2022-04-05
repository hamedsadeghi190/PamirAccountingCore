
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
            this.lbl_Document_Id_value = new System.Windows.Forms.Label();
            this.lbl_Document_Id = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberString = new System.Windows.Forms.Label();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtdesc = new DevExpress.XtraEditors.TextEdit();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.cmbRemainType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Document_Id_value);
            this.groupBox1.Controls.Add(this.lbl_Document_Id);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNumberString);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtdesc);
            this.groupBox1.Controls.Add(this.cmbCustomers);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.cmbRemainType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbCurrencies);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "دریافت و  پرداخت نقدی";
            // 
            // lbl_Document_Id_value
            // 
            this.lbl_Document_Id_value.AccessibleName = "";
            this.lbl_Document_Id_value.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Document_Id_value.Location = new System.Drawing.Point(351, 34);
            this.lbl_Document_Id_value.Name = "lbl_Document_Id_value";
            this.lbl_Document_Id_value.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Document_Id_value.Size = new System.Drawing.Size(166, 24);
            this.lbl_Document_Id_value.TabIndex = 131;
            this.lbl_Document_Id_value.Text = "0";
            this.lbl_Document_Id_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Document_Id
            // 
            this.lbl_Document_Id.AutoSize = true;
            this.lbl_Document_Id.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Document_Id.Location = new System.Drawing.Point(521, 34);
            this.lbl_Document_Id.Name = "lbl_Document_Id";
            this.lbl_Document_Id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Document_Id.Size = new System.Drawing.Size(42, 19);
            this.lbl_Document_Id.TabIndex = 130;
            this.lbl_Document_Id.Text = "سند :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(519, 151);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 121;
            this.label2.Text = "شرح :";
            // 
            // lblNumberString
            // 
            this.lblNumberString.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumberString.ForeColor = System.Drawing.Color.Navy;
            this.lblNumberString.Location = new System.Drawing.Point(22, 181);
            this.lblNumberString.Name = "lblNumberString";
            this.lblNumberString.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNumberString.Size = new System.Drawing.Size(493, 29);
            this.lblNumberString.TabIndex = 128;
            this.lblNumberString.Tag = "";
            this.lblNumberString.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAmount
            // 
            this.txtAmount.EditValue = "0";
            this.txtAmount.Location = new System.Drawing.Point(151, 107);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.AutoHeight = false;
            this.txtAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtAmount.Properties.MaskSettings.Set("mask", "n0");
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(123, 32);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(21, 147);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtdesc.Properties.Appearance.Options.UseFont = true;
            this.txtdesc.Properties.AutoHeight = false;
            this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdesc.Size = new System.Drawing.Size(495, 32);
            this.txtdesc.TabIndex = 6;
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbCustomers.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.ItemHeight = 19;
            this.cmbCustomers.Location = new System.Drawing.Point(22, 68);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCustomers.Size = new System.Drawing.Size(252, 27);
            this.cmbCustomers.TabIndex = 2;
            this.cmbCustomers.SelectedValueChanged += new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(351, 69);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(166, 32);
            this.txtDate.TabIndex = 1;
            this.txtDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyUp);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // cmbRemainType
            // 
            this.cmbRemainType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemainType.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRemainType.FormattingEnabled = true;
            this.cmbRemainType.ItemHeight = 19;
            this.cmbRemainType.Location = new System.Drawing.Point(22, 107);
            this.cmbRemainType.Name = "cmbRemainType";
            this.cmbRemainType.Size = new System.Drawing.Size(123, 27);
            this.cmbRemainType.TabIndex = 5;
            this.cmbRemainType.SelectedIndexChanged += new System.EventHandler(this.cmbRemainType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(278, 72);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 123;
            this.label6.Text = "مشتری :";
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCurrencies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbCurrencies.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.ItemHeight = 19;
            this.cmbCurrencies.Location = new System.Drawing.Point(350, 108);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(167, 27);
            this.cmbCurrencies.TabIndex = 3;
            this.cmbCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencies_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(277, 112);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(44, 19);
            this.label7.TabIndex = 127;
            this.label7.Text = "مبلغ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(138, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "بازگشت";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(532, 120);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 118;
            this.label3.Text = "نوع ارز :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(532, 81);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 117;
            this.label1.Text = "تاریخ :";
            // 
            // btnsavebank
            // 
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnsavebank.Location = new System.Drawing.Point(21, 19);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnsavebank.Size = new System.Drawing.Size(110, 38);
            this.btnsavebank.TabIndex = 7;
            this.btnsavebank.Text = "ثبت";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsavebank);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 65);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            // 
            // PayAndReciveCashFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 311);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PayAndReciveCashFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PayAndReciveCashFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PayAndReciveCashFrm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
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
        private System.Windows.Forms.Label lblNumberString;
        private System.Windows.Forms.Label lbl_Document_Id_value;
        private System.Windows.Forms.Label lbl_Document_Id;
    }
}
