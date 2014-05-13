using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using i3nRiqJSON;
using Comercial_Solutions.Clases;
using Comercial_Solutions.Forms.Principal;
using Comercial_Solutions.Forms.Areas.Logistica;
using Comercial_Solutions.Forms.Seguridad;


namespace Comercial_Solutions.Forms.Principal
{
    public partial class frm_mdi : Form
    {
        int X = 0;
        int Y = 0;
        string usuariolog = "";
        public delegate void P(object sender, EventArgs e);
        Dictionary<string, Form> Ins = new Dictionary<string, Form>();

        i3nRiqJson dataJson = new i3nRiqJson();

        
        
        public frm_mdi(string stus)
        {
            InitializeComponent();
            usuariolog = "";
            usuariolog +=stus;
            CargarMenu();
            tmrDimension.Start();
            ToolTIPmenu();
        }


        public void ToolTIPmenu() {
            toolTip.SetToolTip(this.pictureBox1, "Inicio");
        
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void tmrDimension_Tick(object sender, EventArgs e)
        {
            string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            webBrowser1.Url = new Uri(Path.Combine(appDir, @"HTML\inicio.html"));
            webload.Url = new Uri(Path.Combine(appDir, @"load\load.html")); 

           Properties.Settings.Default.heighty = (this.ClientSize.Height)-186;
            Properties.Settings.Default.widthx = (this.ClientSize.Width)-250;
            Properties.Settings.Default.Save();

            Y=(Properties.Settings.Default.heighty);
            X=(Properties.Settings.Default.widthx);
            Propp.Y = Y;
            Propp.X = X;
            webBrowser1.Size = new Size(X - 75, Y);
            webBrowser1.Location = new Point(250, 56);
            webload.Size = new Size(X - 75, Y);
            webload.Location = new Point(250, 56);

            
         
            tmrDimension.Stop();
            webBrowser1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            webBrowser1.Visible = true;
            LIBERARAM();   
        }


        public void LLAMARVOID()
        {
            webload.Visible = true;
            tmrLoad.Start();

        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            webload.Visible = false;
            tmrLoad.Stop();
            LIBERARAM();

        }


        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void alzheimer()
        {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }

        
        public void LIBERARAM() {

        GC.Collect();
        GC.WaitForPendingFinalizers();
        SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);// - See more at: http://www.nerdcoder.com/c-net-forzar-liberacion-de-memoria-de-nuestras-aplicaciones/#sthash.zIKApAfR.dpuf
        
        }



        public void CargarMenu()
        {
            int i = 0;
            lstMODULOS.Items.Clear();
            try
            {
       
                string query = "select roles_cod_roles,(select txaplicacion from aplicaciones where aplicaciones.idaplicaciones=permisos.aplicaciones_idaplicaciones) as txaplicacion, (select fraplicacion from aplicaciones where aplicaciones.idaplicaciones=permisos.aplicaciones_idaplicaciones) as fraplicacion, (select txmodulos from modulos where modulos.cod_modulos = (select modulos_cod_modulos from aplicaciones where aplicaciones.idaplicaciones=permisos.aplicaciones_idaplicaciones)) as txmod from permisos where permisos.roles_cod_roles = (select rol_usuario.cod_rol from rol_usuario where rol_usuario.cod_usuario=(select usuarios.cod_usuario from usuarios where usuarios.usu_usuario='" + usuariolog + "'))";
      
                System.Collections.ArrayList array = dataJson.consultar(query);
       
                int intamanoarray = array.Count;


                List<string> Modulos = new List<string>();

                foreach (Dictionary<string, string> dict in array)
                {


                    this.lblAREA.Text = dict["txmod"];

                    Properties.Settings.Default.xrol = dict["roles_cod_roles"];

                    lstMODULOS.Items.Add(dict["txaplicacion"]);

                    i++;
                }



            }
            catch (Exception fe)
            {
        
            }
            try { 
            lstMODULOS.SelectedIndex = 0;
            lstMODULOS.Height=(i*16);
         }
            catch (Exception fe)
            {
                lstMODULOS.Visible = false;
        
            }
        }

