
namespace PamirAccounting.UI.Forms.Banks
{
    partial class CreateUpdateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateUpdateFrm));
            this.groupControlCreateUpdate = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbalance = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.btnexitbank = new DevExpress.XtraEditors.SimpleButton();
            this.btnsavebank = new DevExpress.XtraEditors.SimpleButton();
            this.cmbCurrencies = new System.Windows.Forms.ComboBox();
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCreateUpdate)).BeginInit();
            this.groupControlCreateUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlCreateUpdate
            // 
            this.groupControlCreateUpdate.Appearance.Options.UseFont = true;
            this.groupControlCreateUpdate.AppearanceCaption.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupControlCreateUpdate.AppearanceCaption.Options.UseFont = true;
            this.groupControlCreateUpdate.Controls.Add(this.cmbCountries);
            this.groupControlCreateUpdate.Controls.Add(this.cmbCurrencies);
            this.groupControlCreateUpdate.Controls.Add(this.label2);
            this.groupControlCreateUpdate.Controls.Add(this.txtbalance);
            this.groupControlCreateUpdate.Controls.Add(this.label4);
            this.groupControlCreateUpdate.Controls.Add(this.label3);
            this.groupControlCreateUpdate.Controls.Add(this.label1);
            this.groupControlCreateUpdate.Controls.Add(this.txtBankName);
            this.groupControlCreateUpdate.Controls.Add(this.btnexitbank);
            this.groupControlCreateUpdate.Controls.Add(this.btnsavebank);
            this.groupControlCreateUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlCreateUpdate.Location = new System.Drawing.Point(0, 0);
            this.groupControlCreateUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControlCreateUpdate.Name = "groupControlCreateUpdate";
            this.groupControlCreateUpdate.Size = new System.Drawing.Size(777, 281);
            this.groupControlCreateUpdate.TabIndex = 3;
            this.groupControlCreateUpdate.Text = "اطلاعات";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(307, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 23);
            this.label2.TabIndex = 24;
            this.label2.Text = "کشور";
            // 
            // txtbalance
            // 
            this.txtbalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtbalance.Location = new System.Drawing.Point(385, 111);
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtbalance.Properties.Appearance.Options.UseFont = true;
            this.txtbalance.Properties.AutoHeight = false;
            this.txtbalance.Size = new System.Drawing.Size(265, 38);
            this.txtbalance.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(668, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "موجودی اولیه";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(304, 118);
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
            this.label1.Location = new System.Drawing.Point(668, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "نام بانک";
            // 
            // txtBankName
            // 
            this.txtBankName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBankName.Location = new System.Drawing.Point(385, 45);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Properties.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBankName.Properties.Appearance.Options.UseFont = true;
            this.txtBankName.Properties.AutoHeight = false;
            this.txtBankName.Size = new System.Drawing.Size(265, 38);
            this.txtBankName.TabIndex = 17;
            // 
            // btnexitbank
            // 
            this.btnexitbank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnexitbank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnexitbank.Appearance.Options.UseFont = true;
            this.btnexitbank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnexitbank.ImageOptions.SvgImage")));
            this.btnexitbank.Location = new System.Drawing.Point(151, 201);
            this.btnexitbank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnexitbank.Name = "btnexitbank";
            this.btnexitbank.Size = new System.Drawing.Size(110, 38);
            this.btnexitbank.TabIndex = 16;
            this.btnexitbank.Text = "بازگشت";
            // 
            // btnsavebank
            // 
            this.btnsavebank.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnsavebank.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.btnsavebank.Appearance.Options.UseFont = true;
            this.btnsavebank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnsavebank.ImageOptions.SvgImage")));
            this.btnsavebank.Location = new System.Drawing.Point(33, 201);
            this.btnsavebank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsavebank.Name = "btnsavebank";
            this.btnsavebank.Size = new System.Drawing.Size(110, 38);
            this.btnsavebank.TabIndex = 15;
            this.btnsavebank.Text = "ثبت";
            this.btnsavebank.Click += new System.EventHandler(this.btnsavebank_Click_1);
            // 
            // cmbCurrencies
            // 
            this.cmbCurrencies.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCurrencies.FormattingEnabled = true;
            this.cmbCurrencies.Location = new System.Drawing.Point(33, 110);
            this.cmbCurrencies.Name = "cmbCurrencies";
            this.cmbCurrencies.Size = new System.Drawing.Size(265, 39);
            this.cmbCurrencies.TabIndex = 25;
            // 
            // cmbCountries
            // 
            this.cmbCountries.Font = new System.Drawing.Font("B Nazanin", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(33, 44);
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(265, 39);
            this.cmbCountries.TabIndex = 26;
            // 
            // CreateUpdateFrm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 286);
            this.Controls.Add(this.groupControlCreateUpdate);
            this.Font = new System.Drawing.Font("B Nazanin", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "CreateUpdateFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت / ویرایش حساب بانکی";
            this.Load += new System.EventHandler(this.CreateUpdateFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCreateUpdate)).EndInit();
            this.groupControlCreateUpdate.ResumeLayout(false);
            this.groupControlCreateUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlCreateUpdate;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtbalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private DevExpress.XtraEditors.SimpleButton btnexitbank;
        private DevExpress.XtraEditors.SimpleButton btnsavebank;
        private System.Windows.Forms.ComboBox cmbCurrencies;
        private System.Windows.Forms.ComboBox cmbCountries;
    }
}