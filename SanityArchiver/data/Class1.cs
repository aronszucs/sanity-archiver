using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.data
{
    public struct DirSizeCalculationData
    {
        public int Elements;
        public long Size;
        public DirSizeCalculationData(int elements, long size)
        {
            Elements = elements;
            Size = size;
        }
    }
}
