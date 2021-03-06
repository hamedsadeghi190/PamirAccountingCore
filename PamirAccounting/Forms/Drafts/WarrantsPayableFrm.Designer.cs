
namespace PamirAccounting.Forms.Drafts
{
    partial class WarrantsPayableFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarrantsPayableFrm));
            this.txtDepositAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtDraftAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbDraftCurrency = new System.Windows.Forms.ComboBox();
            this.cmbAgency = new System.Windows.Forms.ComboBox();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbDepositCurreny = new System.Windows.Forms.ComboBox();
            this.txtRent = new System.Windows.Forms.TextBox();
            this.txtPayPlace = new System.Windows.Forms.TextBox();
            this.txtReciver = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.txtOtherNumber = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpHavale = new System.Windows.Forms.GroupBox();
            this.txt_forosh_ext_number = new System.Windows.Forms.TextBox();
            this.txt_forosh_number = new System.Windows.Forms.TextBox();
            this.lbl_forosh_ext_number = new System.Windows.Forms.Label();
            this.lbl_forosh_number = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepositAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDraftAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            this.grpHavale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDepositAmount
            // 
            this.txtDepositAmount.EditValue = "";
            this.txtDepositAmount.Enabled = false;
            this.txtDepositAmount.Location = new System.Drawing.Point(47, 187);
            this.txtDepositAmount.Name = "txtDepositAmount";
            this.txtDepositAmount.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDepositAmount.Properties.Appearance.Options.UseFont = true;
            this.txtDepositAmount.Properties.AutoHeight = false;
            this.txtDepositAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtDepositAmount.Properties.MaskSettings.Set("mask", "f");
            this.txtDepositAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDepositAmount.Size = new System.Drawing.Size(188, 32);
            this.txtDepositAmount.TabIndex = 14;
            // 
            // txtDraftAmount
            // 
            this.txtDraftAmount.EditValue = "";
            this.txtDraftAmount.Location = new System.Drawing.Point(47, 74);
            this.txtDraftAmount.Name = "txtDraftAmount";
            this.txtDraftAmount.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDraftAmount.Properties.Appearance.Options.UseFont = true;
            this.txtDraftAmount.Properties.AutoHeight = false;
            this.txtDraftAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtDraftAmount.Properties.MaskSettings.Set("mask", "n0");
            this.txtDraftAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDraftAmount.Size = new System.Drawing.Size(188, 32);
            this.txtDraftAmount.TabIndex = 11;
            this.txtDraftAmount.TextChanged += new System.EventHandler(this.txtDraftAmount_TextChanged);
            this.txtDraftAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDraftAmount_KeyPress);
            this.txtDraftAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDraftAmount_KeyUp);
            // 
            // txtRate
            // 
            this.txtRate.EditValue = "";
            this.txtRate.Location = new System.Drawing.Point(47, 112);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.AutoHeight = false;
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(188, 32);
            this.txtRate.TabIndex = 12;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            this.txtRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyUp);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(377, 37);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(188, 32);
            this.txtDate.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(36, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnClose.Location = new System.Drawing.Point(152, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "بازگشت";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbCustomer.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(47, 266);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(188, 32);
            this.cmbCustomer.TabIndex = 16;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // cmbDraftCurrency
            // 
            this.cmbDraftCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDraftCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbDraftCurrency.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDraftCurrency.FormattingEnabled = true;
            this.cmbDraftCurrency.Location = new System.Drawing.Point(48, 37);
            this.cmbDraftCurrency.Name = "cmbDraftCurrency";
            this.cmbDraftCurrency.Size = new System.Drawing.Size(186, 32);
            this.cmbDraftCurrency.TabIndex = 10;
            this.cmbDraftCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbDraftCurrency_SelectedIndexChanged);
            // 
            // cmbAgency
            // 
            this.cmbAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbAgency.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAgency.FormattingEnabled = true;
            this.cmbAgency.Location = new System.Drawing.Point(377, 77);
            this.cmbAgency.Name = "cmbAgency";
            this.cmbAgency.Size = new System.Drawing.Size(188, 32);
            this.cmbAgency.TabIndex = 2;
            this.cmbAgency.SelectedIndexChanged += new System.EventHandler(this.cmbAgency_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDesc.Location = new System.Drawing.Point(47, 380);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(518, 32);
            this.txtDesc.TabIndex = 19;
            this.txtDesc.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(571, 383);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 24);
            this.label17.TabIndex = 32;
            this.label17.Text = "توضیحات :";
            // 
            // cmbDepositCurreny
            // 
            this.cmbDepositCurreny.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepositCurreny.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbDepositCurreny.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDepositCurreny.FormattingEnabled = true;
            this.cmbDepositCurreny.ItemHeight = 24;
            this.cmbDepositCurreny.Location = new System.Drawing.Point(48, 225);
            this.cmbDepositCurreny.Name = "cmbDepositCurreny";
            this.cmbDepositCurreny.Size = new System.Drawing.Size(188, 32);
            this.cmbDepositCurreny.TabIndex = 15;
            this.cmbDepositCurreny.SelectedValueChanged += new System.EventHandler(this.cmbDepositCurreny_SelectedValueChanged);
            // 
            // txtRent
            // 
            this.txtRent.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRent.Location = new System.Drawing.Point(47, 151);
            this.txtRent.Name = "txtRent";
            this.txtRent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRent.Size = new System.Drawing.Size(188, 31);
            this.txtRent.TabIndex = 13;
            this.txtRent.TextChanged += new System.EventHandler(this.txtRent_TextChanged);
            this.txtRent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRent_KeyPress);
            this.txtRent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRent_KeyUp);
            // 
            // txtPayPlace
            // 
            this.txtPayPlace.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPayPlace.Location = new System.Drawing.Point(377, 305);
            this.txtPayPlace.Name = "txtPayPlace";
            this.txtPayPlace.Size = new System.Drawing.Size(188, 31);
            this.txtPayPlace.TabIndex = 8;
            // 
            // txtReciver
            // 
            this.txtReciver.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtReciver.Location = new System.Drawing.Point(377, 228);
            this.txtReciver.Name = "txtReciver";
            this.txtReciver.Size = new System.Drawing.Size(188, 31);
            this.txtReciver.TabIndex = 6;
            // 
            // txtFatherName
            // 
            this.txtFatherName.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFatherName.Location = new System.Drawing.Point(377, 265);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(188, 31);
            this.txtFatherName.TabIndex = 7;
            // 
            // txtSender
            // 
            this.txtSender.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSender.Location = new System.Drawing.Point(377, 192);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(188, 31);
            this.txtSender.TabIndex = 5;
            // 
            // txtOtherNumber
            // 
            this.txtOtherNumber.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOtherNumber.Location = new System.Drawing.Point(377, 156);
            this.txtOtherNumber.Name = "txtOtherNumber";
            this.txtOtherNumber.Size = new System.Drawing.Size(188, 31);
            this.txtOtherNumber.TabIndex = 4;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(377, 341);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(188, 32);
            this.cmbStatus.TabIndex = 9;
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNumber.Location = new System.Drawing.Point(377, 116);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(188, 31);
            this.txtNumber.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(570, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "محل پرداخت:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(571, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "گیرنده:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(571, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "ولد:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(571, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "فرستنده:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(571, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "شماره متفرقه:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(571, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "شماره:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(571, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "نمایندگی:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(571, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(243, 271);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 24);
            this.label16.TabIndex = 30;
            this.label16.Text = "نوع پرداخت:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(241, 192);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 24);
            this.label14.TabIndex = 28;
            this.label14.Text = "مبلغ دریافتی :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(242, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 24);
            this.label15.TabIndex = 27;
            this.label15.Text = "نوع ارز دریافتی :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(241, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 24);
            this.label10.TabIndex = 24;
            this.label10.Text = "کرایه:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(242, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 24);
            this.label11.TabIndex = 22;
            this.label11.Text = "نرخ تبدیل:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(241, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 24);
            this.label12.TabIndex = 20;
            this.label12.Text = "مبلغ حواله:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(242, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 24);
            this.label13.TabIndex = 18;
            this.label13.Text = "نوع حواله :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(570, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "وضعیت :";
            // 
            // grpHavale
            // 
            this.grpHavale.Controls.Add(this.txt_forosh_ext_number);
            this.grpHavale.Controls.Add(this.txt_forosh_number);
            this.grpHavale.Controls.Add(this.lbl_forosh_ext_number);
            this.grpHavale.Controls.Add(this.lbl_forosh_number);
            this.grpHavale.Controls.Add(this.txtDepositAmount);
            this.grpHavale.Controls.Add(this.txtDraftAmount);
            this.grpHavale.Controls.Add(this.txtRate);
            this.grpHavale.Controls.Add(this.txtDate);
            this.grpHavale.Controls.Add(this.cmbCustomer);
            this.grpHavale.Controls.Add(this.cmbDraftCurrency);
            this.grpHavale.Controls.Add(this.cmbAgency);
            this.grpHavale.Controls.Add(this.txtDesc);
            this.grpHavale.Controls.Add(this.label17);
            this.grpHavale.Controls.Add(this.cmbDepositCurreny);
            this.grpHavale.Controls.Add(this.txtRent);
            this.grpHavale.Controls.Add(this.txtPayPlace);
            this.grpHavale.Controls.Add(this.txtReciver);
            this.grpHavale.Controls.Add(this.txtFatherName);
            this.grpHavale.Controls.Add(this.txtSender);
            this.grpHavale.Controls.Add(this.txtOtherNumber);
            this.grpHavale.Controls.Add(this.cmbStatus);
            this.grpHavale.Controls.Add(this.txtNumber);
            this.grpHavale.Controls.Add(this.label9);
            this.grpHavale.Controls.Add(this.label8);
            this.grpHavale.Controls.Add(this.label7);
            this.grpHavale.Controls.Add(this.label6);
            this.grpHavale.Controls.Add(this.label5);
            this.grpHavale.Controls.Add(this.label3);
            this.grpHavale.Controls.Add(this.label2);
            this.grpHavale.Controls.Add(this.label1);
            this.grpHavale.Controls.Add(this.label16);
            this.grpHavale.Controls.Add(this.label14);
            this.grpHavale.Controls.Add(this.label15);
            this.grpHavale.Controls.Add(this.label10);
            this.grpHavale.Controls.Add(this.label11);
            this.grpHavale.Controls.Add(this.label12);
            this.grpHavale.Controls.Add(this.label13);
            this.grpHavale.Controls.Add(this.label4);
            this.grpHavale.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpHavale.Location = new System.Drawing.Point(7, 7);
            this.grpHavale.Name = "grpHavale";
            this.grpHavale.Size = new System.Drawing.Size(700, 450);
            this.grpHavale.TabIndex = 1;
            this.grpHavale.TabStop = false;
            this.grpHavale.Text = "حواله آمد";
            this.grpHavale.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txt_forosh_ext_number
            // 
            this.txt_forosh_ext_number.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_forosh_ext_number.Location = new System.Drawing.Point(47, 341);
            this.txt_forosh_ext_number.Name = "txt_forosh_ext_number";
            this.txt_forosh_ext_number.Size = new System.Drawing.Size(188, 31);
            this.txt_forosh_ext_number.TabIndex = 18;
            this.txt_forosh_ext_number.Visible = false;
            // 
            // txt_forosh_number
            // 
            this.txt_forosh_number.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_forosh_number.Location = new System.Drawing.Point(47, 305);
            this.txt_forosh_number.Name = "txt_forosh_number";
            this.txt_forosh_number.Size = new System.Drawing.Size(188, 31);
            this.txt_forosh_number.TabIndex = 17;
            this.txt_forosh_number.Visible = false;
            // 
            // lbl_forosh_ext_number
            // 
            this.lbl_forosh_ext_number.AutoSize = true;
            this.lbl_forosh_ext_number.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_forosh_ext_number.Location = new System.Drawing.Point(240, 345);
            this.lbl_forosh_ext_number.Name = "lbl_forosh_ext_number";
            this.lbl_forosh_ext_number.Size = new System.Drawing.Size(133, 24);
            this.lbl_forosh_ext_number.TabIndex = 36;
            this.lbl_forosh_ext_number.Text = "کمیسیون نمایندگی :";
            this.lbl_forosh_ext_number.Visible = false;
            // 
            // lbl_forosh_number
            // 
            this.lbl_forosh_number.AutoSize = true;
            this.lbl_forosh_number.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_forosh_number.Location = new System.Drawing.Point(241, 308);
            this.lbl_forosh_number.Name = "lbl_forosh_number";
            this.lbl_forosh_number.Size = new System.Drawing.Size(52, 24);
            this.lbl_forosh_number.TabIndex = 35;
            this.lbl_forosh_number.Text = "شماره :";
            this.lbl_forosh_number.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(7, 460);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 67);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // WarrantsPayableFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 531);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpHavale);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "WarrantsPayableFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.WarrantsPayableFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WarrantsPayableFrm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.txtDepositAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDraftAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            this.grpHavale.ResumeLayout(false);
            this.grpHavale.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDepositAmount;
        private DevExpress.XtraEditors.TextEdit txtDraftAmount;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbDraftCurrency;
        private System.Windows.Forms.ComboBox cmbAgency;
        private System.Windows.Forms.RichTextBox txtDesc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbDepositCurreny;
        private System.Windows.Forms.TextBox txtRent;
        private System.Windows.Forms.TextBox txtPayPlace;
        private System.Windows.Forms.TextBox txtReciver;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.TextBox txtOtherNumber;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpHavale;
        private System.Windows.Forms.TextBox txt_forosh_ext_number;
        private System.Windows.Forms.TextBox txt_forosh_number;
        private System.Windows.Forms.Label lbl_forosh_ext_number;
        private System.Windows.Forms.Label lbl_forosh_number;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}