using BusinessLogic.DTO;
using BusinessLogic.Infrastucture;
using DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogic
{
    public class ReportService : IReportService
    {
        IRepository<DataAccess.Entities.Report> Repository;
        List<string> changes = new List<string>();
        public ReportService(IRepository<DataAccess.Entities.Report> repository)
        {
            Repository = repository;
        }

        public void CreateReport(List<TaskDTO> taskList, int id)
        {
            string contentrep = null;
            foreach (var item in taskList)
            {
                foreach (var jtem in item.Changes)
                {
                    if (jtem != changes.Find(atem => atem == jtem))
                    {
                        changes.Add(jtem);
                        contentrep += jtem;
                    }
                }
            }
            ReportDTO dtorep = new ReportDTO(contentrep);
            var newrep = new DataAccess.Entities.Report { ID = dtorep.ID, CreatorID = id, СontentsOfTheReport = dtorep.СontentsOfTheReport, ReportIsDraft = dtorep.ReportIsDraft, CreationTime = dtorep.CreationTime };
            Repository.Create(newrep);
        }


        public void CreateReportForTheDay(List<TaskDTO> taskList, int id)
        {
            string contentrep = null;
            foreach (var item in taskList)
            {
                if (DateTime.Now <= item.CreationTime.AddDays(1) && DateTime.Now >= item.CreationTime.AddDays(-1))
                {
                    foreach(var jtem in item.Changes)
                        {
                            if (jtem != changes.Find(atem => atem == jtem))
                            {
                                changes.Add(jtem);
                                contentrep += jtem;
                            }
                        }
                }
            }
            ReportDTO dtorep = new ReportDTO(contentrep);
            var newrep = new DataAccess.Entities.Report { ID = dtorep.ID, CreatorID = id, СontentsOfTheReport = dtorep.СontentsOfTheReport, ReportIsDraft = dtorep.ReportIsDraft, CreationTime = dtorep.CreationTime };
            Repository.Create(newrep);
        }

        public void CreateReportForTheSprint(List<TaskDTO> taskList, int id)
        {
            string contentrep = null;
            foreach (var jtem in Repository.GetAll())
            {
                contentrep += jtem.СontentsOfTheReport;
            }
            ReportDTO dtorep = new ReportDTO(contentrep);
            var newrep = new DataAccess.Entities.Report { ID = dtorep.ID, CreatorID = id, СontentsOfTheReport = dtorep.СontentsOfTheReport, ReportIsDraft = dtorep.ReportIsDraft, CreationTime = dtorep.CreationTime };
            Repository.Create(newrep);
        }

        public void GetTeamReport(List<TaskDTO> taskList)
        {
            string contentrep = null;
            foreach (var jtem in Repository.GetAll())
            {
                if(jtem.ReportIsDraft == false)
                    contentrep += jtem.СontentsOfTheReport;
            }
            ReportDTO dtorep = new ReportDTO(contentrep);
            var newrep = new DataAccess.Entities.Report { ID = dtorep.ID, CreatorID = dtorep.CreatorID, СontentsOfTheReport = dtorep.СontentsOfTheReport, ReportIsDraft = dtorep.ReportIsDraft, CreationTime = dtorep.CreationTime };
            newrep.ReportIsDraft = false;
            Repository.Create(newrep);
        }

        public void WriteReport(int id)
        {
            var rep = Repository.Get(id);
            rep.ReportIsDraft = false;
            Repository.Create(rep);
        }

        public List<ReportDTO> GetListOfReportsSubordinates(WorkerDTO worker)
        {
            List<ReportDTO> ListOfReportsSubordinates = new List<ReportDTO>();
            foreach (var item in worker.SubordinatesList)
                foreach(var jtem in GetAll())
                    if (jtem.CreatorID == item)
                        ListOfReportsSubordinates.Add(jtem);
            return ListOfReportsSubordinates;
        }

        public ReportDTO GetReport(int id)
        {
            return new ReportDTO { ID = Repository.Get(id).ID, CreatorID = Repository.Get(id).CreatorID, СontentsOfTheReport = Repository.Get(id).СontentsOfTheReport, ReportIsDraft = Repository.Get(id).ReportIsDraft, CreationTime = Repository.Get(id).CreationTime };
        }

        public List<ReportDTO> GetAll()
        {
            List<ReportDTO> reports = new List<ReportDTO>();
            foreach(var item in Repository.GetAll())
            {
                reports.Add(new ReportDTO { ID = item.ID,CreatorID = item.ID, СontentsOfTheReport = item.СontentsOfTheReport, ReportIsDraft = item.ReportIsDraft, CreationTime = item.CreationTime });
            }
            return reports;
        }

        public void EditDay(int id, string text)
        {
            if (DateTime.Now <= Repository.Get(id).CreationTime.AddDays(1) && DateTime.Now >= Repository.Get(id).CreationTime.AddDays(-1) && Repository.Get(id).ReportIsDraft == true)
            {
                Edit(id, text);
            }
            else
                throw new Exception("You can edit the report only during the day after it is created!");
        }
        public void Edit(int id, string text)
        {
            Repository.Get(id).СontentsOfTheReport += "\n" + text;
        }


        public void СlearDatabase(string path)
        {
            Repository.СlearDatabase(path);
        }

    }
} 
