using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Report : IEntity
    {
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string СontentsOfTheReport { get; set; }
        public DateTime CreationTime { get; set; }
        public bool ReportIsDraft { get; set; }
        public List<int> CompletedTasksID { set; get; }
    }
}
