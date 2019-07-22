using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanityArchiver.prompter;
using SanityArchiver.form;
using SanityArchiver.data;
using System.Windows.Forms;
using System.IO;
using SanityArchiver.fileManager;


namespace SanityArchiver.service
{
    
    class NavigationService
    {
        private static readonly string PREV_DIRECTORY_SYMBOL = "........................";
        private static readonly string DIRECTORY_SEPARATOR_SYMBOL = "----------------------";

        private ListView Window;
        private TextBox PathBar;

        private Prompter Prompter = Prompter.GetInstance();

        public FilePathContainer Root { get; private set; }
        private Dictionary<string, FileSystemInfo> Files = new Dictionary<string, FileSystemInfo>();

        private string[] LastSelectedItems = new string[0];
        private string LastSelectedItem;

        public NavigationService(ListView window, TextBox pathBar)
        {
            Window = window;
            PathBar = pathBar;
            Root = new FilePathContainer("c:\\");
        }

        public ICollection<FileSystemInfo> Selected
        {
            get
            {
                List<FileSystemInfo> selected = new List<FileSystemInfo>();
                foreach (ListViewItem item in Window.SelectedItems)
                {
                    string name = item.Text;
                    try
                    {
                        selected.Add(Files[name]);
                    }
                    catch (KeyNotFoundException)
                    {
                        throw new FileManagerException("Invalid Selection");
                    }
                }
                return selected;
            }
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

        public void OnItemDoubleClick()
        {
            Window.SelectedItems.Clear();
            NavigateTo(LastSelectedItem);
        }

        public void AttachPathBar(TextBox pathBarTextBox)
        {
            PathBar = pathBarTextBox;
        }

        public void Refresh()
        {
            try
            {
                DirectoryInfo[] dirs = Root.Path.GetDirectories();
                FileInfo[] files = Root.Path.GetFiles();
                TryRefresh(dirs, files);
            }
            catch (IOException e)
            {
                Prompter.HandleError(e);
            }

            catch (UnauthorizedAccessException e)
            {
                Prompter.HandleError(e);
            }
        }

        private void TryRefresh(ICollection<DirectoryInfo> dirs, ICollection<FileInfo> files)
        {

            Files.Clear();
            Window.Items.Clear();
            Window.Items.Add(PREV_DIRECTORY_SYMBOL);
            foreach (FileSystemInfo dirInfo in dirs)
            {
                AddElement(dirInfo);
            }
            Window.Items.Add(DIRECTORY_SEPARATOR_SYMBOL);
            foreach (FileSystemInfo fileInfo in files)
            {
                AddElement(fileInfo);
            }
            if (PathBar != null)
            {
                PathBar.Text = Root.Path.FullName;
            }
        }

        private void AddElement(FileSystemInfo info)
        {
            string size;
            try
            {
                FileInfo fileInfo = (FileInfo)info;
                size = HRDataSizeConverter.ConvertBytes(fileInfo.Length).ToString();
            }
            catch (InvalidCastException)
            {
                size = "";
            }
            Window.Items.Add(info.Name).SubItems.Add(size);
            Files.Add(info.Name, info);
        }

        private List<FileSystemInfo> GetSelected()
        {
            List<FileSystemInfo> selected = new List<FileSystemInfo>();
            foreach (ListViewItem item in Window.SelectedItems)
            {
                string name = item.Text;
                try
                {
                    selected.Add(Files[name]);
                }
                catch (KeyNotFoundException)
                {
                    throw new FileManagerException("Invalid Selection");
                }
            }
            return selected;
        }

        private void NavigateTo(String dirName)
        {
            if (dirName.Equals(PREV_DIRECTORY_SYMBOL))
            {
                DirectoryInfo prev = Root.Path;
                Root.Path = Root.Path.Parent;
                try
                {
                    Refresh();
                }
                catch (NullReferenceException)
                {
                    Root.Path = prev;
                }
            }
            else
            {
                try
                {
                    DirectoryInfo dirInfo = (DirectoryInfo)Files[dirName];
                    NavigateToDir(dirInfo);
                }
                catch (InvalidCastException)
                {
                    DirectoryInfo dirInfo = ((FileInfo)Files[dirName]).Directory;
                    NavigateToDir(dirInfo);
                }
                catch (KeyNotFoundException) { }
            }
        }

        private void NavigateToDir(DirectoryInfo dirInfo)
        {
            Root.Path = new DirectoryInfo(dirInfo.FullName);
            Refresh();
        }

        public void ChangeRoot(DirectoryInfo dirInfo)
        {
            Root.Path = dirInfo;
            Refresh();
        }

        public void ChangeDrive()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveForm df = new DriveForm(drives, OnChangeDriveResponse);
        }

        public void NavigateTo(DirectoryInfo dirInfo)
        {
            Root.Path = dirInfo;
            Refresh();
        }

        // Response
        private void OnChangeDriveResponse(string drive)
        {
            Root.Path = new DirectoryInfo(drive);
            Refresh();
        }

        public void OnSearchResponse(ICollection<DirectoryInfo> dirs, ICollection<FileInfo> files)
        {
            TryRefresh(dirs, files);
        }

    }
}
