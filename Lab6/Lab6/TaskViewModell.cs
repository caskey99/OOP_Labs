using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class TaskViewModell
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public string Comment { get; set; }
        public int ID { get; set; }
        public int AssignedEmployeeID { get; set; }
    }
}
