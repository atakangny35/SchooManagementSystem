using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfDersRepository : EfGenericRepository<Ders>, IDersRepository
    {
        private readonly ApplicationDbContext dbcontext;
        public EfDersRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbcontext = _dbContext;
        }

        public async Task<bool> IsDersExists(int dersid)
        {
            return !await dbcontext.Dersler.AsNoTracking().Where(x => x.Id == dersid).AnyAsync();
        }
    }
}
