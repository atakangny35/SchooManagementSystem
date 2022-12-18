using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.Note
{
    public class UserNote:IDto
    {
        public int UserId { get; set; }
        public int? DersId { get; set; }
        public float AvgValue { get; set; }
    }
}
