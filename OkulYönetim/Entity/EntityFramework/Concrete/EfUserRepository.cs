using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using OkulYönetim.Costum_Tools.Validation;
using OkulYönetim.Costum_Tools.Validation.Rules;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;
using OkulYönetim.Utilities;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public EfUserRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        public async  Task<User> FindByMail(string email)
        {
            return  await dbContext.Users.Where(i => i.Email == email).FirstOrDefaultAsync();
             

        }

        public async Task<UserProfileGetModel> FindByMailWithRoleName(string email)
        {
            var result = from u in dbContext.Users
                         join ur in dbContext.UserRoles
                         on u.UserRoleId equals ur.Id
                         where u.Email == email
                         select new UserProfileGetModel
                         {
                             Branch = u.Branch,
                             Email = email,
                             Name = u.Name,
                             Surname = u.Surname,
                             RoleName = ur.RoleName
                         };
            return await result.FirstOrDefaultAsync();

            
        }
        public async Task<bool> AddFromExcel(string FilePath, int ClassId)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        string Name=reader.GetString(0);
                        string Surname=reader.GetString(1);
                        string Mail=reader.GetString(2);
                        string Password = reader.GetString(3);
                        double DersId=reader.GetDouble(4);
                        double UserRoleId =reader.GetDouble(5);

                       // int dersidd = (int)DersId;
                        UserAddModel model = new UserAddModel 
                        { 
                            Branch=null,
                            Surname=Surname,
                            ClassId=ClassId,
                            DersId= (int)DersId,
                            Email=Mail,
                            Name=Name,
                            Password=Password,
                           UserRoleId= (int)UserRoleId
                        };
                        var result = ValidationTool.Validate(model, new UserAddValidator());
                        if (result.Count > 0)
                        {
                            continue;
                        }
                        HashingHelper.CreatePasswordHash(model.Password, out byte[] salt, out byte[] Hash);

                        User user = new User
                        {
                            Branch = model.Branch,
                            Surname = model.Surname,
                            Email = model.Email,
                            Name = model.Name,
                            PasswordHash = Hash,
                            PasswordSalt = salt,
                            UserRoleId = model.UserRoleId
                        };
                        await dbContext.Users.AddAsync(user);
                        await dbContext.SaveChangesAsync();
                        UserDers userDers = new UserDers
                        {
                            Dersid = (int)model.DersId,
                            Userid = user.Id,

                        };
                        await dbContext.UserDers.AddAsync(userDers);
                        await dbContext.SaveChangesAsync();

                        UserClass userClass = new UserClass
                        {
                            ClassId = (int)model.ClassId,
                            UserId = user.Id,
                        };
                        await dbContext.UserClasses.AddAsync(userClass);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
            System.IO.File.Delete(FilePath);
            return true;
        }
    }
}
