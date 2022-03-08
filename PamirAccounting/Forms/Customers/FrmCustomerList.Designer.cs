﻿
namespace PamirAccounting.Forms.Customers
{
    partial class FrmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnprint = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.txtphoneSearch = new System.Windows.Forms.TextBox();
            this.txtNumberSearch = new System.Windows.Forms.TextBox();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.cmbGroupsSearch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreatBankBtn = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRowEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRowDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnprint);
            this.groupBox1.Controls.Add(this.simpleButton3);
            this.groupBox1.Controls.Add(this.txtphoneSearch);
            this.groupBox1.Controls.Add(this.txtNumberSearch);
            this.groupBox1.Controls.Add(this.txtNameSearch);
            this.groupBox1.Controls.Add(this.cmbGroupsSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CreatBankBtn);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1130, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست مشتریان";
            // 
            // btnprint
            // 
            this.btnprint.AppearanceHovered.Options.UseTextOptions = true;
            this.btnprint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnprint.ImageOptions.SvgImage")));
            this.btnprint.Location = new System.Drawing.Point(52, 29);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(39, 41);
            this.btnprint.TabIndex = 96;
            this.btnprint.Text = "چاپ";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton3.ImageOptions.SvgImage")));
            this.simpleButton3.Location = new System.Drawing.Point(7, 29);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(39, 41);
            this.simpleButton3.TabIndex = 97;
            this.simpleButton3.Text = "راهنما";
            // 
            // txtphoneSearch
            // 
            this.txtphoneSearch.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtphoneSearch.Location = new System.Drawing.Point(265, 37);
            this.txtphoneSearch.Name = "txtphoneSearch";
            this.txtphoneSearch.Size = new System.Drawing.Size(143, 30);
            this.txtphoneSearch.TabIndex = 94;
            this.txtphoneSearch.TextChanged += new System.EventHandler(this.txtphoneSearch_TextChanged);
            this.txtphoneSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtphoneSearch_KeyUp);
            // 
            // txtNumberSearch
            // 
            this.txtNumberSearch.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNumberSearch.Location = new System.Drawing.Point(493, 37);
            this.txtNumberSearch.Name = "txtNumberSearch";
            this.txtNumberSearch.Size = new System.Drawing.Size(143, 30);
            this.txtNumberSearch.TabIndex = 93;
            this.txtNumberSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumberSearch_KeyUp);
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtNameSearch.Location = new System.Drawing.Point(939, 39);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.Size = new System.Drawing.Size(143, 30);
            this.txtNameSearch.TabIndex = 91;
            this.txtNameSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNameSearch_KeyUp);
            // 
            // cmbGroupsSearch
            // 
            this.cmbGroupsSearch.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbGroupsSearch.FormattingEnabled = true;
            this.cmbGroupsSearch.Location = new System.Drawing.Point(720, 37);
            this.cmbGroupsSearch.Name = "cmbGroupsSearch";
            this.cmbGroupsSearch.Size = new System.Drawing.Size(143, 32);
            this.cmbGroupsSearch.TabIndex = 92;
            this.cmbGroupsSearch.TextChanged += new System.EventHandler(this.cmbGroupsSearch_TextChanged);
            this.cmbGroupsSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbGroupsSearch_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(862, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 19);
            this.label5.TabIndex = 88;
            this.label5.Text = "گروه :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(406, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 57;
            this.label4.Text = "تلفن :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(635, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 55;
            this.label2.Text = "شماره :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1251, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "نام";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1080, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 19);
            this.label3.TabIndex = 52;
            this.label3.Text = "نام :";
            // 
            // CreatBankBtn
            // 
            this.CreatBankBtn.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CreatBankBtn.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.CreatBankBtn.Appearance.Options.UseFont = true;
            this.CreatBankBtn.Appearance.Options.UseForeColor = true;
            this.CreatBankBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CreatBankBtn.ImageOptions.SvgImage")));
            this.CreatBankBtn.Location = new System.Drawing.Point(96, 29);
            this.CreatBankBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CreatBankBtn.Name = "CreatBankBtn";
            this.CreatBankBtn.Size = new System.Drawing.Size(39, 41);
            this.CreatBankBtn.TabIndex = 95;
            this.CreatBankBtn.Click += new System.EventHandler(this.CreatBankBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.GroupName,
            this.btnRowEdit,
            this.btnRowDelete,
            this.btnView});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1134, 459);
            this.dataGridView1.TabIndex = 98;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 75F;
            this.Column1.HeaderText = "شماره";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 75;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FullName";
            this.Column3.FillWeight = 340F;
            this.Column3.HeaderText = "نام";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 340;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Phone";
            this.Column2.FillWeight = 130F;
            this.Column2.HeaderText = "تلفن";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Mobile";
            this.Column4.FillWeight = 130F;
            this.Column4.HeaderText = "موبایل";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 130;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.FillWeight = 150F;
            this.GroupName.HeaderText = "گروه";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Width = 150;
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
            // btnView
            // 
            this.btnView.FillWeight = 70F;
            this.btnView.HeaderText = "نمایش";
            this.btnView.MinimumWidth = 6;
            this.btnView.Name = "btnView";
            this.btnView.ReadOnly = true;
            this.btnView.Text = "نمایش";
            this.btnView.UseColumnTextForButtonValue = true;
            this.btnView.Width = 70;
            // 
            // FrmCustomerList
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 560);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmCustomerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmCustomerList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCustomerList_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton CreatBankBtn;
        private System.Windows.Forms.ComboBox cmbGroupsSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtNameSearch;
        private System.Windows.Forms.TextBox txtphoneSearch;
        private System.Windows.Forms.TextBox txtNumberSearch;
        private DevExpress.XtraEditors.SimpleButton btnprint;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowDelete;
        private System.Windows.Forms.DataGridViewButtonColumn btnView;
    }
}