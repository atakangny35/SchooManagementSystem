using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.User
{
    public class ListOfUserListModel:IDto
    {
        public int ClassId { get; set; }
        public List<UserListModel> userList { get; set; }
    }
}
