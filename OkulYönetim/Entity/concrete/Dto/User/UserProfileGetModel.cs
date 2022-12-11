using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserProfileGetModel:IDto
    {
        public string Email { get; set; }       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Branch { get; set; }
        public string RoleName { get; set; }
    }
}
