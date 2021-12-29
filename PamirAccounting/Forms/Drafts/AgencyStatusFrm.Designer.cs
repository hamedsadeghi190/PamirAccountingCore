
namespace PamirAccounting.Forms.Drafts
{
    partial class AgencyStatusFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgencyStatusFrm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btncurrencyexchange = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBal = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.gridDrafts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grdTotals = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDrafts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotals)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btncurrencyexchange);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBal);
            this.groupBox2.Controls.Add(this.simpleButton4);
            this.groupBox2.Controls.Add(this.simpleButton3);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1457, 77);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "نمایندگی مزار";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(80, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "دلار";
            // 
            // btncurrencyexchange
            // 
            this.btncurrencyexchange.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btncurrencyexchange.ImageOptions.SvgImage")));
            this.btncurrencyexchange.Location = new System.Drawing.Point(1181, 24);
            this.btncurrencyexchange.Name = "btncurrencyexchange";
            this.btncurrencyexchange.Size = new System.Drawing.Size(39, 41);
            this.btncurrencyexchange.TabIndex = 7;
            this.btncurrencyexchange.Text = "تبدیل";
            this.btncurrencyexchange.Click += new System.EventHandler(this.btncurrencyexchange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(117, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "ارز معیار :";
            // 
            // btnBal
            // 
            this.btnBal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton5.ImageOptions.SvgImage")));
            this.btnBal.Location = new System.Drawing.Point(1227, 24);
            this.btnBal.Name = "btnBal";
            this.btnBal.Size = new System.Drawing.Size(39, 41);
            this.btnBal.TabIndex = 5;
            this.btnBal.Text = "تسویه حساب";
            this.btnBal.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.AppearanceHovered.Options.UseTextOptions = true;
            this.simpleButton4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton4.ImageOptions.SvgImage")));
            this.simpleButton4.Location = new System.Drawing.Point(1273, 24);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(39, 41);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "چاپ";
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(1135, 24);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(39, 41);
            this.simpleButton3.TabIndex = 2;
            this.simpleButton3.Text = "راهنما";
            // 
            // btnSearch
            // 
            this.btnSearch.AppearanceHovered.Options.UseTextOptions = true;
            this.btnSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSearch.ImageOptions.SvgImage")));
            this.btnSearch.Location = new System.Drawing.Point(1317, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 41);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridDrafts
            // 
            this.gridDrafts.AllowUserToDeleteRows = false;
            this.gridDrafts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridDrafts.BackgroundColor = System.Drawing.Color.White;
            this.gridDrafts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDrafts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.a,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column11,
            this.Column7,
            this.Column10,
            this.Column13,
            this.Column14,
            this.Column16,
            this.Column15,
            this.Column18,
            this.Column17,
            this.Column21,
            this.Column22});
            this.gridDrafts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridDrafts.Location = new System.Drawing.Point(-1, 87);
            this.gridDrafts.Name = "gridDrafts";
            this.gridDrafts.ReadOnly = true;
            this.gridDrafts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridDrafts.RowHeadersWidth = 51;
            this.gridDrafts.ShowEditingIcon = false;
            this.gridDrafts.Size = new System.Drawing.Size(1462, 387);
            this.gridDrafts.TabIndex = 25;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 60F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "ردیف";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
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
            this.Column2.HeaderText = "شماره";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "شماره متفرقه";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // a
            // 
            this.a.HeaderText = "فرستنده";
            this.a.MinimumWidth = 6;
            this.a.Name = "a";
            this.a.ReadOnly = true;
            this.a.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "گیرنده";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "مبلغ اصلی";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ارز ";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "کمیشن";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "مبلغ تبدیل شده";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "نرخ";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 125;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "ارز ";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 125;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "باقیمانده";
            this.Column14.MinimumWidth = 6;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 125;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "وضعیت";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 125;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "محل ";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 125;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "توضیحات";
            this.Column18.MinimumWidth = 6;
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 125;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "تطبیق";
            this.Column17.MinimumWidth = 6;
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 125;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "ویرایش";
            this.Column21.MinimumWidth = 6;
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column21.Text = "ویرایش";
            this.Column21.Width = 50;
            // 
            // Column22
            // 
            this.Column22.HeaderText = "حذف";
            this.Column22.MinimumWidth = 6;
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column22.Text = "حذف";
            this.Column22.Width = 50;
            // 
            // grdTotals
            // 
            this.grdTotals.AllowUserToAddRows = false;
            this.grdTotals.AllowUserToDeleteRows = false;
            this.grdTotals.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdTotals.BackgroundColor = System.Drawing.Color.White;
            this.grdTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTotals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Column8,
            this.Column12});
            this.grdTotals.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdTotals.Location = new System.Drawing.Point(-1, 472);
            this.grdTotals.Name = "grdTotals";
            this.grdTotals.ReadOnly = true;
            this.grdTotals.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdTotals.RowHeadersWidth = 51;
            this.grdTotals.ShowEditingIcon = false;
            this.grdTotals.Size = new System.Drawing.Size(1462, 153);
            this.grdTotals.TabIndex = 24;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.FillWeight = 610F;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "نوع ارز";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 620;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TotalWithdrawAmount";
            this.dataGridViewTextBoxColumn3.FillWeight = 150F;
            this.dataGridViewTextBoxColumn3.HeaderText = "جمع بدهکار";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 260;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalDepositAmount";
            this.dataGridViewTextBoxColumn4.FillWeight = 150F;
            this.dataGridViewTextBoxColumn4.HeaderText = "جمع طلبکار";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 260;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CurrenyName";
            this.dataGridViewTextBoxColumn5.FillWeight = 130F;
            this.dataGridViewTextBoxColumn5.HeaderText = "نوع ارز";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "باقیمانده";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 250;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "وضعیت";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 110;
            // 
            // AgencyStatusFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 625);
            this.Controls.Add(this.gridDrafts);
            this.Controls.Add(this.grdTotals);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "AgencyStatusFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "وضعیت نمایندگی";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDrafts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTotals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnBal;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DataGridView gridDrafts;
        private System.Windows.Forms.DataGridView grdTotals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewButtonColumn Column21;
        private System.Windows.Forms.DataGridViewButtonColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private DevExpress.XtraEditors.SimpleButton btncurrencyexchange;
        private System.Windows.Forms.Label label2;
    }
}