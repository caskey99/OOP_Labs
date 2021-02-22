using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Infrastucture
{
    public interface IReportService
    {
        void CreateReport(List<TaskDTO> taskList, int id);
        void CreateReportForTheDay(List<TaskDTO> taskList, int id);
        void CreateReportForTheSprint(List<TaskDTO> taskList, int id);
        void GetTeamReport(List<TaskDTO> taskList);
        void WriteReport(int id);
        ReportDTO GetReport(int id);
        List<ReportDTO> GetListOfReportsSubordinates(WorkerDTO worker);
        List<ReportDTO> GetAll();
        void EditDay(int id, string text);
        void Edit(int id, string text);
        void СlearDatabase(string path);
        //List<ReportDTO> Get();
    }
}
