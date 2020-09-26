using InfoManager.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoManager.Data.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
    }
}
