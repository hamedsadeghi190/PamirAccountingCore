
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
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtwithdraw = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdeposit = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdesc = new DevExpress.XtraEditors.TextEdit();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwithdraw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeposit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.Location = new System.Drawing.Point(13, 242);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.Size = new System.Drawing.Size(100, 38);
            this.btnsavebank.TabIndex = 80;
            this.btnsavebank.Text = "ثبت";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click);
            // 
            // txtDate
            // 
            this.txtDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDate.Location = new System.Drawing.Point(366, 37);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.Size = new System.Drawing.Size(138, 38);
            this.txtDate.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(271, 163);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 90;
            this.label5.Text = "طلبکار(آمد) :";
            // 
            // txtwithdraw
            // 
            this.txtwithdraw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtwithdraw.Location = new System.Drawing.Point(364, 156);
            this.txtwithdraw.Name = "txtwithdraw";
            this.txtwithdraw.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtwithdraw.Properties.Appearance.Options.UseFont = true;
            this.txtwithdraw.Properties.AutoHeight = false;
            this.txtwithdraw.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtwithdraw.Properties.MaskSettings.Set("mask", "n");
            this.txtwithdraw.Size = new System.Drawing.Size(140, 38);
            this.txtwithdraw.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(519, 171);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 88;
            this.label4.Text = "بدهکار (رفت ):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdeposit
            // 
            this.txtdeposit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdeposit.Location = new System.Drawing.Point(139, 154);
            this.txtdeposit.Name = "txtdeposit";
            this.txtdeposit.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtdeposit.Properties.Appearance.Options.UseFont = true;
            this.txtdeposit.Properties.AutoHeight = false;
            this.txtdeposit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtdeposit.Properties.MaskSettings.Set("mask", "n");
            this.txtdeposit.Size = new System.Drawing.Size(126, 38);
            this.txtdeposit.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(271, 105);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(39, 23);
            this.label2.TabIndex = 86;
            this.label2.Text = "شرح :";
            // 
            // txtdesc
            // 
            this.txtdesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdesc.Location = new System.Drawing.Point(13, 98);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtdesc.Properties.Appearance.Options.UseFont = true;
            this.txtdesc.Properties.AutoHeight = false;
            this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdesc.Size = new System.Drawing.Size(252, 38);
            this.txtdesc.TabIndex = 85;
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(366, 99);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(138, 39);
            this.cmbCurrencies.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(519, 107);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 83;
            this.label3.Text = "نوع ارز :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(519, 46);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 82;
            this.label1.Text = "تاریخ :";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(13, 36);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(252, 39);
            this.cmbCustomers.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(271, 44);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 92;
            this.label6.Text = "صاحب حساب :";
            // 
            // PayAndReciveCashFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 294);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtwithdraw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtdeposit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.cmbCurrencies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsavebank);
            this.MaximizeBox = false;
            this.Name = "PayAndReciveCashFrm";
            this.RightToLeftLayout = true;
            this.Text = "دریافت و پرداخت نقدی";
            this.Load += new System.EventHandler(this.PayAndReciveCashFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwithdraw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeposit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtwithdraw;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtdeposit;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtdesc;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label label6;
    }
}