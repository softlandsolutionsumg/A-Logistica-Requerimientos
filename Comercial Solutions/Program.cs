using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using i3nRiqJSON;
using Comercial_Solutions.Forms.Principal;
using Comercial_Solutions.Forms.Seguridad;

namespace Comercial_Solutions
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frm_login());
            Application.Run(new frm_login());
        }
    }
}
