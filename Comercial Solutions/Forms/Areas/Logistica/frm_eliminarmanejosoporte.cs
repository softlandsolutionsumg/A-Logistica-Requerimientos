
/***************************************************************
NOMBRE:Formulario eliminar soporte
FECHA:21/05/2014
CREADOR:Eduardo Otoniel Tumax Sulecio
DESCRIPCIÓN:Elimina registros de soporte.
DETALLE:Busca y elimina registros.
MODIFICACIÓN:22/05/2014
***************************************************************/

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
        i3nRiqJson x = new i3nRiqJson();
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
            
            string query2 = "select nombre,departamento,tipo_soporte,comentario,fecha from soporte where nombre='" + cbm_incidente.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           


            string query4 = "select Idtbm_soporte from soporte where nombre='" + cbm_incidente.Text + "'";
            System.Collections.ArrayList array = x.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                ABC = (dic["Idtbm_soporte"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);


            }
            string tabla = "soporte";
            string condicion = "Idtbm_soporte=" + ABC;

            x.eliminar("4", tabla, condicion);
            MessageBox.Show("datos eliminados correctamente");

          
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + cbm_incidente.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));


            cargar();
        }

        private void frm_eliminarmanejosoporte_Load(object sender, EventArgs e)
        {
           
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + cbm_incidente.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));


            cargar();   
        }

        public void cargar()  {

            
            string query = "SELECT Idtbm_soporte,nombre FROM soporte";
            cbm_incidente.DataSource = ((x.consulta_DataGridView(query)));
            cbm_incidente.ValueMember = "Idtbm_soporte";
            cbm_incidente.DisplayMember = "nombre";

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
           

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
