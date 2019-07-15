using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SanityArchiver.archiver;
using SanityArchiver.forms;
using SanityArchiver.prompter;

namespace SanityArchiver.service
{
    class ArchiveService : AbstractService
    {
        private IArchiver Archiver;
        
        private DirectoryInfo RootDirInfo;

        public ArchiveService(IArchiver archiver)
        {
            Archiver = archiver;
        }
        public void Archive(ICollection<FileSystemInfo> sources, DirectoryInfo rootDirInfo)
        {
            try
            {
                RootDirInfo = rootDirInfo;
                SentSources = sources;
                ArchiverForm af = new ArchiverForm
                    (OnArchiveNameInputResponse,
                     SentSources.ElementAt(0).Name + ".zip");
                af.Show();
            }
            catch (UnauthorizedAccessException e)
            {
                Prompter.HandleError(e);
            }
            catch (IOException e)
            {
                Prompter.HandleError(e);
            }

        }
        public void OnArchiveNameInputResponse(string input, string password)
        {
            if (password != "")
            {
                Archiver.SetEncryption(password);
            }
            Archiver.CompressItems(SentSources, RootDirInfo + "\\" + input);
            Archiver.DisableEncryption();
            OnResponse();
        }
        public void Decompress(ICollection<FileSystemInfo> sources, DirectoryInfo rootDirInfo)
        {
            try
            {
                RootDirInfo = rootDirInfo;
                SentSources = sources;
                ArchiverForm af = new ArchiverForm
                    (OnDecompressInputResponse,
                     SentSources.ElementAt(0).Name);
                af.Show();
            }
            catch (IOException e)
            {
                Prompter.HandleError(e);
            }
        }
        public void OnDecompressInputResponse(string input, string password)
        {
            if (password != "")
            {
                Archiver.SetEncryption(password);
            }
            try
            {
                Archiver.DecompressItem(SentSources.ElementAt(0), RootDirInfo + "\\" + input);
            }
            catch (IOException e)
            {
                Prompter.HandleError(e);
            }
            Archiver.DisableEncryption();
            OnResponse();
        }
    }
}
