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
    public partial class frm_Menu_crear_permiso_rol : Form
    {
       
 //*********************************** Conexion ****************************************************
        i3nRiqJson db = new i3nRiqJson();

        public frm_Menu_crear_permiso_rol()
        {
            InitializeComponent();
        }
//*****************************************************************************************************








 //*********************************** Menu de permisos ************************************************
        private void Menu_Crear_permiso_perfil_Load(object sender, EventArgs e)
        {
           // actualizar_solo();   
            combobox1_modulo();   
       
            //lll
           // combobox2_aplicaciones();
           // combo_rol();
        }
//*******************************************************************************************************
    






//******************************************* comboBox1 de modulos****************************************************
        public void combobox1_modulo() // Primer comboBox para el modulo
        {
            try { 
            string consulta1 = "select cod_modulos, txmodulos from modulos";
            comboBox1.DataSource = db.consulta_ComboBox(consulta1);
            comboBox1.DisplayMember = "txmodulos";
            comboBox1.ValueMember = "cod_modulos";
            }
            catch (Exception e) { }
        }
//*************************************************************************************************************

        public void combo_rol()
          {
              //string consulta1 = "select txrol,cod_roles from roles where modulos_cod_modulos='" + comboBox1.SelectedValue + "'";
              try { 
              string consulta1 = "select txrol,cod_roles from roles where modulos_cod_modulos='" + comboBox1.SelectedValue.ToString() + "'";
              comborol.DataSource = db.consulta_ComboBox(consulta1);
              comborol.DisplayMember = "txrol";
              comborol.ValueMember = "cod_roles";     
             }
            catch (Exception e) { }
          }
        

        public void combobox2_aplicaciones() // Segundo comboBox para las aplicaciones
        {   

        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cb1 = cmbaplicacion.SelectedValue.ToString();

            checkedListBox1.Items.Clear();
          //  MessageBox.Show(cb1);         Esto lab1
            checkedListBox1.Items.Add("Nuevo");
            checkedListBox1.Items.Add("Grabar");
            checkedListBox1.Items.Add("Editar");
            checkedListBox1.Items.Add("Buscar");
            checkedListBox1.Items.Add("Borrar");
            checkedListBox1.Items.Add("Imprimir");
            
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            CARGARAPLICACIONES();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }




//***************************************** finalizar ***************************************************
        private void button3_Click(object sender, EventArgs e)
        {
           try{
            string tabla = "permisos";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("roles_cod_roles", comborol.SelectedValue.ToString()); // cambio de Roles_idRoles a Roles_cod_Roles
            String Consulta = "Select * from permisos where aplicaciones_idaplicaciones = '" + cmbaplicacion.SelectedValue.ToString() + "' and roles_cod_roles ='" + comborol.SelectedValue.ToString() + "'";
            System.Collections.ArrayList otro = db.consultar(Consulta);
            int juank = 0;
            juank = otro.Count;
            //MessageBox.Show(Consulta);
            if (juank != 0)
            {
                MessageBox.Show("Aplicacion ya asignada");
            }
            else
            {
            dict.Add("aplicaciones_idaplicaciones", cmbaplicacion.SelectedValue.ToString());

           if (checkedListBox1.CheckedItems.Count != 0)
            {
                string ficherosSeleccionados = "";
                for (int i = 0; i <= checkedListBox1.CheckedItems.Count - 1; i++)
                {
                    if (ficherosSeleccionados != "")
                        {
                            ficherosSeleccionados = ficherosSeleccionados + Environment.NewLine +
                               checkedListBox1.CheckedItems[i].ToString();
                        }
                    else
                        {
                            ficherosSeleccionados = checkedListBox1.CheckedItems[i].ToString();
                        }
                      

                   switch(checkedListBox1.CheckedItems[i].ToString())
                        {   
                       case "Nuevo":
                            dict.Add("bonuevo", "1");
                        break;

                       case "Grabar":
                            dict.Add("bograbar", "1");
                        break;

                       case "Editar":
                            dict.Add("boeditar", "1");
                        break;

                       case "Buscar":
                            dict.Add("bobuscar", "1");
                        break;

                       case "Borrar":
                            dict.Add("boborrar", "1");
                        break;

                       case "Imprimir":
                            dict.Add("boimprimir", "1");
                        break;

                        }
 
                }
                db.insertar("1",tabla, dict);   
                MessageBox.Show("Datos insertados exitosamente");
                MessageBox.Show(ficherosSeleccionados);        
            } 
        }
             }
            catch (Exception ex) { }
        }
//**********************************************************************************************************



//*********************************************** boton de generar *****************************************

 //****************************************************************************************************************
      
        
        
        
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comborol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void frm_Menu_crear_permiso_rol_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try{
            //MessageBox.Show("COMBOBOX1: "+comboBox1.SelectedValue.ToString());
            CARGARAPLICACIONES();
         }
            catch (Exception ex) { }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
           
        }



        public void CARGARAPLICACIONES() {
            try { 
            combo_rol();
            // string consulta2 = "SELECT idaplicaciones,txaplicacion,	modulos_cod_modulos FROM aplicaciones where modulos_cod_modulos='" + comboBox1.SelectedValue + "'";

            string consulta2 = "SELECT idaplicaciones,txaplicacion,modulos_cod_modulos FROM aplicaciones where modulos_cod_modulos=(" + comboBox1.SelectedValue.ToString() + ")";
            cmbaplicacion.DataSource = db.consulta_ComboBox(consulta2);
            cmbaplicacion.DisplayMember = "txaplicacion";
            cmbaplicacion.ValueMember = "idaplicaciones";
            }
            catch (Exception e) { }
        }
//****************************************************************************************************************
        
    }
}


  
