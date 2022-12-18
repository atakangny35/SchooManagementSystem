using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserClassSetModel:IDto
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }
}

