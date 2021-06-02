using MultiDofus.Classes;
using NonInvasiveKeyboardHookLibrary;
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

namespace MultiDofus
{
    public partial class MainWindow : Form
    {
        //Hotkeys
        public KeyboardHookManager keyboardHookManager;

        //Liste des personnages
        public readonly List<Perso> _personnages;

        public MainWindow(List<Perso> personnages)
        {
            //Keyboard shortcuts
            keyboardHookManager = new KeyboardHookManager();
            keyboardHookManager.Start();

            //Characters
            _personnages = personnages;

            InitializeComponent();

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

            AssingShortcuts();
        }

        public TableLayoutPanel GetListePersoControl()
        {
            return ListeBtn;
        }

        /// <summary>
        /// Switch to next character's window (0 to n way)
        /// </summary>
        public void SwitchWindow()
        {
            AppControl.switchToNextPerso(_personnages);
            AppControl.ChangeFocusBtn(GetListePersoControl());
        }
        /// <summary>
        /// Switch to next character's window (n to 0 way)
        /// </summary>
        public void SwitchWindowDown()
        {
            AppControl.switchToPreviousPerso(_personnages);
            AppControl.ChangeFocusBtn(GetListePersoControl());
        }
        /// <summary>
        /// Bind shotcuts in settings
        /// </summary>
        public void AssingShortcuts()
        {
            keyboardHookManager.UnregisterAll();

            int modifierUp = Properties.SwitchCharacterUp.Default.Modifier;
            int keyUp = Properties.SwitchCharacterUp.Default.Key;

            //Shortbut with modifier
            if (modifierUp != 0)
            {
                ModifierKeys modifierUpKeys = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), modifierUp.ToString(), true);
                keyboardHookManager.RegisterHotkey(modifierUpKeys, keyUp, SwitchWindow);
            }
            //Shortcut without modifier
            else
            {
                keyboardHookManager.RegisterHotkey(keyUp, SwitchWindow);
            }

            int modifierDown = Properties.SwitchCharacterDown.Default.Modifier;
            int keyDown = Properties.SwitchCharacterDown.Default.Key;

            //Shortbut with modifier
            if (modifierDown != 0)
            {
                ModifierKeys modifierDownKeys = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), modifierDown.ToString(), true);
                keyboardHookManager.RegisterHotkey(modifierDownKeys, keyDown, SwitchWindowDown);
            }
            //Shortcut without modifier
            else
            {
                keyboardHookManager.RegisterHotkey(keyDown, SwitchWindowDown);
            }
        }
        /// <summary>
        /// Event for drag main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void holdTopBar(object sender, MouseEventArgs e)
        {
            AppControl.TopBarHolded(this, sender);
        }
        /// <summary>
        /// Open character's window when user has clicked on its button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="perso"></param>
        private void openWindow_Click(object sender, EventArgs e, Perso perso)
        {
            AppControl.openPersoWindow(perso);
        }
        /// <summary>
        /// Open settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionBtn_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            keyboardHookManager.Stop();

            ConfigurationWindow _configurationWindow = new ConfigurationWindow(this);
            _configurationWindow.Show();
        }
    }
}
