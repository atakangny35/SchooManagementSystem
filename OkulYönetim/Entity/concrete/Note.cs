using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class Note:IEntity
    {
        public int Id { get; set; }
        public float NoteValue { get; set; }
        public string? Description { get; set; }
        public DateTime AddedTime { get; set; }
        public  int UserId { get; set; }
        public User Users { get; set; }

        public int DersID { get; set; }

        public Ders Dersler { get; set; }
    }
}
