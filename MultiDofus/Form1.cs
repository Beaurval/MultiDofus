using MultiDofus.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDofus
{
    public partial class MainWindow : Form
    {
        private readonly List<Perso> _personnages; 
        public MainWindow(List<Perso> personnages)
        {
            InitializeComponent();
            _personnages = personnages;

            foreach(var perso in _personnages)
            {
                Button btn = new Button();
                btn.Text = perso.Pseudo;
                btn.Click += (sender, EventArgs) => { openWindow_Click(sender, EventArgs, perso); };                         
                ListeBtn.Controls.Add(btn);
            }
        }


        private void openWindow_Click(object sender, EventArgs e,Perso perso)
        {
            user32.SwitchToThisWindow(perso.ProcessHandler, true);
        }
    }
}
