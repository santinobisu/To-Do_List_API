using To_Do_List_API.Models;

namespace To_Do_List_API.DTOs.User
{
    public class UpdateUserDto
    {
        public string? Username { get; set; }
        public List<ToDoItem>? ToDoItems { get; set; }

    }
}
