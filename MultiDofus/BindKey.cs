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

        public BindKey(ConfigurationWindow config)
        {
            InitializeComponent();
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
                    NonInvasiveKeyboardHookLibrary.ModifierKeys keyControlPressed;
                    //do stuff with pressed and modifier keys
                    var converter = new KeysConverter();
                    fShortcut.Text = converter.ConvertToString(e.KeyData);

                    switch (modifierKeys)
                    {
                        case Keys.Control:
                            keyControlPressed = NonInvasiveKeyboardHookLibrary.ModifierKeys.Control;
                            break;
                        case Keys.Alt:
                            keyControlPressed = NonInvasiveKeyboardHookLibrary.ModifierKeys.Alt;
                            break;
                        case Keys.Shift:
                            keyControlPressed = NonInvasiveKeyboardHookLibrary.ModifierKeys.Shift;
                            break;
                        case Keys.LWin:
                            keyControlPressed = NonInvasiveKeyboardHookLibrary.ModifierKeys.WindowsKey;
                            break;
                        case Keys.RWin:
                            keyControlPressed = NonInvasiveKeyboardHookLibrary.ModifierKeys.WindowsKey;
                            break;
                        default:
                            keyControlPressed = NonInvasiveKeyboardHookLibrary.ModifierKeys.Control;
                            break;
                    }

                    if (pressedKey != Keys.ControlKey 
                        && pressedKey != Keys.Menu
                        && pressedKey != Keys.LWin
                        && pressedKey != Keys.RWin
                        && pressedKey != Keys.ShiftKey)
                    {
                        _config.keyboardHookManager
                        .RegisterHotkey(keyControlPressed, e.KeyValue, () =>
                        {
                            _config.SwitchWindow();
                        });
                    }
                }
                else if (modifierKeys == Keys.None && pressedKey != Keys.None)
                {
                    var converter = new KeysConverter();
                    fShortcut.Text = converter.ConvertToString(e.KeyData);
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
    }
}
