using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SanityArchiver.service;
using SanityArchiver.fileManager;
using SanityArchiver.archiver;

namespace SanityArchiver.forms
{
    public partial class FileViewForm : Form
    {
        FileManager LeftFileManager;
        FileManager RightFileManager;
        public FileViewForm()
        {
            InitializeComponent();
            IArchiver archiver = new DotnetZipArchiver();
            ArchiveService archiveService = new ArchiveService(archiver);
            LeftFileManager = new FileManager(leftWindow, archiveService);
            RightFileManager = new FileManager(rightWindow, archiveService, LeftFileManager);
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

        private void LeftDecompressButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnDecompressClicked();
        }

        private void RightDecompressButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnDecompressClicked();
        }

        private void LeftRootAlignButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnAlignRootClicked();
        }

        private void RightRootAlignButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnAlignRootClicked();
        }
    }
}
