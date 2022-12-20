using RabbitMQ.Client;
using System.Text;

namespace OkulYönetim.Costum_Tools.RabbitMQ
{
   
        public class RabbitMQRepository
        {
            private readonly Uri _uri;
            
            //public IConfiguration configuration { get; }

            public RabbitMQRepository( )
            {
            //var data = configuration.GetSection("RabbitMQ:Uri").Value;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var data = configuration.GetSection("RabbitMQ:Uri").Value;

            _uri = new Uri (data);
               
            }

            public void Send(string message,string queueName)
            {
                // Create a connection factory
                var factory = new ConnectionFactory() { Uri = _uri };

                // Create a connection
                using (var connection = factory.CreateConnection())
                {
                    // Create a channel
                    using (var channel = connection.CreateModel())
                    {
                        // Declare a queue
                        channel.QueueDeclare(queueName, true, false, false);

                        // Convert the message to a byte array
                        var body = Encoding.UTF8.GetBytes(message.ToString());

                        // Send the message to the queue
                        channel.BasicPublish("", queueName, null, body);
                    }
                }
            }

            public string Receive(string queueName)
            {
                // Create a connection factory
                var factory = new ConnectionFactory() { Uri = _uri };

                // Create a connection
                using (var connection = factory.CreateConnection())
                {
                    // Create a channel
                    using (var channel = connection.CreateModel())
                    {
                        // Declare a queue
                        channel.QueueDeclare(queueName, true, false, false);

                        // Receive a message from the queue
                        var result = channel.BasicGet(queueName, true);
                        if (result == null)
                        {
                        return "";
                        }

                        // Convert the message to the desired type
                        var message = Encoding.UTF8.GetString(result.Body.ToArray());
                    return message;
                    }
                }
            }
        }
    
}
