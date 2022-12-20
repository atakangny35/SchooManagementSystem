using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkulYönetim.Costum_Tools.RabbitMQ;
using OkulYönetim.Entity.concrete;
using OkulYönetim.Entity.concrete.Dto.Messages;
using OkulYönetim.Entity.EntityFramework.interfaces;

namespace OkulYönetim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private RabbitMQRepository RabbitMQRepository;
        private readonly IMessagesRepository messagesRepository;
        public MessagesController(RabbitMQRepository _RabbitMQRepository, IMessagesRepository _messagesRepository)
        {
            RabbitMQRepository=_RabbitMQRepository;
            messagesRepository=_messagesRepository;
        }


        [HttpPost("Send")]
        public async Task<IActionResult> RaabitSend(SendMessageModel sendMessageModel)
        {
            string QueueName = Guid.NewGuid().ToString();
            var message = new Messages
            {
                SendedDate = DateTime.Now,
                SenderId = sendMessageModel.SenderId,
                ReceiverId = sendMessageModel.ReceiverrId,
                IsSended = true,
                QueueName = QueueName
            };
          await messagesRepository.add(message);
          RabbitMQRepository.Send(sendMessageModel.Message, QueueName);
            return Ok("mesaj gitti");
        }

        [HttpPost("Receive")]
        public async Task<IActionResult> RaabitReceive(ReceiveMessageModel model)
        {
           var QueueName = await messagesRepository.GetQueueName(model.SenderId,model.ReceiverId);
            var data = RabbitMQRepository.Receive(QueueName);
            return Ok(data);
        }
    }
}
