using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class Ders:IEntity
    {
        public int Id { get; set; }

        public string DersAdi { get; set; }

        public ICollection<UserDers> userDers { get; set; }

    }
}
