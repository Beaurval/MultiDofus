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
            this.BackColor = Color.FromArgb(25,26,17);
            
            InitializeComponent();
            _personnages = personnages;

            ListeBtn.RowCount = _personnages.Count;
            ListeBtn.ColumnCount = 1;
            ListeBtn.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
                    | AnchorStyles.Left)
                    | AnchorStyles.Right)));
            

            for (int i = 0; i < _personnages.Count; i++)
            {
                var perso = _personnages[i];
                ListeBtn.RowStyles.Add(new RowStyle(SizeType.Absolute,ListeBtn.Height / _personnages.Count ));

                Button btn = new Button();
                btn.BackColor = Color.White;
                btn.Click += (sender, EventArgs) => { openWindow_Click(sender, EventArgs, perso); };
                btn.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);
                btn.AutoSize = true;
                btn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Feca));
                btn.BackgroundImageLayout = ImageLayout.Center;
                            
                ListeBtn.Controls.Add(btn, 0, 1);
            }
        }


        private void openWindow_Click(object sender, EventArgs e, Perso perso)
        {
            user32.SwitchToThisWindow(perso.ProcessHandler, true);
        }
    }
}
