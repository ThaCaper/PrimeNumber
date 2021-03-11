using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LoadBalancer.Controllers
{
    [Route("")]
    [ApiController]
    public class LoadBalancerController : ControllerBase
    {
        private readonly ILogger<LoadBalancerController> _logger;

        private static readonly string[] _servers = { "https://localhost:44355", "https://localhost:44395" };

        private static int next = 0;

        public LoadBalancerController(ILogger<LoadBalancerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{input}")]
        public IEnumerable<string> IsPrime(string input)
        {
            _logger.LogInformation("LoadBalancer server requested");

            string server = _servers[next] + "/primes/" + input;
            next = (next + 1) % _servers.Length;

            Response.Redirect(server);

            IEnumerable<string> result = new List<string>();

            return result;
        }

        [HttpGet]
        [Route("{start}={end}")]
        public IEnumerable<string> GetNumbers(string start, string end)
        {
            _logger.LogInformation("LoadBalancer server requested");

            string server = _servers[next] + "/primes/" + start + "=" + end;
            next = (next + 1) % _servers.Length;

            Response.Redirect(server);

            IEnumerable<string> result = new List<string>();

            return result;
        }
    }
}
