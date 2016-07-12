using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TLog
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
            bool managerStartSuccess = false;

            try
            {
                Manager.Main.Init();
                Application.ApplicationExit += new EventHandler(Manager.Main.Instance.onExit);
                managerStartSuccess = true;
            }

            catch (Manager.FatalException E)
            {
                MessageBox.Show("Unable to start TLog!\n" + E.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (managerStartSuccess)
                Application.Run(new Login());
        }
    }
}
