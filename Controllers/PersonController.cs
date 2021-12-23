using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using secret_santa.Domain;
using secret_santa.handlers;

namespace secret_santa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonHandler _handler;

        public PersonController(ILogger<PersonController> logger, IPersonHandler personHandler)
        {
            _logger = logger;
            _handler = personHandler;
        }

        [HttpGet]
        [Route("getPeople")]
        public async Task<IEnumerable<Person>> GetPeople() => await _handler.GetPeople();

        [HttpPost]
        [Route("insertPerson")]
        public async Task<Person> InsertPerson([FromBody] Person person) => await _handler.InsertPerson(person);
        

        [HttpPost]
        [Route("getSantaFriend")]
        public async Task<Person> GetSantaFriend([FromBody] string personName) => await _handler.GetSantaFriend(personName);
    }
}
