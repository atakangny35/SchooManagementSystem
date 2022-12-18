using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.Note;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface INoteRepository:IGenericRepository<Note>
    {
        Task<List<GetNoteByCLass>> GetClassRate(int? Dersid, int ClassId);
        Task<List<GetNodeByUSer>> GetUserRate(int? Dersid, int Userid);
        Task<UserNote> GetUserAvarage(int? Dersid, int Userid);
        Task<ClassNote> GetClassAvarage(int? Dersid, int ClassId);

    }
}
