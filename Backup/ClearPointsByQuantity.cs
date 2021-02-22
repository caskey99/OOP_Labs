using System;

namespace Backup
{
    class ClearPointsByQuantity : ICleaningAlg
    {
        private int Quantity = 0;
        private Backup CurrBackup;

        public ClearPointsByQuantity(Backup backup, int quantity)
        {
            CurrBackup = backup;
            Quantity = quantity;
        }

        public int GetClearPointsByQuantity()
        {
            int Counter = 0;
            if (Quantity >= CurrBackup.RecPointList.Count)
                throw new Exception("Quantity not exist!");
            if (Quantity <= 0)
                throw new Exception("Сhain Quantity is zero or less than zero");
            int RecPointNum = CurrBackup.RecPointList.Count;
            while (RecPointNum != Quantity)
            {
                RecPointNum--;
                Counter++;
            }
            return Counter;
        }
        public int GetClearPoints()
        {
            return GetClearPointsByQuantity();
        }
    }
}
