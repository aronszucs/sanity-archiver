namespace SanityArchiver.form
{
    partial class PropertyForm
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
            this.components = new System.ComponentModel.Container();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.elementsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.archiveChBox = new System.Windows.Forms.CheckBox();
            this.hiddenChBox = new System.Windows.Forms.CheckBox();
            this.readOnlyChBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(101, 85);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.ReadOnly = true;
            this.sizeTextBox.Size = new System.Drawing.Size(147, 22);
            this.sizeTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elements";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(101, 29);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(147, 22);
            this.nameTextBox.TabIndex = 3;
            // 
            // elementsTextBox
            // 
            this.elementsTextBox.Location = new System.Drawing.Point(101, 57);
            this.elementsTextBox.Name = "elementsTextBox";
            this.elementsTextBox.ReadOnly = true;
            this.elementsTextBox.Size = new System.Drawing.Size(147, 22);
            this.elementsTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // archiveChBox
            // 
            this.archiveChBox.AutoSize = true;
            this.archiveChBox.Location = new System.Drawing.Point(32, 198);
            this.archiveChBox.Name = "archiveChBox";
            this.archiveChBox.Size = new System.Drawing.Size(77, 21);
            this.archiveChBox.TabIndex = 9;
            this.archiveChBox.Text = "Archive";
            this.archiveChBox.UseVisualStyleBackColor = true;
            // 
            // hiddenChBox
            // 
            this.hiddenChBox.AutoSize = true;
            this.hiddenChBox.Location = new System.Drawing.Point(32, 171);
            this.hiddenChBox.Name = "hiddenChBox";
            this.hiddenChBox.Size = new System.Drawing.Size(75, 21);
            this.hiddenChBox.TabIndex = 8;
            this.hiddenChBox.Text = "Hidden";
            this.hiddenChBox.UseVisualStyleBackColor = true;
            // 
            // readOnlyChBox
            // 
            this.readOnlyChBox.AutoSize = true;
            this.readOnlyChBox.Location = new System.Drawing.Point(32, 144);
            this.readOnlyChBox.Name = "readOnlyChBox";
            this.readOnlyChBox.Size = new System.Drawing.Size(94, 21);
            this.readOnlyChBox.TabIndex = 7;
            this.readOnlyChBox.Text = "Read only";
            this.readOnlyChBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(186, 198);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 27);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 265);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.archiveChBox);
            this.Controls.Add(this.hiddenChBox);
            this.Controls.Add(this.readOnlyChBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.elementsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeTextBox);
            this.Name = "PropertyForm";
            this.Text = "Properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PropertyForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox elementsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox archiveChBox;
        private System.Windows.Forms.CheckBox hiddenChBox;
        private System.Windows.Forms.CheckBox readOnlyChBox;
        private System.Windows.Forms.Button okButton;
    }
}