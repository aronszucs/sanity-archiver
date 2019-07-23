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
            NavigationService navLeft = new NavigationService(leftWindow, leftPathTextBox);
            NavigationService navRight = new NavigationService(rightWindow, rightPathTextBox);

            LeftFileManager = new FileManager(navLeft, fileService, archiveService);
            RightFileManager = new FileManager(navRight, fileService, archiveService, LeftFileManager);
            

            LeftFileManager.Refresh();
            RightFileManager.Refresh();
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

        private void RightMoveButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnMoveClicked();
        }

        private void RightCopyButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnCopyClicked();
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

        private void RightWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            RightFileManager.OnSelectionChanged();

        }

        private void RightWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RightFileManager.OnItemDoubleClick();
        }

        private void LeftPropertyButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnPropertyClicked();
        }

        private void RightPropertyButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnPropertyClicked();
        }

        private void LeftSearchButton_Click(object sender, EventArgs e)
        {
            LeftFileManager.OnSearchClicked();
        }

        private void RightSearchButton_Click(object sender, EventArgs e)
        {
            RightFileManager.OnSearchClicked();
        }
    }
}
