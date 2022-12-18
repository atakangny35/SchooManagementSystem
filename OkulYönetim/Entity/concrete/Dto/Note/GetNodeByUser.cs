using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.Note
{
    public class GetNodeByUSer:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float NoteValue { get; set; }
        public string? Description { get; set; }
        public DateTime AddedTime { get; set; }
        public string DersAdi { get; set; }
    }
}
