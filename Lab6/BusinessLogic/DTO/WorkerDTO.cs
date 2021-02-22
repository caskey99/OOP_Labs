using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DTO
{
    public class WorkerDTO// : TaskManagementSystem
    {
        public string Name;
        public int ID;
        public WorkerDTO Director { get; set; }
        public List<int> SubordinatesList { get; set; }
        public List<int> MyTasksListID { get; set; }
        public string TheNameProperty
        {
            set
            {
                if (value != null)
                    Name = value;
                else
                    throw new Exception("No Name!");
            }
            get { return Name; }
        }
        public WorkerDTO(string name, List<int> subordinatesList, List<int> myTasksListID)
        {
            Name = name;
            Director = null;
            SubordinatesList = subordinatesList;
            MyTasksListID = myTasksListID;
        }

        public int GetId()
        {
            return ID;
        }

        public void AddTask(int id)
        {
            MyTasksListID.Add(id);
        }
    }
}
