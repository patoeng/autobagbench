using System;
using System.Collections.Generic;

namespace AutoBagBench.Persistence
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        T Add(T obj);
        void Delete(Guid id);
        bool Update(T obj);
       
    }
}