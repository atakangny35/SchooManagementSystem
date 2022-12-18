using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class NoteUpdateValidator:AbstractValidator<Note>
    {
        public NoteUpdateValidator()
        {
            RuleFor(x => x.DersID).NotEmpty().WithMessage(Constance.DersNotFound);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(Constance.DersNotFound);
            RuleFor(x => x.NoteValue).NotEmpty().WithMessage("Not bilgisi boş geçilemez!");
            RuleFor(x => x.DersID).Must(DersID => IsDersExists(DersID)).WithMessage(Constance.DersNotExists);
            RuleFor(x => x.UserId).Must(UserId => IsUserExists(UserId)).WithMessage(Constance.UserNotFOund);
        }
        public bool IsUserExists(int userId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Users.Where(x => x.Id == userId).Any();
                return a;


            }
        }
        public bool IsDersExists(int dersid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Dersler.Where(x => x.Id == dersid).Any();

                return a;


            }
        }
    }
}
