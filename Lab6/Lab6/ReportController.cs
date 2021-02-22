using BusinessLogic;
using BusinessLogic.DTO;
using BusinessLogic.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    class ReportController
    {
        IReportService Service;

        public ReportController(IReportService service)
        {
            Service = service;
        }
        public ReportDTO CreateReport(List<TaskDTO> taskList, int id)
        {
            Service.CreateReport(taskList, id);
            return Service.GetAll().Last();
        }
        public ReportDTO CreateReportForTheDay(List<TaskDTO> taskList, int id)
        {
            Service.CreateReportForTheDay(taskList, id);
            return Service.GetAll().Last();
        }

        public ReportDTO CreateReportForTheSprint(List<TaskDTO> taskList, int id)
        {
            Service.CreateReportForTheSprint(taskList, id);
            return Service.GetAll().Last();
        }

        public void GetTeamReport(List<TaskDTO> taskList)
        {
            Service.GetTeamReport(taskList);
        }

        public void WriteReport(int id)
        {
            Service.WriteReport(id);
        }

        public ReportDTO GetReport(int id )
        {
            return Service.GetReport(id);
        }

        public void EditDay(int id, string text)
        {
            Service.EditDay(id, text);
        }

        public void Edit(int id, string text)
        {
            Service.Edit(id, text);
        }

        public List<ReportDTO> GetListOfReportsSubordinates(WorkerDTO worker)
        {
            return Service.GetListOfReportsSubordinates(worker);
        }

        public void СlearDatabase(string path)
        {
            Service.СlearDatabase(path);
        }
    }
}
