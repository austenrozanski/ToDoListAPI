using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Entities
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;

        public List<Todo>? Todos { get; set; } = default!;
    }
}
