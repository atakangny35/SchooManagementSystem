using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class Class:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserClass> userClasses { get; set; }

    }
}
