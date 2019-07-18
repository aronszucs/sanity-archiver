using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using SanityArchiver.data;

namespace SanityArchiver.service
{
    class DirSizeCalculator
    {
        private long CurrentSize;
        private int CurrentElementNumber;
        private bool AbortCalculation;
        private ICollection<DirectoryInfo> SearchDirRoots;
        
        public void Calculate(ICollection<FileSystemInfo> elements)
        {
            List<FileInfo> files = new List<FileInfo>();
            SearchDirRoots = new List<DirectoryInfo>();

            foreach (FileSystemInfo info in elements)
            {
                try
                {
                    SearchDirRoots.Add((DirectoryInfo)info);
                }
                catch (InvalidCastException)
                {
                    files.Add((FileInfo)info);
                }
            }
            AbortCalculation = false;
            CurrentSize = CalculateFiles(files);
            CurrentElementNumber = files.Count;
            if (SearchDirRoots.Count > 0)
            {
                ThreadStart threadStart = new ThreadStart(StartDirCalculation);
                Thread th = new Thread(threadStart);
                th.Start();
            }
        }

        public void Terminate()
        {
            AbortCalculation = true;
        }

        public SizeCalculationData RequestData()
        {
            return new SizeCalculationData(CurrentElementNumber, CurrentSize);
        }

        private long CalculateFiles(ICollection<FileInfo> files)
        {
            long size = 0;
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }
            return size;
        }

        private void StartDirCalculation()
        {
            foreach (DirectoryInfo dir in SearchDirRoots)
            {
                try
                {
                    GetRecursiveSize(dir);
                }
                catch (UnauthorizedAccessException) { }
            }
        }

        private void GetRecursiveSize(DirectoryInfo root)
        {
            if (AbortCalculation)
            {
                return;
            }
            FileSystemInfo[] elements = root.GetFileSystemInfos();
            DirectoryInfo[] dirs = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            foreach (FileInfo file in files)
            {
                CurrentElementNumber++;
                CurrentSize += file.Length;
            }
            foreach (DirectoryInfo dir in dirs)
            {
                CurrentElementNumber++;

                try
                {
                    GetRecursiveSize(dir);
                }
                catch (UnauthorizedAccessException) { }
            }
        }
    }
}
