using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SanityArchiver.data
{
    public class FilePathContainer
    {
        public DirectoryInfo Path { get; set; }
        public FilePathContainer(DirectoryInfo path)
        {
            Init(path);
        }
        public FilePathContainer(string path)
        {
            Init(new DirectoryInfo(path));
        }
        private void Init(DirectoryInfo path)
        {
            Path = path;
        }
    }
}
