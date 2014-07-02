using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shiphrator
{
    struct FileData
    {
        public readonly ulong[] data;
        public readonly byte[] moduleData;
        public FileData(ulong[] data, byte[] moduleData)
        {
            this.data = data;
            this.moduleData = moduleData;
        }
    }
}
