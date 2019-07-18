using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.data
{
    public struct HRDataSize
    {
        public HRDataSize(double value, string prefix)
        {
            Value = value;
            Prefix = prefix;
        }
        public double Value;
        public string Prefix;

        public override string ToString()
        {
            double rounded = Math.Round(Value, 2);
            return string.Format("{0} {1}", rounded, Prefix);
        }
    }
}
