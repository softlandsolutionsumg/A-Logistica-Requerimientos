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
    public partial class frm_empleado : Form
    {
        int X = 0;
        int Y = 0;
        public frm_empleado()
        {
            X = Propp.X;
            Y = Propp.Y;

            InitializeComponent();
        }

        private void frm_empleado_Load(object sender, EventArgs e)
        {

            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
            cargar();  
        }
        public void cargar()
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "SELECT `nombre_empleado`,`Telefono_Empleado`,`Direccion_Empleado`,`Salario_Empleado`,`Documento_identificacion_empleado` FROM `tbm_empleado` ";
            dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if ((txtnombre.Text.Equals("")) || (txttelefono.Text.Equals("")))
            {

                MessageBox.Show("ALGUNO ESTA VACIO");
            }
            else
            {

                string tabla = "tbm_empleado";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("nombre_empleado", txtnombre.Text);
                dict.Add("telefono_empleado", txttelefono.Text);
                dict.Add("direccion_empleado", txtdireccion.Text);
                dict.Add("salario_empleado", txtsalario.Text);
                dict.Add("Documento_identificacion_empleado", txtdi.Text);

                


                i3nRiqJson x = new i3nRiqJson();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frm_eliminarempleado x = new frm_eliminarempleado();
            x.Show();
        }
    }
}
