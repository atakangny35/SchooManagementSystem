using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfUserDersRepository : EfGenericRepository<UserDers>, IUserDersRepository
    {   
        private readonly ApplicationDbContext _context;
        public EfUserDersRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            _context = _dbContext;
        }

        public async Task<bool> HasUserDers(int userId, int DersId)
        {
            return await _context.UserDers.Where(x => x.Userid == userId && x.Dersid == DersId).AnyAsync();
        }
    }
}
