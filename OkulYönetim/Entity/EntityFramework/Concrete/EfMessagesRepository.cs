using Microsoft.EntityFrameworkCore;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.EntityFramework.Context;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Entity.EntityFramework.Concrete
{
    public class EfMessagesRepository : EfGenericRepository<Messages>, IMessagesRepository
    {   
        
        public EfMessagesRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {

        }

        public  async Task<string> GetQueueName(int senderid,int receiverid)
        {
            using(ApplicationDbContext dbContext=new ApplicationDbContext())
            {
                var QueueName = await dbContext.Messages.Where(x => x.SenderId == senderid && x.ReceiverId == receiverid).Select(y=>y.QueueName).FirstOrDefaultAsync();
                return QueueName is null ? "" : QueueName;
            }
        }

    }
}
