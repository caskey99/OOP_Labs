using BusinessLogic;
using BusinessLogic.DTO;
using BusinessLogic.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab6
{
    class TaskController
    {
        ITaskManagementSystem Service;
        public TaskController(ITaskManagementSystem service)
        {
            Service = service;
        }
 
        public TaskDTO GetTask(int id)
        {
            return Service.GetTask(id);
        }

        public List<TaskDTO> GetAll()
        {
            return Service.GetAll();
        }

        //public List<TaskViewModell> Show()
        //{
        //    return Service.Get().Select(task => new TaskViewModell { Name = task.Name, Description = task.Description, Comment = task.Comment, ID = task.ID });
        //}

        public TaskDTO CreateTask(TaskViewModell item)
        {
            Service.CreateTask(new BusinessLogic.DTO.TaskDTO(item.Name, item.Description, item.AssignedEmployeeID));
            return Service.GetAll().Last();
        }

        public void ChangingTheTaskState(int id, string state)
        {
            Service.ChangingTheTaskState(id, state);
        }

        public void AddComment(int id, string text)
        {
            Service.AddComment(id, text);
        }

        public void СhangingTheTaskAssignedEmployee(int id, int newAssignedEmployeeID)
        {
            Service.СhangingTheTaskAssignedEmployee(id, newAssignedEmployeeID);
        }

        public List<TaskDTO> GetListOfTasksSubordinate(WorkerDTO worker)
        {
            return Service.GetListOfTasksSubordinate(worker);
        }

        public List<TaskDTO> GetAllTasksOfWorker(int id)
        {
            return Service.GetAllTasksOfWorker(id);
        }

        public string CheckingStatus (int id)
        {
            return Service.CheckingStatus(id);
        }

        public void CompleteTheTask(int id)
        {
            Service.CompleteTheTask(id);
        }

        public List<TaskDTO> GetTasksForTheDay(ReportDTO rep)
        {
            return Service.GetTasksForTheDay(rep);
        }

        //Search methods

        public TaskDTO SearchForTaskById(int id)
        {
            return Service.SearchForTaskById(id);
        }

        public TaskDTO SearchForTaskByTime(DateTime time)
        {
            return Service.SearchForTaskByTime(time);
        }
        public TaskDTO SearchForTaskByEmployee(WorkerDTO employee)
        {
            return Service.SearchForTaskByEmployee(employee);
        }

        public TaskDTO SearchForTaskByChanges(DateTime time)
        {
            return Service.SearchForTaskByChanges(time);
        }

        //Methods for getting time

        public DateTime GetTheStateChangeTime(TaskDTO task)
        {
            return Service.GetTheStateChangeTime(task);
        }

        public DateTime GetTheExecutorChangeTime(TaskDTO task)
        {
            return Service.GetTheExecutorChangeTime(task);
        }
        public DateTime GetTheCommentChangeTime(TaskDTO task)
        {
            return Service.GetTheCommentChangeTime(task);
        }

    }
}
