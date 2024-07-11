﻿namespace To_Do_List_API.Models
{
    public class ToDoItem
    {
        public const int MaxDescriptionLength = 50;
        public Guid ToDoItemId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
