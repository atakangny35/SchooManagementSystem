using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserAddModel:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Branch { get; set; }
        public int? ClassId { get; set; }
        public int? DersId { get; set; }
        public int UserRoleId { get; set; }
    }
}
