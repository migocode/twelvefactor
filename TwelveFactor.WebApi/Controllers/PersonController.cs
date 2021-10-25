using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwelveFactor.WebApi.Data;
using TwelveFactor.WebApi.Data.Models;

namespace TwelveFactor.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await personRepository.SelectAllAsync();
        }

        [HttpPost]
        public async Task Post(Person person)
        {
            await personRepository.InsertAsync(person);
        }
    }
}
