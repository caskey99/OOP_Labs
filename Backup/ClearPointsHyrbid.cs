using System;
using System.Linq;
using System.Collections.Generic;

namespace Backup
{
    
    public class ClearPointsHyrbid
    {
        public bool IsHyrbid = false;
        List<ICleaningAlg> cleaningAlgs;
        public ClearPointsHyrbid()
        { 
            cleaningAlgs = new List<ICleaningAlg>();
        }
        public void AddCondition(ICleaningAlg cleaningsPoints)
        {
            cleaningAlgs.Add(cleaningsPoints);
        }

        public void DeleteCondition(ICleaningAlg cleaningsPoints)
        {
            cleaningAlgs.Remove(cleaningsPoints);
        }

        public void SetHyrbid()
        {
            IsHyrbid = true;
        }
        public void ClearPointsHyrbidAlg(Backup backup)
        {
            int CountPointsRemove = 0;
            if (IsHyrbid)
            {
                CountPointsRemove = int.MinValue; //max number of points
                foreach (var item in cleaningAlgs)
                {
                    if (CountPointsRemove < item.GetClearPoints())
                        CountPointsRemove = item.GetClearPoints();
                }
            }
            else
            {
                CountPointsRemove = int.MaxValue; //min number of points
                foreach (var item in cleaningAlgs)
                {
                    if (CountPointsRemove > item.GetClearPoints())
                        CountPointsRemove = item.GetClearPoints();
                }
            }
            while (CountPointsRemove != 0)
            {
                if (backup.RecPointList.First().IsDelta != true)
                    backup.RecPointList.Remove(backup.RecPointList.First());
                else
                    throw new Exception("The delta is taken from this point!");
                CountPointsRemove--;
            }
        }
    }
}
