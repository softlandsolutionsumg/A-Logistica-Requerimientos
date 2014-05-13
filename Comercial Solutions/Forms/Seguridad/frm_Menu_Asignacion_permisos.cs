using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using i3nRiqJSON;


namespace Comercial_Solutions.Forms.Seguridad
{
    public partial class frm_Menu_Asignacion_permisos : Form
    {
        public frm_Menu_Asignacion_permisos()
        {
            InitializeComponent();
            Cargarmodulos();
            lbl_ROL.Visible = false;
            cmb_roles.Visible = false;
            cargarlistausuarios();
        }
       // DBConnect gCon = new DBConnect(Properties.Settings.Default.odbc);
        i3nRiqJson gCon = new i3nRiqJson();
        public void Cargarmodulos() {
            string sql = "SELECT cod_modulos, txmodulos FROM modulos";
            cmb_area.DataSource = gCon.consulta_ComboBox(sql);
            cmb_area.DisplayMember = "txModulos";
           cmb_area.ValueMember = "cod_Modulos";
        
        }

        public void CargarRoles()
        {
            int k = cmb_roles.Items.Count;
            
          
                if (k > 0)
                {
                    cmb_roles.Text=("");
                }
                else
                {
                    
                }


                // string sql = "select txrol,cod_roles from roles where roles.modulos_cod_modulos=(select cod_modulos from where txmodulos='" + cmb_area.SelectedValue + "'";
               
                string sql = "select txrol,cod_roles from roles where roles.modulos_cod_modulos=(select cod_modulos from modulos where txmodulos='Logistica')";
                Console.WriteLine("SQL>>//" + sql);
            cmb_roles.DataSource = gCon.consulta_ComboBox(sql);
            cmb_roles.DisplayMember = "txrol";
            cmb_roles.ValueMember = "cod_roles";
            
           

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try{
            if (txt_nombre.Text.Equals(""))
                
            {
                MessageBox.Show("Ingrese Nombre");
            }
            else
            {
                if (txt_apellido.Text.Equals(""))
                {
                    MessageBox.Show("Ingrese Apellido");
                }
                else
                {
                    int j = 0;int k = 0;
                    string[] vector = txt_apellido.Text.Split(' ');
                    string A = Convert.ToString(txt_nombre.Text[0]);
                    string B = Convert.ToString(txt_apellido.Text[0]);
                    
                    foreach (char c in A){j = Convert.ToInt32(c);}
                    foreach (char c in B){k = Convert.ToInt32(c);}
                    string stcontrasena = (268000000 + ((j + k) * 10000)).ToString("X");
                    string stnombre = txt_nombre.Text + " " + txt_apellido.Text;
                    string stusuario = (A + B + vector[0]).ToLower();
                    


                    txtu.Text = (stusuario);
                    txtc.Text = (stcontrasena);
                    MessageBox.Show("Nombre: \t" + stnombre + "\n" + "Usuario: \t" + stusuario + "\n" + "Contraseña: \t" + stcontrasena,"Usuario creadio");
                    
                     //string querybeta="(select tx_ubicacionpedido from tbm_ubicacionpedido where tbm_ubicacionpedido.id_ubicacionpedido=tbt_historialenvios.tbm_ubicacionpedido_id_ubicacionpedido)AS ubicacion";
                    string query = "select cod_usuario from usuarios where usu_usuario='" + stusuario + "'";
                    
                    System.Collections.ArrayList array = gCon.consultar(query);
            int intamanoarray = array.Count;
            if (intamanoarray > 0) {
                MessageBox.Show("Usuario ya existente: Ingrese segundo nombre y segundo apellido");
                txt_apellido.Text = "";
                txt_nombre.Text = "";
            } else {
                // inserta usuario

                string tabla = "usuarios";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("nom_usuario", stnombre);
                dict.Add("con_usuario", stcontrasena);
                dict.Add("es_usuario", "activo");
                dict.Add("usu_usuario", stusuario);



                string query2 = "select cod_roles from roles where txrol='" + cmb_roles.SelectedValue + "'";
                System.Collections.ArrayList array2 = gCon.consultar(query2);
                int intamanoarray22 = array2.Count;
                
                string gg="";
                foreach (Dictionary<string, string> dict22 in array2)
                {

                    gg="";
                    gg=gg+(dict22["cod_roles"]);
                  


                }
                dict.Add("roles_cod_roles", gg);



                ///
                string query3 = "select MAX(cod_usuario)AS cod from usuarios";
                System.Collections.ArrayList array3 = gCon.consultar(query3);
                int intamanoarray3 = array3.Count;

                string g3 = "";
                foreach (Dictionary<string, string> dict3 in array3)
                {

                    g3 = "";
                    g3 = g3 + (dict3["cod"]);
                    Console.WriteLine("xxxx: "+g3);


                }
                if (g3.Equals("")) { 
                    g3 = ""; g3 = "1";
                } else {

                    
                }
                ///

                string tabla2 = "rol_usuario";
                Dictionary<string, string> dict2 = new Dictionary<string, string>();
                dict2.Add("nom_usuario", stnombre);
                dict2.Add("cod_rol", gg);
                dict2.Add("cod_usuario", g3); 
                
                gCon.insertar("1",tabla, dict);
                gCon.insertar("1",tabla2, dict2);
               

               
            
            }

                }

            }
             }
            catch (Exception ex) { 
        }

        }

        private void cmb_area_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_ROL.Visible = true;
            cmb_roles.Visible = true;
           
        
        CargarRoles();
        }

        public void cargarlistausuarios() {

            try{

            string sql = "SELECT nom_Usuario AS Nombre,usu_Usuario AS Usuario, con_Usuario AS Password,es_Usuario AS Estado FROM usuarios";
            dataGridView1.DataSource = gCon.consulta_DataGridView(sql);
             }
            catch (Exception ex) { }
        

        }

        private void cmb_roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
