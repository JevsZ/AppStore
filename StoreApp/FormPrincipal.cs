﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace StoreApp
{
    public partial class FormPrincipal : MetroForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {            
            FormEmpresas empresas = new FormEmpresas();            
            empresas.MdiParent = this;
            empresas.Show();
        }
    }
}
