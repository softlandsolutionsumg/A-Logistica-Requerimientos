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

namespace Comercial_Solutions.Forms.Areas.Logistica
{
    public partial class beta3 : Form
    {
        int X = 0;
        int Y = 0;
        public beta3()
        {
            X = Propp.X;
            Y = Propp.Y;

            InitializeComponent();
        }

        private void beta3_Load(object sender, EventArgs e)
        {
            this.Size = new Size(X, Y);
            this.Location = new Point(250, 56);
        }
    }
}
