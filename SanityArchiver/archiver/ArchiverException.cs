using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SanityArchiver
{
    class ArchiverException : Exception
    {
        public FileSystemInfo DamagedFile { get; private set; }
        public ArchiverException(string msg) : base(msg)
        {
        }
        public ArchiverException()
        {

        }
        public ArchiverException(string msg, FileSystemInfo damagedFile) : base(msg)
        {
            DamagedFile = damagedFile;
        }
    }
}
