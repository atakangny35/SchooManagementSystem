using OkulYönetim.Entity.concrete.Dto.Login;
using OkulYönetim.Entity.concrete.Dto.Token;

namespace OkulYönetim.Utilities.JWT.Abstract
{
    public interface IJwtHelper
    {
        Task<Token> GenerateJwtToken(UserLoginModel model);
    }
}
