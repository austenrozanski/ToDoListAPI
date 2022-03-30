using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Blls;
using ToDoListApi.Dtos;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;
        private readonly TodosBll _todosBll;

        public TodosController(ILogger<TodosController> logger, TodosBll todosBll)
        {
            _logger = logger;
            _todosBll = todosBll;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetTodos([FromQuery] int? listId)
        {
            try
            {
                var result = await _todosBll.GetTodos(listId);
                return Ok(result);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in GET Todos. Parameters(listId: {listId}). Error: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoDto>> CreateTodo([FromQuery] int? listId, [FromBody] string label)
        {
            try
            {
                var result = await _todosBll.CreateTodo(listId, label);
                return Ok(result);
            }
            catch (BadHttpRequestException ex)
            {
                //TODO: Decide if you want to return 400 code or put into some default list if no listId provided
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in POST Todos. Parameters(listId: {listId}, label: {label}). Error: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] string label)
        {
            try
            {
                await _todosBll.UpdateTodo(id, label);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in PUT Todos. Parameters(id: {id}, label: {label}). Error: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("Toggle/{id}")]
        public async Task<IActionResult> ToggleTodo(int id)
        {
            try
            {
                await _todosBll.ToggleTodo(id);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in POST Todos/Toggle/{id}. Error: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                await _todosBll.DeleteTodo(id);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in DELETE Todos/{id}. Error: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
