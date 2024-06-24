using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudwindowsformnet
{
    public partial class FrmNuevo : Form
    {
        private int? Id;
        public FrmNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
                LoadData();
        }

        private void LoadData()
        {
            PeopleDB oPeopleDB = new PeopleDB();
            People oPeople = oPeopleDB.Get((int)Id);
            txtEmail.Text = oPeople.Email;
            txtEdad.Text = oPeople.Edad.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmNuevo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeopleDB oPeopleDB = new PeopleDB();
            try
            {
                if (Id == null)
                    oPeopleDB.Add(txtEmail.Text, int.Parse(txtEdad.Text));
                else
                    oPeopleDB.Update(txtEmail.Text, int.Parse(txtEdad.Text), (int)Id);
                this.Close(); 
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error: "+ex.Message);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
