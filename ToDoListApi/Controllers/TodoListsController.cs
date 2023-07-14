using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Blls;
using ToDoListApi.Dtos;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly ILogger<TodoListsController> _logger;
        private readonly TodoListsBll _todoListsBll;

        public TodoListsController(ILogger<TodoListsController> logger, TodoListsBll todoListsBll)
        {
            _logger = logger;
            _todoListsBll = todoListsBll;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoListDto>>> GetLists()
        {
            try
            {
                var result = await _todoListsBll.GetTodoLists();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GET Lists. Error: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
