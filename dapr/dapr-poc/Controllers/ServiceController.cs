using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dapr_poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly DaprClient _daprClient;
        public ServiceController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {

            var response =
            await _daprClient.InvokeMethodAsync<List<string>>(
              HttpMethod.Get, "backend", "/WeatherForecast/GetWeatherForecast");
            return Ok(response);
        }


    }
}
