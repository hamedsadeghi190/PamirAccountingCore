
namespace PamirAccounting.UI.Forms.Customers
{
    partial class ViewCustomerAccountFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCustomerAccountFrm));
            this.groupBoxViewAccountCustomer = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbActions = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnprint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.btnprintResid = new DevExpress.XtraEditors.SimpleButton();
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.grdTransactions = new System.Windows.Forms.DataGridView();
            this.grdTotals = new System.Windows.Forms.DataGridView();
            this.txtDate2 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate1 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsearch = new DevExpress.XtraEditors.SimpleButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRowEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRowDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxViewAccountCustomer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxViewAccountCustomer
            // 
            this.groupBoxViewAccountCustomer.Controls.Add(this.groupBox2);
            this.groupBoxViewAccountCustomer.Controls.Add(this.groupBox1);
            this.groupBoxViewAccountCustomer.Controls.Add(this.btnprint);
            this.groupBoxViewAccountCustomer.Controls.Add(this.simpleButton5);
            this.groupBoxViewAccountCustomer.Controls.Add(this.btnprintResid);
            this.groupBoxViewAccountCustomer.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxViewAccountCustomer.Location = new System.Drawing.Point(6, 16);
            this.groupBoxViewAccountCustomer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxViewAccountCustomer.Name = "groupBoxViewAccountCustomer";
            this.groupBoxViewAccountCustomer.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxViewAccountCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBoxViewAccountCustomer.Size = new System.Drawing.Size(1676, 169);
            this.groupBoxViewAccountCustomer.TabIndex = 9;
            this.groupBoxViewAccountCustomer.TabStop = false;
            this.groupBoxViewAccountCustomer.Text = "نمایش اطلاعات حساب";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbActions);
            this.groupBox2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(1397, 38);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(269, 115);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "عملیات حساب";
            // 
            // cmbActions
            // 
            this.cmbActions.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbActions.FormattingEnabled = true;
            this.cmbActions.Location = new System.Drawing.Point(36, 43);
            this.cmbActions.Margin = new System.Windows.Forms.Padding(4);
            this.cmbActions.Name = "cmbActions";
            this.cmbActions.Size = new System.Drawing.Size(194, 37);
            this.cmbActions.TabIndex = 102;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDate2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDate1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnsearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbCurrencies);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(132, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1257, 115);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(965, 45);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Properties.AutoHeight = false;
            this.txtSearch.Size = new System.Drawing.Size(194, 37);
            this.txtSearch.TabIndex = 113;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(1161, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(61, 23);
            this.label4.TabIndex = 110;
            this.label4.Text = "شماره :";
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(670, 43);
            this.cmbCurrencies.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(194, 37);
            this.cmbCurrencies.TabIndex = 114;
            this.cmbCurrencies.TextChanged += new System.EventHandler(this.cmbCurrencies_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(867, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 111;
            this.label1.Text = "نوع ارز :";
            // 
            // btnprint
            // 
            this.btnprint.AppearanceHovered.Options.UseTextOptions = true;
            this.btnprint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnprint.ImageOptions.SvgImage")));
            this.btnprint.Location = new System.Drawing.Point(56, 51);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(46, 50);
            this.btnprint.TabIndex = 117;
            this.btnprint.Text = "چاپ";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton5.ImageOptions.SvgImage")));
            this.simpleButton5.Location = new System.Drawing.Point(7, 51);
            this.simpleButton5.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(46, 50);
            this.simpleButton5.TabIndex = 118;
            this.simpleButton5.Text = "راهنما";
            // 
            // btnprintResid
            // 
            this.btnprintResid.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnprintResid.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnprintResid.Appearance.Options.UseFont = true;
            this.btnprintResid.Appearance.Options.UseForeColor = true;
            this.btnprintResid.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnprintResid.ImageOptions.SvgImage")));
            this.btnprintResid.Location = new System.Drawing.Point(7, 104);
            this.btnprintResid.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnprintResid.Name = "btnprintResid";
            this.btnprintResid.Size = new System.Drawing.Size(95, 49);
            this.btnprintResid.TabIndex = 116;
            this.btnprintResid.Text = "رسید";
            this.btnprintResid.Click += new System.EventHandler(this.btnprintResid_Click);
            // 
            // galleryDropDown1
            // 
            this.galleryDropDown1.Manager = null;
            this.galleryDropDown1.Name = "galleryDropDown1";
            // 
            // grdTransactions
            // 
            this.grdTransactions.AllowUserToAddRows = false;
            this.grdTransactions.AllowUserToDeleteRows = false;
            this.grdTransactions.BackgroundColor = System.Drawing.Color.White;
            this.grdTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.DocumentId,
            this.Column3,
            this.Column2,
            this.Column4,
            this.GroupName,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.btnRowEdit,
            this.btnRowDelete});
            this.grdTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdTransactions.Location = new System.Drawing.Point(0, 186);
            this.grdTransactions.Margin = new System.Windows.Forms.Padding(4);
            this.grdTransactions.Name = "grdTransactions";
            this.grdTransactions.ReadOnly = true;
            this.grdTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdTransactions.RowHeadersWidth = 51;
            this.grdTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTransactions.ShowEditingIcon = false;
            this.grdTransactions.Size = new System.Drawing.Size(1682, 423);
            this.grdTransactions.TabIndex = 15;
            this.grdTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTransactions_CellClick);
            this.grdTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTransactions_CellContentClick);
            this.grdTransactions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTransactions_CellValueChanged);
            this.grdTransactions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdTransactions_KeyPress);
            // 
            // grdTotals
            // 
            this.grdTotals.AllowUserToAddRows = false;
            this.grdTotals.AllowUserToDeleteRows = false;
            this.grdTotals.BackgroundColor = System.Drawing.Color.White;
            this.grdTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTotals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column10,
            this.Column11});
            this.grdTotals.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdTotals.Location = new System.Drawing.Point(0, 609);
            this.grdTotals.Margin = new System.Windows.Forms.Padding(4);
            this.grdTotals.Name = "grdTotals";
            this.grdTotals.ReadOnly = true;
            this.grdTotals.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdTotals.RowHeadersWidth = 51;
            this.grdTotals.ShowEditingIcon = false;
            this.grdTotals.Size = new System.Drawing.Size(1682, 154);
            this.grdTotals.TabIndex = 16;
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(73, 42);
            this.txtDate2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate2.Properties.Appearance.Options.UseFont = true;
            this.txtDate2.Properties.AutoHeight = false;
            this.txtDate2.Size = new System.Drawing.Size(194, 37);
            this.txtDate2.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(272, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 119;
            this.label2.Text = "تا تاریخ :";
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(354, 43);
            this.txtDate1.Margin = new System.Windows.Forms.Padding(4);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate1.Properties.Appearance.Options.UseFont = true;
            this.txtDate1.Properties.AutoHeight = false;
            this.txtDate1.Size = new System.Drawing.Size(194, 37);
            this.txtDate1.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(552, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 117;
            this.label3.Text = "از تاریخ :";
            // 
            // btnsearch
            // 
            this.btnsearch.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsearch.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnsearch.Appearance.Options.UseFont = true;
            this.btnsearch.Appearance.Options.UseForeColor = true;
            this.btnsearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsearch.ImageOptions.SvgImage")));
            this.btnsearch.Location = new System.Drawing.Point(14, 40);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(43, 40);
            this.btnsearch.TabIndex = 116;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowId";
            this.Column1.FillWeight = 70F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "ردیف";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 70;
            // 
            // DocumentId
            // 
            this.DocumentId.DataPropertyName = "DocumentId";
            this.DocumentId.FillWeight = 70F;
            this.DocumentId.Frozen = true;
            this.DocumentId.HeaderText = "سند";
            this.DocumentId.MinimumWidth = 6;
            this.DocumentId.Name = "DocumentId";
            this.DocumentId.ReadOnly = true;
            this.DocumentId.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TransactionDateTime";
            this.Column3.FillWeight = 110F;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "تاریخ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 110;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Description";
            this.Column2.FillWeight = 250F;
            this.Column2.HeaderText = "شرح";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 313;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "WithdrawAmount";
            this.Column4.HeaderText = "بدهکار";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "DepositAmount";
            this.GroupName.HeaderText = "طلبکار";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CurrenyName";
            this.Column5.FillWeight = 70F;
            this.Column5.HeaderText = "نوع ارز";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RemainigAmount";
            this.Column6.HeaderText = "باقیمانده";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Status";
            this.Column7.HeaderText = "وضعیت";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "UserName";
            this.Column8.FillWeight = 80F;
            this.Column8.HeaderText = "کابر عامل";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 120;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Date";
            this.Column9.HeaderText = "زمان";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.FillWeight = 70F;
            this.btnRowEdit.HeaderText = "ویرایش";
            this.btnRowEdit.MinimumWidth = 6;
            this.btnRowEdit.Name = "btnRowEdit";
            this.btnRowEdit.ReadOnly = true;
            this.btnRowEdit.Text = "ویرایش";
            this.btnRowEdit.UseColumnTextForButtonValue = true;
            this.btnRowEdit.Width = 70;
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.FillWeight = 70F;
            this.btnRowDelete.HeaderText = "حذف";
            this.btnRowDelete.MinimumWidth = 6;
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.ReadOnly = true;
            this.btnRowDelete.Text = "حذف";
            this.btnRowDelete.UseColumnTextForButtonValue = true;
            this.btnRowDelete.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.FillWeight = 610F;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "شرح";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 720;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TotalWithdrawAmount";
            this.dataGridViewTextBoxColumn3.FillWeight = 150F;
            this.dataGridViewTextBoxColumn3.HeaderText = "جمع بدهکار";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalDepositAmount";
            this.dataGridViewTextBoxColumn4.FillWeight = 150F;
            this.dataGridViewTextBoxColumn4.HeaderText = "جمع طلبکار";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CurrenyName";
            this.dataGridViewTextBoxColumn5.FillWeight = 130F;
            this.dataGridViewTextBoxColumn5.HeaderText = "نوع ارز";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 130;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "RemainigAmount";
            this.Column10.FillWeight = 150F;
            this.Column10.HeaderText = "باقیمانده";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 175;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "Status";
            this.Column11.HeaderText = "وضعیت";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 300;
            // 
            // ViewCustomerAccountFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1681, 751);
            this.Controls.Add(this.grdTotals);
            this.Controls.Add(this.grdTransactions);
            this.Controls.Add(this.groupBoxViewAccountCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ViewCustomerAccountFrm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ViewCustomerAccountFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ViewCustomerAccountFrm_KeyUp);
            this.groupBoxViewAccountCustomer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxViewAccountCustomer;
        private DevExpress.XtraEditors.SimpleButton btnprintResid;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
        private System.Windows.Forms.DataGridView grdTransactions;
        private System.Windows.Forms.DataGridView grdTotals;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbActions;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnprint;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.TextEdit txtDate2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtDate1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnsearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}