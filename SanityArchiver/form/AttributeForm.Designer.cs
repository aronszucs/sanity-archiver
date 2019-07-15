namespace SanityArchiver.form
{
    partial class AttributeForm
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
            this.readOnlyChBox = new System.Windows.Forms.CheckBox();
            this.hiddenChBox = new System.Windows.Forms.CheckBox();
            this.archiveChBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // readOnlyChBox
            // 
            this.readOnlyChBox.AutoSize = true;
            this.readOnlyChBox.Location = new System.Drawing.Point(29, 21);
            this.readOnlyChBox.Name = "readOnlyChBox";
            this.readOnlyChBox.Size = new System.Drawing.Size(94, 21);
            this.readOnlyChBox.TabIndex = 0;
            this.readOnlyChBox.Text = "Read only";
            this.readOnlyChBox.UseVisualStyleBackColor = true;
            // 
            // hiddenChBox
            // 
            this.hiddenChBox.AutoSize = true;
            this.hiddenChBox.Location = new System.Drawing.Point(29, 48);
            this.hiddenChBox.Name = "hiddenChBox";
            this.hiddenChBox.Size = new System.Drawing.Size(75, 21);
            this.hiddenChBox.TabIndex = 1;
            this.hiddenChBox.Text = "Hidden";
            this.hiddenChBox.UseVisualStyleBackColor = true;
            // 
            // archiveChBox
            // 
            this.archiveChBox.AutoSize = true;
            this.archiveChBox.Location = new System.Drawing.Point(29, 75);
            this.archiveChBox.Name = "archiveChBox";
            this.archiveChBox.Size = new System.Drawing.Size(77, 21);
            this.archiveChBox.TabIndex = 2;
            this.archiveChBox.Text = "Archive";
            this.archiveChBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(31, 112);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AttributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 164);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.archiveChBox);
            this.Controls.Add(this.hiddenChBox);
            this.Controls.Add(this.readOnlyChBox);
            this.Name = "AttributeForm";
            this.Text = "Attributes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox readOnlyChBox;
        private System.Windows.Forms.CheckBox hiddenChBox;
        private System.Windows.Forms.CheckBox archiveChBox;
        private System.Windows.Forms.Button okButton;
    }
}