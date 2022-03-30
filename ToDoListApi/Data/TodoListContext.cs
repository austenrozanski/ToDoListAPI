using Microsoft.EntityFrameworkCore;
using ToDoListApi.Entities;

namespace ToDoListApi.Data
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoList> TodoList { get; set; } = default!;
        public DbSet<Todo> Todo { get; set; } = default!;
    }
}
