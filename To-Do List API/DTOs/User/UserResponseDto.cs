using To_Do_List_API.Models;

namespace To_Do_List_API.DTOs.User
{
    public class UserResponseDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public DateTime DateCreated { get; set; }
    }
}
