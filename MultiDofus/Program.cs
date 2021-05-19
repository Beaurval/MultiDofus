using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDofus
{
    static class Program
    {
        private delegate bool EnumDesktopWindowsDelegate(IntPtr hWnd, int lParam);
        [DllImport("user32.dll")]

        static extern bool EnumDesktopWindows(IntPtr hDesktop,
        EnumDesktopWindowsDelegate lpfn, IntPtr lParam);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(user32.RecupererLesPersonnagesEnJeu()));
        }
    }
}
