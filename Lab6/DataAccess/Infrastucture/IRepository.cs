using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T Get(int id);
        string GetPath();
        void Create(T item);
        void Delete(int id);
        void СlearDatabase(string path);
    }
}
