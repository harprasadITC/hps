using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SSEUpdate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class sseventController : ControllerBase
    {
        private readonly ILogger<sseventController> _logger;

        public sseventController(ILogger<sseventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Get()
        {
            var response = Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            int intPrint = 10;
            for (var i = 0;i<= intPrint;  ++i)
            {
                await response.WriteAsync($"data: Controller {i} at {DateTime.Now}\r\r");

                response.Body.Flush();
                await Task.Delay(5 * 1000);
            }
        }
    }
}
