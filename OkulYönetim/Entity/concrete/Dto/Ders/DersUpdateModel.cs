using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.Ders
{
    public class DersUpdateModel:IDto
    {
        public int Id { get; set; }

        public string DersAdi { get; set; }
    }
}
