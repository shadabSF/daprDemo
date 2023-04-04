using ConsumerApi.DTO;
using Dapr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderConsumerController : ControllerBase
    {
        private readonly ILogger<OrderConsumerController> _logger;
        private const string DAPR_PUBSUB_NAME = "order_pub_sub";
        private const string TOPIC_NAME = "orders";

        public OrderConsumerController(ILogger<OrderConsumerController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //Subscribe to a topic
        [Topic(DAPR_PUBSUB_NAME, TOPIC_NAME)]
        [HttpPost("order-subscriber")]
        public void OrderSubscriber([FromBody] Order order)
        {
            Console.WriteLine("Subscriber received : " + order.OrderId);
            _logger.LogInformation($"Received checkout: {order.OrderId}, {order.OrderNumber},{order.OrderDate}");
        }
    }
}
