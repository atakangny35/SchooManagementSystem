using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace OkulYönetim.Costum_Tools.Validation
{
    public static class ValidationTool
    {
        public static List<string> Validate(object entity, IValidator validator)
        {
            List<string> result = new List<string>();
            var validationContext = new ValidationContext<object>(entity);
            var validationResult = validator.Validate(validationContext);

            if (!validationResult.IsValid)
            {
                foreach (var item in validationResult.Errors)
                {
                    result.Add(item.ErrorMessage);
                }
            }

            return result;
        }
    }
}
