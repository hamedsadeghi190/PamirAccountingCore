
namespace PamirAccounting.Forms.Drafts
{
    partial class RateListFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateListFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rate = new System.Windows.Forms.GroupBox();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rategrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rategrid)).BeginInit();
            this.SuspendLayout();
            // 
            // rate
            // 
            this.rate.Controls.Add(this.btnNew);
            this.rate.Controls.Add(this.textBox1);
            this.rate.Font = new System.Drawing.Font("B Nazanin", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rate.Location = new System.Drawing.Point(3, 12);
            this.rate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rate.Name = "rate";
            this.rate.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rate.Size = new System.Drawing.Size(610, 110);
            this.rate.TabIndex = 0;
            this.rate.TabStop = false;
            this.rate.Text = "جستجو";
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNew.ImageOptions.SvgImage")));
            this.btnNew.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnNew.Location = new System.Drawing.Point(25, 32);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(67, 38);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "جدید";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(294, 42);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 27);
            this.textBox1.TabIndex = 0;
            // 
            // rategrid
            // 
            this.rategrid.AllowUserToAddRows = false;
            this.rategrid.AllowUserToDeleteRows = false;
            this.rategrid.BackgroundColor = System.Drawing.Color.White;
            this.rategrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rategrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rategrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.rategrid.Location = new System.Drawing.Point(3, 128);
            this.rategrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rategrid.Name = "rategrid";
            this.rategrid.RowTemplate.Height = 25;
            this.rategrid.Size = new System.Drawing.Size(610, 336);
            this.rategrid.TabIndex = 1;
            this.rategrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rategrid_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "نام ارز";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "نرخ";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ویرایش";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Text = "ویرایش";
            this.Column4.Width = 70;
            // 
            // RateListFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 465);
            this.Controls.Add(this.rategrid);
            this.Controls.Add(this.rate);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "RateListFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نرخ های معیار";
            this.rate.ResumeLayout(false);
            this.rate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rategrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox rate;
        private System.Windows.Forms.DataGridView rategrid;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}