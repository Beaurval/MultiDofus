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
        private KeyHandler ghk;

        //Liste des personnages
        private readonly List<Perso> _personnages;

        public MainWindow(List<Perso> personnages)
        {
            _personnages = personnages;
            InitializeComponent();

            ghk = new KeyHandler(Keys.Tab, this);
            ghk.Register();

            //Sizing
            this.ListeBtn.Height = 60 * (_personnages.Count);
            this.ListeBtn.Width = this.Width = this.topBar.Width = 60;
            this.Height = 60 * (_personnages.Count) + topBar.Height + 15;
            this.Width = ListeBtn.Width + 20;

            //margin
            this.topBar.Margin = new Padding(0, 0, 0, 5);
            this.ListeBtn.Margin = new Padding(0, 0, 0, 5);

            //Color
            this.BackColor = Color.FromArgb(25, 26, 17);
            this.ListeBtn.BackColor = Color.FromArgb(25, 26, 17);
            this.topBar.BackColor = Color.FromArgb(58, 59, 59);
            this.topBar.MouseDown += new MouseEventHandler(holdTopBar);
            this.optionBtn.BackColor = Color.FromArgb(199, 238, 2);

            //Style            
            var bm = new Bitmap(((Image)(Properties.Resources.gear)), new Size(optionBtn.Width - 6, optionBtn.Height - 8));
            optionBtn.BackgroundImage = bm;
            optionBtn.Text = null;
            optionBtn.BackgroundImageLayout = ImageLayout.Center;

            optionBtn.FlatStyle = FlatStyle.Flat;
            optionBtn.FlatAppearance.BorderColor = Color.FromArgb(99, 134, 1);
            optionBtn.FlatAppearance.BorderSize = 1;

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
        private void HandleHotkey()
        {
            AppControl.switchToNextPerso(_personnages);
            AppControl.ChangeFocusBtn(ListeBtn);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void holdTopBar(object sender, MouseEventArgs e)
        {
            AppControl.TopBarHolded(this, sender);
        }

        private void openWindow_Click(object sender, EventArgs e, Perso perso)
        {
            AppControl.openPersoWindow(perso);
        }
    }
}
