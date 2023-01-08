using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IClassepository:IGenericRepository<Class>
    {
        Task<List<ListOfUserListModel>> GetUsersByClasses(int userid);
    }
}
