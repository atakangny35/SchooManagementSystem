using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.Messages
{
    public class ReceiveMessageModel:IDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
