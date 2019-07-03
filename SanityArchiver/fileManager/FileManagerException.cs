using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver
{
    public class FileManagerException : Exception
    {
        public FileManagerException(string msg) : base(msg) {}
    }
}
