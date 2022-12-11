using OkulYönetim.Entity.concrete.Dto.Login;
using OkulYönetim.Entity.concrete.Dto.Token;

namespace OkulYönetim.Utilities.JWT.Abstract
{
    public interface IJwtHelper
    {
        Token GenerateJwtToken(UserLoginModel model);
    }
}
