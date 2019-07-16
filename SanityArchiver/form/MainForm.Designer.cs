using System.Windows.Forms;



namespace SanityArchiver.forms
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "",
            ""}, -1);
            this.leftArchiveButton = new System.Windows.Forms.Button();
            this.rightArchiveButton = new System.Windows.Forms.Button();
            this.leftDecompressButton = new System.Windows.Forms.Button();
            this.rightDecompressButton = new System.Windows.Forms.Button();
            this.leftRootAlignButton = new System.Windows.Forms.Button();
            this.rightRootAlignButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.copyButton = new System.Windows.Forms.Button();
            this.leftSetAttributeButton = new System.Windows.Forms.Button();
            this.rightSetAttributeButton = new System.Windows.Forms.Button();
            this.rightCopyButton = new System.Windows.Forms.Button();
            this.rightMoveButton = new System.Windows.Forms.Button();
            this.leftPathTextBox = new System.Windows.Forms.TextBox();
            this.rightPathTextBox = new System.Windows.Forms.TextBox();
            this.leftChangeDriveButton = new System.Windows.Forms.Button();
            this.rightChangeDriveButton = new System.Windows.Forms.Button();
            this.leftWindow = new System.Windows.Forms.ListView();
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rightWindow = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leftPropertyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftArchiveButton
            // 
            this.leftArchiveButton.Location = new System.Drawing.Point(515, 77);
            this.leftArchiveButton.Name = "leftArchiveButton";
            this.leftArchiveButton.Size = new System.Drawing.Size(83, 37);
            this.leftArchiveButton.TabIndex = 2;
            this.leftArchiveButton.Text = "Archive";
            this.leftArchiveButton.UseVisualStyleBackColor = true;
            this.leftArchiveButton.Click += new System.EventHandler(this.LeftArchiveButton_Click);
            // 
            // rightArchiveButton
            // 
            this.rightArchiveButton.Location = new System.Drawing.Point(1121, 79);
            this.rightArchiveButton.Name = "rightArchiveButton";
            this.rightArchiveButton.Size = new System.Drawing.Size(83, 37);
            this.rightArchiveButton.TabIndex = 3;
            this.rightArchiveButton.Text = "Archive";
            this.rightArchiveButton.UseVisualStyleBackColor = true;
            this.rightArchiveButton.Click += new System.EventHandler(this.RightArchiveButton_Click);
            // 
            // leftDecompressButton
            // 
            this.leftDecompressButton.Location = new System.Drawing.Point(515, 120);
            this.leftDecompressButton.Name = "leftDecompressButton";
            this.leftDecompressButton.Size = new System.Drawing.Size(83, 37);
            this.leftDecompressButton.TabIndex = 4;
            this.leftDecompressButton.Text = "Unpack";
            this.leftDecompressButton.UseVisualStyleBackColor = true;
            this.leftDecompressButton.Click += new System.EventHandler(this.LeftDecompressButton_Click);
            // 
            // rightDecompressButton
            // 
            this.rightDecompressButton.Location = new System.Drawing.Point(1121, 122);
            this.rightDecompressButton.Name = "rightDecompressButton";
            this.rightDecompressButton.Size = new System.Drawing.Size(83, 37);
            this.rightDecompressButton.TabIndex = 5;
            this.rightDecompressButton.Text = "Unpack";
            this.rightDecompressButton.UseVisualStyleBackColor = true;
            this.rightDecompressButton.Click += new System.EventHandler(this.RightDecompressButton_Click);
            // 
            // leftRootAlignButton
            // 
            this.leftRootAlignButton.Location = new System.Drawing.Point(639, 12);
            this.leftRootAlignButton.Name = "leftRootAlignButton";
            this.leftRootAlignButton.Size = new System.Drawing.Size(74, 33);
            this.leftRootAlignButton.TabIndex = 6;
            this.leftRootAlignButton.Text = "<==";
            this.leftRootAlignButton.UseVisualStyleBackColor = true;
            this.leftRootAlignButton.Click += new System.EventHandler(this.LeftRootAlignButton_Click);
            // 
            // rightRootAlignButton
            // 
            this.rightRootAlignButton.Location = new System.Drawing.Point(435, 12);
            this.rightRootAlignButton.Name = "rightRootAlignButton";
            this.rightRootAlignButton.Size = new System.Drawing.Size(74, 33);
            this.rightRootAlignButton.TabIndex = 7;
            this.rightRootAlignButton.Text = "==>";
            this.rightRootAlignButton.UseVisualStyleBackColor = true;
            this.rightRootAlignButton.Click += new System.EventHandler(this.RightRootAlignButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(515, 163);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(83, 36);
            this.moveButton.TabIndex = 8;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(515, 205);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(83, 36);
            this.copyButton.TabIndex = 9;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // leftSetAttributeButton
            // 
            this.leftSetAttributeButton.Location = new System.Drawing.Point(515, 247);
            this.leftSetAttributeButton.Name = "leftSetAttributeButton";
            this.leftSetAttributeButton.Size = new System.Drawing.Size(83, 36);
            this.leftSetAttributeButton.TabIndex = 10;
            this.leftSetAttributeButton.Text = "Attr";
            this.leftSetAttributeButton.UseVisualStyleBackColor = true;
            this.leftSetAttributeButton.Click += new System.EventHandler(this.LeftSetAttributeButton_Click);
            // 
            // rightSetAttributeButton
            // 
            this.rightSetAttributeButton.Location = new System.Drawing.Point(1121, 249);
            this.rightSetAttributeButton.Name = "rightSetAttributeButton";
            this.rightSetAttributeButton.Size = new System.Drawing.Size(83, 36);
            this.rightSetAttributeButton.TabIndex = 13;
            this.rightSetAttributeButton.Text = "Attr";
            this.rightSetAttributeButton.UseVisualStyleBackColor = true;
            this.rightSetAttributeButton.Click += new System.EventHandler(this.RightSetAttributeButton_Click);
            // 
            // rightCopyButton
            // 
            this.rightCopyButton.Location = new System.Drawing.Point(1121, 207);
            this.rightCopyButton.Name = "rightCopyButton";
            this.rightCopyButton.Size = new System.Drawing.Size(83, 36);
            this.rightCopyButton.TabIndex = 12;
            this.rightCopyButton.Text = "Copy";
            this.rightCopyButton.UseVisualStyleBackColor = true;
            this.rightCopyButton.Click += new System.EventHandler(this.RightCopyButton_Click);
            // 
            // rightMoveButton
            // 
            this.rightMoveButton.Location = new System.Drawing.Point(1121, 165);
            this.rightMoveButton.Name = "rightMoveButton";
            this.rightMoveButton.Size = new System.Drawing.Size(83, 36);
            this.rightMoveButton.TabIndex = 11;
            this.rightMoveButton.Text = "Move";
            this.rightMoveButton.UseVisualStyleBackColor = true;
            this.rightMoveButton.Click += new System.EventHandler(this.RightMoveButton_Click);
            // 
            // leftPathTextBox
            // 
            this.leftPathTextBox.Location = new System.Drawing.Point(33, 51);
            this.leftPathTextBox.Name = "leftPathTextBox";
            this.leftPathTextBox.ReadOnly = true;
            this.leftPathTextBox.Size = new System.Drawing.Size(476, 22);
            this.leftPathTextBox.TabIndex = 14;
            // 
            // rightPathTextBox
            // 
            this.rightPathTextBox.Location = new System.Drawing.Point(639, 51);
            this.rightPathTextBox.Name = "rightPathTextBox";
            this.rightPathTextBox.ReadOnly = true;
            this.rightPathTextBox.Size = new System.Drawing.Size(476, 22);
            this.rightPathTextBox.TabIndex = 15;
            // 
            // leftChangeDriveButton
            // 
            this.leftChangeDriveButton.Location = new System.Drawing.Point(33, 17);
            this.leftChangeDriveButton.Name = "leftChangeDriveButton";
            this.leftChangeDriveButton.Size = new System.Drawing.Size(133, 28);
            this.leftChangeDriveButton.TabIndex = 16;
            this.leftChangeDriveButton.Text = "Change drive";
            this.leftChangeDriveButton.UseVisualStyleBackColor = true;
            this.leftChangeDriveButton.Click += new System.EventHandler(this.LeftChangeDriveButton_Click);
            // 
            // rightChangeDriveButton
            // 
            this.rightChangeDriveButton.Location = new System.Drawing.Point(982, 17);
            this.rightChangeDriveButton.Name = "rightChangeDriveButton";
            this.rightChangeDriveButton.Size = new System.Drawing.Size(133, 28);
            this.rightChangeDriveButton.TabIndex = 17;
            this.rightChangeDriveButton.Text = "Change drive";
            this.rightChangeDriveButton.UseVisualStyleBackColor = true;
            this.rightChangeDriveButton.Click += new System.EventHandler(this.RightChangeDriveButton_Click);
            // 
            // leftWindow
            // 
            this.leftWindow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file,
            this.size});
            this.leftWindow.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.leftWindow.Location = new System.Drawing.Point(33, 79);
            this.leftWindow.Name = "leftWindow";
            this.leftWindow.Size = new System.Drawing.Size(476, 402);
            this.leftWindow.TabIndex = 18;
            this.leftWindow.UseCompatibleStateImageBehavior = false;
            this.leftWindow.View = System.Windows.Forms.View.Details;
            this.leftWindow.SelectedIndexChanged += new System.EventHandler(this.LeftWindow_SelectedIndexChanged);
            this.leftWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LeftWindow_MouseDoubleClick);
            // 
            // file
            // 
            this.file.Text = "Item";
            this.file.Width = 160;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.size.Width = 88;
            // 
            // rightWindow
            // 
            this.rightWindow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.rightWindow.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.rightWindow.Location = new System.Drawing.Point(639, 79);
            this.rightWindow.Name = "rightWindow";
            this.rightWindow.Size = new System.Drawing.Size(476, 402);
            this.rightWindow.TabIndex = 19;
            this.rightWindow.UseCompatibleStateImageBehavior = false;
            this.rightWindow.View = System.Windows.Forms.View.Details;
            this.rightWindow.SelectedIndexChanged += new System.EventHandler(this.RightWindow_SelectedIndexChanged);
            this.rightWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RightWindow_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // leftPropertyButton
            // 
            this.leftPropertyButton.Location = new System.Drawing.Point(515, 289);
            this.leftPropertyButton.Name = "leftPropertyButton";
            this.leftPropertyButton.Size = new System.Drawing.Size(83, 36);
            this.leftPropertyButton.TabIndex = 20;
            this.leftPropertyButton.Text = "Prop";
            this.leftPropertyButton.UseVisualStyleBackColor = true;
            this.leftPropertyButton.Click += new System.EventHandler(this.LeftPropertyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 524);
            this.Controls.Add(this.leftPropertyButton);
            this.Controls.Add(this.rightWindow);
            this.Controls.Add(this.leftWindow);
            this.Controls.Add(this.rightChangeDriveButton);
            this.Controls.Add(this.leftChangeDriveButton);
            this.Controls.Add(this.rightPathTextBox);
            this.Controls.Add(this.leftPathTextBox);
            this.Controls.Add(this.rightSetAttributeButton);
            this.Controls.Add(this.rightCopyButton);
            this.Controls.Add(this.rightMoveButton);
            this.Controls.Add(this.leftSetAttributeButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.rightRootAlignButton);
            this.Controls.Add(this.leftRootAlignButton);
            this.Controls.Add(this.rightDecompressButton);
            this.Controls.Add(this.leftDecompressButton);
            this.Controls.Add(this.rightArchiveButton);
            this.Controls.Add(this.leftArchiveButton);
            this.Name = "MainForm";
            this.Text = "WinSanity Archiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button leftArchiveButton;
        private System.Windows.Forms.Button rightArchiveButton;
        private System.Windows.Forms.Button leftDecompressButton;
        private System.Windows.Forms.Button rightDecompressButton;
        private System.Windows.Forms.Button leftRootAlignButton;
        private System.Windows.Forms.Button rightRootAlignButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button leftSetAttributeButton;
        private System.Windows.Forms.Button rightSetAttributeButton;
        private System.Windows.Forms.Button rightCopyButton;
        private System.Windows.Forms.Button rightMoveButton;
        private System.Windows.Forms.TextBox leftPathTextBox;
        private System.Windows.Forms.TextBox rightPathTextBox;
        private System.Windows.Forms.Button leftChangeDriveButton;
        private System.Windows.Forms.Button rightChangeDriveButton;
        private System.Windows.Forms.ListView leftWindow;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ColumnHeader size;
        private ListView rightWindow;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button leftPropertyButton;
    }
}

