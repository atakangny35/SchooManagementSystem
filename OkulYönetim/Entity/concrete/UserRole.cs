using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class UserRole:IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public  ICollection<User> Users { get; set; }

    }
}
