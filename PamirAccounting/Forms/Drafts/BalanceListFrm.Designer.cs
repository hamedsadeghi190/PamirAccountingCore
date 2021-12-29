
namespace PamirAccounting.Forms.Drafts
{
    partial class BalanceListFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalanceListFrm));
            this.btnNewBalance = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridDrafts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDrafts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewBalance
            // 
            this.btnNewBalance.Appearance.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewBalance.Appearance.Options.UseFont = true;
            this.btnNewBalance.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNewBalance.ImageOptions.SvgImage")));
            this.btnNewBalance.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnNewBalance.Location = new System.Drawing.Point(17, 35);
            this.btnNewBalance.Name = "btnNewBalance";
            this.btnNewBalance.Size = new System.Drawing.Size(103, 38);
            this.btnNewBalance.TabIndex = 0;
            this.btnNewBalance.Text = "تسویه جدید";
            this.btnNewBalance.Click += new System.EventHandler(this.btnNewBalance_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewBalance);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تسویه حساب نمایندگی مزار";
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
            this.Column22});
            this.gridDrafts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridDrafts.Location = new System.Drawing.Point(-1, 142);
            this.gridDrafts.Name = "gridDrafts";
            this.gridDrafts.ReadOnly = true;
            this.gridDrafts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridDrafts.RowHeadersWidth = 51;
            this.gridDrafts.ShowEditingIcon = false;
            this.gridDrafts.Size = new System.Drawing.Size(1101, 487);
            this.gridDrafts.TabIndex = 27;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "ردیف";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 80;
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
            this.Column2.HeaderText = "شماره رفت";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "شماره آمد";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // a
            // 
            this.a.HeaderText = "بدهکار";
            this.a.MinimumWidth = 6;
            this.a.Name = "a";
            this.a.ReadOnly = true;
            this.a.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "بستانکار";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "نوع ارز";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "وضعیت";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 90;
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
            // BalanceListFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 628);
            this.Controls.Add(this.gridDrafts);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "BalanceListFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تسویه حساب ";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDrafts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnNewBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridDrafts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn Column22;
    }
}