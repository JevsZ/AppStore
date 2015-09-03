using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StoreApp.ConexionClass;
using DevComponents.DotNetBar.Metro;

namespace StoreApp
{
    public partial class FormLogin : MetroForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnClass oConexion = new ConnClass();
            string usuario = this.txtUsername.Text.Trim();
            string contra = this.txtPassword.Text.Trim();
            string comando = "SELECT Count(*) FROM usuarios where UsuarioName = '" + usuario + "' and Password = '" + contra + "'";
            if (oConexion.Count(comando) == 1)
            {
                FormPrincipal principal = new FormPrincipal();
                principal.Show();
                //se le otorga como propietario del formulario a Login
                this.Owner = principal;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Password no coinciden");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
