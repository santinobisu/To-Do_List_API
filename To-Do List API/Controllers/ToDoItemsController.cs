using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using To_Do_List_API.DTOs.ToDoItem;
using To_Do_List_API.Exceptions;
using To_Do_List_API.Interfaces;
using To_Do_List_API.Models;
using To_Do_List_API.Utils;

namespace To_Do_List_API.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoItemsService _toDoItemsService;
        private readonly IUserService _userService;

        public ToDoItemsController(IToDoItemsService toDoItemsService, IUserService userService)
        {
            _toDoItemsService = toDoItemsService;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ToDoItem>> CreateToDoItem([FromBody] CreateToDoItemDto request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request body." });
            }

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            try
            {
                var toDoItem = await _toDoItemsService.CreateToDoItem(userId, request);
                var response = ToDoItemControllerUtils.MapToItemResponse(toDoItem);
                return CreatedAtAction(nameof(GetToDoItems), new { id = response.ToDoItemId }, response);

            }
            catch (ToDoItemCreationException ex)
            {
                string errorMessage = string.Join(Environment.NewLine, ex.Errors);
                return Problem(statusCode: StatusCodes.Status400BadRequest,
                    detail: errorMessage);
            }
            catch (Exception)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error has occurred while processing the request.");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ToDoItemResponseDto>>> GetToDoItems(
            [FromQuery] bool? isCompleted = null,
            [FromQuery] DateTime? dueDate = null)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var items = await _toDoItemsService.GetToDoItemsByUser(userId, isCompleted, dueDate);
                var response = ToDoItemControllerUtils.MapItemCollectionResponse(items);
                return Ok(response);
            }
            catch (Exception)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error has occurred while processing the request.");
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<ActionResult> DeleteToDoItemById(Guid id)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _toDoItemsService.DeleteToDoItemByUser(userId, id);
                return NoContent();
            }
            catch (Exception)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error has occurred while processing the request.");
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult<ToDoItemResponseDto>> UpdateToDoItem(Guid id)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var updatedItem = await _toDoItemsService.UpdateToDoItemByUser(userId, id);

                if (updatedItem is null) return Problem(statusCode: StatusCodes.Status404NotFound, detail: "Requested To-Do Item wasn't found.");

                var response = ToDoItemControllerUtils.MapToItemResponse(updatedItem);
                return Ok(response);
            }
            catch (Exception)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error has occurred while processing the request.");
            }
        }
    }
}
