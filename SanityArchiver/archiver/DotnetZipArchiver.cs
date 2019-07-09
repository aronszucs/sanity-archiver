using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;


namespace SanityArchiver
{
    class DotnetZipArchiver : AbstractArchiver, IArchiver
    {
        private string Password = "anyud";
        public void SetEncoding(string password)
        {
            Password = password;
        }
        public void DisableEncoding()
        {
            Password = null;
        }
        public string GetSuffix()
        {
            return ".zip";
        }
        public void CompressItems(ICollection<FileSystemInfo> inputInfos, DirectoryInfo outputInfo)
        {
            
        }
        public void DecompressItems(ICollection<FileSystemInfo> inputInfos, DirectoryInfo outputInfo)
        {
            
        }
        public void CompressItem(FileSystemInfo inputInfo, string outputInfo)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                HandleEncoding(zip);
                zip.AddFile(inputInfo.FullName);
                zip.Save(outputInfo);
            }
        }
        public void DecompressItem(FileSystemInfo inputInfo, string outputPath)
        {
            using (ZipFile zip = ZipFile.Read(inputInfo.FullName))
            {
                HandleEncoding(zip);
                try
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(outputPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                catch (BadPasswordException)
                {
                    throw new ArchiverException("Bad password!");
                }
            }
        }
        private void HandleEncoding(ZipFile zipFile)
        {
            if (Password != null)
            {
                zipFile.Encryption = EncryptionAlgorithm.WinZipAes256;
                zipFile.Password = Password;
                
            }
        }
    }
}
