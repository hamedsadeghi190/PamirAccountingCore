﻿using PamirAccounting.Services;
using System;
using System.Windows.Forms;

namespace PamirAccounting.UI.Forms.Header
{
    public partial class HeaderCreateUpdateFrm : DevExpress.XtraEditors.XtraForm
    {
        private UnitOfWork unitOfWork;
        private Domains.Header header;
        public HeaderCreateUpdateFrm()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

      

        private void HeaderCreateUpdateFrm_Load(object sender, EventArgs e)
        {
            header = unitOfWork.Headers.FindFirstOrDefault();
            if (header != null)
            {
                txtname.Text = header.Name;
                txtphone.Text = header.Phone;
                txtMobile.Text = header.Mobile;
                txtAddress.Text = header.Address;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (header != null)
                {

                    header.Name = txtname.Text;
                    header.Phone = txtphone.Text;
                    header.Mobile = txtMobile.Text;
                    header.Address = txtAddress.Text;
                    unitOfWork.HeaderServices.Update(header);
                }
                else
                {
                    header = new Domains.Header();
                    header.Name = txtname.Text;
                    header.Phone = txtphone.Text;
                    header.Mobile = txtMobile.Text;
                    header.Address = txtAddress.Text;
                    unitOfWork.HeaderServices.Insert(header);
                }
                unitOfWork.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ذخییره تغییرات با شکست مواجه شد");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void HeaderCreateUpdateFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}