using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete.Dto.Messages
{
    public class SendMessageModel:IDto
    {
        public string Message { get; set; }
        public  int SenderId  { get; set; }
        public  int ReceiverrId  { get; set; }
    }
}
