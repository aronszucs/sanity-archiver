using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SanityArchiver.service
{
    class FileService : AbstractService
    {
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
                    throw new ServiceException(item.Name + " already exists!");
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
                catch (IOException)
                {
                    throw new ServiceException(item.Name + " already exists!");
                }
            }
            OnResponse();
        }
    }
}
