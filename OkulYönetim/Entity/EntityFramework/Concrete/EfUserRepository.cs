using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public EfUserRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async  Task<User> FindByMail(string email)
        {
            return  await dbContext.Users.Where(i => i.Email == email).FirstOrDefaultAsync();
             

        }

        public async Task<UserProfileGetModel> FindByMailWithRoleName(string email)
        {
            var result = from u in dbContext.Users
                         join ur in dbContext.UserRoles
                         on u.UserRoleId equals ur.Id
                         where u.Email == email
                         select new UserProfileGetModel
                         {
                             Branch = u.Branch,
                             Email = email,
                             Name = u.Name,
                             Surname = u.Surname,
                             RoleName = ur.RoleName
                         };
            return await result.FirstOrDefaultAsync();

            
        }
    }
}