        private void lstMODULOS_DoubleClick(object sender, EventArgs e)
        {
            LLAMARVOID();
            webBrowser1.Visible = false;
   
          
            string x = "";
            x = lstMODULOS.SelectedItem.ToString();
           
            string query = "select fraplicacion from aplicaciones where txaplicacion ='" + x + "'";
            System.Collections.ArrayList array = dataJson.consultar(query);
            string stFormulario = "";
            foreach (Dictionary<string, string> dict in array)
            {

                stFormulario = dict["fraplicacion"];
      
            }

            AbrirForm("Comercial_Solutions.Forms.Areas." + AREA() + "." + stFormulario, stFormulario);
        }


        public void GenerarOBJNavegador(string stformulario)
        {
           
            try
            {
                //
                string query = "select idaplicaciones from aplicaciones where fraplicacion ='" + stformulario + "'";
                System.Collections.ArrayList array = dataJson.consultar(query);
                int i = 0;
                int intamanoarray = array.Count;
                //ToolStripMenuItem[] items = new ToolStripMenuItem[intamanoarray]; // You would obviously calculate this value at runtime 
                //Console.WriteLine("tamaddddddno de vector: " + intamanoarray + " " + query);
                foreach (Dictionary<string, string> dict in array)
                {

                    Properties.Settings.Default.xaplicacion = dict["idaplicaciones"];
                    //Console.WriteLine("ID aplicacion: " + Properties.Settings.Default.xaplicacion);
                }

            }
            catch (Exception e)
            {


            }
        }

        public void AbrirForm(String NombreForm, string stFormulario)
        {
            if (ActiveMdiChild != null)
            {

                ActiveMdiChild.Close();
            }
            try
            {
                //Console.WriteLine("NOMBREFORM "+NombreForm+" STFORMULACIO "+stFormulario);
                GenerarOBJNavegador(stFormulario);
                Form Frm;
                if (!Ins.TryGetValue(NombreForm, out Frm) || Frm.IsDisposed)
                {
                    Frm = (Form)Activator.CreateInstance(null, NombreForm).Unwrap();
                    Ins[NombreForm] = Frm;
                }
                webBrowser1.Visible = false;

                // Console.WriteLine("X= " + Properties.Settings.Default.widthx + " Y=" + Properties.Settings.Default.heighty);
              
      
                Frm.MdiParent = this;
       
                Frm.Show();
        
            }
            catch (Exception e)
            {
                //throw e;
                MessageBox.Show("Aplicacion no asignada favor consultar a soporte");
            }
        }


        public string AREA()
        {
            string area = "";
            string query = "select txmodulos from modulos where cod_modulos=(select modulos_cod_modulos from roles where cod_roles=(select cod_rol from rol_usuario where cod_usuario=(select usuarios.cod_usuario from usuarios where usuarios.usu_usuario='" + usuariolog + "')))";

            System.Collections.ArrayList array = dataJson.consultar(query);
            foreach (Dictionary<string, string> dict in array)
            {
                area = area + (dict["txmodulos"]);
            }
          //  Console.WriteLine("::" + area);
            return area;

        }




private void salirToolStripMenuItem_Click(object sender, EventArgs e)
{
    Application.Exit();
}



private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
{
    this.Hide();
    frm_login x = new frm_login();
    x.Show();
    //CerrarSesion();
}

private void frm_mdi_FormClosing(object sender, FormClosingEventArgs e)
{
    Application.Exit();
}

private void lstMODULOS_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void toolStripContainer5_ContentPanel_Load(object sender, EventArgs e)
{

}

private void toolStripContainer2_TopToolStripPanel_Click(object sender, EventArgs e)
{

}

private void crearToolStripMenuItem_Click(object sender, EventArgs e)
{
    frm_Menu_aplicacion x =new frm_Menu_aplicacion();
    x.Show();
}

private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
{
    frm_Menu_crear_permiso_rol x = new frm_Menu_crear_permiso_rol();
    x.Show();
}


   }
}
