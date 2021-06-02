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
    public partial class BindKey : Form
    {
        ConfigurationWindow _config;
        private int keySelected;
        private int? modifierSelected;

        public BindKey(ConfigurationWindow config)
        {
            InitializeComponent();
            this.fShortcut.Select();
            _config = config;
            this.KeyPreview = true;
            this.closeKeyBindForm.TabStop = false;
            this.fShortcut.TabStop = false;
        }

        private void fShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                e.SuppressKeyPress = true;

            if (e.KeyCode != Keys.Back)
            {
                Keys modifierKeys = e.Modifiers;
                Keys pressedKey = e.KeyData ^ modifierKeys; //remove modifier keys

                if (modifierKeys != Keys.None && pressedKey != Keys.None)
                {
                    int keyControlPressed;
                    //do stuff with pressed and modifier keys
                    var converter = new KeysConverter();
                    

                    switch (modifierKeys)
                    {
                        case Keys.Control:
                            keyControlPressed = 2;
                            break;
                        case Keys.Alt:
                            keyControlPressed = 1;
                            break;
                        case Keys.Shift:
                            keyControlPressed = 4;
                            break;
                        case Keys.LWin:
                            keyControlPressed = 8;
                            break;
                        case Keys.RWin:
                            keyControlPressed = 8;
                            break;
                        default:
                            keyControlPressed = 2;
                            break;
                    }

                    if (pressedKey != Keys.ControlKey 
                        && pressedKey != Keys.Menu
                        && pressedKey != Keys.LWin
                        && pressedKey != Keys.RWin
                        && pressedKey != Keys.ShiftKey)
                    {
                        //Save shortcut for character swap here
                        keySelected = e.KeyValue;
                        modifierSelected = keyControlPressed;


                        fShortcut.Text = converter.ConvertToString(e.KeyData);
                        fShortcut.Refresh();

                        Properties.Settings.Default.SwitchWindowsUpModifier = modifierSelected.HasValue ? modifierSelected.Value : 0;
                        Properties.Settings.Default.SwitchWindowsUpKey = keySelected;
                        Properties.Settings.Default.SwitchWindowsUpText = fShortcut.Text;
                        //Properties.Settings.Default.Save();

                        System.Threading.Thread.Sleep(800);
                        this.Close();
                    }
                }
                else if (modifierKeys == Keys.None && pressedKey != Keys.None)
                {
                    var converter = new KeysConverter();
                    fShortcut.Text = converter.ConvertToString(e.KeyData);
                    fShortcut.Refresh();

                    //Save shortcut for character swap here
                    keySelected = e.KeyValue;
                    modifierSelected = null;

                    Properties.Settings.Default.SwitchWindowsUpModifier = modifierSelected.HasValue ? modifierSelected.Value : 0;
                    Properties.Settings.Default.SwitchWindowsUpKey = keySelected;
                    Properties.Settings.Default.SwitchWindowsUpText = fShortcut.Text;

                    System.Threading.Thread.Sleep(800);
                    this.Close();
                }
            }
            else
            {
                e.Handled = false;
                e.SuppressKeyPress = true;

                fShortcut.Text = "";
            }
        }

        private void closeKeyBindForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            _config.MajShortcuts();
        }
    }
}
