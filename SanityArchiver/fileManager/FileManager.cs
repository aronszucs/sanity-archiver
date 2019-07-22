using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SanityArchiver.service;
using SanityArchiver.prompter;
using SanityArchiver.form;
using SanityArchiver.data;

namespace SanityArchiver.fileManager
{

    public delegate void FileSystemRequest(ICollection<FileSystemInfo> sources);
    public delegate void ActionRequest();
    public delegate void DirectoryRequest(DirectoryInfo dirInfo);
    public delegate void RefreshRequest();
    public delegate void RootChangeRequest(DirectoryInfo dirInfo);

    class FileManager
    {
        private ActionRequest OnRefreshRequested;
        private DirectoryRequest OnRootChangeRequested;

        public FileSystemRequest OnArchiveRequested;
        public FileSystemRequest OnDecompressRequested;
        public FileSystemRequest OnCopyRequested;
        public FileSystemRequest OnMoveRequested;
        
        private ArchiveService ArchiveService;
        private FileService FileService;
        private NavigationService NavService;
        private Prompter Prompter = Prompter.GetInstance();
        private FilePathContainer Root;


        public FileManager(NavigationService navService, FileService fileService, ArchiveService archiver)
        {
            Init(navService, fileService, archiver);
        }

        public FileManager(NavigationService navService, FileService fileService, ArchiveService archiver, FileManager fileManager)
        {
            Init(navService, fileService, archiver);
            OnArchiveRequested = new FileSystemRequest(fileManager.Archive);
            fileManager.OnArchiveRequested = new FileSystemRequest(Archive);

            OnDecompressRequested = new FileSystemRequest(fileManager.Decompress);
            fileManager.OnDecompressRequested = new FileSystemRequest(Decompress);

            OnCopyRequested = new FileSystemRequest(fileManager.Copy);
            fileManager.OnCopyRequested = new FileSystemRequest(Copy);

            OnMoveRequested = new FileSystemRequest(fileManager.Move);
            fileManager.OnMoveRequested = new FileSystemRequest(Move);

            OnRefreshRequested = new ActionRequest(fileManager.Refresh);
            fileManager.OnRefreshRequested = new ActionRequest(Refresh);

            OnRootChangeRequested = new DirectoryRequest(fileManager.ChangeRoot);
            fileManager.OnRootChangeRequested = new DirectoryRequest(ChangeRoot);
        }

        private void Init(NavigationService navService, FileService fileService, ArchiveService archiver)
        {
            NavService = navService;
            ArchiveService = archiver;
            ArchiveService.OnResponse = RefreshBoth;
            FileService = fileService;
            FileService.OnResponse = RefreshBoth;
            Root = NavService.Root;
            FileService.Root = NavService.Root;
        }

        // Navigation methods

        
        // Clicks and other form calls

        public void OnItemDoubleClick()
        {
            NavService.OnItemDoubleClick();
        }

        public void OnArchiveClicked()
        {
            OnArchiveRequested(NavService.Selected);
        }

        public void OnDecompressClicked()
        {
            OnDecompressRequested(NavService.Selected);
        }

        public void OnCopyClicked()
        {
            OnCopyRequested(NavService.Selected);
        }

        public void OnMoveClicked()
        {
            OnMoveRequested(NavService.Selected);
        }

        public void OnAlignRootClicked()
        {
            OnRootChangeRequested(Root.Path);
        }

        public void OnPropertyClicked()
        {
            FileService.ViewProperty(NavService.Selected);
        }

        public void OnSearchClicked()
        {
            FileService.Search(NavService.OnSearchResponse);
        }

        public void OnSelectionChanged()
        {
            NavService.OnSelectionChanged();
        }

        // Service wrappers

        public void ChangeRoot(DirectoryInfo dirInfo)
        {
            NavService.ChangeRoot(dirInfo);
        }

        public void OnChangeDriveClicked()
        {
            NavService.ChangeDrive();
        }

        public void Refresh()
        {
            NavService.Refresh();
        }

        public void RefreshBoth()
        {
            Refresh();
            OnRefreshRequested();
        }

        public void Archive(ICollection<FileSystemInfo> sources)
        {
             ArchiveService.Archive(sources, Root.Path);
        }

        public void Decompress(ICollection<FileSystemInfo> sources)
        {
             ArchiveService.Decompress(sources, Root.Path);
        }

        public void Move(ICollection<FileSystemInfo> items)
        {
            FileService.Move(items, Root.Path);
        }

        public void Copy(ICollection<FileSystemInfo> items)
        {
           FileService.Copy(items, Root.Path);
        }
    }
}
