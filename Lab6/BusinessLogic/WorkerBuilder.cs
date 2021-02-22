using BusinessLogic.DTO;
using BusinessLogic.Infrastucture;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class WorkerBuilder : IWorker
    {

        IRepository<DataAccess.Entities.Worker> Repository;
        public WorkerBuilder(IRepository<DataAccess.Entities.Worker> repository)
        {
            Repository = repository;
        }

        public List<WorkerDTO> GetAll()
        {
            List<WorkerDTO> ListWorkerDTO = new List<WorkerDTO>();
            foreach (var item in Repository.GetAll())
            {
                ListWorkerDTO.Add(changeToWorkerDTO(item));
            }
            return ListWorkerDTO;
        }

        public void AddSubordinatesList(List<WorkerDTO> workers, int id)
        {
            foreach (var item in workers)
                GetWorker(id).SubordinatesList.Add(item.ID);
        }
        public WorkerDTO changeToWorkerDTO(Worker worker)
        {
            WorkerDTO workerDTO = new WorkerDTO(worker.Name, worker.SubordinatesList, worker.MyTasksList);
            if (worker.Director != null)
                workerDTO.Director = GetWorker(worker.Director.ID);
            workerDTO.ID = worker.ID;
            return workerDTO;
        }

        public Worker changeToWorker(WorkerDTO worker)
        {
            Worker newWorker = new Worker(worker.Name, worker.SubordinatesList, worker.MyTasksListID);
            if (worker.Director != null)
                newWorker.Director = Repository.Get(worker.Director.ID);
            return newWorker;
        }

        public void CreateWorker(WorkerDTO workerDTO)
        {
            var tempWorker = new Worker(workerDTO.Name, workerDTO.SubordinatesList, workerDTO.MyTasksListID);
            if (workerDTO.Director != null)
                tempWorker.Director = Repository.Get(workerDTO.Director.ID);
            Repository.Create(tempWorker);
        }


        public void СhangeTheDirector(int id, WorkerDTO newDirector)
        {
            var found = GetAll().Find(item => item.ID == id);
            if (found != null)
            {
                if (newDirector != null)
                    found.Director = newDirector;
                else
                    throw new Exception("Non-existent new director!");
            }
            else
                throw new Exception("Employee with the given d not found!");
        }

        public WorkerDTO GetWorker(int id)
        {
            Worker worker = Repository.Get(id);
            return changeToWorkerDTO(worker);
        }
    }
}
