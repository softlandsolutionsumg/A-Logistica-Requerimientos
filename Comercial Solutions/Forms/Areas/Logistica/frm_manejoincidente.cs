
/***************************************************************
NOMBRE:Formulario Manejo De Incidentes
FECHA:22/05/2014
CREADOR:Eduardo Otoniel Tumax Sulecio
DESCRIPCIÓN:Realiza inserciones de incidentes nuevos.
DETALLE:Contiene enlances para eliminar y editar incidentes.
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
    public partial class frm_manejoincidente : Form

    {
        int X = 0;
        int Y = 0;
        string datos_empleado;
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



            cargarempleados();




           
          
        }
        public void cargarempleados()
            {
            i3nRiqJson x = new i3nRiqJson();
            i3nRiqJson x2 = new i3nRiqJson();


            string query = "SELECT idtbm_empleado,nombre_empleado FROM tbm_empleado";
            cmb_empleado.DataSource = ((x2.consulta_DataGridView(query)));
            cmb_empleado.ValueMember = "idtbm_empleado";
            cmb_empleado.DisplayMember = "nombre_empleado";
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));
            }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        /***************************************************************
        DESCRIPCION:  
         
         ***************************************************************/
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
                dict.Add("fecha", dtpfecha.Value.Date.ToString("yyy-MM-dd HH:mm"));

                i3nRiqJson x4 = new i3nRiqJson();
                string query4 = "select idtbm_empleado from tbm_empleado where nombre_empleado='" + cmb_empleado.Text + "'";
                System.Collections.ArrayList array = x4.consultar(query4);


              
                foreach (Dictionary<string, string> dic in array)
                {
                  datos_empleado=(dic["idtbm_empleado"] + "\n");
                    // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            
                }
                dict.Add("tbm_empleado_idtbm_empleado", datos_empleado);

                


                
                i3nRiqJson x = new i3nRiqJson();
                x.insertar("1", tabla, dict);






                MessageBox.Show("Datos Ingresados Exitosamente",
            "Editar Incidentes",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation
         
         
          );

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frm_editarmanejoincidente x = new frm_editarmanejoincidente();
            x.Show();
            

            

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
            txtnombre.Text = "";
            txtcomentario.Text = "";
            txtdepartamento.Text = "";
            txttipoincidente.Text = "";

                }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarempleados();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtdepartamento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txttipoincidente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtcomentario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
}
}
   
