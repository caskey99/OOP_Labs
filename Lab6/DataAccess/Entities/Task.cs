using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Task : IEntity
    {
        public string Name, Description, Comment;
        public int ID { get; set; }
        private static int NextID = 1;
        public List<string> Changes { get; set; }
        public DateTime CreationTime, СhangeTime, ChangeOfExecutorTime, ChangeTheCommentTime, CompletionTime;
        public int AssignedEmployeeID;

        enum TaskState
        {
            Open,
            Active,
            Resolved
        }
        private TaskState taskState;
        public Task() { }
        public Task(string name, string description, string comment, int assignedEmployeeID)
        {
            Name = name;
            Description = description;
            Comment = comment;
            AssignedEmployeeID = assignedEmployeeID;
            ID = NextID;
            NextID++;
        }

        public void ChangingTheState(string state)
        {
            var EnumArr = Enum.GetNames(typeof(TaskState));
            bool found = false;
            for (var i = 0; i < EnumArr.Length; i++)
                if (EnumArr[i] == state)
                {
                    this.taskState = (TaskState)Enum.GetValues(typeof(TaskState)).GetValue(i);
                    СhangeTime = DateTime.Now;
                    //TaskChange.Add(new Change($"The status of the task was changed to [{taskState}]. ({СhangeTime})\n", СhangeTime));
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("The state does not exist!");
        }

        public string GetState()
        {
            return this.taskState.ToString();
        }
    }
}
