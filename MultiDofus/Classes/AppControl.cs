using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDofus.Classes
{
    public static class AppControl
    {
        //Windows funtions in WIN32
        [DllImport("user32.dll")]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, UIntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern bool ReleaseCapture(IntPtr hwnd);
        const uint WM_SYSCOMMAND = 0x112;
        const uint MOUSE_MOVE = 0xF012;
        //----------------------------------------------------

        //Character & windows controls
        public static int lastPersoSelectedIndex = 0;

        public static void switchToNextPerso(List<Perso> persos)
        {
            if (persos.Count - 1 == lastPersoSelectedIndex)
                lastPersoSelectedIndex = 0;
            else
                lastPersoSelectedIndex++;

            openPersoWindow(persos[lastPersoSelectedIndex]);
        }

        public static void switchToPreviousPerso(List<Perso> persos)
        {
            if (0 == lastPersoSelectedIndex)
                lastPersoSelectedIndex = persos.Count - 1;
            else
                lastPersoSelectedIndex--;

            openPersoWindow(persos[lastPersoSelectedIndex]);
        }

        public static void openPersoWindow(Perso perso)
        {
            user32.SwitchToThisWindow(perso.ProcessHandler, true);
        }
        //----------------------------------------------------


        // ----------- MOUSE CONTROL TOP BAR
        public static void DragMe(MainWindow main)
        {
            DefWindowProc(main.Handle, WM_SYSCOMMAND, (UIntPtr)MOUSE_MOVE, IntPtr.Zero);
        }

        public static void TopBarHolded(MainWindow main, object sender)
        {
            Control ctl = sender as Control;

            // when we get a buttondown message from a button control
            // the button has capture, we need to release capture so
            // or DragMe() won't work.
            ReleaseCapture(ctl.Handle);

            AppControl.DragMe(main); // put the form into mousedrag mode.
        }

        public static void ChangeFocusBtn(FlowLayoutPanel layout)
        {
            layout.Invoke(new MethodInvoker(delegate
            {
                layout.Controls[lastPersoSelectedIndex].Focus();
                layout.Refresh();
            }));
        }
    }
}
