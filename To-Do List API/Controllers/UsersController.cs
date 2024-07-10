using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.DTOs.User;
using To_Do_List_API.Exceptions;
using To_Do_List_API.Interfaces;
using To_Do_List_API.Utils;

namespace To_Do_List_API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> CreateUser([FromBody] UserCreateDto request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request body." });
            }

            try
            {
                var newUser = await _userService.CreateUser(request.Username, request.Password);
                var response = UsersControllerUtils.MapToUserResponse(newUser);
                return CreatedAtAction(
                    actionName: nameof(GetUserById),
                    routeValues: new {id = response.UserId},
                    value: response);
            }
            catch (UserCreationException ex)
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserResponseDto>> GetUserById(Guid id)
        {
            try
            {
                var getUserResult = await _userService.GetUserById(id);
                if (getUserResult is null)
                    return Problem(statusCode: StatusCodes.Status404NotFound, detail: "Requested user with provided id wasn't found.");
                return Ok(UsersControllerUtils.MapToUserResponse(getUserResult));
            }
            catch (Exception)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error has occurred while processing the request.");
            }

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUserById(Guid id)
        {
            try
            {
                await _userService.DeleteUserById(id);
                return NoContent();
            }
            catch (Exception)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError, detail: "An error has occurred while processing the request.");
            }
        }
    }
}
