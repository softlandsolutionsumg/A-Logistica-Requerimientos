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
        string ABC;
        public frm_manejoincidente()
        {
            X = Propp.X;
            Y = Propp.Y;

            InitializeComponent();
        }

        private void frm_manejoincidente_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            i3nRiqJson x = new i3nRiqJson();
            i3nRiqJson x2 = new i3nRiqJson();


            string query = "SELECT idtbm_empleado,nombre_empleado FROM tbm_empleado";
            comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
            comboBox1.ValueMember = "idtbm_empleado";
            comboBox1.DisplayMember = "nombre_empleado";
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));



            

           
          
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

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbm_empleado from tbm_empleado where nombre_empleado='" + comboBox1.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);


              
                foreach (Dictionary<string, string> dic in array)
                {
                  ABC=(dic["idtbm_empleado"] + "\n");
                    // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            
                }
                dict.Add("tbm_empleado_idtbm_empleado", ABC);

                


                
                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);

               



                MessageBox.Show("Datos Ingresados Exitosamente " + i3nRiqJson.RespuestaConexion.ToString());
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            

            

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frm_eliminarmanejoincidente x = new frm_eliminarmanejoincidente();
            x.Show();

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query = "select 	idtbm_empleado from tbm_empleado where nombre_empleado='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x.consultar(query);



            foreach(Dictionary<string,string> dic in array){
                textBox1.AppendText(dic["idtbm_empleado"] + "\n");
               // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }

                }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
}
}
   
