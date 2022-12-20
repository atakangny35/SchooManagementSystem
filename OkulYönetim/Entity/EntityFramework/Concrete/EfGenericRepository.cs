using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;
using OkulYönetim.Entity.Interfaces;
using System.Linq.Expressions;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly ApplicationDbContext dbContext;

        public EfGenericRepository(ApplicationDbContext _dbContext)
        {
                dbContext = _dbContext;
        }
        
        public async Task add(T Entity)
        {   
            

            await  dbContext.Set<T>().AddAsync(Entity);
            await dbContext.SaveChangesAsync();           
        }

        public async Task Delete(T entity)
        {
             dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> exp(Expression<Func<T, bool>>? filter = null)
        {
            return  await (filter is not null
                ? dbContext.Set<T>().AsNoTracking().Where(filter).ToListAsync() 
                : dbContext.Set<T>().ToListAsync());
        }

        public async Task<T> Get(int id)
        {

            return await dbContext.Set<T>().FindAsync(id);
           
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T entity)
        {

            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
