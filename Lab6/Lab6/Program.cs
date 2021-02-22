using DataAccess;
using BusinessLogic;
using System;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.DTO;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Work Team
            var Wrepository = new WorkerListRepositpry();
            var Wservice = new WorkerBuilder(Wrepository);
            var WorkerController = new WorkerController(Wservice);

            var DirIvan = WorkerController.CreateWorker(new WorkerViewModell { Name = "Ivan" });
            var SubLi = WorkerController.CreateWorker(new WorkerViewModell { Name = "Li", Director = DirIvan });
            var SubBob = WorkerController.CreateWorker(new WorkerViewModell { Name = "Bob", Director = SubLi });
            var SubBill = WorkerController.CreateWorker(new WorkerViewModell { Name = "Bill", Director = DirIvan});
            List<WorkerDTO> IvanSub = new List<WorkerDTO> { SubLi, SubBob };
            WorkerController.AddSubordinatesList(IvanSub, DirIvan.GetId());
            var WorkerList = WorkerController.GetAll();

            //Create Tasks
            var Trepositpry = new TaskListRepositpry();
            var Tservice = new TaskManagementSystem(Trepositpry);
            var TaskController = new TaskController(Tservice);

            var TaskOne = TaskController.CreateTask(new TaskViewModell { Name = "Calc", Description = "Must return the sum of two numbers.", AssignedEmployeeID = SubLi.ID });
            TaskController.ChangingTheTaskState(TaskOne.GetId(), "Active"); 
            TaskController.AddComment(TaskOne.GetId(), "Сomplete this task as soon as possible");
            TaskController.СhangingTheTaskAssignedEmployee(TaskOne.GetId(), SubBill.ID);


            var repository = new FileReportRepositpry(@"D:\Report\bd.txt");
            var Rservice = new ReportService(repository);
            var RepController = new ReportController(Rservice);
            RepController.СlearDatabase(@"D:\Report\bd.txt");

            var a = RepController.CreateReport(TaskController.GetAll(), SubLi.GetId());
            RepController.WriteReport(a.ID);

            var TaskTwo = TaskController.CreateTask(new TaskViewModell { Name = "Equation", Description = "solve the equation.", AssignedEmployeeID = SubLi.ID });
            TaskController.ChangingTheTaskState(TaskTwo.GetId(), "Active"); 
            TaskController.AddComment(TaskTwo.GetId(), "Solve and check by substitution");
            TaskController.AddComment(TaskTwo.GetId(), "Let your subordinate perform the check");
            TaskController.CompleteTheTask(TaskTwo.GetId());

            var TaskThree = TaskController.CreateTask(new TaskViewModell { Name = "Stool", Description = "Assemble the stool from the parts.", AssignedEmployeeID = SubLi.ID });
            TaskController.ChangingTheTaskState(TaskThree.GetId(), "Active");
            TaskController.AddComment(TaskThree.GetId(), "Do not forget to paint");
            TaskController.AddComment(TaskThree.GetId(), "Do not forget to paint");
            TaskController.CompleteTheTask(TaskThree.GetId());

            //Search + Get
            TaskController.SearchForTaskById(2);
            TaskController.SearchForTaskByEmployee(SubLi);
            TaskController.SearchForTaskByTime(TaskThree.CreationTime);

            TaskController.GetTheStateChangeTime(TaskTwo);
            TaskController.GetTheExecutorChangeTime(TaskTwo);
            TaskController.GetTheCommentChangeTime(TaskTwo);


            //// CreateReportForTheDay
            var RepForTheDay = RepController.CreateReportForTheDay(TaskController.GetAll(), SubLi.GetId());
            RepController.Edit(RepForTheDay.ID, $"Correction. ({ DateTime.Now}).\n");
            RepController.WriteReport(RepForTheDay.ID);

            var TaskFour = TaskController.CreateTask(new TaskViewModell { Name = "Drawing", Description = "Draw a model 6 laborato.", AssignedEmployeeID = SubLi.ID });
            TaskController.ChangingTheTaskState(TaskFour.GetId(), "Active"); 
            TaskController.AddComment(TaskFour.GetId(), "Don't forget to do this");
            TaskController.CompleteTheTask(TaskFour.GetId());

            var RepForTheDay2 = RepController.CreateReportForTheDay(TaskController.GetAll(), SubLi.GetId());
            RepController.Edit(RepForTheDay2.ID, $"Correction. ({ DateTime.Now}).\n");
            RepController.WriteReport(RepForTheDay2.ID);

            //CreateReportForTheSprint
            var RepForTheSprint = RepController.CreateReportForTheSprint(TaskController.GetAll(), SubLi.GetId());
            RepController.Edit(RepForTheSprint.ID, $"Correction. ({ DateTime.Now}).\n");
            RepController.WriteReport(RepForTheSprint.ID);


            var RepForTeam = RepController.CreateReportForTheSprint(TaskController.GetAll(), SubLi.GetId());
            RepController.WriteReport(RepForTeam.ID);

            RepController.GetTeamReport(TaskController.GetAll());


            //  Displaying the employee's task list
            //foreach (var item in TaskController.GetAllTasksOfWorker(SubLi.ID))
            //    Console.WriteLine(item.Name + " " + item.ID);

            //  Displaying the Subordinates reports list
            //foreach (var item in RepController.GetListOfReportsSubordinates(DirIvan))
             //    Console.WriteLine(item.ID);





           // var Rep =  RepController.GetReport(TaskThree.GetId());
           // Console.WriteLine(Rep.СontentsOfTheReport);
           // List<TaskDTO> TasksForTheDay = TaskController.GetTasksForTheDay(Rep);


        }
    }
}
