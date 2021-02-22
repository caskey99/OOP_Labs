using BusinessLogic;
using BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class WorkerViewModell
    {
        public string Name { get; set; }
        public WorkerDTO Director { get; set; }
        public int ID { get; set; }
        public List<int> SubordinatesList = new List<int>() ;
        public List<int> MyTasksList = new List<int>();
    }
}
