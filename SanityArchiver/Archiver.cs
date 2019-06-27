using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;



namespace SanityArchiver
{
    public class Archiver : IArchiver
    {
        public void CompressItems(ICollection<FileSystemInfo> inputInfos, DirectoryInfo outputInfo)
        {
            foreach (FileSystemInfo info in inputInfos)
            {
                CompressItem(info, outputInfo);
            }
        }

        private void CompressItem(FileSystemInfo inputInfo, DirectoryInfo outputInfo)
        {

            FileStream input = new FileStream
                (inputInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            
            FileStream output = new FileStream
                (outputInfo.FullName + "\\" +inputInfo.Name + ".gz", FileMode.Create, FileAccess.Write, FileShare.Write);
            GZipStream compressor = new GZipStream(output, CompressionMode.Compress);
            int b = 0;
            while (b != -1)
            {
                b = input.ReadByte();
                compressor.WriteByte((byte)b);
            }
            compressor.Close();
            input.Close();
            output.Close();
        }
    }
}
