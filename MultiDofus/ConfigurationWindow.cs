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
        private MainWindow _mainWindow;

        public ConfigurationWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;
            //optionList.Items.AddRange(_mainWindow._personnages.Select(x => x.Pseudo).ToArray());
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
