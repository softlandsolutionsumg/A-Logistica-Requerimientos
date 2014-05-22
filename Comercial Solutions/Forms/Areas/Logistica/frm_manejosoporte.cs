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
    public partial class frm_manejosoporte : Form
    {
        int X = 0;
        int Y = 0;
        string datos_empleado;
        string datos_incidente;
        public frm_manejosoporte()
        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
        }

        private void frm_manejosoporte_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);



            cargar();
        }

        public void cargar()
        {
            i3nRiqJson x = new i3nRiqJson();
            i3nRiqJson x2 = new i3nRiqJson();
            i3nRiqJson x3 = new i3nRiqJson();

            string query = "SELECT idtbm_empleado,nombre_empleado FROM tbm_empleado";
            comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
            comboBox1.ValueMember = "idtbm_empleado";
            comboBox1.DisplayMember = "nombre_empleado";


            string query3 = "SELECT Idtbm_incidente,nombre FROM incidente";
            comboBox2.DataSource = ((x3.consulta_DataGridView(query3)));
            comboBox2.ValueMember = "Idtbm_incidente";
            comboBox2.DisplayMember = "nombre";

            string query2 = "select nombre,departamento,tipo_soporte,comentario,fecha from soporte";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if ((txtnombre.Text.Equals("")) || (txtdepartamento.Text.Equals("")))
            {

                MessageBox.Show("ALGUNO ESTA VACIO");
            }
            else
            {
                i3nRiqJson x = new i3nRiqJson();
                string tabla = "soporte";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("nombre", txtnombre.Text);
                dict.Add("departamento", txtdepartamento.Text);
                dict.Add("tipo_soporte", txttipoincidente.Text);
                dict.Add("comentario", txtcomentario.Text);
                dict.Add("fecha", dtpfecha.Value.Date.ToString("yyy-MM-dd HH:mm"));


                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbm_empleado from tbm_empleado where nombre_empleado='" + comboBox1.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);
                foreach (Dictionary<string, string> dic in array)
                {
                    datos_empleado = (dic["idtbm_empleado"] + "\n");
                    // Console.WriteLine("VIENEN: "+dic["employee_name"]);
                }
                dict.Add("tbm_empleado_idtbm_empleado", datos_empleado);

             
               







                i3nRiqJson x5 = new i3nRiqJson();
                string query5 = "select idtbm_incidente from incidente where nombre='" + comboBox2.Text + "'";
                System.Collections.ArrayList array5 = x5.consultar(query5);
                foreach (Dictionary<string, string> dic2 in array5)
                {
                    datos_incidente = (dic2["idtbm_incidente"] + "\n");
                    // Console.WriteLine("VIENEN: "+dic["employee_name"]);
                }
                dict.Add("incidente_Idtbm_incidente", datos_incidente);



               
                x.insertar("1", tabla, dict);







                MessageBox.Show("Datos Ingresados Exitosamente",
            "Editar Incidentes",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation
         
         
          );

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargar();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "";
            txtcomentario.Text = "";
            txtdepartamento.Text = "";
            txttipoincidente.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frm_eliminarmanejosoporte x = new frm_eliminarmanejosoporte();
            x.Show();
        }
    }
}
