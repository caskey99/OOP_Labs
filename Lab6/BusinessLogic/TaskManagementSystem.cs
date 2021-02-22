using System;
using BusinessLogic.DTO;
using System.Collections.Generic;
using BusinessLogic.Infrastucture;
using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic
{
    public class TaskManagementSystem : ITaskManagementSystem
    {

        IRepository<DataAccess.Entities.Task> Repository;
        public TaskManagementSystem(IRepository<DataAccess.Entities.Task> repository)
        {
            Repository = repository;
        }

        public void CreateTask(TaskDTO item)
        {
            item.AddChange($"The \"{item.Name}\" task has been created. Id of the Person responsible for completing the task : {item.AssignedEmployeeID}. ({item.CreationTime})\n");
            Repository.Create(changeToTask(item));
        }

        public TaskDTO GetTask(int id)
        {
            return changeToTaskDTO(Repository.Get(id));
        }

        public List<TaskDTO> GetAll()
        {
            List<TaskDTO> ListTaskDTO = new List<TaskDTO>();
            foreach (var item in Repository.GetAll())
            {
                ListTaskDTO.Add(changeToTaskDTO(item));
            }
            return ListTaskDTO;
        }

        public TaskDTO changeToTaskDTO(Task task)
        {
            TaskDTO newTaskDTO = new TaskDTO(task.Name, task.Description, task.AssignedEmployeeID);
            newTaskDTO.ID = task.ID;
            newTaskDTO.Changes = task.Changes;
            newTaskDTO.Comment = task.Comment;
            newTaskDTO.СhangeTime = task.СhangeTime;
            newTaskDTO.CreationTime = task.CreationTime;
            newTaskDTO.CompletionTime = task.CompletionTime;
            newTaskDTO.ChangeTheCommentTime = task.ChangeTheCommentTime;
            newTaskDTO.ChangeOfExecutorTime = task.ChangeOfExecutorTime;
            newTaskDTO.ChangingTheState(task.GetState());
            return newTaskDTO;
        }

        public Task changeToTask(TaskDTO taskDTO)
        {
            Task newTask = new Task(taskDTO.Name, taskDTO.Description, taskDTO.Comment, taskDTO.AssignedEmployeeID);
            newTask.Changes = taskDTO.Changes;
            newTask.СhangeTime = taskDTO.СhangeTime;
            newTask.CreationTime = taskDTO.CreationTime;
            newTask.CompletionTime = taskDTO.CompletionTime;
            newTask.ChangeTheCommentTime = taskDTO.ChangeTheCommentTime;
            newTask.ChangeOfExecutorTime = taskDTO.ChangeOfExecutorTime;
            newTask.ChangingTheState(taskDTO.GetState());
            return newTask;
        }

        public void ChangingTheTaskState(int id, string newState)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            {
                found.ChangingTheState(newState);
                found.Changes.Add($"The status of the task was changed to [{found.GetState()}]. ({found.СhangeTime})\n");
            }
            else
                throw new Exception("No task found for this id!");
        }

        public void СhangingTheTaskAssignedEmployee(int id, int newAssignedEmployeeID)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
                found.AssignedEmployeeID = newAssignedEmployeeID;
            else
                throw new Exception("No task found for this id!");
        }

        public void AddComment(int id, string comm)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            {
                found.AddComment(comm);
                found.Changes.Add( $"A comment was added to the task: " + $"\"{comm}\". ({found.СhangeTime})\n");
            }
            else
                throw new Exception("No task found for this id!");
        }

        public string CheckingStatus(int id)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            { 
                return found.GetState();
            }

            else
                throw new Exception("No task found for this id!");
        }

        public List<TaskDTO> GetListOfTasksSubordinate(WorkerDTO worker)
        {
            List<TaskDTO> SubordinatesTasks = new List<TaskDTO>();
            foreach (var item in GetAll())
                if (item.AssignedEmployeeID == worker.ID)
                    SubordinatesTasks.Add(item);
             return SubordinatesTasks;
        }

        public List<TaskDTO> GetAllTasksOfWorker(int id)
        {
            List<TaskDTO> AllTasksOfWorker = new List<TaskDTO>();
            foreach (var item in GetAll())
                if(item.AssignedEmployeeID == id)
                    AllTasksOfWorker.Add(GetTask(item.ID));
            return AllTasksOfWorker;
        }

        public List<TaskDTO> GetTasksForTheDay(ReportDTO rep)
        {

                List<TaskDTO> tasksForTheDay = new List<TaskDTO>();
                foreach (var item in GetAll())
                {
                    if (item.GetState() == "Resolved" && item.CompletionTime <= rep.CreationTime.AddDays(1) && item.CompletionTime >= rep.CreationTime.AddDays(-1))
                        tasksForTheDay.Add(item);
                }
                return tasksForTheDay;
        }

        public void CompleteTheTask(int id)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            {
                found.AddChange($"The task was completed. ({found.СhangeTime})\n");
                found.CompleteTheTask();
                found.ChangingTheState("Resolved");
            }
            else
                throw new Exception("No task found for this id!");
        }

        //Search methods
        public TaskDTO SearchForTaskById(int id)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
                return found;
            else
                throw new Exception("No task found for this id!");
        }

        public TaskDTO SearchForTaskByTime(DateTime time)
        {
            var FoundCreationTime = GetAll().Find(item => item.CreationTime == time);
            if (FoundCreationTime != null)
                return FoundCreationTime;
            else
            {
                return SearchForTaskByChanges(time);
            }
        }

        public TaskDTO SearchForTaskByEmployee(WorkerDTO employee)
        {
            var found = GetAll().Find(item => item.AssignedEmployeeID == employee.ID);
            if (found != null)
                return found;
            else
                throw new Exception("No task found for this employee!");
        }

        public TaskDTO SearchForTaskByChanges(DateTime time)
        {
            var FoundChangeTime = GetAll().Find(item => item.СhangeTime == time);
            if (FoundChangeTime != null)
                return FoundChangeTime;
            else
                throw new Exception("No task found for this СhangeTime!");
        }

        //Methods for getting time
        public DateTime GetTheStateChangeTime(TaskDTO name)
        {
            return name.CreationTime;
        }

        public DateTime GetTheExecutorChangeTime(TaskDTO name)
        {
            return name.ChangeOfExecutorTime;
        }

        public DateTime GetTheCommentChangeTime(TaskDTO name)
        {
            return name.ChangeTheCommentTime;
        }

    }
}
