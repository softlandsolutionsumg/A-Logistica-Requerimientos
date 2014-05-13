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
using Comercial_Solutions.Forms.Principal;

namespace Comercial_Solutions.Forms.Areas.Logistica
{
    
    public partial class beta1 : Form
    {
        int X = 0;
        int Y = 0;
        // Instanciamos un objeto de FORM2
        frm_mdi formulario = new frm_mdi("");
        
        public beta1()

        {
            X = Propp.X;
            Y = Propp.Y;
            InitializeComponent();
            //Console.WriteLine("W " + Properties.Settings.Default.widthx + " H " + Properties.Settings.Default.heighty);
            //formulario.MiEvento += new Form2.DelegadoTitulo(PonerTitulo);
           
           
            
        }

        private void beta1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
           // this.Size = new Size(Properties.Settings.Default.widthx, Properties.Settings.Default.heighty);
            
        }

        void formulario_MiEvento(string mensaje)
        {
            throw new NotImplementedException();
        }
        static void PonerTitulo()
        {
            Console.WriteLine("ddddddddddddd");
            //button1.Text = mensaje;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
        public void casa() {
            Console.WriteLine("PRUEBA :D");
            button1.Text = "hola";
        }
    }
}
