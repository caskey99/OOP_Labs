using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace DataAccess
{
    public class TaskListRepositpry : IRepository<Task>
    {
        public List<Task> TaskList = new List<Task>();

        public List<Task> GetTaskList()
        {
            return TaskList;
        }

        public void Create(Task task)
        {
            TaskList.Add(task);
        }

        public void Delete(int id)
        {
            var found = TaskList.Find(item => item.ID == id);
            if (found != null)
                TaskList.Remove(found);
            else
                throw new Exception("No task found for this id!");
        }

        public Task Get(int id)
        {
            var found = TaskList.Find(item => item.ID == id);
            //if (found != null)
            return found;
            //else
            //throw new Exception("No task found for this id!");
        }

        public List<Task> GetAll()
        {
            return TaskList;
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }


        public void СlearDatabase(string path)
        {
            TaskList.Clear();
        }
    }
}
