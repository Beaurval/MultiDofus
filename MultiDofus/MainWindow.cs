using MultiDofus.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDofus
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, UIntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern bool ReleaseCapture(IntPtr hwnd);

        const uint WM_SYSCOMMAND = 0x112;
        const uint MOUSE_MOVE = 0xF012;

        private readonly List<Perso> _personnages;
        public MainWindow(List<Perso> personnages)
        {
            _personnages = personnages;
            InitializeComponent();

            //Sizing
            this.ListeBtn.Height = 60 * (_personnages.Count);
            this.ListeBtn.Width = this.Width = this.topBar.Width = 60;
            this.Height = ListeBtn.Height + topBar.Height + 10;
            this.Width = ListeBtn.Width + 20;
            
            //margin
            this.topBar.Margin = new Padding(0, 0, 0, 5);
            this.ListeBtn.Margin = new Padding(0, 0, 0, 5);

            //Color
            this.BackColor = Color.FromArgb(25, 26, 17);
            this.ListeBtn.BackColor = Color.FromArgb(25, 26, 17);
            this.topBar.BackColor = Color.FromArgb(58, 59, 59);
            this.topBar.MouseDown += new MouseEventHandler(holdTopBar);

            ListeBtn.RowCount = _personnages.Count;
            ListeBtn.ColumnCount = 1;

            

            ListeBtn.ColumnStyles[0].SizeType = SizeType.Absolute;
            ListeBtn.ColumnStyles[0].Width = 60;

            for (int i = 0; i < _personnages.Count; i++)
            {
                var perso = _personnages[i];
                ListeBtn.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));     

                Button btn = new Button();
                btn.BackColor = Color.FromArgb(80, 80, 80);

                btn.Click += (sender, EventArgs) => { openWindow_Click(sender, EventArgs, perso); };

                btn.AutoSize = true;
                btn.BackgroundImage = ((Image)(Properties.Resources.Feca));
                btn.BackgroundImageLayout = ImageLayout.Center;

                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom);
                btn.Margin = new Padding(0, 0, 0, 0);
                ListeBtn.Controls.Add(btn, 0, 1);
            }

        }

        // ----------- MOUSE CONTROL TOP BAR
        public void DragMe()
        {
            DefWindowProc(this.Handle, WM_SYSCOMMAND, (UIntPtr)MOUSE_MOVE, IntPtr.Zero);
        }
        private void holdTopBar(object sender, MouseEventArgs e)
        {
            Control ctl = sender as Control;

            // when we get a buttondown message from a button control
            // the button has capture, we need to release capture so
            // or DragMe() won't work.
            ReleaseCapture(ctl.Handle);

            this.DragMe(); // put the form into mousedrag mode.
        }
        // ----------- MOUSE CONTROL TOP BAR ////

        private void openWindow_Click(object sender, EventArgs e, Perso perso)
        {
            user32.SwitchToThisWindow(perso.ProcessHandler, true);
        }
    }
}
