using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfUserRoleRepository : EfGenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EfUserRoleRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<int> CheckRoleHasUsers(int userRoleId)
        {
             return await dbContext.Users.Where(i => i.UserRoleId == userRoleId).CountAsync();
            
        }
    }
}
