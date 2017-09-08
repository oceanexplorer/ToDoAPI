using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Domain;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoManager _todoManager;

        public TodoController(TodoManager todoManager)
        {
            _todoManager = todoManager;
        }

        public IEnumerable<TodoItem> Index()
        {
            return _todoManager.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult Show(long id)
        {
            var item = _todoManager.GetById(id);

            if(item == null) return NotFound();

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null) return BadRequest(); 

            _todoManager.Add(item);         

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id) { return BadRequest(); }

            _todoManager.Update(item);

            return new NoContentResult();
        }        
        
        [HttpDelete("{id}")]
        public IActionResult Destroy(long id)
        {
            _todoManager.Remove(id);
            
            return new NoContentResult();
        }
    }    
}
