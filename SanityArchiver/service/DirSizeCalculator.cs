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
        private long CurrentDirSize;
        private int CurrentElementNumber;
        private bool AbortCalculation;
        private DirectoryInfo Root;
        
        public void Calculate(DirectoryInfo dir)
        {
            Root = dir;
            AbortCalculation = false;
            CurrentDirSize = 0;
            CurrentElementNumber = 0;
            ThreadStart threadStart = new ThreadStart(StartCalculation);
            Thread th = new Thread(threadStart);
            th.Start();
            
        }
        public void Terminate()
        {
            AbortCalculation = true;
        }

        public DirSizeCalculationData RequestData()
        {
            return new DirSizeCalculationData(CurrentElementNumber, CurrentDirSize);
        }
        private void StartCalculation()
        {
            GetRecursiveSize(Root);
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
            CurrentElementNumber++;
            foreach (FileInfo file in files)
            {
                CurrentDirSize += file.Length;
            }
            foreach (DirectoryInfo dir in dirs)
            {
                try
                {
                    GetRecursiveSize(dir);
                }
                catch (UnauthorizedAccessException) { }
            }
        }
    }
}
