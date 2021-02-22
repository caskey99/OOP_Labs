using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backup
{
    class DeltaRecoveryPoint : FullRecoveryPoint
    {
        public DeltaRecoveryPoint(List<FileInfo> FileCopyList, List<RecoveryPoint> RecPointList) : base(FileCopyList)
        {
            if (RecPointList.Count == 0)
                new FullRecoveryPoint(FileCopyList);
            else
            {
                var NowRec = new FullRecoveryPoint(FileCopyList);
                List<FileInfo> CurrFile = new List<FileInfo>();
                CurrFile.AddRange(FileCopyList);
                foreach (var item in RecPointList.Last().FileCopyList)
                {
                    foreach (var jtem in NowRec.FileCopyList)
                    {
                        if (item.Name == jtem.Name)
                        {
                            if ((item.LastWriteTime == jtem.LastWriteTime))
                            {
                                CurrFile.Remove(jtem);
                            }
                        }
                    }
                }
                RecPointList.Last().IsDelta = true;
                new FullRecoveryPoint(CurrFile);
            }
        }
    }
    
}
