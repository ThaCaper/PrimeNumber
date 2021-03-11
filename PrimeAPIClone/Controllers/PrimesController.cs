using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PrimeAPIClone.Data;

namespace PrimeAPIClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimesController : ControllerBase
    {
        private readonly IRepository _repo;

        private readonly ILogger<PrimesController> _logger;

        public PrimesController(IRepository repo, ILogger<PrimesController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET <PrimesController>/5
        [HttpGet("{input}")]
        public bool Get(string input)
        {
            _logger.LogInformation("Prime Server request started " + DateTime.Now.ToLongTimeString());
            Thread.Sleep(2000);
            _logger.LogInformation("Prime Server request stopped " + DateTime.Now.ToLongTimeString());
            return _repo.IsPrimeNumber(input);
        }

        [HttpGet]
        [Route("{start}={end}")]
        public string CountPrimeNumbers(string start, string end)
        {
            _logger.LogInformation("Prime Server request started " + DateTime.Now.ToLongTimeString());
            Thread.Sleep(2000);
            _logger.LogInformation("Prime Server request stopped " + DateTime.Now.ToLongTimeString());
            return _repo.CountPrimes(start, end);
        }
    }
}
