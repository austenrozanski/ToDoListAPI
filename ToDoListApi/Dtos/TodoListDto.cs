using ToDoListApi.Entities;

namespace ToDoListApi.Dtos
{
    public class TodoListDto
    {
        public TodoListDto(TodoList list)
        {
            Id = list.Id;
            Title = list.Title;
            TodoIds = list.Todos?.Select(x => x.Id).ToList();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public List<int>? TodoIds { get; set; }
    }
}
