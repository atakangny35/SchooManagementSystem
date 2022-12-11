using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class UserDers:IEntity
    {
        public int Id { get; set; }



        public int Userid { get; set; }
        public  User Users { get; set; }

        public int Dersid { get; set; }
        public Ders Dersler { get; set; }
    }
}
