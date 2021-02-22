using System;
using System.Linq;

namespace Backup
{
    class ClearPointsInSize : ICleaningAlg
    {
        private long SizeMB = 0;
        private Backup CurrBackup;

        public ClearPointsInSize(Backup backup, long size)
        {
            CurrBackup = backup;
            SizeMB = size;
        }
        public int GetClearPointsInSize()
        {
            //long SizeMB
            int Counter = 0;
            long SizeB = SizeMB * (1024 * 1024);
            if (SizeB >= CurrBackup.GetBackupSize())
                throw new Exception("SizeB > BackupSize");
            if (SizeB <= 0)
                throw new Exception("Сhain Size is zero or less than zero");
            long RecPointSize = CurrBackup.GetBackupSize();
            while (RecPointSize > SizeB)
            {
                RecPointSize -= CurrBackup.RecPointList.First().GetSize();
                Counter++;
            }
            return Counter;
        }
        public int GetClearPoints()
        {
            return GetClearPointsInSize();
        }
    }
}
