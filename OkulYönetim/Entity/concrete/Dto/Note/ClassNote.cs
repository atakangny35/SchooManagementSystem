using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.Note
{
    public class ClassNote:IDto
    {
        public string ClassName { get; set; }
        public string DersAdi { get; set; }
        public float AveragaValue { get; set; }
    }
}
