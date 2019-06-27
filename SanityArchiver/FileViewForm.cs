using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class FileViewForm : Form
    {
        FileManager LeftFileManager;
        FileManager RightFileManager;
        public FileViewForm()
        {
            InitializeComponent();
            IArchiver archiver = new Archiver();
            LeftFileManager = new FileManager(leftWindow, archiver);
            RightFileManager = new FileManager(rightWindow, archiver, LeftFileManager);
            LeftFileManager.Refresh();
            RightFileManager.Refresh();
        }

        private void LeftWindow_DoubleClick(object sender, MouseEventArgs e)
        {
            LeftFileManager.OnItemDoubleClick();
            
        }

        private void LeftWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeftFileManager.OnSelectionChanged();
        }

        private void RightWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            RightFileManager.OnSelectionChanged();
        }

        private void RightWindow_DoubleClick(object sender, EventArgs e)
        {
            RightFileManager.OnItemDoubleClick();
        }

        private void LeftArchiveButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnArchiveClicked();
        }

        private void RightArchiveButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnArchiveClicked();
        }
    }
}
