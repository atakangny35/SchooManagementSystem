using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserDetailModel:IDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ClassName { get; set; }
        public List<string> DersName { get; set; }
        public int DersCount { get; set; }
    }
}
