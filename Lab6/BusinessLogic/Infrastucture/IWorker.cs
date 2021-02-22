using BusinessLogic.DTO;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Infrastucture
{
    public interface IWorker
    {
        void CreateWorker(WorkerDTO workerDTO);
        // void СhangeTheDirector(int id, WorkerDTO newDirector);
        WorkerDTO GetWorker(int id);
        List<WorkerDTO> GetAll();
        void AddSubordinatesList(List<WorkerDTO> workers, int id);
        WorkerDTO changeToWorkerDTO(Worker worker);
        Worker changeToWorker(WorkerDTO worker);
    }
}
