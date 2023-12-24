using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T obj);
        Task Delete(T obj);
        Task<T> GetById(Guid id);
        Task<List<T>> List(T obj);
        Task Update(T obj);
    }
}