using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimesController : ControllerBase
    {
        private readonly IRepository _repo;

        public PrimesController(IRepository repo)
        {
            _repo = repo;
        }

        // GET <PrimesController>/5
        [HttpGet("{input}")]
        public bool Get(string input)
        {
            return _repo.IsPrimeNumber(input);
        }

        [HttpGet]
        [Route("{start}={end}")]
        public string CountPrimeNumbers(string start, string end)
        {
            return _repo.CountPrimes(start, end);
        }
    }
}
