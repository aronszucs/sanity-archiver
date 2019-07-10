using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.service
{
    public abstract class AbstractService
    {
        public delegate void RefreshHandler();
        public RefreshHandler OnResponse;
    }
}
