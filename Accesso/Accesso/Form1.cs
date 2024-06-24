using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accesso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sPass = Encrypt.GetSHA256(txtPassword.Text.Trim());
            using (Models.cursomvcEntities db= new Models.cursomvcEntities())
            {
                // funcion LINQ para el login
                var lst = from d in db.user
                          where d.email == txtUserName.Text
                          && d.password == sPass
                          select d;

                // comparar si existen
                if (lst.Count() >0)
                {
                    // MessageBox.Show("Usuario existe");

                    this.Hide();
                    FrmMain frm = new FrmMain();
                    frm.FormClosed += (s, args) => this.Close();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario NO existe");
                }
            }
        }
    }
}
