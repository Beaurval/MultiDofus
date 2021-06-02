
namespace MultiDofus
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topBar = new System.Windows.Forms.Panel();
            this.optionBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ListeBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.topBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.Controls.Add(this.optionBtn);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(3, 3);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(54, 20);
            this.topBar.TabIndex = 1;
            // 
            // optionBtn
            // 
            this.optionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optionBtn.Location = new System.Drawing.Point(32, 0);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(22, 20);
            this.optionBtn.TabIndex = 0;
            this.optionBtn.UseVisualStyleBackColor = true;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.topBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListeBtn, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.365439F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.63456F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(60, 353);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ListeBtn
            // 
            this.ListeBtn.Location = new System.Drawing.Point(3, 29);
            this.ListeBtn.Name = "ListeBtn";
            this.ListeBtn.Size = new System.Drawing.Size(54, 321);
            this.ListeBtn.TabIndex = 2;
            this.ListeBtn.DragDrop += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel_DragDrop);
            this.ListeBtn.DragEnter += new System.Windows.Forms.DragEventHandler(this.flowLayoutPanel_DragEnter);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(60, 353);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "MainWindow";
            this.Text = "Multi Dofus";
            this.TopMost = true;
            this.topBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.FlowLayoutPanel ListeBtn;
    }
}

