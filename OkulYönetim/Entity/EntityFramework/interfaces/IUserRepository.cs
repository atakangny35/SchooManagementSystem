using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> FindByMail(string email);
        Task<UserProfileGetModel> FindByMailWithRoleName(string email);
        Task<bool> AddFromExcel(string FilePath, int ClassId);
    }
}
