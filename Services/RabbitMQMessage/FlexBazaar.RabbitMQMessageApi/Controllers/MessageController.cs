using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
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

            await channel.QueueDeclareAsync("Kuyruk1", false, false, false, arguments: null);

            var messageContent = "Merhaba bu bir RabbitMQ kuyruk mesajıdır.";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            await channel.BasicPublishAsync(exchange:"",routingKey:"Kuyruk1",body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır");
        }
    }
}
