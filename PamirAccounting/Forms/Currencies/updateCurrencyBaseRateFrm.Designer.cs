
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.btnRowEdit});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(473, 274);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "ردیف";
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
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BaseRate";
            this.Column3.HeaderText = "نرخ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnRowEdit
            // 
            this.btnRowEdit.FillWeight = 60F;
            this.btnRowEdit.HeaderText = "ویرایش";
            this.btnRowEdit.Name = "btnRowEdit";
            this.btnRowEdit.ReadOnly = true;
            this.btnRowEdit.Text = "ویرایش";
            this.btnRowEdit.UseColumnTextForButtonValue = true;
            this.btnRowEdit.Width = 60;
            // 
            // lblRate
            // 
            this.lblRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRate.Location = new System.Drawing.Point(432, 326);
            this.lblRate.Name = "lblRate";
            this.lblRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRate.Size = new System.Drawing.Size(34, 23);
            this.lblRate.TabIndex = 222;
            this.lblRate.Text = "نرخ :";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRate.Visible = false;
            // 
            // txtRate
            // 
            this.txtRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtRate.EnterMoveNextControl = true;
            this.txtRate.Location = new System.Drawing.Point(255, 317);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.AutoHeight = false;
            this.txtRate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtRate.Properties.MaskSettings.Set("mask", "f");
            this.txtRate.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(149, 38);
            this.txtRate.TabIndex = 221;
            this.txtRate.Visible = false;
            // 
            // cmbAction
            // 
            this.cmbAction.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(26, 316);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(149, 39);
            this.cmbAction.TabIndex = 223;
            this.cmbAction.Visible = false;
            this.cmbAction.SelectedIndexChanged += new System.EventHandler(this.cmbVarizType_SelectedIndexChanged);
            // 
            // lblAction
            // 
            this.lblAction.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAction.Location = new System.Drawing.Point(181, 326);
            this.lblAction.Name = "lblAction";
            this.lblAction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAction.Size = new System.Drawing.Size(52, 23);
            this.lblAction.TabIndex = 224;
            this.lblAction.Text = "عملیات :";
            this.lblAction.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(26, 382);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(112, 38);
            this.btnSave.TabIndex = 225;
            this.btnSave.Text = "ثبت";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCurrenyName
            // 
            this.lblCurrenyName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrenyName.Location = new System.Drawing.Point(255, 286);
            this.lblCurrenyName.Name = "lblCurrenyName";
            this.lblCurrenyName.Size = new System.Drawing.Size(149, 28);
            this.lblCurrenyName.TabIndex = 226;
            this.lblCurrenyName.Text = "دلار";
            this.lblCurrenyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrenyName.Visible = false;
            // 
            // lblArz
            // 
            this.lblArz.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblArz.AutoSize = true;
            this.lblArz.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblArz.Location = new System.Drawing.Point(432, 288);
            this.lblArz.Name = "lblArz";
            this.lblArz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblArz.Size = new System.Drawing.Size(26, 23);
            this.lblArz.TabIndex = 227;
            this.lblArz.Text = "ارز:";
            this.lblArz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArz.Visible = false;
            // 
            // updateCurrencyBaseRateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 461);
            this.Controls.Add(this.lblArz);
            this.Controls.Add(this.lblCurrenyName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "updateCurrencyBaseRateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت نرخ معیار";
            this.Load += new System.EventHandler(this.updateCurrencyBaseRateFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn btnRowEdit;
        private System.Windows.Forms.Label lblRate;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.Label lblAction;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblCurrenyName;
        private System.Windows.Forms.Label lblArz;
    }
}