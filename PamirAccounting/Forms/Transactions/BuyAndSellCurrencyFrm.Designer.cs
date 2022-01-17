
namespace PamirAccounting.Forms.Transactions
{
    partial class BuyAndSellCurrencyFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyAndSellCurrencyFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.BtnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbuyerprice = new DevExpress.XtraEditors.TextEdit();
            this.txtbuyername = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtrate = new DevExpress.XtraEditors.TextEdit();
            this.txtcurrencybuyer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnshowcustomer1 = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtsellername = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsellercurrency = new System.Windows.Forms.ComboBox();
            this.txtsellerprice = new DevExpress.XtraEditors.TextEdit();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnshowcustomer = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbuyerprice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbuyername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsellername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsellerprice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 539);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت / ویرایش خرید و فروش ارز";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnSave);
            this.groupBox4.Controls.Add(this.BtnClose);
            this.groupBox4.Location = new System.Drawing.Point(8, 442);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1034, 92);
            this.groupBox4.TabIndex = 101;
            this.groupBox4.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSave.ImageOptions.SvgImage")));
            this.BtnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.BtnSave.Location = new System.Drawing.Point(134, 30);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnSave.Size = new System.Drawing.Size(110, 38);
            this.BtnSave.TabIndex = 89;
            this.BtnSave.Text = "ثبت";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnSave_KeyUp);
            // 
            // BtnClose
            // 
            this.BtnClose.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.Appearance.Options.UseFont = true;
            this.BtnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnClose.ImageOptions.SvgImage")));
            this.BtnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.BtnClose.Location = new System.Drawing.Point(20, 30);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnClose.Size = new System.Drawing.Size(110, 38);
            this.BtnClose.TabIndex = 90;
            this.BtnClose.Text = "بازگشت";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbuyerprice);
            this.groupBox3.Controls.Add(this.txtbuyername);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtrate);
            this.groupBox3.Controls.Add(this.txtcurrencybuyer);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnshowcustomer1);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(8, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 260);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "خرید ارز";
            // 
            // txtbuyerprice
            // 
            this.txtbuyerprice.Location = new System.Drawing.Point(274, 189);
            this.txtbuyerprice.Name = "txtbuyerprice";
            this.txtbuyerprice.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtbuyerprice.Properties.Appearance.Options.UseFont = true;
            this.txtbuyerprice.Properties.AutoHeight = false;
            this.txtbuyerprice.Size = new System.Drawing.Size(140, 38);
            this.txtbuyerprice.TabIndex = 118;
            this.txtbuyerprice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbuyerprice_KeyUp);
            // 
            // txtbuyername
            // 
            this.txtbuyername.Location = new System.Drawing.Point(274, 61);
            this.txtbuyername.Name = "txtbuyername";
            this.txtbuyername.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtbuyername.Properties.Appearance.Options.UseFont = true;
            this.txtbuyername.Properties.AutoHeight = false;
            this.txtbuyername.Size = new System.Drawing.Size(140, 38);
            this.txtbuyername.TabIndex = 113;
            this.txtbuyername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbuyername_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(412, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 26);
            this.label7.TabIndex = 119;
            this.label7.Text = "مبلغ معادل";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(208, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 24);
            this.label13.TabIndex = 120;
            this.label13.Text = "یک میلیون";
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(274, 145);
            this.txtrate.Name = "txtrate";
            this.txtrate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtrate.Properties.Appearance.Options.UseFont = true;
            this.txtrate.Properties.AutoHeight = false;
            this.txtrate.Size = new System.Drawing.Size(140, 38);
            this.txtrate.TabIndex = 101;
            // 
            // txtcurrencybuyer
            // 
            this.txtcurrencybuyer.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtcurrencybuyer.FormattingEnabled = true;
            this.txtcurrencybuyer.Location = new System.Drawing.Point(274, 105);
            this.txtcurrencybuyer.Name = "txtcurrencybuyer";
            this.txtcurrencybuyer.Size = new System.Drawing.Size(140, 34);
            this.txtcurrencybuyer.TabIndex = 116;
            this.txtcurrencybuyer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcurrencybuyer_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(414, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 114;
            this.label3.Text = "صاحب حساب";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(415, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 26);
            this.label4.TabIndex = 117;
            this.label4.Text = "نوع ارز";
            // 
            // btnshowcustomer1
            // 
            this.btnshowcustomer1.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnshowcustomer1.Appearance.Options.UseFont = true;
            this.btnshowcustomer1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnshowcustomer1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnshowcustomer1.ImageOptions.SvgImage")));
            this.btnshowcustomer1.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnshowcustomer1.Location = new System.Drawing.Point(238, 61);
            this.btnshowcustomer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnshowcustomer1.Name = "btnshowcustomer1";
            this.btnshowcustomer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnshowcustomer1.Size = new System.Drawing.Size(38, 38);
            this.btnshowcustomer1.TabIndex = 115;
            this.btnshowcustomer1.Click += new System.EventHandler(this.btnshowcustomer1_Click);
            this.btnshowcustomer1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnshowcustomer1_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(412, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 26);
            this.label11.TabIndex = 104;
            this.label11.Text = "نرخ تبدیل";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDesc.Location = new System.Drawing.Point(528, 370);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(468, 39);
            this.txtDesc.TabIndex = 88;
            this.txtDesc.Text = "";
            this.txtDesc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtsellername);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtsellercurrency);
            this.groupBox2.Controls.Add(this.txtsellerprice);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnshowcustomer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(528, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 260);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "فروش ارز";
            // 
            // txtsellername
            // 
            this.txtsellername.Location = new System.Drawing.Point(282, 107);
            this.txtsellername.Name = "txtsellername";
            this.txtsellername.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtsellername.Properties.Appearance.Options.UseFont = true;
            this.txtsellername.Properties.AutoHeight = false;
            this.txtsellername.Size = new System.Drawing.Size(140, 38);
            this.txtsellername.TabIndex = 107;
            this.txtsellername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsellername_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(423, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 26);
            this.label2.TabIndex = 93;
            this.label2.Text = "نوع ارز";
            // 
            // txtsellercurrency
            // 
            this.txtsellercurrency.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtsellercurrency.FormattingEnabled = true;
            this.txtsellercurrency.Location = new System.Drawing.Point(282, 195);
            this.txtsellercurrency.Name = "txtsellercurrency";
            this.txtsellercurrency.Size = new System.Drawing.Size(140, 34);
            this.txtsellercurrency.TabIndex = 86;
            this.txtsellercurrency.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsellercurrency_KeyUp);
            // 
            // txtsellerprice
            // 
            this.txtsellerprice.Location = new System.Drawing.Point(282, 151);
            this.txtsellerprice.Name = "txtsellerprice";
            this.txtsellerprice.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtsellerprice.Properties.Appearance.Options.UseFont = true;
            this.txtsellerprice.Properties.AutoHeight = false;
            this.txtsellerprice.Size = new System.Drawing.Size(140, 38);
            this.txtsellerprice.TabIndex = 103;
            this.txtsellerprice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsellerprice_KeyUp);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(282, 61);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Size = new System.Drawing.Size(140, 38);
            this.txtDate.TabIndex = 83;
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDate_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(420, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 26);
            this.label6.TabIndex = 95;
            this.label6.Text = "تاریخ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(422, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 26);
            this.label12.TabIndex = 108;
            this.label12.Text = "صاحب حساب";
            // 
            // btnshowcustomer
            // 
            this.btnshowcustomer.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnshowcustomer.Appearance.Options.UseFont = true;
            this.btnshowcustomer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnshowcustomer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnshowcustomer.ImageOptions.SvgImage")));
            this.btnshowcustomer.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnshowcustomer.Location = new System.Drawing.Point(246, 107);
            this.btnshowcustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnshowcustomer.Name = "btnshowcustomer";
            this.btnshowcustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnshowcustomer.Size = new System.Drawing.Size(38, 38);
            this.btnshowcustomer.TabIndex = 111;
            this.btnshowcustomer.Click += new System.EventHandler(this.btnshowcustomer_Click);
            this.btnshowcustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnshowcustomer_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(216, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 112;
            this.label1.Text = "یک میلیون";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(420, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 26);
            this.label9.TabIndex = 106;
            this.label9.Text = "مبلغ ارز";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(996, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 26);
            this.label8.TabIndex = 100;
            this.label8.Text = "شرح";
            // 
            // BuyAndSellCurrencyFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 553);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BuyAndSellCurrencyFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BuyAndSellCurrencyFrm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbuyerprice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbuyername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsellername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsellerprice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnshowcustomer;
        private DevExpress.XtraEditors.TextEdit txtsellername;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtsellerprice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox txtsellercurrency;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtbuyerprice;
        private DevExpress.XtraEditors.TextEdit txtbuyername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtrate;
        private System.Windows.Forms.ComboBox txtcurrencybuyer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnshowcustomer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.SimpleButton BtnClose;
    }
}