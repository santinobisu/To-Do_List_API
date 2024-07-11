namespace To_Do_List_API.DTOs.ToDoItem
{
    public class CreateToDoItemDto
    {
        public string Description { get; set; } = null!;
        public string DueDate { get; set; } = null!;
    }
}
