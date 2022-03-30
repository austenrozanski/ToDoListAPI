using Microsoft.EntityFrameworkCore;
using ToDoListApi.Blls;
using ToDoListApi.Dals;
using ToDoListApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<TodoListsBll>();
builder.Services.AddTransient<TodosBll>();
builder.Services.AddTransient<TodoListDal>();

builder.Services.AddDbContext<TodoListContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
