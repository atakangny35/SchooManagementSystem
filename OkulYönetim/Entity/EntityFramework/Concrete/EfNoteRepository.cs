using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.Note;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfNoteRepository : EfGenericRepository<Note>, INoteRepository
    {
        private readonly ApplicationDbContext dbcontext;
        public EfNoteRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbcontext= _dbContext;
        }

        public async Task<List<GetNoteByCLass>> GetClassRate(int? Dersid, int ClassId)
        {
            
                var result = from u in dbcontext.Users.AsNoTracking()
                             join uc in dbcontext.UserClasses.AsNoTracking()
                             on u.Id equals uc.UserId
                             join c in dbcontext.Classes.AsNoTracking()
                             on uc.ClassId equals c.Id
                             join n in dbcontext.Notes.AsNoTracking()
                             on u.Id equals n.UserId
                             join d in dbcontext.Dersler.AsNoTracking()
                             on n.DersID equals d.Id
                             where c.Id == ClassId && uc.ClassId == ClassId
                             && n.DersID == (Dersid !=null ? Dersid: n.DersID)
                             && d.Id == (Dersid != null ? Dersid : n.DersID)
                             select new GetNoteByCLass
                             {
                                 Description = n.Description,
                                 AddedTime = n.AddedTime,
                                 Surname = u.Surname,
                                 ClassName = c.Name,
                                 Name = u.Name,
                                 NoteValue = n.NoteValue,
                                 DersAdi=d.DersAdi
                             };
                                         

                return await result.ToListAsync();
           
        }

        public async Task<List<GetNodeByUSer>> GetUserRate(int? Dersid, int Userid)
        {
           
                var result = from u in dbcontext.Users.AsNoTracking()
                             join n in dbcontext.Notes.AsNoTracking()
                             on u.Id equals n.UserId
                             join d in dbcontext.Dersler.AsNoTracking()
                             on n.DersID equals d.Id
                             where d.Id == (Dersid ==null ? d.Id: Dersid)
                             && u.Id == Userid
                             select new GetNodeByUSer
                             {
                                 DersAdi = d.DersAdi,
                                 Description = n.Description,
                                 AddedTime = n.AddedTime,
                                 Name = u.Name,
                                 Surname = u.Surname,
                                 NoteValue = n.NoteValue

                             };

            return await result.ToListAsync();
        }
        public async Task<UserNote> GetUserAvarage(int? Dersid, int Userid)
        {

            var resultQery = await (from u in dbcontext.Users.AsNoTracking()
                                    join n in dbcontext.Notes.AsNoTracking()
                         on u.Id equals n.UserId
                         join d in dbcontext.Dersler.AsNoTracking()
                         on n.DersID equals d.Id
                         where d.Id == (Dersid == null ? d.Id : Dersid)
                         && u.Id == Userid
                         select n.NoteValue).ToListAsync();


            var average = resultQery.Average();

            var userNote =new UserNote
            {
                AvgValue = average,
                DersId =Dersid,
                UserId=Userid
            };

            return  userNote;
        }

        public async Task<ClassNote> GetClassAvarage(int? Dersid, int ClassId)
        {
            var resultofNOtes =await (from u in dbcontext.Users.AsNoTracking()
                            join uc in dbcontext.UserClasses.AsNoTracking()
                            on u.Id equals uc.UserId
                            join n in dbcontext.Notes.AsNoTracking()
                            on u.Id equals n.UserId
                            join d in dbcontext.Dersler.AsNoTracking()
                            on n.DersID equals d.Id
                            join c in dbcontext.Classes.AsNoTracking()
                            on uc.ClassId equals c.Id
                            where uc.ClassId == ClassId
                            && d.Id == (Dersid == null ? d.Id : Dersid)
                            && n.DersID == (Dersid == null ? d.Id : Dersid)
                            select n.NoteValue).ToListAsync();

            var averageValue =  resultofNOtes.Average();
            var name = await dbcontext.Classes.AsNoTracking().Where(x => x.Id == ClassId).Select(y=>y.Name)
                .FirstOrDefaultAsync();
            var ad = Dersid is null ? "Genel Ortalama"
                : await dbcontext.Dersler.AsNoTracking()
                .Where(X => X.Id == Dersid).Select(y => y.DersAdi)
                .FirstOrDefaultAsync();

            var classNote = new ClassNote
            {
                AveragaValue = averageValue,
                ClassName = name,
                DersAdi = ad
            };
            
            return classNote;      
        }

        
    }
}
