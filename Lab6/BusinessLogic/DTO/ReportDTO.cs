using System;
using System.IO;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class ReportDTO
    {
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string СontentsOfTheReport { get; set; }
        private static int NextID = 1;
        public DateTime CreationTime;
        public List<int> CompletedTasksID { set; get; }
        public bool ReportIsDraft = true;
        public ReportDTO() { }
        public ReportDTO(string text)
        {
            СontentsOfTheReport = text;
            ID = NextID;
            NextID++;
            CreationTime = DateTime.Now;
        }
    }
}
