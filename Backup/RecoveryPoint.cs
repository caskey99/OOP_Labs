using System;
using System.IO;
using System.Collections.Generic;

namespace Backup
{
    public class RecoveryPoint
    {
        public DateTime CreationTime;
        public bool IsDelta = false;
        public List<FileInfo> FileCopyList = new List<FileInfo>();
        public RecoveryPoint(List <FileInfo> FileList)
        {
            FileCopyList.AddRange(FileList);
            CreationTime = DateTime.Now;
        }
        public long GetSize()
        {
            long RecoveryPointSize = 0;
            foreach (var jtem in FileCopyList)
                RecoveryPointSize += jtem.Length;
            return RecoveryPointSize;
        }
    }
}
