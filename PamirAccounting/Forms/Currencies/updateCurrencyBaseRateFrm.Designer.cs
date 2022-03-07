
namespace PamirAccounting.Forms.Currencies
{
    partial class updateCurrencyBaseRateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updateCurrencyBaseRateFrm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRowEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblRate = new System.Windows.Forms.Label();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblCurrenyName = new System.Windows.Forms.Label();
            this.lblArz = new System.Windows.Forms.Label();
            this.exitbtn = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.btnRowEdit});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(5, 60);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(520, 337);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "ردیف";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "نام ارز";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BaseRate";
            this.Column3.HeaderText = "نرخ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.FillWeight = 60F;
            this.btnRowEdit.HeaderText = "ویرایش";
            this.btnRowEdit.MinimumWidth = 6;
            this.btnRowEdit.Name = "btnRowEdit";
            this.btnRowEdit.ReadOnly = true;
            this.btnRowEdit.Text = "ویرایش";
            this.btnRowEdit.UseColumnTextForButtonValue = true;
            this.btnRowEdit.Width = 80;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRate.Location = new System.Drawing.Point(471, 461);
            this.lblRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRate.Name = "lblRate";
            this.lblRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRate.Size = new System.Drawing.Size(46, 23);
            this.lblRate.TabIndex = 222;
            this.lblRate.Text = "نرخ :";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRate.Visible = false;
            // 
            // txtRate
            // 
            this.txtRate.EnterMoveNextControl = true;
            this.txtRate.Location = new System.Drawing.Point(294, 452);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.AutoHeight = false;
            this.txtRate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtRate.Properties.MaskSettings.Set("mask", "f");
            this.txtRate.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(174, 36);
            this.txtRate.TabIndex = 221;
            this.txtRate.Visible = false;
            // 
            // cmbAction
            // 
            this.cmbAction.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(30, 451);
            this.cmbAction.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(173, 37);
            this.cmbAction.TabIndex = 223;
            this.cmbAction.Visible = false;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbVarizType_SelectedIndexChanged);
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAction.Location = new System.Drawing.Point(207, 461);
            this.lblAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAction.Size = new System.Drawing.Size(71, 23);
            this.lblAction.TabIndex = 224;
            this.lblAction.Text = "عملیات :";
            this.lblAction.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(21, 24);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(110, 38);
            this.btnSave.TabIndex = 225;
            this.btnSave.Text = "ثبت";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCurrenyName
            // 
            this.lblCurrenyName.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrenyName.Location = new System.Drawing.Point(309, 400);
            this.lblCurrenyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrenyName.Name = "lblCurrenyName";
            this.lblCurrenyName.Size = new System.Drawing.Size(174, 34);
            this.lblCurrenyName.TabIndex = 226;
            this.lblCurrenyName.Text = "دلار";
            this.lblCurrenyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrenyName.Visible = false;
            // 
            // lblArz
            // 
            this.lblArz.AutoSize = true;
            this.lblArz.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblArz.Location = new System.Drawing.Point(482, 404);
            this.lblArz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArz.Name = "lblArz";
            this.lblArz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblArz.Size = new System.Drawing.Size(41, 23);
            this.lblArz.TabIndex = 227;
            this.lblArz.Text = " ارز :";
            this.lblArz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArz.Visible = false;
            // 
            // exitbtn
            // 
            this.exitbtn.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitbtn.Appearance.Options.UseFont = true;
            this.exitbtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("exitbtn.ImageOptions.SvgImage")));
            this.exitbtn.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.exitbtn.Location = new System.Drawing.Point(140, 24);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitbtn.Size = new System.Drawing.Size(110, 38);
            this.exitbtn.TabIndex = 228;
            this.exitbtn.Text = "بازگشت";
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exitbtn);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(2, 531);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 71);
            this.groupBox1.TabIndex = 229;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.lblCurrenyName);
            this.groupBox2.Controls.Add(this.lblArz);
            this.groupBox2.Controls.Add(this.txtRate);
            this.groupBox2.Controls.Add(this.lblRate);
            this.groupBox2.Controls.Add(this.cmbAction);
            this.groupBox2.Controls.Add(this.lblAction);
            this.groupBox2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(2, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 513);
            this.groupBox2.TabIndex = 230;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ثبت / ویرایش نرخ معیار";
            // 
            // updateCurrencyBaseRateFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 616);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "updateCurrencyBaseRateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.updateCurrencyBaseRateFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.updateCurrencyBaseRateFrm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblRate;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label lblAction;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblCurrenyName;
        private System.Windows.Forms.Label lblArz;
        private DevExpress.XtraEditors.SimpleButton exitbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowEdit;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}