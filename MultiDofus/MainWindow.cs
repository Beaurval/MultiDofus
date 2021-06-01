﻿using MultiDofus.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NonInvasiveKeyboardHookLibrary;

namespace MultiDofus
{
    public partial class MainWindow : Form
    {
        private ConfigurationWindow _configurationWindow;
        
        //Liste des personnages
        public readonly List<Perso> _personnages;

        public MainWindow(List<Perso> personnages)
        {
            _personnages = personnages;
            InitializeComponent();
            _configurationWindow = new ConfigurationWindow(this);


            //Sizing
            this.ListeBtn.Height = 60 * (_personnages.Count);
            this.Height = 60 * (_personnages.Count) + topBar.Height + 15;
            this.Width = 85;

            //margin
            this.topBar.Margin = new Padding(0, 0, 0, 5);
            this.ListeBtn.Margin = new Padding(5, 0, 5, 5);

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


                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                btn.Margin = new Padding(0, 0, 0, 0);
                ListeBtn.Controls.Add(btn, 0, 1);
            }

        }

        public TableLayoutPanel GetListePersoControl()
        {
            return ListeBtn;
        }

        private void holdTopBar(object sender, MouseEventArgs e)
        {
            AppControl.TopBarHolded(this, sender);
        }

        private void openWindow_Click(object sender, EventArgs e, Perso perso)
        {
            AppControl.openPersoWindow(perso);
        }

        private void optionBtn_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            _configurationWindow.Show();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _configurationWindow.keyboardHookManager.Stop();
        }
    }
}
