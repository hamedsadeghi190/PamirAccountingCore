﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PamirAccounting.Forms.Checks
{
    public partial class OdatCheckSareHesabFrm : DevExpress.XtraEditors.XtraForm
    {
        public OdatCheckSareHesabFrm()
        {
            InitializeComponent();
        }

        private void OdatCheckSareHesabFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}