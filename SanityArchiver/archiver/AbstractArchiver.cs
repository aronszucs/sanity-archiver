using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SanityArchiver
{
    public abstract class AbstractArchiver
    {
        protected void WriteFile(Stream input, Stream output, string outputPath)
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
            }
            catch (InvalidDataException)
            {
                FileSystemInfo invalidFile = new FileInfo(outputPath);
                invalidFile.Delete();
                throw new InvalidDataException();
            }
        }
    }
}
