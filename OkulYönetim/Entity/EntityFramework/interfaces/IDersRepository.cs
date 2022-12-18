using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IDersRepository:IGenericRepository<Ders>
    {
        Task<bool> IsDersExists(int dersid);
    }
}
