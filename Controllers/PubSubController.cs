using Dapr;
using Dapr.Client;
using dapr_poc.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dapr_poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubSubController : ControllerBase
    {
        private string PUBSUB_NAME = "order_pub_sub";
        private string TOPIC_NAME = "orders";

        private readonly ILogger<PubSubController> _logger;
        private readonly DaprClient _daprClient;

        public PubSubController(ILogger<PubSubController> logger, DaprClient daprClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("Get Order API");
            return new List<string>();
        }

        [HttpPost]
        [Route("publishorder")]
        public async Task<IActionResult> OrderProduct(Order order)
        {
            _logger.LogInformation("Post Order API");

            //Validate order placeholder
            try
            {
                var orderMessage = new Order
                {
                    OrderId = Guid.NewGuid(),
                    OrderAmount = order.OrderAmount,
                    OrderNumber = order.OrderNumber,
                    OrderDate = DateTime.UtcNow
                };

                await _daprClient.PublishEventAsync(PUBSUB_NAME, TOPIC_NAME, orderMessage);

                _logger.LogInformation(
                    "Send a message with Order ID {orderId}, {orderNumber}",
                    orderMessage.OrderId, orderMessage.OrderNumber);

                return Ok("Your order is processing.");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error Send a message, {OrderNumber}", order.OrderNumber);

            }

            return BadRequest();
        }

    }
}
