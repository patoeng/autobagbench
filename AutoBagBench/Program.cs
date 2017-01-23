using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        private const string AppGuid = "464745B4-9C2A-4B59-A097-8155F0480CAD";
    }
}
