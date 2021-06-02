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
using MultiDofus.Extensions;
using System.Reflection;

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

            ListeBtn.AllowDrop = true;

            //Sizing
            this.ListeBtn.Height = 60 * (_personnages.Count);
            this.Height = 60 * (_personnages.Count) + topBar.Height + 15;
            this.Width = ListeBtn.Width = 80;

            //margin
            this.topBar.Margin = new Padding(0, 0, 0, 5);
            this.ListeBtn.Margin = new Padding(5, 0, 5, 5);

            //Color
            this.BackColor = Color.FromArgb(25, 26, 17);
            this.ListeBtn.BackColor = Color.FromArgb(25, 26, 17);
            this.topBar.BackColor = Color.FromArgb(58, 59, 59);
            this.topBar.MouseDown += new MouseEventHandler(holdTopBar);
            this.optionBtn.BackColor = Color.FromArgb(199, 238, 2);
            this.lockBtn.BackColor = Color.FromArgb(199, 238, 2);

            //Style            
            var bm = new Bitmap(((Image)(Properties.Resources.gear)), new Size(optionBtn.Width - 6, optionBtn.Height - 8));
            optionBtn.BackgroundImage = bm;
            optionBtn.Text = null;
            optionBtn.BackgroundImageLayout = ImageLayout.Center;

            optionBtn.FlatStyle = FlatStyle.Flat;
            optionBtn.FlatAppearance.BorderColor = Color.FromArgb(99, 134, 1);
            optionBtn.FlatAppearance.BorderSize = 1;

            var bmLock = new Bitmap(((Image)(Properties.Resources._lock)), new Size(optionBtn.Width - 6, optionBtn.Height - 8));
            lockBtn.BackgroundImage = bmLock;
            lockBtn.Text = null;
            lockBtn.BackgroundImageLayout = ImageLayout.Center;

            lockBtn.FlatStyle = FlatStyle.Flat;
            lockBtn.FlatAppearance.BorderColor = Color.FromArgb(99, 134, 1);
            lockBtn.FlatAppearance.BorderSize = 1;
            lockBtn.Tag = "lock";



            for (int i = 0; i < _personnages.Count; i++)
            {
                var perso = _personnages[i];

                ToolTip toolTip = new ToolTip();

                Button btn = new Button();
                btn.Height = 60;
                btn.Width = 70;
                btn.BackColor = Color.FromArgb(80, 80, 80);
                btn.Click += (sender, EventArgs) => { openWindow_Click(sender, EventArgs, perso); };


                btn.AutoSize = true;
                btn.BackgroundImage = ((Image)(Properties.Resources.Feca));
                btn.BackgroundImageLayout = ImageLayout.Center;


                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                btn.Margin = new Padding(0, 0, 0, 0);

                toolTip.SetToolTip(btn, _personnages[i].Pseudo);
                ListeBtn.Controls.Add(btn);
            }

            AssingShortcuts();


        }

        private void flowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void flowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            Button data = (Button)e.Data.GetData(typeof(Button));
            FlowLayoutPanel _destination = (FlowLayoutPanel)sender;
            FlowLayoutPanel _source = (FlowLayoutPanel)data.Parent;

            // Reorder
            Point p = _destination.PointToClient(new Point(e.X, e.Y));
            Button item = (Button)_destination.GetChildAtPoint(p);

            if (item != data)
            {
                AppControl.lastPersoSelectedIndex = _destination.Controls.GetChildIndex(item, false);

                int index = _destination.Controls.GetChildIndex(item, false);

                _personnages.Move(_destination.Controls.GetChildIndex(data, false),
                    AppControl.lastPersoSelectedIndex);

                //data.ClearEventInvocations("Click");
                //data.Click += (sender, EventArgs) => { openWindow_Click(sender, EventArgs, _personnages[index]); }; ;

                 
                _destination.Controls.SetChildIndex(data, index);

                // Invalidate to paint!
                _destination.Invalidate();
                _source.Invalidate();
            }
            else
            {
                data.PerformClick();
            }
        }

        private void Data_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            this.DoDragDrop(control, DragDropEffects.Move);
        }


        public FlowLayoutPanel GetListePersoControl()
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
            AppControl.openPersoWindow(perso, _personnages.IndexOf(perso));
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

        private void lockBtn_Click(object sender, EventArgs e)
        {
            if (lockBtn.Tag.ToString() == "lock")
            {
                lockBtn.BackgroundImage = new Bitmap(((Image)(Properties.Resources._unlock)), new Size(optionBtn.Width - 6, optionBtn.Height - 8));
                lockBtn.Tag = "unlock";
                AllowDragButtons();
                lockBtn.Refresh();
            }
            else
            {
                lockBtn.BackgroundImage = new Bitmap(((Image)(Properties.Resources._lock)), new Size(optionBtn.Width - 6, optionBtn.Height - 8));
                lockBtn.Tag = "lock";
                ForbidDragButtons();
                lockBtn.Refresh();
            }
        }

        private void AllowDragButtons()
        {
            foreach (Button button in ListeBtn.Controls.OfType<Button>())
            {
                button.MouseDown +=
                    new MouseEventHandler(this.button_MouseDown);
            }
        }

        private void ForbidDragButtons()
        {
            foreach (Button button in ListeBtn.Controls.OfType<Button>())
            {
                button.MouseDown -=
                    new MouseEventHandler(this.button_MouseDown);
            }
        }
    }
}
