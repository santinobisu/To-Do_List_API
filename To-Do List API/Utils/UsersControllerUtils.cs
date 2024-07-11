using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.DTOs.User;
using To_Do_List_API.Models;

namespace To_Do_List_API.Utils
{
    public static class UsersControllerUtils
    {
        public static UserResponseDto MapToUserResponse(User user)
        {
            return new UserResponseDto
            {
                UserId = user.UserId,
                Username = user.Username,
                DateCreated = user.DateCreated
            };
        }
    }
}
