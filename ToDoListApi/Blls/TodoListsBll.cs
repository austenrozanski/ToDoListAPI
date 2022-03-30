using ToDoListApi.Dals;
using ToDoListApi.Dtos;

namespace ToDoListApi.Blls
{
    public class TodoListsBll
    {
        private readonly TodoListDal _todoListDal;
        public TodoListsBll(TodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public async Task<IEnumerable<TodoListDto>> GetTodoLists()
        {
            return await _todoListDal.GetTodoLists();
        }
    }
}
