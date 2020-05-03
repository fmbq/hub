using System;
using System.Threading.Tasks;
using FMBQ.Hub.Auth;
using FMBQ.Hub.Models;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers.Api
{
    [Route("/api/people")]
    [OpenApiTag("person")]
    public class PersonController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<Person> GetPerson(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [AuthRequired]
        public async Task CreatePerson([FromBody] Person person)
        {
            throw new NotImplementedException();
        }
    }
}
