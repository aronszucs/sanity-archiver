using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SanityArchiver
{
    interface IArchiver
    {
        string GetSuffix();
        void SetEncryption(string password);
        void DisableEncryption();
        void CompressItems(ICollection<FileSystemInfo> inputInfos, string outputInfo);
        void DecompressItems(ICollection<FileSystemInfo> inputInfos, string outputInfo);
        void CompressItem(FileSystemInfo inputInfo, string outputInfo);
        void DecompressItem(FileSystemInfo inputInfo, string outputInfo);
    }
}
