using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.data
{
    public class HRDataSizeConverter
    {

        private static readonly HRDataSize[] Values = 
        {
            new HRDataSize(1024, "kB"),
            new HRDataSize(Math.Pow(1024, 2), "MB"),
            new HRDataSize(Math.Pow(1024, 3), "GB")
        };
        
        public static HRDataSize ConvertBytes(long size)
        {
            for (int i = Values.Length - 1; i >= 0; i--)
            {
                double val = Values[i].Value;
                string prefix = Values[i].Prefix;
                if (size >= val)
                {
                    return new HRDataSize(size / val, prefix);
                }
            }
            return new HRDataSize(size, null);
        }
    }
}
