namespace OkulYönetim.Entity.concrete.Dto.Note
{
    public class GetNoteByCLass
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public float NoteValue { get; set; }
        public string? Description { get; set; }
        public DateTime AddedTime { get; set; }
        public string DersAdi { get; set; }
        public string ClassName { get; set; }
    }
}
