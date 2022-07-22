namespace ToDoAppApi.Services.Todos
{
    public interface ITodosService
    {
        List<Todo> GetTodos();

        Boolean AddTodos(Todo todo);
        Boolean UpdateTodos(int id, Todo todo);
        Boolean DeleteTodos(int id);
    }
}
