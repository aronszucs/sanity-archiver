using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SanityArchiver.service;

namespace SanityArchiver.fileManager
{
    class FileManager
    {
        public ArchiveRequest OnArchiveRequested;
        public DecompressRequest OnDecompressRequested;
        public RefreshRequest OnRefreshRequested;
        public RootChangeRequest OnRootChangeRequested;

        private static readonly String PREV_DIRECTORY_SYMBOL = "..";
        private static readonly String DIRECTORY_SEPARATOR_SYMBOL = "----------------------";
        private ListBox Window;
        private ArchiveService ArchiveService;
        private DirectoryInfo RootDirInfo;
        private string[] LastSelectedItems;
        private String LastSelectedItem;
        private Dictionary<string, FileSystemInfo> Files = new Dictionary<string, FileSystemInfo>();
        public FileManager(ListBox listBox, ArchiveService archiver)
        {
            Init(listBox, archiver);
        }
        public FileManager(ListBox listBox, ArchiveService archiver, FileManager fileManager)
        {
            Init(listBox, archiver);
            OnArchiveRequested = new ArchiveRequest(fileManager.Archive);
            fileManager.OnArchiveRequested = new ArchiveRequest(Archive);

            OnDecompressRequested = new DecompressRequest(fileManager.Decompress);
            fileManager.OnDecompressRequested = new DecompressRequest(Decompress);

            OnRefreshRequested = new RefreshRequest(fileManager.Refresh);
            fileManager.OnRefreshRequested = new RefreshRequest(Refresh);

            OnRootChangeRequested = new RootChangeRequest(fileManager.ChangeRoot);
            fileManager.OnRootChangeRequested = new RootChangeRequest(ChangeRoot);
        }

        public delegate void ArchiveRequest(ICollection<FileSystemInfo> sources);

        public delegate void DecompressRequest(ICollection<FileSystemInfo> sources);

        public delegate void RefreshRequest();

        public delegate void RootChangeRequest(DirectoryInfo dirInfo);

        private void Init(ListBox listBox, ArchiveService archiver)
        {
            Window = listBox;
            ArchiveService = archiver;
            RootDirInfo = new DirectoryInfo("c:\\");
            LastSelectedItems = new string[0];
            archiver.OnResponse = RefreshBoth;
        }
        public void Refresh()
        {
            FileSystemInfo[] dirs = RootDirInfo.GetDirectories();
            FileSystemInfo[] files = RootDirInfo.GetFiles();
            FileSystemInfo[] fileSystems = new FileSystemInfo[dirs.Length + files.Length];
            Array.Copy(dirs, 0, fileSystems, 0, dirs.Length);
            Array.Copy(files, 0, fileSystems, dirs.Length, files.Length);
            Files.Clear();
            Window.Items.Clear();
            Window.Items.Add(PREV_DIRECTORY_SYMBOL);
            foreach (FileSystemInfo dirInfo in dirs)
            {
                Window.Items.Add(dirInfo.Name);
                Files.Add(dirInfo.Name, dirInfo);
            }
            Window.Items.Add(DIRECTORY_SEPARATOR_SYMBOL);
            foreach (FileSystemInfo fileInfo in files)
            {
                Window.Items.Add(fileInfo.Name);
                Files.Add(fileInfo.Name, fileInfo);
            }
        }
        public void RefreshBoth()
        {
            Refresh();
            OnRefreshRequested();
            
        }
        private List<FileSystemInfo> GetSelected()
        {
            List<FileSystemInfo> selected = new List<FileSystemInfo>();
            foreach (string item in Window.SelectedItems)
            {
                try
                {
                    selected.Add(Files[item]);
                }
                catch (KeyNotFoundException)
                {
                    throw new FileManagerException("Invalid Selection");
                }
            }
            return selected;
        }
        public void OnItemDoubleClick()
        {
            Window.SelectedItems.Clear();
            Window.SelectedItem = LastSelectedItem;
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

        public void OnSelectionChanged()
        {
            foreach (String item in Window.SelectedItems)
            {
                if (!LastSelectedItems.Contains(item))
                {
                    LastSelectedItem = item;
                }
            }
            LastSelectedItems = new string[Window.SelectedItems.Count];
            int i = 0;
            foreach (String item in Window.SelectedItems)
            {
                LastSelectedItems[i] = item;
                i++;
            }
        }

        public void OnAlignRootClicked()
        {
            OnRootChangeRequested(RootDirInfo);
        }

        private void NavigateTo(String dirName)
        {
            
            if (dirName.Equals(PREV_DIRECTORY_SYMBOL))
            {
                RootDirInfo = RootDirInfo.Parent;
            } else
            {
                try
                {
                    DirectoryInfo dirInfo = (DirectoryInfo)Files[dirName];
                    RootDirInfo = new DirectoryInfo(dirInfo.FullName);
                }
                catch (InvalidCastException) {}
                catch (KeyNotFoundException) { }
            }
            Refresh();
        }
       
        public void ChangeRoot(DirectoryInfo dirInfo)
        {
            RootDirInfo = dirInfo;
            Refresh();
        }

        public void NavigateTo(DirectoryInfo dirInfo)
        {
            RootDirInfo = dirInfo;
            Refresh();
        }

        public void Archive(ICollection<FileSystemInfo> sources)
        {
            ArchiveService.Archive(sources, RootDirInfo);
        }
        
        public void Decompress(ICollection<FileSystemInfo> sources)
        {
            ArchiveService.Decompress(sources, RootDirInfo);
        }

       
    }
}
