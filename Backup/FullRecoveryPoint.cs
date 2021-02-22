using System;
using System.Collections.Generic;
using System.IO;

namespace Backup
{
    public class FullRecoveryPoint : RecoveryPoint
    {
        public FullRecoveryPoint(List<FileInfo> FileCopyList) : base(FileCopyList)
        {
            CreationTime = DateTime.Now;
        }
    }
}
