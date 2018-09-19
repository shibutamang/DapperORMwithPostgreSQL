using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Repo.Interface
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
