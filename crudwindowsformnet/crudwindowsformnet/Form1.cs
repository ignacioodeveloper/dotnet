﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    PeopleDB oPeople = new PeopleDB();
        //    if (oPeople.Ok())
        //        MessageBox.Show("conectado");
        //    else
        //        MessageBox.Show("no se conecto");
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            PeopleDB oPeopleDB = new PeopleDB();
            dataGridView1.DataSource = oPeopleDB.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNuevo frm = new FrmNuevo();

            frm.ShowDialog();
            Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if(Id != null)
            {
                FrmNuevo frmEdit = new FrmNuevo(Id);
                frmEdit.ShowDialog();
                Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();

            try
            {
                if (Id != null)
                {
                    PeopleDB oPeopleDB = new PeopleDB();
                    oPeopleDB.Delete((int)Id);
                    Refresh();


                }
            }
            catch(Exception ex)
            {
                throw new Exception("Hubo un error al eleminar"+ex.Message);
            }
        }
        #region HELPER
        private int? GetId()
        {
            try
            {
                return int.Parse(
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                );
            }
            catch
            {
                return null;
            }
     
        }
        #endregion




    }
}
