
namespace PamirAccounting.UI.Forms.Groups
{
    partial class GroupCreateUpdateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupCreateUpdateFrm));
            this.exitbtn = new DevExpress.XtraEditors.SimpleButton();
            this.insertbtn = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitbtn
            // 
            this.exitbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitbtn.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitbtn.Appearance.Options.UseFont = true;
            this.exitbtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("exitbtn.ImageOptions.SvgImage")));
            this.exitbtn.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.exitbtn.Location = new System.Drawing.Point(131, 23);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitbtn.Size = new System.Drawing.Size(110, 38);
            this.exitbtn.TabIndex = 11;
            this.exitbtn.Text = "بازگشت";
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // insertbtn
            // 
            this.insertbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.insertbtn.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.insertbtn.Appearance.Options.UseFont = true;
            this.insertbtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("insertbtn.ImageOptions.SvgImage")));
            this.insertbtn.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.insertbtn.Location = new System.Drawing.Point(15, 23);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.insertbtn.Size = new System.Drawing.Size(110, 38);
            this.insertbtn.TabIndex = 10;
            this.insertbtn.Text = "ثبت";
            this.insertbtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 119);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت / ویرایش گروه ها";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Location = new System.Drawing.Point(175, 47);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Size = new System.Drawing.Size(176, 32);
            this.txtName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(354, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "نام گروه :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exitbtn);
            this.groupBox2.Controls.Add(this.insertbtn);
            this.groupBox2.Font = new System.Drawing.Font("IRANSansMobile(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 70);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // GroupCreateUpdateFrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 197);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.IconOptions.ShowIcon = false;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "GroupCreateUpdateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.GroupCreateUpdateFrm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GroupCreateUpdateFrm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton exitbtn;
        private DevExpress.XtraEditors.SimpleButton insertbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}