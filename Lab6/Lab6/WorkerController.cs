using BusinessLogic.DTO;
using BusinessLogic.Infrastucture;
using System.Collections.Generic;
using System.Linq;

namespace Lab6
{
    class WorkerController
    {
        IWorker Service;

        public WorkerController(IWorker service)
        {
            Service = service;
        }

        public void AddSubordinatesList(List<WorkerDTO> workers, int id)
        {
            Service.AddSubordinatesList(workers, id);
        }
        public WorkerDTO CreateWorker(WorkerViewModell item)
        {
            var worker = new WorkerDTO(item.Name, item.SubordinatesList, item.MyTasksList);
            if (item.Director != null)
            {
                WorkerDTO dir = GetWorker(item.Director.ID);
                worker.Director = dir;
            }
            Service.CreateWorker(worker);
            return Service.GetAll().Last();
        }

        public List<WorkerDTO> GetAll()
        {
            return Service.GetAll();
        }

        public WorkerDTO GetWorker(int id)
        {
            return Service.GetWorker(id);
        }

        //public void СhangeTheDirector(int id, WorkerDTO newDirector)
        //{
        //    Service.СhangeTheDirector(id, newDirector);
        //}


    }
}
