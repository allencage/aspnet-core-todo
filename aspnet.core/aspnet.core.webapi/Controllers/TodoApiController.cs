using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.EF.Core;

namespace aspnet.core.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoApiController : Controller
    {
        private readonly ITodoRepository _repo;
        public TodoApiController(ITodoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var result = _repo.Get(id);
            if (result == null)
                return NotFound();
            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Todo item)
        {
            if (item == null)
                return BadRequest();
            _repo.Add(item);

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
    }
}