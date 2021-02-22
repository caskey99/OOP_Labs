using System;
using BusinessLogic;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DTO
{
    public class Change
    {
        //Dictionary<string, DateTime> Сhanges = new Dictionary<string, DateTime>();
        public string NameOfTheChange = null;
        DateTime TimeOfChange;
        public int ID;
        private static int NextID = 0;
        public Change(string nameOfTheChange, DateTime timeOfChange)
        {
            NameOfTheChange = nameOfTheChange;
            TimeOfChange = timeOfChange;
            ID = NextID;
            NextID++;
        }

        //public string GetChangeString(Change change)
        //{
        //    var found = СhangesList.Find(item => item.ID == change.ID);
        //    if (found == null)
        //        throw new Exception("This change does not exist!");
        //    else
        //        return found.NameOfTheChange;
        //    //test = test.Insert(0, " ");
        //    //return test = test.Insert(0, change.Сhanges.Keys.ToString() + "\n");
        //}
    }
}
