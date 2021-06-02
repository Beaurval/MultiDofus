using MultiDofus.Classes;
using NonInvasiveKeyboardHookLibrary;
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
            MajShortcuts();

            //optionList.Items.AddRange(_mainWindow._personnages.Select(x => x.Pseudo).ToArray());
        }
        /// <summary>
        /// Mise à jour des raccourcis
        /// </summary>
        public void MajShortcuts()
        {
            switchWindowUpBtn.Text = Properties.SwitchCharacterUp.Default.Text;
            switchWindowDownBtn.Text = Properties.SwitchCharacterDown.Default.Text;
        }



        private void optionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            formulaire.Controls.Clear();
        }
        /// <summary>
        /// User cliked OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            RefreshShortcuts();
            SaveSettings();
            _mainWindow.TopMost = true;
            this.Close();
        }
        /// <summary>
        /// User cliked cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ReloadSettings();
            _mainWindow.TopMost = true;
            this.Close();
        }

        /// <summary>
        /// Call AssingShortcuts again in order to refresh
        /// </summary>
        private void RefreshShortcuts()
        {
            _mainWindow.AssingShortcuts();
        }

        private void ConfigurationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainWindow.TopMost = true;
            _mainWindow.keyboardHookManager.Start();
        }
        /// <summary>
        /// Save settings
        /// </summary>
        private void SaveSettings()
        {
            Properties.SwitchCharacterDown.Default.Save();
            Properties.SwitchCharacterUp.Default.Save();
        }

        /// <summary>
        /// Reload settings
        /// </summary>
        private void ReloadSettings()
        {
            Properties.SwitchCharacterDown.Default.Reload();
            Properties.SwitchCharacterUp.Default.Reload();
        }

        /// <summary>
        /// Used has cliked a shortcut btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchWindowUpBtn_Click(object sender, EventArgs e)
        {
            Control senderControl = (Control)sender;
            if (senderControl.Name == "switchWindowUpBtn")
            {
                BindKey bindKey = new BindKey(this,"up");
                bindKey.Show();
            }
            else if(senderControl.Name == "switchWindowDownBtn")
            {
                BindKey bindKey = new BindKey(this, "down");
                bindKey.Show();
            }
        }
    }
}
