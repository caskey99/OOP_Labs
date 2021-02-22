using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Worker : IEntity
    {
        public string Name { get; set; }
        public int ID { get; set; }
        private static int NextId = 1;
        public Worker Director { get; set; }
        public List<int> SubordinatesList { get; set; }
        public List<int> MyTasksList { get; set; }
        public Worker(string name,  List<int> subordinatesList, List<int> myTasksList)
        {
            Name = name;
            Director = null;
            SubordinatesList = subordinatesList;
            MyTasksList = myTasksList;
            ID = NextId;
            NextId++;
        }
    }

}
