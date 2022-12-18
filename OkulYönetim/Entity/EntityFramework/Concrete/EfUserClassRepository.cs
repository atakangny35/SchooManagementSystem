using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfUserClassRepository : EfGenericRepository<UserClass>, IUserClassRepository
    {
        private readonly ApplicationDbContext dbContext;
        public EfUserClassRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext=_dbContext;
        }

        public async Task<bool> HasUserClass(int userId, int CLassId)
        {
            return await dbContext.UserClasses.Where(x => x.UserId == userId && x.ClassId == CLassId).AnyAsync();
        }
    }
}
