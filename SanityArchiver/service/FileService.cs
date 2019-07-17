using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SanityArchiver.form;
using SanityArchiver.data;
using System.Threading;

namespace SanityArchiver.service
{
    class FileService : AbstractService
    {
        public FilePathContainer Root {get; private set; }
        private bool AbortCalculation = false;
        public FileService(FilePathContainer filePathContainer)
        {
            Root = filePathContainer;
        }
        public void Copy(ICollection<FileSystemInfo> items, DirectoryInfo destination)
        {
            foreach (FileSystemInfo item in items)
            {
                try
                {
                    File.Copy(item.FullName, destination.FullName + "\\" + item.Name);
                }
                catch (IOException)
                {
                    Prompter.HandleError(item.Name + " already exists!");
                }
            }
            OnResponse();
        }
        public void Move(ICollection<FileSystemInfo> items, DirectoryInfo destination)
        {
            foreach (FileSystemInfo item in items)
            {
                try
                {
                    File.Move(item.FullName, destination.FullName + "\\" + item.Name);
                }
                catch (IOException e)
                {
                    Prompter.HandleError(e);
                }
            }
            OnResponse();
        }
        public void ViewProperty(ICollection<FileSystemInfo> infos)
        {
            FileSystemInfo info = infos.ElementAt(0);
            SettableAttributes attrs = GetSettableAttributes(infos);
            SentSources = infos;
            try
            {
                DirectoryInfo dir = (DirectoryInfo)info;
                DirSizeCalculator calc = new DirSizeCalculator();
                PropertyForm pr = new PropertyForm
                    (dir.Name, calc.RequestData, calc.Terminate, attrs, OnAttributeResponse);
                calc.Calculate(dir);
            }
            catch (InvalidCastException)
            {
                FileInfo file = (FileInfo)info;
                long size = file.Length;
                PropertyForm pr = new PropertyForm(file.Name, 1, size, attrs, OnAttributeResponse);
            }
        }
        
        private void OnAttributeResponse(SettableAttributes attributes)
        {
            foreach (FileSystemInfo info in SentSources)
            {
                string path = info.FullName;
                RemoveSettableAttributes(path);
                if (attributes.IsReadOnly)
                {
                    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.ReadOnly);
                }
                if (attributes.IsHidden)
                {
                    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                }
                if (attributes.IsArchive)
                {
                    File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Archive);
                }
            }
        }
       
        private void RemoveSettableAttributes(string path)
        {
            File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.ReadOnly);
            File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.Hidden);
            File.SetAttributes(path, File.GetAttributes(path) & ~FileAttributes.Archive);
        }

        private SettableAttributes GetSettableAttributes(ICollection<FileSystemInfo> items)
        {
            bool isReadOnly = true;
            bool isHidden = true;
            bool isArchive = true;
            foreach (FileSystemInfo info in items)
            {
                FileAttributes att = File.GetAttributes(info.FullName);
                if ((att & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    isReadOnly = false;
                }
                if ((att & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    isHidden = false;
                }
                if ((att & FileAttributes.Archive) != FileAttributes.Archive)
                {
                    isArchive = false;
                }
            }
            return new SettableAttributes(isReadOnly, isHidden, isArchive);
        }
    }
}
