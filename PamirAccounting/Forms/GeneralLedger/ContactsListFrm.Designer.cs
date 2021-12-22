
namespace PamirAccounting.UI.Forms.GeneralLedger
{
    partial class ContactsListFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsListFrm));
            this.gridContacts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBoxContacts = new System.Windows.Forms.GroupBox();
            this.searchbank = new DevExpress.XtraEditors.SearchControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.CreateContactsBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBoxContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchbank.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridContacts
            // 
            this.gridContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContacts.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gridContacts.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gridContacts.Location = new System.Drawing.Point(0, 130);
            this.gridContacts.MainView = this.gridView1;
            this.gridContacts.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gridContacts.Name = "gridContacts";
            this.gridContacts.Size = new System.Drawing.Size(1381, 564);
            this.gridContacts.TabIndex = 6;
            this.gridContacts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.DetailHeight = 647;
            this.gridView1.GridControl = this.gridContacts;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ردیف";
            this.gridColumn1.MinWidth = 33;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 68;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "نام";
            this.gridColumn7.MinWidth = 30;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 175;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "نام خانوادگی";
            this.gridColumn2.MinWidth = 30;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 282;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = " تلفن";
            this.gridColumn3.MinWidth = 33;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 467;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "موبایل";
            this.gridColumn4.MinWidth = 33;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 278;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "عملیات";
            this.gridColumn5.MinWidth = 33;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // groupBoxContacts
            // 
            this.groupBoxContacts.Controls.Add(this.searchbank);
            this.groupBoxContacts.Controls.Add(this.simpleButton1);
            this.groupBoxContacts.Controls.Add(this.CreateContactsBtn);
            this.groupBoxContacts.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxContacts.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBoxContacts.Location = new System.Drawing.Point(0, 0);
            this.groupBoxContacts.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBoxContacts.Name = "groupBoxContacts";
            this.groupBoxContacts.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBoxContacts.Size = new System.Drawing.Size(1381, 130);
            this.groupBoxContacts.TabIndex = 5;
            this.groupBoxContacts.TabStop = false;
            this.groupBoxContacts.Text = "جستجو";
            // 
            // searchbank
            // 
            this.searchbank.Location = new System.Drawing.Point(754, 47);
            this.searchbank.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.searchbank.Name = "searchbank";
            this.searchbank.Properties.AutoHeight = false;
            this.searchbank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchbank.Size = new System.Drawing.Size(562, 48);
            this.searchbank.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(132, 34);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(126, 66);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "چاپ";
            // 
            // CreateContactsBtn
            // 
            this.CreateContactsBtn.Appearance.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CreateContactsBtn.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.CreateContactsBtn.Appearance.Options.UseFont = true;
            this.CreateContactsBtn.Appearance.Options.UseForeColor = true;
            this.CreateContactsBtn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CreateContactsBtn.ImageOptions.SvgImage")));
            this.CreateContactsBtn.Location = new System.Drawing.Point(7, 34);
            this.CreateContactsBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CreateContactsBtn.Name = "CreateContactsBtn";
            this.CreateContactsBtn.Size = new System.Drawing.Size(119, 66);
            this.CreateContactsBtn.TabIndex = 1;
            this.CreateContactsBtn.Text = " جدید";
            this.CreateContactsBtn.Click += new System.EventHandler(this.CreateContactsBtn_Click);
            // 
            // ContactsListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 694);
            this.Controls.Add(this.gridContacts);
            this.Controls.Add(this.groupBoxContacts);
            this.MaximizeBox = false;
            this.Name = "ContactsListFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست مخاطبین";
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBoxContacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchbank.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridContacts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.GroupBox groupBoxContacts;
        private DevExpress.XtraEditors.SearchControl searchbank;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton CreateContactsBtn;
    }
}