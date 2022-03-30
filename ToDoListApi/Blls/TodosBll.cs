using ToDoListApi.Dals;
using ToDoListApi.Dtos;

namespace ToDoListApi.Blls
{
    public class TodosBll
    {
        private readonly TodoListDal _todoListDal;
        public TodosBll(TodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public async Task<IEnumerable<TodoDto>> GetTodos(int? listId)
        {
            if (listId == null)
            {
                return await _todoListDal.GetAllTodos();
            }
            else
            {
                return await _todoListDal.GetTodosFromList(listId.GetValueOrDefault());
            }
        }

        public async Task<TodoDto> CreateTodo(int? listId, string label)
        {
            if (listId == null)
            {
                throw new BadHttpRequestException($"No valid listId provided");
            }

            var newTodo = await _todoListDal.CreateTodo(listId.GetValueOrDefault(), label);
            return newTodo;
        }

        public async Task<TodoDto> UpdateTodo(int id, string label)
        {
            if (String.IsNullOrEmpty(label))
            {
                throw new BadHttpRequestException($"Invalid label for todo provided");
            }

            var newTodo = await _todoListDal.UpdateTodo(id, label);
            return newTodo;
        }

        public async Task<TodoDto> ToggleTodo(int id)
        {
            var newTodo = await _todoListDal.ToggleTodo(id);
            return newTodo;
        }

        public async Task DeleteTodo(int id)
        {
            await _todoListDal.DeleteTodo(id);
        }
    }
}
