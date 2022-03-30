using ToDoListApi.Entities;

namespace ToDoListApi.Dtos
{
    public class TodoDto
    {
        public TodoDto(Todo todo)
        {
            Id = todo.Id;
            Label = todo.Label;
            CreatedTimestamp = todo.CreatedTimestamp;
            IsDone = todo.IsDone;
            TodoListId = todo.TodoList.Id;
            TodoListTitle = todo.TodoList.Title;
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public bool IsDone { get; set; }

        public int TodoListId { get; set; }
        public string TodoListTitle { get; set; }
    }
}
