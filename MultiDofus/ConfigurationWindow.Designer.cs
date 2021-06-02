
namespace MultiDofus
{
    partial class ConfigurationWindow
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.optionList = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.formulaire = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.switchWindowDownBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.switchWindowUpBtn = new System.Windows.Forms.Button();
            this.formulaire.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(294, 280);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Annuler";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(213, 279);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // optionList
            // 
            this.optionList.FormattingEnabled = true;
            this.optionList.Location = new System.Drawing.Point(42, 12);
            this.optionList.Name = "optionList";
            this.optionList.Size = new System.Drawing.Size(298, 23);
            this.optionList.TabIndex = 3;
            this.optionList.SelectedIndexChanged += new System.EventHandler(this.optionList_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(342, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 24);
            this.button4.TabIndex = 5;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // formulaire
            // 
            this.formulaire.BackColor = System.Drawing.SystemColors.ControlLight;
            this.formulaire.Controls.Add(this.groupBox1);
            this.formulaire.Location = new System.Drawing.Point(12, 41);
            this.formulaire.Name = "formulaire";
            this.formulaire.Size = new System.Drawing.Size(358, 221);
            this.formulaire.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.switchWindowDownBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.switchWindowUpBtn);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raccourcis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Changer de fenêtre sens inverse";
            // 
            // switchWindowDownBtn
            // 
            this.switchWindowDownBtn.Location = new System.Drawing.Point(218, 55);
            this.switchWindowDownBtn.Name = "switchWindowDownBtn";
            this.switchWindowDownBtn.Size = new System.Drawing.Size(110, 23);
            this.switchWindowDownBtn.TabIndex = 6;
            this.switchWindowDownBtn.Text = "Non assigné";
            this.switchWindowDownBtn.UseVisualStyleBackColor = true;
            this.switchWindowDownBtn.Click += new System.EventHandler(this.switchWindowUpBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Changer de fenêtre";
            // 
            // switchWindowUpBtn
            // 
            this.switchWindowUpBtn.AccessibleName = "";
            this.switchWindowUpBtn.Location = new System.Drawing.Point(218, 22);
            this.switchWindowUpBtn.Name = "switchWindowUpBtn";
            this.switchWindowUpBtn.Size = new System.Drawing.Size(110, 23);
            this.switchWindowUpBtn.TabIndex = 4;
            this.switchWindowUpBtn.Text = "Non assigné";
            this.switchWindowUpBtn.UseVisualStyleBackColor = true;
            this.switchWindowUpBtn.Click += new System.EventHandler(this.switchWindowUpBtn_Click);
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 315);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.optionList);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.formulaire);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ConfigurationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préférences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigurationWindow_FormClosed);
            this.formulaire.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox optionList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel formulaire;
        private System.Windows.Forms.Button switchWindowUpBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button switchWindowDownBtn;
        private System.Windows.Forms.Label label1;
    }
}