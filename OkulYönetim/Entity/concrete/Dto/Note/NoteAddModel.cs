namespace OkulYönetim.Entity.concrete.Dto.Note
{
    public class NoteAddModel
    {
        public float NoteValue { get; set; }
        public int UserId { get; set; }
        public int DersID { get; set; }
        public string? Description { get; set; }
    }
}
