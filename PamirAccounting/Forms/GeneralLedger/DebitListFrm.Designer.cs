
namespace PamirAccounting.UI.Forms.GeneralLedger
{
    partial class DebitListFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebitListFrm));
            this.tileBar1 = new DevExpress.XtraBars.Navigation.TileBar();
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbalance = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drcountries = new DevExpress.XtraEditors.DropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tileBar1
            // 
            this.tileBar1.AllowSelectedItem = true;
            this.tileBar1.AppearanceGroupText.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tileBar1.AppearanceGroupText.Options.UseFont = true;
            this.tileBar1.AppearanceText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tileBar1.AppearanceText.Font = new System.Drawing.Font("B Nazanin", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tileBar1.AppearanceText.Options.UseBackColor = true;
            this.tileBar1.AppearanceText.Options.UseFont = true;
            this.tileBar1.AppearanceText.Options.UseTextOptions = true;
            this.tileBar1.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tileBar1.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tileBar1.BackColor = System.Drawing.Color.Lavender;
            this.tileBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar1.Location = new System.Drawing.Point(0, 0);
            this.tileBar1.Name = "tileBar1";
            this.tileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar1.SelectionColor = System.Drawing.Color.Maroon;
            this.tileBar1.Size = new System.Drawing.Size(717, 103);
            this.tileBar1.TabIndex = 0;
            this.tileBar1.Text = "لیست بدهکاران";
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "3c94f6da-ecd7-4f8e-8f25-d64cb7166a5d";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(268, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(198, 57);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "لیست بدهکاران";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnsavebank);
            this.groupBox1.Controls.Add(this.textEdit1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbalance);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dropDownButton1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.drcountries);
            this.groupBox1.Location = new System.Drawing.Point(6, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 297);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.Location = new System.Drawing.Point(16, 215);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.Size = new System.Drawing.Size(105, 55);
            this.btnsavebank.TabIndex = 33;
            this.btnsavebank.Text = "تایید";
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit1.Location = new System.Drawing.Point(16, 83);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Size = new System.Drawing.Size(265, 49);
            this.textEdit1.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(280, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 32);
            this.label4.TabIndex = 31;
            this.label4.Text = " تا تاریخ";
            // 
            // txtbalance
            // 
            this.txtbalance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtbalance.Location = new System.Drawing.Point(357, 83);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtbalance.Properties.Appearance.Options.UseFont = true;
            this.txtbalance.Properties.AutoHeight = false;
            this.txtbalance.Size = new System.Drawing.Size(265, 49);
            this.txtbalance.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(621, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 32);
            this.label3.TabIndex = 29;
            this.label3.Text = "از تاریخ";
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dropDownButton1.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.dropDownButton1.Appearance.Options.UseFont = true;
            this.dropDownButton1.Location = new System.Drawing.Point(357, 27);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(265, 49);
            this.dropDownButton1.TabIndex = 28;
            this.dropDownButton1.Text = "انتخاب کنید...";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(628, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 32);
            this.label1.TabIndex = 27;
            this.label1.Text = "حساب";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(287, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 32);
            this.label2.TabIndex = 26;
            this.label2.Text = "نوع ارز";
            // 
            // drcountries
            // 
            this.drcountries.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drcountries.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F);
            this.drcountries.Appearance.Options.UseFont = true;
            this.drcountries.Location = new System.Drawing.Point(16, 27);
            this.drcountries.Name = "drcountries";
            this.drcountries.Size = new System.Drawing.Size(265, 49);
            this.drcountries.TabIndex = 25;
            this.drcountries.Text = "انتخاب کنید...";
            // 
            // DebitListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tileBar1);
            this.MaximizeBox = false;
            this.Name = "DebitListFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست بدهکاران";
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileBar tileBar1;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtbalance;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DropDownButton drcountries;
    }
}