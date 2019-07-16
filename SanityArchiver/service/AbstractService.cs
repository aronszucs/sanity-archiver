using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SanityArchiver.prompter;

namespace SanityArchiver.service
{
    public abstract class AbstractService
    {
        public delegate void RefreshHandler();
        public RefreshHandler OnResponse;
        protected ICollection<FileSystemInfo> SentSources;
        protected FileSystemInfo SentSource;
        protected Prompter Prompter = Prompter.GetInstance();
    }
}
