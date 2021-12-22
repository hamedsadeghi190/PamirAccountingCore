
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
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdeposit = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtwithdraw = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdesc = new DevExpress.XtraEditors.TextEdit();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeposit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwithdraw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.Location = new System.Drawing.Point(11, 54);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.Size = new System.Drawing.Size(100, 38);
            this.btnsavebank.TabIndex = 69;
            this.btnsavebank.Text = "ثبت";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(307, 28);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 68;
            this.label5.Text = "طلبکار(آمد) :";
            // 
            // txtdeposit
            // 
            this.txtdeposit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtdeposit.Location = new System.Drawing.Point(266, 54);
            this.txtdeposit.Name = "txtdeposit";
            this.txtdeposit.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtdeposit.Properties.Appearance.Options.UseFont = true;
            this.txtdeposit.Properties.AutoHeight = false;
            this.txtdeposit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtdeposit.Properties.MaskSettings.Set("mask", "n");
            this.txtdeposit.Size = new System.Drawing.Size(120, 38);
            this.txtdeposit.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(432, 27);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 66;
            this.label4.Text = "بدهکار (رفت ):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtwithdraw
            // 
            this.txtwithdraw.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtwithdraw.Location = new System.Drawing.Point(388, 54);
            this.txtwithdraw.Name = "txtwithdraw";
            this.txtwithdraw.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtwithdraw.Properties.Appearance.Options.UseFont = true;
            this.txtwithdraw.Properties.AutoHeight = false;
            this.txtwithdraw.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtwithdraw.Properties.MaskSettings.Set("mask", "n");
            this.txtwithdraw.Size = new System.Drawing.Size(126, 38);
            this.txtwithdraw.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(713, 27);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(39, 23);
            this.label2.TabIndex = 64;
            this.label2.Text = "شرح :";
            // 
            // txtdesc
            // 
            this.txtdesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtdesc.Location = new System.Drawing.Point(520, 54);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtdesc.Properties.Appearance.Options.UseFont = true;
            this.txtdesc.Properties.AutoHeight = false;
            this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdesc.Size = new System.Drawing.Size(232, 38);
            this.txtdesc.TabIndex = 63;
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(125, 53);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(138, 39);
            this.cmbCurrencies.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(207, 28);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 61;
            this.label3.Text = "نوع ارز :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(828, 27);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(42, 23);
            this.label1.TabIndex = 60;
            this.label1.Text = "تاریخ :";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDate.Location = new System.Drawing.Point(760, 54);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.Size = new System.Drawing.Size(126, 38);
            this.txtDate.TabIndex = 70;
            // 
            // CreateNewCustomerAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 118);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnsavebank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdeposit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtwithdraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.cmbCurrencies);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "CreateNewCustomerAccount";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت حساب جدید";
            this.Load += new System.EventHandler(this.CreateNewCustomerAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtdeposit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwithdraw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtdeposit;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtwithdraw;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtdesc;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtDate;
    }
}