﻿
namespace PamirAccounting.Forms.Checks
{
    partial class PaymentCheckList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentCheckList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtChequeNumber = new DevExpress.XtraEditors.TextEdit();
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
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(2, 227);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1336, 567);
            this.dataGridView1.TabIndex = 120;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
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
            this.Column1.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ChequeNumber";
            this.Column3.FillWeight = 450F;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "شماره چک";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "IssueDate";
            this.Column2.FillWeight = 130F;
            this.Column2.HeaderText = "صدور";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DueDate";
            this.Column4.FillWeight = 130F;
            this.Column4.HeaderText = "سررسید";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Amount";
            this.GroupName.FillWeight = 130F;
            this.GroupName.HeaderText = "مبلغ";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 130;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "CustomerName";
            this.Column5.HeaderText = "صاحب چک";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DocumentID";
            this.Column6.HeaderText = "سند";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "BankAccountNumber";
            this.Column10.HeaderText = "شماره حساب";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 150;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "RealBankName";
            this.Column9.HeaderText = "بانک";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.HeaderText = "ویرایش";
            this.btnRowEdit.MinimumWidth = 6;
            this.btnRowEdit.Name = "btnRowEdit";
            this.btnRowEdit.ReadOnly = true;
            this.btnRowEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnRowEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnRowEdit.Text = "ویرایش";
            this.btnRowEdit.UseColumnTextForButtonValue = true;
            this.btnRowEdit.Width = 50;
            // 
            // btnRowDelete
            // 
            this.btnRowDelete.HeaderText = "حذف";
            this.btnRowDelete.MinimumWidth = 6;
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.ReadOnly = true;
            this.btnRowDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnRowDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnRowDelete.Text = "حذف";
            this.btnRowDelete.UseColumnTextForButtonValue = true;
            this.btnRowDelete.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(350, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(106, 32);
            this.label1.TabIndex = 114;
            this.label1.Text = "شماره حساب";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(691, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(91, 32);
            this.label4.TabIndex = 110;
            this.label4.Text = "شماره چک";
            // 
            // btnPrint
            // 
            this.btnPrint.AppearanceHovered.Options.UseTextOptions = true;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Location = new System.Drawing.Point(59, 92);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 50);
            this.btnPrint.TabIndex = 118;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(7, 92);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(46, 50);
            this.simpleButton2.TabIndex = 119;
            this.simpleButton2.Text = "راهنما";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.btnPrint);
            this.groupBox4.Controls.Add(this.simpleButton2);
            this.groupBox4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(2, 17);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(1336, 202);
            this.groupBox4.TabIndex = 117;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "لیست چک های پرداختنی";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccountNumber);
            this.groupBox1.Controls.Add(this.txtChequeNumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(453, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(866, 118);
            this.groupBox1.TabIndex = 113;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(125, 50);
            this.txtAccountNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAccountNumber.Properties.Appearance.Options.UseFont = true;
            this.txtAccountNumber.Properties.AutoHeight = false;
            this.txtAccountNumber.Size = new System.Drawing.Size(218, 41);
            this.txtAccountNumber.TabIndex = 117;
            this.txtAccountNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAccountNumber_KeyUp);
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Location = new System.Drawing.Point(462, 47);
            this.txtChequeNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtChequeNumber.Properties.Appearance.Options.UseFont = true;
            this.txtChequeNumber.Properties.AutoHeight = false;
            this.txtChequeNumber.Size = new System.Drawing.Size(218, 41);
            this.txtChequeNumber.TabIndex = 116;
            this.txtChequeNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChequeNumber_KeyUp);
            // 
            // PaymentCheckList
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 776);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "PaymentCheckList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PaymentCheckList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PaymentCheckList_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeNumber.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtAccountNumber;
        private DevExpress.XtraEditors.TextEdit txtChequeNumber;
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