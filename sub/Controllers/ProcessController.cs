using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace sub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly ILogger<ProcessController> _logger;

        public ProcessController(ILogger<ProcessController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/process")]
        public void Run([FromBody] object body)
        {
             
            _logger.LogInformation("dataset process request received");
            if (body.ToString().Contains("9999"))
            {
                System.Threading.Thread.Sleep(10000);
            }
            _logger.LogInformation(body.ToString());
            _logger.LogInformation("dataset processing done");
        }

        [HttpPost("/completed")]
        public void RunCompletedStatusActivity([FromBody] object body)
        {

            _logger.LogInformation("dataset complete status request received");
            _logger.LogInformation(body.ToString());
            _logger.LogInformation("Post status activity has been done.");
        }



    }
}
