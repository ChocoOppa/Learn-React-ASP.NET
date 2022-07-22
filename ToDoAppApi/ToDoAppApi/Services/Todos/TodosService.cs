using ToDoAppApi.Data;

namespace ToDoAppApi.Services.Todos
{
    public class TodosService : ITodosService
    {
        private readonly TodosDbContext _todosDbContext;

        public TodosService(TodosDbContext todosDbContext)
        {
            _todosDbContext = todosDbContext;
        }

        public bool AddTodos(Todo todo)
        {
            _todosDbContext.Todos.Add(todo);
            _todosDbContext.SaveChanges();
            return true;
        }

        public bool DeleteTodos(int id)
        {
            Todo todo = _todosDbContext.Todos.Find(id);

            _todosDbContext.Todos.Remove(todo);
            _todosDbContext.SaveChanges();
            return true;
        }

        public List<Todo> GetTodos()
        {
            return _todosDbContext.Todos.OrderBy(x => x.Id).ToList();
        }

        public bool UpdateTodos(int id, Todo todo)
        {
            _todosDbContext.Todos.Update(todo);
            _todosDbContext.SaveChanges();
            return true;
        }
    }
}
