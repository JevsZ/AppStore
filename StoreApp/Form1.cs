using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreApp
{
    public partial class Form1 : Form
    {
        int timeLeft = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //the timer is now going to start            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;

            }
            else
            {
                timer1.Stop();
                FormLogin loginf = new FormLogin();
                loginf.Show();
                //se le otorga como propietario del formulario a Login
                this.Owner = loginf;
                this.Hide();
            }
        }
    }
}
