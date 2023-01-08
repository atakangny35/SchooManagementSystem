using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;
using System.Collections.Generic;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfClassRepository : EfGenericRepository<Class>, IClassepository
    {
        private readonly ApplicationDbContext dbcontext;
        public EfClassRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbcontext = _dbContext;
        }

        public async Task<List<ListOfUserListModel>> GetUsersByClasses(int userid)
        {




            var classlist = dbcontext.UserClasses.AsNoTracking().Where(x=>x.UserId==userid).ToList();

            List <ListOfUserListModel> f= new List<ListOfUserListModel> ();
                
            foreach (var item in classlist)
            {
                var a = from uc in dbcontext.UserClasses.AsNoTracking()
                        join u in dbcontext.Users.AsNoTracking()
                        on uc.UserId equals u.Id
                        where u.Id != userid && uc.ClassId == item.ClassId && u.Branch ==null
                        select new UserListModel
                        {
                            Userid = u.Id,
                            UserSurname = u.Surname,
                            UserName = u.Name,
                           // ClassId= item.ClassId
                        };

                ListOfUserListModel listOfUserListModel = new ListOfUserListModel
                {
                    ClassId = item.ClassId,
                    userList = await a.ToListAsync()

                };
                f.Add(listOfUserListModel);

                   

            }

            return f;
            
        }
    }
}
