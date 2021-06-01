using MultiDofus.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDofus
{
    public partial class ConfigurationWindow : Form
    {
        const int WM_KEYDOWN = 0x0100, WM_KEYUP = 0x0101, WM_CHAR = 0x0102, WM_SYSKEYDOWN = 0x0104, WM_SYSKEYUP = 0x0105;
        
        private KeyHandler ghk;
        private MainWindow _mainWindow;

        public ConfigurationWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            ghk = new KeyHandler(Keys.Control, this);
            ghk.Register();

            _mainWindow = mainWindow;
            //optionList.Items.AddRange(_mainWindow._personnages.Select(x => x.Pseudo).ToArray());
        }

        private void HandleHotkey()
        {
            MessageBox.Show("Coucou");
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP || m.Msg == WM_CHAR || m.Msg == WM_SYSKEYDOWN || m.Msg == WM_SYSKEYUP)
            {
                MessageBox.Show("Test");
            }

            base.WndProc(ref m);
        }

        private void ConfigurationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainWindow.TopMost = true;
        }

        private void optionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            formulaire.Controls.Clear();    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Appuyez sur une touche");
        }
    }
}
