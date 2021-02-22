using System;
using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Infrastucture
{
    public interface ITaskManagementSystem
    {
        void CreateTask(TaskDTO item);
        TaskDTO GetTask(int id);
        List<TaskDTO> GetAll();
        //void CreatingATask(string name, string description, WorkerDTO employee);
        void ChangingTheTaskState(int id, string newState);
        void СhangingTheTaskAssignedEmployee(int id, int newAssignedEmployeeID);
        void AddComment(int id, string comm);
        string CheckingStatus(int id);
        void CompleteTheTask(int id);
        List<TaskDTO> GetTasksForTheDay(ReportDTO rep);
        List<TaskDTO> GetAllTasksOfWorker(int id);
        List<TaskDTO> GetListOfTasksSubordinate(WorkerDTO worker);
        TaskDTO SearchForTaskById(int id);
        TaskDTO SearchForTaskByTime(DateTime time);
        TaskDTO SearchForTaskByEmployee(WorkerDTO employee);
        TaskDTO SearchForTaskByChanges(DateTime time);
        DateTime GetTheStateChangeTime(TaskDTO name);
        DateTime GetTheExecutorChangeTime(TaskDTO name);
        DateTime GetTheCommentChangeTime(TaskDTO name);
    }
}
