﻿using System;
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
                try
                {
                    CompressItem(info, outputInfo.FullName + info.Name + ".gz");
                }
                catch (InvalidDataException)
                {
                    throw new ArchiverException(info.Name + " can't be compressed");
                }
            }
        }
        public void DecompressItems(ICollection<FileSystemInfo> inputInfos, DirectoryInfo outputInfo)
        {
            foreach (FileSystemInfo info in inputInfos)
            {
                try
                {
                    DecompressItem
                        (info, outputInfo.FullName + info.Name.Substring(0, info.Name.Length - 3));
                }
                catch (InvalidDataException)
                {
                    throw new ArchiverException(info.Name + " can't be decompressed.");
                }
            }
        }

        public void CompressItem(FileSystemInfo inputInfo, string outputPath)
        {
            using (FileStream input = new FileStream
                (inputInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (FileStream output = new FileStream
                (outputPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            using (GZipStream compressor = new GZipStream(output, CompressionMode.Compress))
            {
                WriteFile(input, compressor, outputPath);
            }
        }
        public void DecompressItem(FileSystemInfo inputInfo, string outputPath)
        {
            using (FileStream input = new FileStream
                (inputInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (GZipStream compressor = new GZipStream(input, CompressionMode.Decompress))
            using (FileStream output = new FileStream
                (outputPath, FileMode.Create, FileAccess.Write, FileShare.Delete))
            {
                WriteFile(compressor, output, outputPath);
            }
        }
        private void WriteFile(Stream input, Stream output, string outputPath)
        {
            try
            {
                while (true)
                {
                    int b = input.ReadByte();
                    if (b == -1)
                    {
                        break;
                    }
                    output.WriteByte((byte)b);
                }
            } catch (InvalidDataException)
            {
                FileSystemInfo invalidFile = new FileInfo(outputPath);
                invalidFile.Delete();
                throw new InvalidDataException();
            }
        }
    }
}
