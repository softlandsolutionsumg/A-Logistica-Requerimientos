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
    public partial class frm_eliminarempleado : Form
    {
        String datos_empleado;
        public frm_eliminarempleado()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            


            i3nRiqJson x = new i3nRiqJson();


            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select Idtbm_empleado from tbm_empleado  where nombre_empleado='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                datos_empleado = (dic["Idtbm_empleado"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);


            }
            string tabla = "tbm_empleado";
            string condicion = "Idtbm_empleado=" + datos_empleado;

            x.eliminar("4", tabla, condicion);
            MessageBox.Show("datos eliminados correctamente");
        }
        public void cargargrid(){
             i3nRiqJson x = new i3nRiqJson();
             string query2 = "select nombre_empleado,telefono_empleado,direccion_empleado,salario_empleado,Documento_identificacion_empleado from tbm_empleado where nombre_empleado='" + comboBox1.Text + "'";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));
            }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cargargrid();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargargrid();


            cargar();

        }
       public void cargar(){
           i3nRiqJson x2 = new i3nRiqJson();
           string query = "SELECT 	idtbm_empleado,nombre_empleado FROM tbm_empleado";
            comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
            comboBox1.ValueMember = "idtbm_empleado";
            comboBox1.DisplayMember = "nombre_empleado";
       }   

        private void frm_eliminarempleado_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
