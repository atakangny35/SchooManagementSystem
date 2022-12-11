namespace OkulYönetim.Entity.Jwt
{
    public class Token
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpireDate { get; set; }
        public string SecurityKey { get; set; }
    }
}
