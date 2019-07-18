using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SanityArchiver.service
{
    public class FileSeeker
    {
        public List<FileSystemInfo> Seek(String fileName, String dirName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dirName);
            List<FileSystemInfo> files = new List<FileSystemInfo>();
            try
            {
                RecursiveSeek(directoryInfo, files, fileName);
            }
            catch (UnauthorizedAccessException) {}
            return files;
        }
        private void RecursiveSeek(DirectoryInfo rootDirInfo, List<FileSystemInfo> items, String fileName)
        {
            FileSystemInfo[] fileSystemInfos = rootDirInfo.GetFileSystemInfos(fileName);
            DirectoryInfo[] dirInfos = rootDirInfo.GetDirectories();
            foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
            {
                items.Add(fileSystemInfo);
            }
            foreach (DirectoryInfo dirInfo in dirInfos)
            {
                RecursiveSeek(dirInfo, items, fileName);
            }
        }
    }
}
