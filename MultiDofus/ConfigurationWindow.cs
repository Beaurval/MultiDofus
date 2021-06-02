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
        public KeyboardHookManager keyboardHookManager;


        public ConfigurationWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            MajShortcuts();
            _mainWindow = mainWindow;

            //Keyboard shortcuts
            keyboardHookManager = new KeyboardHookManager();
            keyboardHookManager.Start();

            //optionList.Items.AddRange(_mainWindow._personnages.Select(x => x.Pseudo).ToArray());
        }

        public void MajShortcuts()
        {
            switchWindowUpBtn.Text = Properties.Settings.Default.SwitchWindowsUpText;
        }


        public void SwitchWindow()
        {
            AppControl.switchToNextPerso(_mainWindow._personnages);
            AppControl.ChangeFocusBtn(_mainWindow.GetListePersoControl());
        }



        private void optionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            formulaire.Controls.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BindKey bindKey = new BindKey(this);
            bindKey.Show();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            AssingShortcuts();
            this.Hide();
            Properties.Settings.Default.Save();
            _mainWindow.TopMost = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Properties.Settings.Default.Reload();
            _mainWindow.TopMost = true;
        }




        private void AssingShortcuts()
        {
            keyboardHookManager.UnregisterAll();

            int settingModifierKey = Properties.Settings.Default.SwitchWindowsUpModifier;
            int key = Properties.Settings.Default.SwitchWindowsUpKey;

            if (settingModifierKey != 0)
            {
                ModifierKeys modifier = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), settingModifierKey.ToString(), true);

                keyboardHookManager.RegisterHotkey(modifier, key, hook_KeyPressed);
            }
            else
            {
                keyboardHookManager.RegisterHotkey(key, hook_KeyPressed);
            }
        }

        void hook_KeyPressed()
        {
            AppControl.switchToNextPerso(_mainWindow._personnages);
            AppControl.ChangeFocusBtn(_mainWindow.GetListePersoControl());
        }


        private void ConfigurationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainWindow.TopMost = true;
        }
    }
}
