using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.data
{
    public struct SettableAttributes
    {
        public SettableAttributes(bool isReadOnly, bool isHidden, bool isArchive)
        {
            IsReadOnly = isReadOnly;
            IsHidden = isHidden;
            IsArchive = isArchive;
        }
        public bool IsReadOnly, IsHidden, IsArchive;
    }
}
