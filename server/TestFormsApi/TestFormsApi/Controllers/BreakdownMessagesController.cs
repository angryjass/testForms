using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestFormsApi.Entities;
using Newtonsoft.Json;

namespace TestFormsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakdownMessagesController : ControllerBase
    {
        private readonly ILogger<BreakdownMessagesController> _logger;

        public BreakdownMessagesController(ILogger<BreakdownMessagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<object>> GetBreakdownMessanges([FromQuery] string text)
        {
            var result = new List<object>();
            foreach(var message in BreakdownMessages.Messages)
            {
                foreach(var keyValuePair in JsonConvert.DeserializeObject<Dictionary<string, string>>(message.ToString()))
                {
                    if (keyValuePair.Value.Contains(text))
                    {
                        result.Add(message);
                        break;
                    }
                }
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public ActionResult SaveBreakdownMessage([FromBody] object breakdownMessage)
        {
            BreakdownMessages.Messages.Add(breakdownMessage);
            
            return Ok();
        }
    }
}
