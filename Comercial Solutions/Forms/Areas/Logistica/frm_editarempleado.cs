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
   
    public partial class frm_editarempleado : Form
    {
        String datos_empleado;
        public frm_editarempleado()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select idtbm_empleado from tbm_empleado where nombre_empleado='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                datos_empleado = (dic["idtbm_empleado"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }

            i3nRiqJson x = new i3nRiqJson();
            string tabla = "tbm_empleado";
            Dictionary<string, string> dict = new Dictionary<string, string>();
           dict.Add("nombre_empleado", txtnombre.Text);
            dict.Add("Telefono_Empleado", txttelefono.Text);
            //dict2.Add("departamento", comboBox2.Text);
            dict.Add("Direccion_Empleado", txtdireccion.Text);
            dict.Add("Salario_Empleado", txtsalario.Text);
            dict.Add("Documento_identificacion_empleado", txtdi.Text);
            string condicion = "idtbm_empleado= " + datos_empleado;
            x.actualizar("3", tabla, dict, condicion);
           


            MessageBox.Show("Datos Actualizados Exitosamente",
        "Editar Empleados",
        MessageBoxButtons.OK);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select nombre_empleado,Telefono_Empleado,Direccion_Empleado,Salario_Empleado,Documento_identificacion_empleado from tbm_empleado where nombre_empleado='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                txtnombre.Text = (dic["nombre_empleado"] );
                txttelefono.Text = (dic["Telefono_Empleado"]);
                txtdireccion.Text = (dic["Direccion_Empleado"]);
                txtsalario.Text = (dic["Salario_Empleado"]);
                txtdi.Text = (dic["Documento_identificacion_empleado"]);
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }
        }
        public void cargarempleado(){
            i3nRiqJson x2 = new i3nRiqJson();
            string query = "select idtbm_empleado,nombre_empleado from tbm_empleado";
                 comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
                 comboBox1.ValueMember = "idtbm_empleado";
                 comboBox1.DisplayMember = "nombre_empleado";
        }
        private void frm_editarempleado_Load(object sender, EventArgs e)
        {
            cargarempleado(); 

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargarempleado();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
