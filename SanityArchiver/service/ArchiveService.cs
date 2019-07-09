using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SanityArchiver.service
{
    class ArchiveService
    {
        private ICollection<FileSystemInfo> SentSources;
        private IArchiver Archiver;
        public delegate void RefreshHandler();
        private RefreshHandler OnRefresh;
        private DirectoryInfo RootDirInfo;
        public void Archive(ICollection<FileSystemInfo> sources, DirectoryInfo rootDirInfo)
        {
            RootDirInfo = rootDirInfo;
            SentSources = sources;
            ArchiverForm af = new ArchiverForm
                (OnArchiveNameInputResponse,
                 SentSources.ElementAt(0).Name + ".zip");
            af.Show();

        }
        public void OnArchiveNameInputResponse(string input, string password)
        {
            if (password != "")
            {
                Archiver.SetEncryption(password);
            }
            Archiver.CompressItems(SentSources, RootDirInfo + "\\" + input);
            Archiver.DisableEncryption();
            OnRefresh();
        }
        public void Decompress(ICollection<FileSystemInfo> sources)
        {


        }
        public void OnDecompressInputResponse(string input)
        {

        }
    }
}
