using System;
using System.IO;
using System.Windows.Forms;

namespace Hikari_Android_Toolkit
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {



            CheckAndDownloadDependencies.Start();

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
            
        }
    }
}
