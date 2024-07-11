namespace To_Do_List_API.DTOs.ToDoItem
{
    public class ToDoItemResponseDto
    {
        public Guid ToDoItemId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
