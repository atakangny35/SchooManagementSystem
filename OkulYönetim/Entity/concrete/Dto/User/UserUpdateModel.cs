using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserUpdateModel:IDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Branch { get; set; }
       // public int? ClassId { get; set; }
        //public int? DersId { get; set; }
    }
}
