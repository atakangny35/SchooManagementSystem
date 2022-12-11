using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IUserRoleRepository:IGenericRepository<UserRole>
    {
        Task<int> CheckRoleHasUsers(int userRoleId);
    }
}
