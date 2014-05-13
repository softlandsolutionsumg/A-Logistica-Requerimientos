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
    public partial class frm_manejoincidente : Form

    {
        int X = 0;
        int Y = 0;
        public frm_manejoincidente()
        {
            X = Propp.X;
            Y = Propp.Y;

            InitializeComponent();
        }

        private void frm_manejoincidente_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if ((txtnombre.Text.Equals("")) || (txtdepartamento.Text.Equals("")))
            {

                MessageBox.Show("ALGUNO ESTA VACIO");
            }
            else
            {

                string tabla = "incidente";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("nombre", txtnombre.Text);
                dict.Add("departamento", txtdepartamento.Text);
                dict.Add("tipo_incidente", txttipoincidente.Text);
                dict.Add("comentario", txtcomentario.Text);
                dict.Add("fecha", txtfecha.Text);
                dict.Add("tbm_empleado_idtbm_empleado", "1");

                //
                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);
                MessageBox.Show("Datos Ingresados Exitosamente " + i3nRiqJson.RespuestaConexion.ToString());
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            i3nRiqJson x = new i3nRiqJson();
            string query = "select nombre,departamento from incidente";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query))); 

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();


                       string query = txtnombre.Text;
            System.Collections.ArrayList array = x.consultar(query);

                        foreach (Dictionary<string, string> dic in array)
            {
                textBox1.AppendText(dic["Idtbm_incidente"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            }
            string tabla = "incidente";
            string condicion = "Idtbm_incidente	=" +textBox1.Text;

            x.eliminar("4", tabla, condicion);
        }
    }
}
