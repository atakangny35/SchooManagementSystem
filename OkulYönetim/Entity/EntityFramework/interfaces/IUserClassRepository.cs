using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IUserClassRepository:IGenericRepository<UserClass>
    {
        Task<bool> HasUserClass(int userId, int CLassId);
    }
}
