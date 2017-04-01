using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repository.EF.Core;
using Repository.EF.Core.Models;

namespace aspnet.core.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoApiController : Controller
    {
        private readonly IRepository<Todo> _repo;
        public TodoApiController(IRepository<Todo> repo)
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
            _repo.Commit();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Todo item)
        {   
            if (item == null || item.Id != id)
                return BadRequest();

            var todo = _repo.Get(id);
            if (todo == null)
                return NotFound();

            todo.IsCompleted = item.IsCompleted;
            todo.Content = item.Content;

            _repo.Update(todo);
            _repo.Commit();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _repo.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            _repo.Delete(todo);
            _repo.Commit();

            return new NoContentResult();
        }
    }
}