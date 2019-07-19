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
    class FileManager
    {
        public FileSystemRequest OnArchiveRequested;
        public FileSystemRequest OnDecompressRequested;
        public RefreshRequest OnRefreshRequested;
        public RootChangeRequest OnRootChangeRequested;
        public FileSystemRequest OnCopyRequested;
        public FileSystemRequest OnMoveRequested;
        
        private ArchiveService ArchiveService;
        private FileService FileService;
        private Prompter Prompter = Prompter.GetInstance();
        private FilePathContainer Root;
        private string[] LastSelectedItems;
        private string LastSelectedItem;
        private Dictionary<string, FileSystemInfo> Files = new Dictionary<string, FileSystemInfo>();

        public delegate void FileSystemRequest(ICollection<FileSystemInfo> sources);
        public delegate void RefreshRequest();
        public delegate void RootChangeRequest(DirectoryInfo dirInfo);

        public FileManager(ListView listBox, ArchiveService archiver, FileService fileService)
        {
            Init(listBox, archiver, fileService);
        }
        public FileManager(ListView listBox, ArchiveService archiver, FileService fileService, FileManager fileManager)
        {
            Init(listBox, archiver, fileService);
            OnArchiveRequested = new FileSystemRequest(fileManager.Archive);
            fileManager.OnArchiveRequested = new FileSystemRequest(Archive);

            OnDecompressRequested = new FileSystemRequest(fileManager.Decompress);
            fileManager.OnDecompressRequested = new FileSystemRequest(Decompress);

            OnCopyRequested = new FileSystemRequest(fileManager.Copy);
            fileManager.OnCopyRequested = new FileSystemRequest(Copy);

            OnMoveRequested = new FileSystemRequest(fileManager.Move);
            fileManager.OnMoveRequested = new FileSystemRequest(Move);

            OnRefreshRequested = new RefreshRequest(fileManager.Refresh);
            fileManager.OnRefreshRequested = new RefreshRequest(Refresh);

            OnRootChangeRequested = new RootChangeRequest(fileManager.ChangeRoot);
            fileManager.OnRootChangeRequested = new RootChangeRequest(ChangeRoot);
        }

        

        private void Init(ListView listBox, ArchiveService archiver, FileService fileService)
        {
            ArchiveService = archiver;
            ArchiveService.OnResponse = RefreshBoth;
            FileService = fileService;
            FileService.OnResponse = RefreshBoth;
            Root = FileService.Root;
            LastSelectedItems = new string[0];
        }

        // Navigation methods

        
        // Clicks and other form calls

        public void OnItemDoubleClick()
        {
            Window.SelectedItems.Clear();
            NavigateTo(LastSelectedItem);
        }

        public void OnArchiveClicked()
        {
            OnArchiveRequested(GetSelected());
        }

        public void OnDecompressClicked()
        {
            OnDecompressRequested(GetSelected());
        }

        public void OnCopyClicked()
        {
            OnCopyRequested(GetSelected());
        }

        public void OnMoveClicked()
        {
            OnMoveRequested(GetSelected());
        }

        public void OnChangeDriveClicked()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveForm df = new DriveForm(drives, OnChangeDriveResponse);
        }

        public void OnAlignRootClicked()
        {
            OnRootChangeRequested(Root.Path);
        }

        public void OnPropertyClicked()
        {
            FileService.ViewProperty(GetSelected());
        }

        public void OnSearchClicked()
        {
            FileService.OnSearchCompleted = OnSearchResponse;
            FileService.Search(OnSearchResponse);
        }

        public void OnSelectionChanged()
        {
            foreach (ListViewItem item in Window.SelectedItems)
            {
                string name = item.Text;
                if (!LastSelectedItems.Contains(name))
                {
                    LastSelectedItem = name;
                }
            }
            LastSelectedItems = new string[Window.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in Window.SelectedItems)
            {
                string name = item.Text;

                LastSelectedItems[i] = name;
                i++;
            }
        }

        // Responses

        private void OnChangeDriveResponse(string drive)
        {
            Root.Path = new DirectoryInfo(drive);
            Refresh();
        }

        private void OnSearchResponse(ICollection<DirectoryInfo> dirs, ICollection<FileInfo> files)
        {
            TryRefresh(dirs, files);
        }

        // Service wrappers

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
