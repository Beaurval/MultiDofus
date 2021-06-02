
namespace MultiDofus
{
    partial class BindKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.closeKeyBindForm = new System.Windows.Forms.Button();
            this.fShortcut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // closeKeyBindForm
            // 
            this.closeKeyBindForm.Location = new System.Drawing.Point(148, 41);
            this.closeKeyBindForm.Name = "closeKeyBindForm";
            this.closeKeyBindForm.Size = new System.Drawing.Size(93, 33);
            this.closeKeyBindForm.TabIndex = 0;
            this.closeKeyBindForm.Text = "Annuler";
            this.closeKeyBindForm.UseVisualStyleBackColor = true;
            this.closeKeyBindForm.Click += new System.EventHandler(this.closeKeyBindForm_Click);
            // 
            // fShortcut
            // 
            this.fShortcut.Location = new System.Drawing.Point(34, 12);
            this.fShortcut.Name = "fShortcut";
            this.fShortcut.PlaceholderText = "Cliquez ici pour assigner un raccourci";
            this.fShortcut.Size = new System.Drawing.Size(322, 23);
            this.fShortcut.TabIndex = 2;
            this.fShortcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fShortcut_KeyDown);
            // 
            // BindKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 83);
            this.ControlBox = false;
            this.Controls.Add(this.fShortcut);
            this.Controls.Add(this.closeKeyBindForm);
            this.Name = "BindKey";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appuyez sur une touche ou une combinaison";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BindKey_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeKeyBindForm;
        private System.Windows.Forms.TextBox fShortcut;
    }
}