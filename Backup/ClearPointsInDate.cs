using System;

namespace Backup
{
    class ClearPointsInDate : ICleaningAlg
    {
        private Backup CurrBackup;
        private DateTime Date;
        public ClearPointsInDate(Backup backup, DateTime date)
        {
            CurrBackup = backup;
            Date = date;
        }
        public int GetClearPointsInDate()
        {
            if (Date > DateTime.Now)
                throw new Exception("Data is not exist!");
            int Counter = 0;
            foreach (var item in CurrBackup.RecPointList)
            {
                if (item.CreationTime >= Date)
                {
                    Counter++;
                }
            }
            return Counter;
        }
        public int GetClearPoints()
        {
            return GetClearPointsInDate();
        }
    }
}
