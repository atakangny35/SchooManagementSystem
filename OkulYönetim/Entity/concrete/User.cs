using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Name  { get; set; }
        public string Surname { get; set; }
        public string? Branch { get; set; }

        //public int? UserClassId { get; set; }

       // public int? UserDersId { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public ICollection<UserClass> userClasses { get; set; }
        public ICollection<UserDers> userDers { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}
