using Microsoft.IdentityModel.Tokens;
using OkulYönetim.Entity.concrete.Dto.Login;
using OkulYönetim.Entity.concrete.Dto.Token;
using OkulYönetim.Entity.EntityFramework.interfaces;
using OkulYönetim.Utilities.JWT.Abstract;
using OkulYönetim.Utilities.JWT.Encryption;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OkulYönetim.Utilities.JWT.Constance
{
    public class JwtGenerator : IJwtHelper
    {

        public IConfiguration configuration { get; }
        private TokenOption _tokenOptions;
        private IUserRepository userRepository;
        DateTime expireDate;
        public JwtGenerator(IConfiguration _configuration,IUserRepository _userRepository)
        {
            configuration = _configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOption>();// Extensiond.configration.binder kurulmalı !
            userRepository = _userRepository;
        }

        public  async Task<Token> GenerateJwtToken(UserLoginModel model)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var data = SignInCreditentialGeneretor.GenereteSignInKey(_tokenOptions.SecurityKey);
            expireDate = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpireDate);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity( await GetClaims(model.Role, model.Email, model.Id));

            var jwt = new JwtSecurityToken(issuer: _tokenOptions.Issuer, audience: _tokenOptions.Audience, expires: expireDate, notBefore: DateTime.Now, claims: await GetClaims(model.Role, model.Email, model.Id), signingCredentials: data);

            var test = jwtSecurityTokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Audience = _tokenOptions.Audience,
                Subject = claimsIdentity,
                SigningCredentials = data,
                Issuer = _tokenOptions.Issuer,
                Expires = expireDate,
                NotBefore = DateTime.Now,
            });



            var token = jwtSecurityTokenHandler.WriteToken(test);

            return new Token { token = token, succes = true, expire = expireDate };
        }
        public async Task<IEnumerable<Claim>> GetClaims(string? Role, string? Email, int id)
        {

            var user = await userRepository.Get(id);
            var FullName = user.Name + ' ' + user.Surname;
            List<Claim> claims = new List<Claim>();
            if (Role is not null && Email is not null)
            {
                claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, Role));
                claims.Add(new Claim(ClaimTypes.Email, Email));
                claims.Add(new Claim(ClaimTypes.Name, FullName));
            }


            return claims;
        }
    }
}
