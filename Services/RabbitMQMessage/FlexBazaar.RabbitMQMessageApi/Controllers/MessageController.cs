using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMessage() {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            var connection = await connectionFactory.CreateConnectionAsync();

            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync("Kuyruk2", false, false, false, arguments: null);

            var messageContent = "Merhaba bugün hava çok soğuk.";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            await channel.BasicPublishAsync(exchange:"",routingKey: "Kuyruk2", body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }

        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            var factory = new ConnectionFactory();

            factory.HostName = "localhost";

            var connection = await factory.CreateConnectionAsync();            

            using(var channel = await connection.CreateChannelAsync())
            {
              await channel.QueueDeclareAsync("Kuyruk2", false, false, false, arguments: null);

                BasicGetResult? result = await channel.BasicGetAsync(queue: "Kuyruk2", autoAck: false);

                if (result is null)
                {
                    return Ok("Kuyrukta okunacak mesaj bulunamadı.");
                }

                try
                {
                    var messageBody = result.Body.ToArray();
                    var message = Encoding.UTF8.GetString(messageBody);

                   await channel.BasicAckAsync(deliveryTag: result.DeliveryTag, multiple: false);

                    return Ok(message);
                }
                catch(Exception)
                {
                    return StatusCode(500, "Mesaj işlenirken bir hata oluştu.");
                }
            }                        
        }      
    }
}
