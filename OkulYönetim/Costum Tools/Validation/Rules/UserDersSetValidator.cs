using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.Context;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class UserDersSetValidator : AbstractValidator<UserDersSetModel>
    {
        public UserDersSetValidator()
        {
            RuleFor(x => x.DersId).NotEmpty().WithMessage(Constance.DersNotFound);
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID Bilgisi Boş Geçilemez!");
            RuleFor(x => x.UserId).Must(userid => IsUserExists(userid)).WithMessage(Constance.UserNotFOund);
            RuleFor(x => x.DersId).Must(DersId => IsDersExists(DersId)).WithMessage(Constance.DersNotFound);
        }
        public bool IsUserExists(int userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Users.Where(x => x.Id == userId).Any();
                return a;


            }
        }
        public bool IsDersExists(int DersId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Dersler.Where(x => x.Id == DersId).Any();
                return a;


            }
        }
    }
}
