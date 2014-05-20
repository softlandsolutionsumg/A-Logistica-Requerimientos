﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comercial_Solutions.Clases;
using i3nRiqJSON;

namespace Comercial_Solutions.Forms.Areas.Logistica
{
    public partial class frm_eliminarmanejoincidente : Form
    {
        int X = 0;
        int Y = 0;
        String ABC;
        

         
        public frm_eliminarmanejoincidente()
        {
            X = Propp.X;
            Y = Propp.Y;
            
            InitializeComponent();
        }

        private void frm_eliminarmanejoincidente_Load(object sender, EventArgs e)
        {
            
            i3nRiqJson x2 = new i3nRiqJson();
            string query = "SELECT Idtbm_incidente,nombre FROM incidente";
            comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
            comboBox1.ValueMember = "Idtbm_incidente";
            comboBox1.DisplayMember = "nombre";

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='"+comboBox1.Text+"'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();


            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select Idtbm_incidente from incidente where nombre='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                ABC = (dic["Idtbm_incidente"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);


            }
            string tabla = "incidente";
            string condicion = "Idtbm_incidente=" + ABC;

            x.eliminar("4", tabla, condicion);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + comboBox1.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));


            i3nRiqJson x2 = new i3nRiqJson();
            string query = "SELECT Idtbm_incidente,nombre FROM incidente";
            comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
            comboBox1.ValueMember = "Idtbm_incidente";
            comboBox1.DisplayMember = "nombre";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Dispose();
           


        }
    }
}