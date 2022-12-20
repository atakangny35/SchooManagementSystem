using OkulYönetim.Entity.concrete;

namespace OkulYönetim.Entity.EntityFramework.interfaces
{
    public interface IMessagesRepository:IGenericRepository<Messages>
    {
        Task<string> GetQueueName(int senderid, int receiverid);
    }
}
