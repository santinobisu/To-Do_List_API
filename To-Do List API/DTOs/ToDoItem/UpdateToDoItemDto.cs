namespace To_Do_List_API.DTOs.ToDoItem
{
    public class UpdateToDoItemDto
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public string? DueDate { get; set; }
    }
}
