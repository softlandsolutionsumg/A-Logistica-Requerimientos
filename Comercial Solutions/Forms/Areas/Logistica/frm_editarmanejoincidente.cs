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
    public partial class frm_editarmanejoincidente : Form
    {
        String datos_empleado;
        String datos_incidente;
        String datos_empleado2;
        String datos_empleado3;
       

        public frm_editarmanejoincidente()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i3nRiqJson x = new i3nRiqJson();
            string query2 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + comboBox1.Text + "'";
            //dataGridView1.DataSource = ((x.consulta_DataGridView(query2)));
        }

        private void frm_editarmanejoincidente_Load(object sender, EventArgs e)
        {
            actualizar();


        }
        public void actualizar()
             {
                 i3nRiqJson x2 = new i3nRiqJson();
                 string query = "SELECT Idtbm_incidente,nombre FROM incidente";
                 comboBox1.DataSource = ((x2.consulta_DataGridView(query)));
                 comboBox1.ValueMember = "Idtbm_incidente";
                 comboBox1.DisplayMember = "nombre";

                 i3nRiqJson x1 = new i3nRiqJson();
                 string query2 = "SELECT idtbm_empleado,nombre_empleado FROM tbm_empleado";
                 comboBox2.DataSource = ((x1.consulta_DataGridView(query2)));
                 comboBox2.ValueMember = "idtbm_empleado";
                 comboBox2.DisplayMember = "nombre_empleado";


             }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            actualizar();
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select Idtbm_incidente from incidente where nombre='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                datos_incidente = (dic["Idtbm_incidente"] + "\n");
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }

            i3nRiqJson x = new i3nRiqJson();
            string tabla = "incidente";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            Dictionary<string, string> dict3 = new Dictionary<string, string>();
             Dictionary<string, string> dict4 = new Dictionary<string, string>();
            dict.Add("nombre", txtnombre.Text);
            dict1.Add("departamento", txtdepartamento.Text);
            //dict2.Add("departamento", comboBox2.Text);
            dict2.Add("tipo_incidente", txttipoincidente.Text);
            dict3.Add("comentario", txtcomentario.Text);
           dict4.Add("fecha", dtpfecha.Value.Date.ToString("yyy-MM-dd HH:mm"));
            string condicion = "Idtbm_incidente= '" + datos_incidente +"'";
            x.actualizar("3", tabla, dict, condicion);
            x.actualizar("3", tabla, dict1, condicion);
            x.actualizar("3", tabla, dict2, condicion);
            x.actualizar("3", tabla, dict3, condicion);

              i3nRiqJson x5 = new i3nRiqJson();
                string query5 = "select idtbm_empleado from tbm_empleado where nombre_empleado='" + comboBox2.Text + "'";
                System.Collections.ArrayList array2 = x4.consultar(query5);


              
                foreach (Dictionary<string, string> dic in array2)
                {
                  datos_empleado=(dic["idtbm_empleado"] + "\n");
                    // Console.WriteLine("VIENEN: "+dic["employee_name"]);
            
                }
                Dictionary<string, string> dict5 = new Dictionary<string, string>();
                dict5.Add("tbm_empleado_idtbm_empleado", datos_empleado);
              x.actualizar("3", tabla, dict5, condicion);

              MessageBox.Show("Datos Actualizados Exitosamente",
          "Editar Incidentes",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1,
          MessageBoxOptions.RightAlign,
          true);


        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i3nRiqJson x4 = new i3nRiqJson();
            string query4 = "select nombre,departamento,tipo_incidente,comentario,fecha from incidente where nombre='" + comboBox1.Text + "'";
            System.Collections.ArrayList array = x4.consultar(query4);



            foreach (Dictionary<string, string> dic in array)
            {
                txtnombre.Text = (dic["nombre"]);
                txtdepartamento.Text = (dic["departamento"]);
                txttipoincidente.Text = (dic["tipo_incidente"]);
                //comboBox2.Text = (dic["Salario_Empleado"]);
                txtcomentario.Text = (dic["comentario"]);
                dtpfecha.Text = (dic["fecha"]);
               
                // Console.WriteLine("VIENEN: "+dic["employee_name"]);

            }

           


           

          

           
        }
    }
}
