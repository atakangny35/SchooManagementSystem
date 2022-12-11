using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OkulYönetim.Utilities.JWT.Encryption
{
    public class SignInCreditentialGeneretor
    {
        public static SigningCredentials GenereteSignInKey(string key)
        {

            var symetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(symetrickey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
