
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.BtnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbDestCustomers = new System.Windows.Forms.ComboBox();
            this.txtbuyerprice = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_target_mablagh = new System.Windows.Forms.Label();
            this.txtrate = new DevExpress.XtraEditors.TextEdit();
            this.cmbCurrencybuyer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSellCurrencies = new System.Windows.Forms.ComboBox();
            this.txtsellerprice = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Document_Id_value = new System.Windows.Forms.Label();
            this.lbl_Document_Id = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbuyerprice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsellerprice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Document_Id_value);
            this.groupBox1.Controls.Add(this.lbl_Document_Id);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 418);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت / ویرایش خرید و فروش ارز";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDesc);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(6, 275);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(688, 64);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDesc.Location = new System.Drawing.Point(30, 20);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(544, 34);
            this.txtDesc.TabIndex = 120;
            this.txtDesc.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(580, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 24);
            this.label8.TabIndex = 122;
            this.label8.Text = "شرح:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnSave);
            this.groupBox4.Controls.Add(this.BtnClose);
            this.groupBox4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(6, 339);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(688, 70);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.AppearanceDisabled.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.AppearanceDisabled.Options.UseFont = true;
            this.BtnSave.AppearanceHovered.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.AppearanceHovered.Options.UseFont = true;
            this.BtnSave.AppearancePressed.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.AppearancePressed.Options.UseFont = true;
            this.BtnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnSave.ImageOptions.SvgImage")));
            this.BtnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.BtnSave.Location = new System.Drawing.Point(12, 22);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnSave.Size = new System.Drawing.Size(110, 38);
            this.BtnSave.TabIndex = 121;
            this.BtnSave.Text = "ثبت";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnSave_KeyUp);
            // 
            // BtnClose
            // 
            this.BtnClose.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.Appearance.Options.UseFont = true;
            this.BtnClose.AppearanceDisabled.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.AppearanceDisabled.Options.UseFont = true;
            this.BtnClose.AppearanceHovered.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.AppearanceHovered.Options.UseFont = true;
            this.BtnClose.AppearancePressed.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.AppearancePressed.Options.UseFont = true;
            this.BtnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BtnClose.ImageOptions.SvgImage")));
            this.BtnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.BtnClose.Location = new System.Drawing.Point(130, 22);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnClose.Size = new System.Drawing.Size(110, 38);
            this.BtnClose.TabIndex = 122;
            this.BtnClose.Text = "بازگشت";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbDestCustomers);
            this.groupBox3.Controls.Add(this.txtbuyerprice);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lbl_target_mablagh);
            this.groupBox3.Controls.Add(this.txtrate);
            this.groupBox3.Controls.Add(this.cmbCurrencybuyer);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(7, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 214);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "خرید ارز";
            // 
            // cmbDestCustomers
            // 
            this.cmbDestCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDestCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbDestCustomers.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDestCustomers.FormattingEnabled = true;
            this.cmbDestCustomers.Location = new System.Drawing.Point(29, 30);
            this.cmbDestCustomers.Name = "cmbDestCustomers";
            this.cmbDestCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbDestCustomers.Size = new System.Drawing.Size(193, 32);
            this.cmbDestCustomers.TabIndex = 116;
            this.cmbDestCustomers.SelectedIndexChanged += new System.EventHandler(this.cmbDestCustomers_SelectedIndexChanged);
            // 
            // txtbuyerprice
            // 
            this.txtbuyerprice.Location = new System.Drawing.Point(29, 140);
            this.txtbuyerprice.Name = "txtbuyerprice";
            this.txtbuyerprice.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtbuyerprice.Properties.Appearance.Options.UseFont = true;
            this.txtbuyerprice.Properties.AutoHeight = false;
            this.txtbuyerprice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtbuyerprice.Size = new System.Drawing.Size(193, 32);
            this.txtbuyerprice.TabIndex = 119;
            this.txtbuyerprice.TextChanged += new System.EventHandler(this.txtbuyerprice_TextChanged);
            this.txtbuyerprice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbuyerprice_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(225, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 24);
            this.label7.TabIndex = 119;
            this.label7.Text = "مبلغ معادل :";
            // 
            // lbl_target_mablagh
            // 
            this.lbl_target_mablagh.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_target_mablagh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_target_mablagh.Location = new System.Drawing.Point(21, 177);
            this.lbl_target_mablagh.Name = "lbl_target_mablagh";
            this.lbl_target_mablagh.Size = new System.Drawing.Size(204, 27);
            this.lbl_target_mablagh.TabIndex = 120;
            // 
            // txtrate
            // 
            this.txtrate.EditValue = "";
            this.txtrate.Location = new System.Drawing.Point(29, 104);
            this.txtrate.Name = "txtrate";
            this.txtrate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtrate.Properties.Appearance.Options.UseFont = true;
            this.txtrate.Properties.AutoHeight = false;
            this.txtrate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtrate.Properties.MaskSettings.Set("mask", "f");
            this.txtrate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtrate.Size = new System.Drawing.Size(193, 32);
            this.txtrate.TabIndex = 118;
            this.txtrate.TextChanged += new System.EventHandler(this.txtrate_TextChanged);
            // 
            // cmbCurrencybuyer
            // 
            this.cmbCurrencybuyer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCurrencybuyer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbCurrencybuyer.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencybuyer.FormattingEnabled = true;
            this.cmbCurrencybuyer.Location = new System.Drawing.Point(29, 68);
            this.cmbCurrencybuyer.Name = "cmbCurrencybuyer";
            this.cmbCurrencybuyer.Size = new System.Drawing.Size(193, 32);
            this.cmbCurrencybuyer.TabIndex = 117;
            this.cmbCurrencybuyer.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencybuyer_SelectedIndexChanged);
            this.cmbCurrencybuyer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcurrencybuyer_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(223, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 24);
            this.label3.TabIndex = 114;
            this.label3.Text = "حساب بدهکار :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(224, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 117;
            this.label4.Text = "نوع ارز :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(224, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 24);
            this.label11.TabIndex = 104;
            this.label11.Text = "نرخ تبدیل :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.cmbCustomers);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbSellCurrencies);
            this.groupBox2.Controls.Add(this.txtsellerprice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(357, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 215);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "فروش ارز";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtDate
            // 
            this.txtDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDate.Location = new System.Drawing.Point(31, 31);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(193, 32);
            this.txtDate.TabIndex = 112;
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbCustomers.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(32, 68);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCustomers.Size = new System.Drawing.Size(193, 32);
            this.cmbCustomers.TabIndex = 113;
            this.cmbCustomers.SelectedValueChanged += new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(229, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 93;
            this.label2.Text = "نوع ارز:";
            // 
            // cmbSellCurrencies
            // 
            this.cmbSellCurrencies.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSellCurrencies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbSellCurrencies.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSellCurrencies.FormattingEnabled = true;
            this.cmbSellCurrencies.Location = new System.Drawing.Point(31, 140);
            this.cmbSellCurrencies.Name = "cmbSellCurrencies";
            this.cmbSellCurrencies.Size = new System.Drawing.Size(193, 32);
            this.cmbSellCurrencies.TabIndex = 115;
            this.cmbSellCurrencies.SelectedIndexChanged += new System.EventHandler(this.cmbSellCurrencies_SelectedIndexChanged);
            this.cmbSellCurrencies.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsellercurrency_KeyUp);
            // 
            // txtsellerprice
            // 
            this.txtsellerprice.EditValue = "0";
            this.txtsellerprice.Location = new System.Drawing.Point(31, 104);
            this.txtsellerprice.Name = "txtsellerprice";
            this.txtsellerprice.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtsellerprice.Properties.Appearance.Options.UseFont = true;
            this.txtsellerprice.Properties.AutoHeight = false;
            this.txtsellerprice.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtsellerprice.Properties.MaskSettings.Set("mask", "n0");
            this.txtsellerprice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtsellerprice.Size = new System.Drawing.Size(193, 32);
            this.txtsellerprice.TabIndex = 114;
            this.txtsellerprice.TextChanged += new System.EventHandler(this.txtsellerprice_TextChanged);
            this.txtsellerprice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsellerprice_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(230, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 24);
            this.label6.TabIndex = 95;
            this.label6.Text = "تاریخ :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(229, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 24);
            this.label12.TabIndex = 108;
            this.label12.Text = "حساب طلبکار :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(31, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 112;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(231, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 24);
            this.label9.TabIndex = 106;
            this.label9.Text = "مبلغ ارز:";
            // 
            // lbl_Document_Id_value
            // 
            this.lbl_Document_Id_value.AccessibleName = "";
            this.lbl_Document_Id_value.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Document_Id_value.Location = new System.Drawing.Point(228, 24);
            this.lbl_Document_Id_value.Name = "lbl_Document_Id_value";
            this.lbl_Document_Id_value.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Document_Id_value.Size = new System.Drawing.Size(123, 24);
            this.lbl_Document_Id_value.TabIndex = 135;
            this.lbl_Document_Id_value.Text = "0";
            this.lbl_Document_Id_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Document_Id
            // 
            this.lbl_Document_Id.AutoSize = true;
            this.lbl_Document_Id.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Document_Id.Location = new System.Drawing.Point(357, 24);
            this.lbl_Document_Id.Name = "lbl_Document_Id";
            this.lbl_Document_Id.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Document_Id.Size = new System.Drawing.Size(42, 24);
            this.lbl_Document_Id.TabIndex = 134;
            this.lbl_Document_Id.Text = "سند :";
            // 
            // BuyAndSellCurrencyFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 435);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BuyAndSellCurrencyFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BuyAndSellCurrencyFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BuyAndSellCurrencyFrm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbuyerprice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsellerprice.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtsellerprice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSellCurrencies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtbuyerprice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_target_mablagh;
        private DevExpress.XtraEditors.TextEdit txtrate;
        private System.Windows.Forms.ComboBox cmbCurrencybuyer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbDestCustomers;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.SimpleButton BtnClose;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Document_Id_value;
        private System.Windows.Forms.Label lbl_Document_Id;
    }
}