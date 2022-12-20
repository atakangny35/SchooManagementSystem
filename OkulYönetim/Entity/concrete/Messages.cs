using OkulYönetim.Entity.Interfaces;

namespace OkulYönetim.Entity.concrete
{
    public class Messages : IEntity
    {
        public int Id { get; set; }

        public string QueueName { get; set; }

        public DateTime SendedDate { get; set; }

        public bool IsSended { get; set; }

        public bool IsReaded { get; set; }

        public int SenderId { get; set; }

        public User? SenderUser { get; set; }


        public int ReceiverId { get; set; }
        public User? ReceiverUser { get; set; }


        
    }
    
}
