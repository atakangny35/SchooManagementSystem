using FluentValidation;
using OkulYönetim.Constances;
using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Costum_Tools.Validation.Rules
{
    public class DersValidator:AbstractValidator<Ders>

    {
        public DersValidator()
        {
            int charval = 4;

            RuleFor(x => x.DersAdi).MinimumLength(charval).WithMessage($"Ders Adı {charval} Karektarden küçük olamaz!").NotEmpty().WithMessage(Constance.DersNotFound);
        }
    }
}
