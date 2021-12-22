
namespace PamirAccounting.UI.Forms.Agencies
{
    partial class AgencyCreateUpdateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgencyCreateUpdateFrm));
            this.groupControlCreateUpdate = new DevExpress.XtraEditors.GroupControl();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnexitbank = new DevExpress.XtraEditors.SimpleButton();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCreateUpdate)).BeginInit();
            this.groupControlCreateUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlCreateUpdate
            // 
            this.groupControlCreateUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControlCreateUpdate.Appearance.Options.UseFont = true;
            this.groupControlCreateUpdate.AppearanceCaption.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupControlCreateUpdate.AppearanceCaption.Options.UseFont = true;
            this.groupControlCreateUpdate.Controls.Add(this.txtDesc);
            this.groupControlCreateUpdate.Controls.Add(this.label5);
            this.groupControlCreateUpdate.Controls.Add(this.label2);
            this.groupControlCreateUpdate.Controls.Add(this.txtAddress);
            this.groupControlCreateUpdate.Controls.Add(this.cmbCurrencies);
            this.groupControlCreateUpdate.Controls.Add(this.txtPhone);
            this.groupControlCreateUpdate.Controls.Add(this.label4);
            this.groupControlCreateUpdate.Controls.Add(this.label3);
            this.groupControlCreateUpdate.Controls.Add(this.label1);
            this.groupControlCreateUpdate.Controls.Add(this.txtName);
            this.groupControlCreateUpdate.Controls.Add(this.btnexitbank);
            this.groupControlCreateUpdate.Controls.Add(this.btnsavebank);
            this.groupControlCreateUpdate.Location = new System.Drawing.Point(13, 4);
            this.groupControlCreateUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControlCreateUpdate.Name = "groupControlCreateUpdate";
            this.groupControlCreateUpdate.Size = new System.Drawing.Size(866, 307);
            this.groupControlCreateUpdate.TabIndex = 4;
            this.groupControlCreateUpdate.Text = "اطلاعات";
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(67, 57);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(307, 39);
            this.cmbCurrencies.TabIndex = 25;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPhone.Location = new System.Drawing.Point(474, 124);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Properties.AutoHeight = false;
            this.txtPhone.Size = new System.Drawing.Size(265, 38);
            this.txtPhone.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(757, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "تلفن :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(380, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "ارز پایه";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(757, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "نام نمایندگی :";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtName.Location = new System.Drawing.Point(474, 58);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.AutoHeight = false;
            this.txtName.Size = new System.Drawing.Size(265, 38);
            this.txtName.TabIndex = 17;
            // 
            // btnexitbank
            // 
            this.btnexitbank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnexitbank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexitbank.Appearance.Options.UseFont = true;
            this.btnexitbank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnexitbank.ImageOptions.SvgImage")));
            this.btnexitbank.Location = new System.Drawing.Point(142, 262);
            this.btnexitbank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnexitbank.Name = "btnexitbank";
            this.btnexitbank.Size = new System.Drawing.Size(110, 38);
            this.btnexitbank.TabIndex = 16;
            this.btnexitbank.Text = "بازگشت";
            this.btnexitbank.Click += new System.EventHandler(this.btnexitbank_Click);
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.Location = new System.Drawing.Point(24, 262);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.Size = new System.Drawing.Size(110, 38);
            this.btnsavebank.TabIndex = 15;
            this.btnsavebank.Text = "ثبت";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click_1);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtAddress.Location = new System.Drawing.Point(67, 124);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.Properties.Appearance.Options.UseFont = true;
            this.txtAddress.Properties.AutoHeight = false;
            this.txtAddress.Size = new System.Drawing.Size(307, 38);
            this.txtAddress.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(380, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "آدرس :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(757, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "توضیحات :";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDesc.Location = new System.Drawing.Point(67, 198);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDesc.Properties.Appearance.Options.UseFont = true;
            this.txtDesc.Properties.AutoHeight = false;
            this.txtDesc.Size = new System.Drawing.Size(672, 38);
            this.txtDesc.TabIndex = 29;
            // 
            // AgencyCreateUpdateFrm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 325);
            this.Controls.Add(this.groupControlCreateUpdate);
            this.Font = new System.Drawing.Font("B Nazanin", 8F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "AgencyCreateUpdateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش نمایندگی";
            this.Load += new System.EventHandler(this.AgencyCreateUpdateFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCreateUpdate)).EndInit();
            this.groupControlCreateUpdate.ResumeLayout(false);
            this.groupControlCreateUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlCreateUpdate;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.SimpleButton btnexitbank;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
    }
}