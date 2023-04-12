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
        [Route("list")]
        public async Task<ActionResult> GetList()
        {
           
            var response =
            await _daprClient.InvokeMethodAsync<List<string>>(
              HttpMethod.Get, "backend", "/WeatherForecast/GetStates");
            return Ok(response);
        }
        [HttpGet]
        [Route("single")]
        public async Task<ActionResult<string>> GetSigle()
        {

            var response =
            await _daprClient.InvokeMethodAsync<string>(
              HttpMethod.Get, "backend", "/WeatherForecast/GetStates");
            return Ok(response);
        }


    }
}
