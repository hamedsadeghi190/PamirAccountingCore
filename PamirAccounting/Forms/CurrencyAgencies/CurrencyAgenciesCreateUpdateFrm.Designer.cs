
namespace PamirAccounting.UI.Forms.CurrencyAgencies
{
    partial class CurrencyAgenciesCreateUpdateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyAgenciesCreateUpdateFrm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnexitAgencyCurrency = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAgencyCurrency = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbroundLimit = new System.Windows.Forms.ComboBox();
            this.cmbExchangeRate = new System.Windows.Forms.ComboBox();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.cmbDescCurenccy = new System.Windows.Forms.ComboBox();
            this.cmbSourceCurreny = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbroundLimit);
            this.groupBox1.Controls.Add(this.cmbExchangeRate);
            this.groupBox1.Controls.Add(this.cmbAction);
            this.groupBox1.Controls.Add(this.cmbDescCurenccy);
            this.groupBox1.Controls.Add(this.cmbSourceCurreny);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(13, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(698, 261);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت / ویرایش عملیات ارزها";
            // 
            // btnexitAgencyCurrency
            // 
            this.btnexitAgencyCurrency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnexitAgencyCurrency.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnexitAgencyCurrency.Appearance.Options.UseFont = true;
            this.btnexitAgencyCurrency.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnexitAgencyCurrency.ImageOptions.SvgImage")));
            this.btnexitAgencyCurrency.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnexitAgencyCurrency.Location = new System.Drawing.Point(122, 32);
            this.btnexitAgencyCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnexitAgencyCurrency.Name = "btnexitAgencyCurrency";
            this.btnexitAgencyCurrency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnexitAgencyCurrency.Size = new System.Drawing.Size(110, 47);
            this.btnexitAgencyCurrency.TabIndex = 129;
            this.btnexitAgencyCurrency.Text = "بازگشت";
            this.btnexitAgencyCurrency.Click += new System.EventHandler(this.btnexitAgencyCurrency_Click);
            // 
            // btnSaveAgencyCurrency
            // 
            this.btnSaveAgencyCurrency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveAgencyCurrency.Appearance.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveAgencyCurrency.Appearance.Options.UseFont = true;
            this.btnSaveAgencyCurrency.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaveAgencyCurrency.ImageOptions.SvgImage")));
            this.btnSaveAgencyCurrency.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSaveAgencyCurrency.Location = new System.Drawing.Point(7, 31);
            this.btnSaveAgencyCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveAgencyCurrency.Name = "btnSaveAgencyCurrency";
            this.btnSaveAgencyCurrency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSaveAgencyCurrency.Size = new System.Drawing.Size(110, 47);
            this.btnSaveAgencyCurrency.TabIndex = 128;
            this.btnSaveAgencyCurrency.Text = "ثبت";
            this.btnSaveAgencyCurrency.Click += new System.EventHandler(this.btnSaveAgencyCurrency_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveAgencyCurrency);
            this.groupBox2.Controls.Add(this.btnexitAgencyCurrency);
            this.groupBox2.Location = new System.Drawing.Point(14, 268);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(698, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cmbroundLimit
            // 
            this.cmbroundLimit.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbroundLimit.FormattingEnabled = true;
            this.cmbroundLimit.Location = new System.Drawing.Point(366, 156);
            this.cmbroundLimit.Margin = new System.Windows.Forms.Padding(4);
            this.cmbroundLimit.Name = "cmbroundLimit";
            this.cmbroundLimit.Size = new System.Drawing.Size(206, 40);
            this.cmbroundLimit.TabIndex = 127;
            // 
            // cmbExchangeRate
            // 
            this.cmbExchangeRate.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbExchangeRate.FormattingEnabled = true;
            this.cmbExchangeRate.Location = new System.Drawing.Point(366, 110);
            this.cmbExchangeRate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbExchangeRate.Name = "cmbExchangeRate";
            this.cmbExchangeRate.Size = new System.Drawing.Size(206, 40);
            this.cmbExchangeRate.TabIndex = 125;
            // 
            // cmbAction
            // 
            this.cmbAction.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Location = new System.Drawing.Point(19, 110);
            this.cmbAction.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(206, 40);
            this.cmbAction.TabIndex = 126;
            // 
            // cmbDescCurenccy
            // 
            this.cmbDescCurenccy.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbDescCurenccy.FormattingEnabled = true;
            this.cmbDescCurenccy.Location = new System.Drawing.Point(366, 64);
            this.cmbDescCurenccy.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDescCurenccy.Name = "cmbDescCurenccy";
            this.cmbDescCurenccy.Size = new System.Drawing.Size(206, 40);
            this.cmbDescCurenccy.TabIndex = 123;
            // 
            // cmbSourceCurreny
            // 
            this.cmbSourceCurreny.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbSourceCurreny.FormattingEnabled = true;
            this.cmbSourceCurreny.Location = new System.Drawing.Point(19, 64);
            this.cmbSourceCurreny.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSourceCurreny.Name = "cmbSourceCurreny";
            this.cmbSourceCurreny.Size = new System.Drawing.Size(206, 40);
            this.cmbSourceCurreny.TabIndex = 124;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(574, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 32);
            this.label7.TabIndex = 130;
            this.label7.Text = "وضعیت نرخ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(574, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 32);
            this.label3.TabIndex = 127;
            this.label3.Text = "نوع ارز مقابل";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(574, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 32);
            this.label4.TabIndex = 131;
            this.label4.Text = "حد رند کردن";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(228, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 32);
            this.label6.TabIndex = 129;
            this.label6.Text = "نوع ارز";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(228, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 32);
            this.label2.TabIndex = 128;
            this.label2.Text = "عملیات";
            // 
            // CurrencyAgenciesCreateUpdateFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 384);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "CurrencyAgenciesCreateUpdateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CurrencyAgenciesCreateUpdateFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CurrencyAgenciesCreateUpdateFrm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnexitAgencyCurrency;
        private DevExpress.XtraEditors.SimpleButton btnSaveAgencyCurrency;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbroundLimit;
        private System.Windows.Forms.ComboBox cmbExchangeRate;
        private System.Windows.Forms.ComboBox cmbAction;
        private System.Windows.Forms.ComboBox cmbDescCurenccy;
        private System.Windows.Forms.ComboBox cmbSourceCurreny;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}