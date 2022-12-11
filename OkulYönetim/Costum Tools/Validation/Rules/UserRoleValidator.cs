using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class UserRoleValidator: AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {

            RuleFor(x => x.RoleName).NotEmpty().WithMessage(Constance.RoleMust).MinimumLength(3).WithMessage("Kişi ünvanı Minimum 3 karakter olamlıdır");
            


        }
    }
}
