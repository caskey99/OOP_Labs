using BusinessLogic.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogic.DTO
{
    public class TaskDTO
    {
        public string Name, Description, Comment;
        public int ID { get; set; }
        public DateTime CreationTime, СhangeTime, ChangeOfExecutorTime, ChangeTheCommentTime, CompletionTime;
        public int AssignedEmployeeID;
        public List<string> Changes = new List<string>();
        enum TaskState
        {
            Open,
            Active,
            Resolved
        }
        private TaskState taskState;
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
        public string TheDescriptionProperty
        {
            set
            {
                if (value != null)
                    Description = value;
                else
                    throw new Exception("No Description!");
            }
            get { return Description; }
        }

        public TaskDTO(string name, string description, int assignedEmployeeID)
        {
            Name = name;
            Description = description;
            AssignedEmployeeID = assignedEmployeeID;
            ChangeOfExecutorTime = DateTime.Now;
            taskState = TaskState.Open;
            CreationTime = DateTime.Now;
            СhangeTime = DateTime.Now;
        }

        public void AddChange(string change)
        {
            Changes.Add(change);
        }
        public void ChangingTheState(string state)
        {
            var EnumArr = Enum.GetNames(typeof(TaskState));
            bool found = false;
            for (var i = 0; i < EnumArr.Length; i++)
                if (EnumArr[i] == state)
                {
                    taskState = (TaskState)Enum.GetValues(typeof(TaskState)).GetValue(i);
                    СhangeTime = DateTime.Now;
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("The state does not exist!");
        }

        public void AddComment(string comm)
        {
            Comment = comm;
            ChangeTheCommentTime = DateTime.Now;
            СhangeTime = DateTime.Now;
        }

        public void CompleteTheTask()
        {
            taskState = TaskState.Resolved;
            СhangeTime = DateTime.Now;
            CompletionTime = DateTime.Now;
        }
        public int GetId()
        {
            return ID;
        }

        public string GetState()
        {
            return taskState.ToString();
        }
    }
}
