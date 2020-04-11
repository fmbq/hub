using System;
using System.Threading.Tasks;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/people")]
    public class PersonController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<Person> Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task Create([FromBody] Person person)
        {
            throw new NotImplementedException();
        }
    }
}
