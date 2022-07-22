using Microsoft.AspNetCore.Mvc;
using ToDoAppApi.Services.Todos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _todosService;

        public TodosController(ITodosService todosService)
        {
            _todosService = todosService;
        }
        // GET: api/<TodosController>
        [HttpGet]
        public IActionResult Get() => Ok(_todosService.GetTodos());
            
        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TodosController>
        [HttpPost]
        public IActionResult Post(Todo todo)
        {
            return Ok(_todosService.AddTodos(todo));
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Todo todo)
        {
            return Ok(_todosService.UpdateTodos(id, todo));
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_todosService.DeleteTodos(id));
        }
    }
}
