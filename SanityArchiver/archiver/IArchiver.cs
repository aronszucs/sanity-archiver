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
        void CompressItems(ICollection<FileSystemInfo> inputInfos, DirectoryInfo outputInfo);
        void DecompressItems(ICollection<FileSystemInfo> inputInfos, DirectoryInfo outputInfo);
        void CompressItem(FileSystemInfo inputInfo, string outputInfo);
        void DecompressItem(FileSystemInfo inputInfo, string outputInfo);
    }
}
