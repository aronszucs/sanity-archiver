namespace SanityArchiver
{
    partial class FileViewForm
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
            this.leftWindow = new System.Windows.Forms.ListBox();
            this.rightWindow = new System.Windows.Forms.ListBox();
            this.leftArchiveButton = new System.Windows.Forms.Button();
            this.rightArchiveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftWindow
            // 
            this.leftWindow.FormattingEnabled = true;
            this.leftWindow.ItemHeight = 16;
            this.leftWindow.Location = new System.Drawing.Point(69, 39);
            this.leftWindow.Name = "leftWindow";
            this.leftWindow.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.leftWindow.Size = new System.Drawing.Size(357, 404);
            this.leftWindow.TabIndex = 0;
            this.leftWindow.SelectedIndexChanged += new System.EventHandler(this.LeftWindow_SelectedIndexChanged);
            this.leftWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LeftWindow_DoubleClick);
            // 
            // rightWindow
            // 
            this.rightWindow.FormattingEnabled = true;
            this.rightWindow.ItemHeight = 16;
            this.rightWindow.Location = new System.Drawing.Point(606, 39);
            this.rightWindow.Name = "rightWindow";
            this.rightWindow.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.rightWindow.Size = new System.Drawing.Size(357, 404);
            this.rightWindow.TabIndex = 1;
            this.rightWindow.SelectedIndexChanged += new System.EventHandler(this.RightWindow_SelectedIndexChanged);
            this.rightWindow.DoubleClick += new System.EventHandler(this.RightWindow_DoubleClick);
            // 
            // leftArchiveButton
            // 
            this.leftArchiveButton.Location = new System.Drawing.Point(432, 39);
            this.leftArchiveButton.Name = "leftArchiveButton";
            this.leftArchiveButton.Size = new System.Drawing.Size(83, 37);
            this.leftArchiveButton.TabIndex = 2;
            this.leftArchiveButton.Text = "Archive";
            this.leftArchiveButton.UseVisualStyleBackColor = true;
            this.leftArchiveButton.Click += new System.EventHandler(this.LeftArchiveButton_Click);
            // 
            // rightArchiveButton
            // 
            this.rightArchiveButton.Location = new System.Drawing.Point(969, 39);
            this.rightArchiveButton.Name = "rightArchiveButton";
            this.rightArchiveButton.Size = new System.Drawing.Size(83, 37);
            this.rightArchiveButton.TabIndex = 3;
            this.rightArchiveButton.Text = "Archive";
            this.rightArchiveButton.UseVisualStyleBackColor = true;
            this.rightArchiveButton.Click += new System.EventHandler(this.RightArchiveButton_Click);
            // 
            // FileViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 493);
            this.Controls.Add(this.rightArchiveButton);
            this.Controls.Add(this.leftArchiveButton);
            this.Controls.Add(this.rightWindow);
            this.Controls.Add(this.leftWindow);
            this.Name = "FileViewForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox leftWindow;
        private System.Windows.Forms.ListBox rightWindow;
        private System.Windows.Forms.Button leftArchiveButton;
        private System.Windows.Forms.Button rightArchiveButton;
    }
}

