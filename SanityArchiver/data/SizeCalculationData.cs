using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.data
{
    public struct SizeCalculationData
    {
        public int Elements;
        public long Size;
        public SizeCalculationData(int elements, long size)
        {
            Elements = elements;
            Size = size;
        }
    }
}
