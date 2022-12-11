using OkulYönetim.Entity.Interfaces;
using System.Linq.Expressions;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task add(T Entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Delete(T entity);
        Task<List<T>> exp(Expression<Func<T, bool>> filter = null);
        Task Update(T entity);
    }
}
