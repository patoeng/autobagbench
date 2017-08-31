using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AutoBagBench
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
    static void Main() 
    {
       using(Mutex mutex = new Mutex(false, "Global\\" + AppGuid))
       {
          if(!mutex.WaitOne(0, false))
          {
             MessageBox.Show("Aplikasi sudah berjalan.");
             return;
          }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
       }
    }

        private const string AppGuid = "C33AC1EF-D075-461C-8EDA-13C093E5E701";

    }
}
