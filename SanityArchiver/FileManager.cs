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
        private IArchiver Archiver;

        private static readonly String PREV_DIRECTORY_SYMBOL = "..";
        private static readonly String DIRECTORY_SEPARATOR_SYMBOL = "----------------------";
        private ListBox Window;
        private String Path = "";
        private DirectoryInfo RootDirInfo;
        private string[] LastSelectedItems;
        private String LastSelectedItem;
        private Dictionary<string, FileSystemInfo> Files = new Dictionary<string, FileSystemInfo>();
        public FileManager(ListBox listBox, IArchiver archiver)
        {
            Init(listBox, archiver);
        }
        public FileManager(ListBox listBox, IArchiver archiver, FileManager fileManager)
        {
            Init(listBox, archiver);
            OnArchiveRequested = new ArchiveRequest(fileManager.Archive);
            fileManager.OnArchiveRequested = new ArchiveRequest(Archive);
        }

        private void Init(ListBox listBox, IArchiver archiver)
        {
            Window = listBox;
            Archiver = archiver;
            RootDirInfo = new DirectoryInfo("c:\\");
            LastSelectedItems = new string[0];
        }
        public void Refresh()
        {
            //RootDirInfo.Attributes &= ~FileAttributes.ReadOnly;
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

        public void NavigateTo(DirectoryInfo dirInfo)
        {
            RootDirInfo = dirInfo;
            Refresh();
        }

        public void Archive(ICollection<FileSystemInfo> sources)
        {
            Archiver.CompressItems(sources, RootDirInfo);
            Refresh();
        }
        
        public delegate void ArchiveRequest(ICollection<FileSystemInfo> sources);

        private List<FileSystemInfo> GetSelected()
        {
            List<FileSystemInfo> selected = new List<FileSystemInfo>();
            foreach (string item in Window.SelectedItems)
            {
                selected.Add(Files[item]);
            }
            return selected;
        }
    }
}
