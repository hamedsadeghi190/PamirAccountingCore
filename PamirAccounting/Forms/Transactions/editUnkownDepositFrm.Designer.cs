
namespace PamirAccounting.Forms.Transactions
{
    partial class editUnkownDepositFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editUnkownDepositFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRowEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRowDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtReceiptNumber = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.txtdesc = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtradif = new DevExpress.XtraEditors.TextEdit();
            this.txtAmount = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBranchCode = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtradif.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtReceiptNumber);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnsavebank);
            this.groupBox1.Controls.Add(this.txtdesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtBankName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtradif);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBranchCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 552);
            this.groupBox1.TabIndex = 232;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ویرایش واریزی نامعلوم";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.btnRowEdit,
            this.btnRowDelete});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(17, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(488, 150);
            this.dataGridView1.TabIndex = 284;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CustomerId";
            this.Column1.FillWeight = 60F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FullName";
            this.Column2.FillWeight = 130F;
            this.Column2.HeaderText = "مشتری";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Amount";
            this.Column3.HeaderText = "مبلغ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.FillWeight = 70F;
            this.btnRowEdit.HeaderText = "ویرایش";
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
            this.btnRowDelete.Name = "btnRowDelete";
            this.btnRowDelete.ReadOnly = true;
            this.btnRowDelete.Text = "حذف";
            this.btnRowDelete.UseColumnTextForButtonValue = true;
            this.btnRowDelete.Width = 70;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnCancel.Location = new System.Drawing.Point(121, 490);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(98, 38);
            this.btnCancel.TabIndex = 288;
            this.btnCancel.Text = "انصراف";
            // 
            // txtReceiptNumber
            // 
            this.txtReceiptNumber.Enabled = false;
            this.txtReceiptNumber.Location = new System.Drawing.Point(15, 53);
            this.txtReceiptNumber.Name = "txtReceiptNumber";
            this.txtReceiptNumber.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtReceiptNumber.Properties.Appearance.Options.UseFont = true;
            this.txtReceiptNumber.Properties.AutoHeight = false;
            this.txtReceiptNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReceiptNumber.Size = new System.Drawing.Size(149, 38);
            this.txtReceiptNumber.TabIndex = 273;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.simpleButton1.Location = new System.Drawing.Point(15, 490);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.simpleButton1.Size = new System.Drawing.Size(98, 38);
            this.simpleButton1.TabIndex = 287;
            this.simpleButton1.Text = "ذخیره";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(461, 155);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(45, 26);
            this.label1.TabIndex = 275;
            this.label1.Text = "تاریخ ";
            // 
            // btnsavebank
            // 
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnsavebank.Location = new System.Drawing.Point(15, 244);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnsavebank.Size = new System.Drawing.Size(133, 38);
            this.btnsavebank.TabIndex = 286;
            this.btnsavebank.Text = "واریز کننده جدید";
            // 
            // txtdesc
            // 
            this.txtdesc.Enabled = false;
            this.txtdesc.Location = new System.Drawing.Point(15, 197);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtdesc.Properties.Appearance.Options.UseFont = true;
            this.txtdesc.Properties.AutoHeight = false;
            this.txtdesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdesc.Size = new System.Drawing.Size(439, 38);
            this.txtdesc.TabIndex = 274;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(426, 253);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(77, 26);
            this.label4.TabIndex = 285;
            this.label4.Text = "واریز کننده ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(461, 204);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(42, 26);
            this.label2.TabIndex = 276;
            this.label2.Text = "شرح ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(170, 157);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(61, 26);
            this.label3.TabIndex = 283;
            this.label3.Text = "نام بانک ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(305, 148);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDate.Properties.Appearance.Options.UseFont = true;
            this.txtDate.Properties.AutoHeight = false;
            this.txtDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtDate.Properties.MaskSettings.Set("mask", "1999/99/00");
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(149, 38);
            this.txtDate.TabIndex = 270;
            // 
            // txtBankName
            // 
            this.txtBankName.Enabled = false;
            this.txtBankName.Location = new System.Drawing.Point(15, 150);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBankName.Properties.Appearance.Options.UseFont = true;
            this.txtBankName.Properties.AutoHeight = false;
            this.txtBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBankName.Size = new System.Drawing.Size(149, 38);
            this.txtBankName.TabIndex = 282;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(461, 60);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(45, 26);
            this.label6.TabIndex = 277;
            this.label6.Text = "ردیف ";
            // 
            // txtradif
            // 
            this.txtradif.Location = new System.Drawing.Point(305, 53);
            this.txtradif.Name = "txtradif";
            this.txtradif.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtradif.Properties.Appearance.Options.UseFont = true;
            this.txtradif.Properties.AutoHeight = false;
            this.txtradif.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtradif.Properties.MaskSettings.Set("mask", "n0");
            this.txtradif.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtradif.Size = new System.Drawing.Size(149, 38);
            this.txtradif.TabIndex = 281;
            // 
            // txtAmount
            // 
            this.txtAmount.EnterMoveNextControl = true;
            this.txtAmount.Location = new System.Drawing.Point(305, 97);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAmount.Properties.Appearance.Options.UseFont = true;
            this.txtAmount.Properties.AutoHeight = false;
            this.txtAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtAmount.Properties.MaskSettings.Set("mask", "n0");
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(149, 38);
            this.txtAmount.TabIndex = 271;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(170, 60);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(79, 26);
            this.label9.TabIndex = 280;
            this.label9.Text = "شماره فیش ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(461, 106);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(42, 26);
            this.label7.TabIndex = 278;
            this.label7.Text = "مبلغ ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Enabled = false;
            this.txtBranchCode.Location = new System.Drawing.Point(15, 99);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBranchCode.Properties.Appearance.Options.UseFont = true;
            this.txtBranchCode.Properties.AutoHeight = false;
            this.txtBranchCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBranchCode.Size = new System.Drawing.Size(149, 38);
            this.txtBranchCode.TabIndex = 272;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(170, 106);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(63, 26);
            this.label8.TabIndex = 279;
            this.label8.Text = "کد شعبه ";
            // 
            // editUnkownDepositFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 585);
            this.Controls.Add(this.groupBox1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "editUnkownDepositFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.editUnkownDepositFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtradif.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBranchCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtReceiptNumber;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private DevExpress.XtraEditors.TextEdit txtdesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtradif;
        private DevExpress.XtraEditors.TextEdit txtAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtBranchCode;
        private System.Windows.Forms.Label label8;
    }
}