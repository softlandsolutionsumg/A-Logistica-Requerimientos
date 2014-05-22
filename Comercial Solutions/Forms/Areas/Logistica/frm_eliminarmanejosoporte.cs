using System;
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
    public partial class frm_eliminarmanejosoporte : Form
    {
        int X = 0;
        int Y = 0;
        String ABC;
        public frm_eliminarmanejosoporte()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_soporte,comentario,fecha from soporte where nombre='" + comboBox1.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();


            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select Idtbm_soporte from soporte where nombre='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                ABC = (dic["Idtbm_soporte"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);


            }
            string tabla = "soporte";
            string condicion = "Idtbm_soporte=" + ABC;

            x.eliminar("4", tabla, condicion);
            MessageBox.Show("datos eliminados correctamente");
        }

        private void frm_eliminarmanejosoporte_Load(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + comboBox1.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));


            cargar();   
        }

        public void cargar()  {

            i3nRiqJson x2 = new i3nRiqJson();
            string query = "SELECT Idtbm_soporte,nombre FROM soporte";
            comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
            comboBox1.ValueMember = "Idtbm_soporte";
            comboBox1.DisplayMember = "nombre";

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + comboBox1.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));


            cargar();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
