using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dapr_poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateManagementController : ControllerBase
    {
        private readonly DaprClient _daprClient;
        public StateManagementController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }
        [HttpGet("{key}")]
        public async Task<ActionResult<string>> Get(string key)
        {
            var value = await _daprClient.GetStateAsync<string>("statestore", key);
            return Ok(value);
        }
        [HttpPost("savestate")]
        public async Task<ActionResult> Post([FromBody] StateStore stateStore)
        {
            await _daprClient.SaveStateAsync("statestore", stateStore.Key, stateStore.Value);
            return Ok(stateStore);
        }
    }
}
