using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class WorkerListRepositpry : IRepository<Worker>
    {
        public List<Worker> WorkerList = new List<Worker>();

        public void Create(Worker worker)
        {
            WorkerList.Add(worker);
        }

        public void Delete(int id)
        {
            var found = WorkerList.Find(item => item.ID == id);
            if (found != null)
                WorkerList.Remove(found);
            else
                throw new Exception("No worker found for this id!");
        }

        public Worker Get(int id)
        {
            var found = WorkerList.Find(item => item.ID == id);
            //if (found != null)
                return found;
            //else
                //throw new Exception("No worker found for this id!");
        }

        public List<Worker> GetAll()
        {
            return WorkerList;
        }

        public string GetPath()
        {
            throw new NotImplementedException();
        }


        public void СlearDatabase(string path)
        {
            WorkerList.Clear();
        }

    }
}
