using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM.Web.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T Get(int id);
        Task InsertAsync(T entity);
        void Remove(int id);
        void Update(T entity);
    }
}
