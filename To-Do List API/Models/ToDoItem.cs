namespace To_Do_List_API.Models
{
    public class ToDoItem
    {
        public Guid ToDoItemId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
