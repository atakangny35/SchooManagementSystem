using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Entity.concrete.Dto.Login;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class UserLoginModelValidator : AbstractValidator<UserLoginModelController>
    {
        public UserLoginModelValidator()
        {

            //RuleFor(x => x.UserRoleId).NotEmpty().WithMessage(Constance.NameMust);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage(Constance.MustBeEmail);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Constance.PassworMust);
           
        }
    }
}
