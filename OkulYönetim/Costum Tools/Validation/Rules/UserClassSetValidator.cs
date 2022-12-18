using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.Context;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class UserClassSetValidator: AbstractValidator<UserClassSetModel>
    {
        public UserClassSetValidator()
        {
            RuleFor(x => x.ClassId).NotEmpty().WithMessage(Constance.ClassNotFound);
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID Bilgisi Boş Geçilemez!");
            RuleFor(x => x.UserId).Must(userid => IsUserExists(userid)).WithMessage(Constance.UserNotFOund);
            RuleFor(x => x.ClassId).Must(ClassId => IsDersExists(ClassId)).WithMessage(Constance.ClassNotExists);
        }
        public bool IsUserExists(int userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Users.Where(x => x.Id == userId).Any();
                return a;


            }
        }
        public bool IsDersExists(int classid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Classes.Where(x => x.Id == classid).Any();
                return a;


            }
        }
    }
}
