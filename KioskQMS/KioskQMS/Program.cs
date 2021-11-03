using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskQMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (new FormKey().IsInstalled())
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new FormKey());
            }
        }
    }
}
