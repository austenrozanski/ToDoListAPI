using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Entities
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Label { get; set; } = default!;

        [Required]
        public DateTime CreatedTimestamp { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public TodoList TodoList { get; set; } = default!;
    }
}
