
namespace PamirAccounting.Forms
{
    partial class FrmConfirmExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfirmExit));
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnsavebank
            // 
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnsavebank.Location = new System.Drawing.Point(13, 77);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnsavebank.Size = new System.Drawing.Size(172, 38);
            this.btnsavebank.TabIndex = 9;
            this.btnsavebank.Text = "پشتیبان گیری و خروج";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnClose.Location = new System.Drawing.Point(310, 77);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(110, 38);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "انصراف";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.simpleButton1.Location = new System.Drawing.Point(193, 77);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.simpleButton1.Size = new System.Drawing.Size(110, 38);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "خروج";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // FrmConfirmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 129);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnsavebank);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfirmExit";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "خروج";
            this.Load += new System.EventHandler(this.FrmConfirmExit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label1;
    }
}