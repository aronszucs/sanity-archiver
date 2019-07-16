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
using SanityArchiver.data;

namespace SanityArchiver.forms
{
    public partial class MainForm : Form
    {
        private readonly FileManager LeftFileManager;
        private readonly FileManager RightFileManager;
        public MainForm()
        {
            InitializeComponent();
            IArchiver archiver = new DotnetZipArchiver();
            ArchiveService archiveService = new ArchiveService(archiver);
            FileService fileService = new FileService(new FilePathContainer("c:\\"));
            LeftFileManager = new FileManager(leftWindow, archiveService, fileService);
            RightFileManager = new FileManager(rightWindow, archiveService, fileService, LeftFileManager);
            LeftFileManager.AttachPathBar(leftPathTextBox);
            RightFileManager.AttachPathBar(rightPathTextBox);

            LeftFileManager.Refresh();
            RightFileManager.Refresh();
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

        private void MoveButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnMoveClicked();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnCopyClicked();
        }

        private void LeftSetAttributeButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnSetAttributeClicked();
        }

        private void RightMoveButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnMoveClicked();
        }

        private void RightCopyButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnCopyClicked();
        }

        private void RightSetAttributeButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnSetAttributeClicked();
        }

        private void LeftChangeDriveButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnChangeDriveClicked();
        }

        private void RightChangeDriveButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnChangeDriveClicked();
        }

        private void LeftWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LeftFileManager.OnItemDoubleClick();
        }

        private void LeftWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeftFileManager.OnSelectionChanged();
        }
    }
}
