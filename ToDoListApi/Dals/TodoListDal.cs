using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;
using ToDoListApi.Dtos;
using ToDoListApi.Entities;

namespace ToDoListApi.Dals
{
    public class TodoListDal
    {
        private readonly TodoListContext _todoListContext;

        public TodoListDal(TodoListContext todoListContext)
        {
            _todoListContext = todoListContext;
        }

        public async Task<IEnumerable<TodoDto>> GetAllTodos()
        {
            var todos = await _todoListContext.Todo
                .Include(t => t.TodoList)
                .Select(x => new TodoDto(x))
                .ToListAsync();
            return todos;
        }

        public async Task<IEnumerable<TodoDto>> GetTodosFromList(int listId)
        {
            var todos = await _todoListContext.Todo
                .Include(t => t.TodoList)
                .Where(x => x.TodoList.Id == listId)
                .Select(x => new TodoDto(x))
                .ToListAsync();
            return todos;
        }

        public async Task<TodoDto> CreateTodo(int listId, string label)
        {
            var list = await _todoListContext.TodoList
                .Where(x => x.Id == listId)
                .FirstOrDefaultAsync();
            if (list == null) { throw new BadHttpRequestException($"No todo list exists with id {listId}"); }

            var newTodo = new Todo 
            { 
                Label = label,
                CreatedTimestamp = DateTime.Now,
                IsDone = false,
                TodoList = list
            };

            await _todoListContext.AddAsync(newTodo);
            await _todoListContext.SaveChangesAsync();

            return new TodoDto(newTodo);
        }

        public async Task<TodoDto> UpdateTodo(int id, string label)
        {
            var todo = await _todoListContext.Todo
                .Include(t => t.TodoList)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (todo == null) { throw new BadHttpRequestException($"No todo exists with id {id}"); }

            todo.Label = label;
            await _todoListContext.SaveChangesAsync();
            
            return new TodoDto(todo);
        }

        public async Task<TodoDto> ToggleTodo(int id)
        {
            var todo = await _todoListContext.Todo
                .Include(t => t.TodoList)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (todo == null) { throw new BadHttpRequestException($"No todo exists with id {id}"); }

            todo.IsDone = !todo.IsDone;
            await _todoListContext.SaveChangesAsync();

            return new TodoDto(todo);
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _todoListContext.Todo
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (todo == null) { throw new BadHttpRequestException($"No todo exists with id {id}"); }

            _todoListContext.Remove(todo);
            await _todoListContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoListDto>> GetTodoLists()
        {
            var lists = await _todoListContext.TodoList
                .Include(t => t.Todos)
                .Select(x => new TodoListDto(x))
                .ToListAsync();
            return lists;
        }
    }
}
