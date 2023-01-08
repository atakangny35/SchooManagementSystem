using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class UserListModel:IDto
    {
        public int Userid { get; set; }
        public string   UserName { get; set; }
        public string   UserSurname { get; set; }
       // public int  ClassId { get; set; }
    }
}
