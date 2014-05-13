using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using i3nRiqJSON;
namespace Comercial_Solutions.Forms.Seguridad
{
    public partial class frm_Menu_aplicacion : Form
    {
        i3nRiqJson db = new i3nRiqJson();
        public frm_Menu_aplicacion()
        {
            InitializeComponent();
            Consulta_tabla_aplicacion();
            Combo_modulo();
        }

        private void Menu_aplicacion_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Combo_modulo()
        {
            string query = "select cod_modulos, txmodulos from modulos";
            comboBox1.DataSource = db.consulta_ComboBox(query);
            comboBox1.DisplayMember = "txmodulos";
            comboBox1.ValueMember = "cod_modulos";
        }

        public void Consulta_tabla_aplicacion()
            {
                //  string consulta = "SELECT T0.idAplicaciones as Codigo,t0.txaplicacion as Aplicacion,t0.fraplicacion as Formulario ,t1.txmodulos as Modulo FROM APLICACIONES t0 INNER JOIN MODULOS T1 ON T0.modulos_cod_modulos=t1.cod_modulos order by T0.idAplicaciones ";
                string sql = "select txaplicacion AS Logico,fraplicacion AS Fisico,(select txmodulos from modulos where modulos.cod_modulos=aplicaciones.modulos_cod_modulos)as Modulo from aplicaciones order by modulos_cod_modulos";
               // string consulta = "SELECT T0.idaplicaciones as Codigo,t0.txaplicacion as aplicacion,t0.fraplicacion as Formulario ,t1.txmodulos as Modulo FROM aplicaciones t0 INNER JOIN modulos T1 ON T0.modulos_cod_modulos=t1.cod_modulos order by T0.idaplicaciones ";
            dataGridView1.DataSource = db.consulta_DataGridView(sql);
            }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese un nombre para la aplicacion");

            } 
            else
                {
                    string query2 = "select * from aplicaciones where txaplicacion='" + textBox1.Text + "'";
                    System.Collections.ArrayList array = db.consultar(query2);
                    int intamanoarray = 0;
                    intamanoarray = array.Count;
                    String nombre_aplicacion = textBox1.Text;
                    String nombre_formulario = textBox2.Text;
                        if (intamanoarray != 0)
                            {
                                MessageBox.Show("La aplicacion ya existe");
                                textBox1.Clear();
                                textBox2.Clear();
                            }
                          else 
                             {
                                    if (nombre_aplicacion == "")
                                        {
                                            MessageBox.Show("Ingrese un nombre para la aplicacion");
                                        } 
                                     else
                                        {
                                            if (nombre_formulario =="")
                                                {
                                                    MessageBox.Show("Ingrese un nombre para el formulario");
                                                }
                                            else
                                            {
                                              string tabla = "aplicaciones";
                                              Dictionary<string, string> dict = new Dictionary<string, string>();
                                              dict.Add("txaplicacion", textBox1.Text);
                                              dict.Add("fraplicacion", textBox2.Text);
                                              dict.Add("modulos_cod_modulos", comboBox1.SelectedValue.ToString());
                                              db.insertar("1",tabla, dict);
                                              MessageBox.Show("aplicacion creada exitosamente");
                                              textBox1.Text="";
                                              textBox2.Text = "";
                                             // Consulta_tabla_aplicacion();
                                            }
                                           }     
                             }
              }
        }
    }
}
