using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Costum_Tools.Extensions;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.User;
using OkulYönetim.Entity.EntityFramework.Context;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class UserAddValidator: AbstractValidator<UserAddModel>
    {
        public UserAddValidator()
        {

            //RuleFor(x => x.UserRoleId).NotEmpty().WithMessage(Constance.NameMust);
            RuleFor(x => x.Name).MinimumLength(4);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Constance.PassworMust).Matches(@"[A-Z]+").WithMessage(" Şifre En az bir büyük harf bulunmalıdır.")
                .Must(password => CheckPassword(password)).WithMessage("AlfaNUmeric karater bunlunmalı örnek */-+?.!-");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad bilgisi boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage(Constance.MailMust).EmailAddress();
            RuleFor(x => x.UserRoleId).NotEmpty().WithMessage(Constance.RoleMust);
            RuleFor(x => x.Email).Must(email => IsUserExists(email)).WithMessage(Constance.UserExists);


        }
        public bool CheckPassword(string Password)
        {
            if (PasswordExtensions.ContainsAny(Password, "?", "!", ".", "*", "/", "-", "+"))
            {
                return true;
            }
            return false;
        }
        public bool IsUserExists(string email)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var a = db.Users.Where(x => x.Email == email).Any();
                return !a;


            }
        }

    }
}
