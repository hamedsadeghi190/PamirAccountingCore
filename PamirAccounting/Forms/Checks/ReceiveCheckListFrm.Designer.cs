
namespace PamirAccounting.Forms.Checks
{
    partial class ReceiveCheckListFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveCheckListFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtChequeNumber = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRowEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRowDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.GroupName,
            this.Column5,
            this.Column6,
            this.Column10,
            this.Column9,
            this.btnRowEdit,
            this.btnRowDelete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(-1, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(969, 359);
            this.dataGridView1.TabIndex = 120;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnPrint
            // 
            this.btnPrint.AppearanceHovered.Options.UseTextOptions = true;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(6, 37);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(39, 41);
            this.btnPrint.TabIndex = 118;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.btnPrint);
            this.groupBox4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(966, 119);
            this.groupBox4.TabIndex = 115;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "لیست چک های دریافتنی";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccountNumber);
            this.groupBox1.Controls.Add(this.txtChequeNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(159, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 78);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(127, 30);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAccountNumber.Properties.Appearance.Options.UseFont = true;
            this.txtAccountNumber.Properties.AutoHeight = false;
            this.txtAccountNumber.Size = new System.Drawing.Size(187, 32);
            this.txtAccountNumber.TabIndex = 117;
            this.txtAccountNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAccountNumber_KeyUp);
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Location = new System.Drawing.Point(436, 32);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtChequeNumber.Properties.Appearance.Options.UseFont = true;
            this.txtChequeNumber.Properties.AutoHeight = false;
            this.txtChequeNumber.Size = new System.Drawing.Size(187, 32);
            this.txtChequeNumber.TabIndex = 116;
            this.txtChequeNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChequeNumber_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(317, 38);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 114;
            this.label1.Text = "شماره حساب :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(624, 36);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 110;
            this.label4.Text = "شماره چک :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(275, 489);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 133;
            this.label2.Text = "چاپ (F8)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(-6, 488);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 132;
            this.label3.Text = "جستجو (F2) ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(135)))));
            this.label5.Location = new System.Drawing.Point(356, 489);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 131;
            this.label5.Text = "خروج (Esc)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(135)))));
            this.label6.Location = new System.Drawing.Point(173, 489);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 130;
            this.label6.Text = "ویرایش (F7)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(135)))));
            this.label11.Location = new System.Drawing.Point(93, 489);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(74, 19);
            this.label11.TabIndex = 129;
            this.label11.Text = "حذف (F5)";
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RowId";
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
            this.Column3.DataPropertyName = "ChequeNumber";
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "شماره چک";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IssueDatePersian";
            this.Column2.FillWeight = 75F;
            this.Column2.HeaderText = "صدور";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DueDatePersian";
            this.Column4.FillWeight = 75F;
            this.Column4.HeaderText = "سررسید";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 75;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = "1";
            this.GroupName.DefaultCellStyle = dataGridViewCellStyle3;
            this.GroupName.HeaderText = "مبلغ";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CustomerName";
            this.Column5.FillWeight = 110F;
            this.Column5.HeaderText = "صاحب چک";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 110;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DocumentID";
            this.Column6.FillWeight = 75F;
            this.Column6.HeaderText = "سند";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 75;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "BankAccountNumber";
            this.Column10.FillWeight = 130F;
            this.Column10.HeaderText = "شماره حساب";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 130;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "RealBankName";
            this.Column9.HeaderText = "بانک";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.FillWeight = 70F;
            this.btnRowEdit.HeaderText = "ویرایش";
            this.btnRowEdit.MinimumWidth = 6;
            this.btnRowEdit.Name = "btnRowEdit";
            this.btnRowEdit.ReadOnly = true;
            this.btnRowEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnRowEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.btnRowDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnRowDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnRowDelete.Text = "حذف";
            this.btnRowDelete.UseColumnTextForButtonValue = true;
            this.btnRowDelete.Width = 70;
            // 
            // ReceiveCheckListFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ReceiveCheckListFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ReceiveCheckListFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ReceiveCheckListFrm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtAccountNumber;
        private DevExpress.XtraEditors.TextEdit txtChequeNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowDelete;
    }
}