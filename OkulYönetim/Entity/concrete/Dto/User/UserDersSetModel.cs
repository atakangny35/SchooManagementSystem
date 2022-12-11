using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserDersSetModel:IDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int DersId { get; set; }
    }
}
