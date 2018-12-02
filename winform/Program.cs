using System;
using System.Threading;
using System.Windows.Forms;

namespace Winform {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool createdNew = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Mutex mutex = new Mutex(true, "App", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MyForm());
                }
                else
                {
                    MessageBox.Show("The application is already running", "App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
