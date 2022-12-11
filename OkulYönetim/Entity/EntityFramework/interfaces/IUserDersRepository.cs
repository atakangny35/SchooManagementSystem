using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IUserDersRepository:IGenericRepository<UserDers>
    {
        Task<bool> HasUserDers(int userId,int DersId);
    }
}
