using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanityArchiver.prompter;
using SanityArchiver.form;
using SanityArchiver.data;
using System.Windows.Forms;


namespace SanityArchiver.service
{
    class NavigationService
    {
        private static readonly string PREV_DIRECTORY_SYMBOL = "........................";
        private static readonly string DIRECTORY_SEPARATOR_SYMBOL = "----------------------";

        private ListView Window;
        private TextBox PathBar;

        private Prompter Prompter = Prompter.GetInstance();

        private FilePathContainer Root;

        public NavigationService(ListView window, TextBox pathBar)
        {
            Window = window;
            PathBar = pathBar;
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

        public void RefreshBoth()
        {
            Refresh();
            OnRefreshRequested();
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

        public void NavigateTo(DirectoryInfo dirInfo)
        {
            Root.Path = dirInfo;
            Refresh();
        }

    }
}
