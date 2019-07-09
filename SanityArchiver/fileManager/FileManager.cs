using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SanityArchiver
{
    class FileManager
    {
        public ArchiveRequest OnArchiveRequested;
        public DecompressRequest OnDecompressRequested;
        public RefreshRequest OnRefreshRequested;
        public RootChangeRequest OnRootChangeRequested;
        private IArchiver Archiver;

        private static readonly String PREV_DIRECTORY_SYMBOL = "..";
        private static readonly String DIRECTORY_SEPARATOR_SYMBOL = "----------------------";
        private ListBox Window;
        private Prompter Prompter;
        private DirectoryInfo RootDirInfo;
        private string[] LastSelectedItems;
        private String LastSelectedItem;
        private Dictionary<string, FileSystemInfo> Files = new Dictionary<string, FileSystemInfo>();
        private FileSystemInfo SentSource;
        public FileManager(ListBox listBox, IArchiver archiver, Prompter prompter)
        {
            Init(listBox, archiver, prompter);
        }
        public FileManager(ListBox listBox, IArchiver archiver, Prompter prompter, FileManager fileManager)
        {
            Init(listBox, archiver, prompter);
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

        private void Init(ListBox listBox, IArchiver archiver, Prompter prompter)
        {
            Window = listBox;
            Archiver = archiver;
            RootDirInfo = new DirectoryInfo("c:\\");
            LastSelectedItems = new string[0];
            Prompter = prompter;
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
            Refresh();
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
            int count = sources.Count;
            if (count == 1)
            {
                SentSource = sources.ElementAt(0);
                Prompter.HandleInput("Enter archive name",
                                      SentSource.Name + Archiver.GetSuffix(),
                                      OnArchiveNameInputResponse);
            }
            else if (count > 1)
            {
                Archiver.CompressItems(sources, RootDirInfo);
                RefreshBoth();
            }
            
        }
        public void OnArchiveNameInputResponse(string input)
        {
            Archiver.CompressItem(SentSource, RootDirInfo + "\\" + input);
            RefreshBoth();
        }
        public void Decompress(ICollection<FileSystemInfo> sources)
        {
            int count = sources.Count;
            if (count == 1)
            {
                SentSource = sources.ElementAt(0);
                Prompter.HandleInput("Enter file name", SentSource.Name, OnDecompressInputResponse);
            }
            else if (count > 1)
            {
                Archiver.DecompressItems(sources, RootDirInfo);
                RefreshBoth();
            }

        }
        public void OnDecompressInputResponse(string input)
        {
            Archiver.DecompressItem(SentSource, RootDirInfo + "\\" + input);
            RefreshBoth();
        }


        private List<FileSystemInfo> GetSelected()
        {
            List<FileSystemInfo> selected = new List<FileSystemInfo>();
            foreach (string item in Window.SelectedItems)
            {
                try
                {
                    selected.Add(Files[item]);
                } catch (KeyNotFoundException)
                {
                    throw new FileManagerException("Invalid Selection");
                }
            }
            return selected;
        }
    }
}
