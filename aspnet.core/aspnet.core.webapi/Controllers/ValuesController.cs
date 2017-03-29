using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repository.EF.Core;

namespace aspnet.core.webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepository<Todo> _repo;
        public ValuesController(IRepository<Todo> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
