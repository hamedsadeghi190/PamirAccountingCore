
namespace PamirAccounting.UI.Forms.Currencies
{
    partial class CurrencyCreateUpdateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyCreateUpdateFrm));
            this.groupControlCreateUpdate = new DevExpress.XtraEditors.GroupControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.exitbtn = new DevExpress.XtraEditors.SimpleButton();
            this.insertbtn = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCreateUpdate)).BeginInit();
            this.groupControlCreateUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlCreateUpdate
            // 
            this.groupControlCreateUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControlCreateUpdate.Appearance.Options.UseFont = true;
            this.groupControlCreateUpdate.AppearanceCaption.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupControlCreateUpdate.AppearanceCaption.Options.UseFont = true;
            this.groupControlCreateUpdate.Controls.Add(this.txtName);
            this.groupControlCreateUpdate.Controls.Add(this.exitbtn);
            this.groupControlCreateUpdate.Controls.Add(this.insertbtn);
            this.groupControlCreateUpdate.Controls.Add(this.label1);
            this.groupControlCreateUpdate.Location = new System.Drawing.Point(4, 1);
            this.groupControlCreateUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupControlCreateUpdate.Name = "groupControlCreateUpdate";
            this.groupControlCreateUpdate.Size = new System.Drawing.Size(433, 161);
            this.groupControlCreateUpdate.TabIndex = 6;
            this.groupControlCreateUpdate.Text = "اطلاعات";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Location = new System.Drawing.Point(9, 51);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Size = new System.Drawing.Size(329, 38);
            this.txtName.TabIndex = 7;
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitbtn.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.exitbtn.Appearance.Options.UseFont = true;
            this.exitbtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("exitbtn.ImageOptions.SvgImage")));
            this.exitbtn.Location = new System.Drawing.Point(127, 116);
            this.exitbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(110, 38);
            this.exitbtn.TabIndex = 10;
            this.exitbtn.Text = "بازگشت";
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // insertbtn
            // 
            this.insertbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.insertbtn.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.insertbtn.Appearance.Options.UseFont = true;
            this.insertbtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("insertbtn.ImageOptions.SvgImage")));
            this.insertbtn.Location = new System.Drawing.Point(9, 116);
            this.insertbtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.Size = new System.Drawing.Size(110, 38);
            this.insertbtn.TabIndex = 9;
            this.insertbtn.Text = "ثبت";
            this.insertbtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(344, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام ارز :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrencyCreateUpdateFrm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 171);
            this.Controls.Add(this.groupControlCreateUpdate);
            this.Font = new System.Drawing.Font("B Nazanin", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrencyCreateUpdateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت/ویرایش ارز";
            this.Load += new System.EventHandler(this.CurrencyCreateUpdateFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCreateUpdate)).EndInit();
            this.groupControlCreateUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlCreateUpdate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.SimpleButton exitbtn;
        private DevExpress.XtraEditors.SimpleButton insertbtn;
    }
}