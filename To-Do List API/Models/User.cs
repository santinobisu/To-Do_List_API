namespace To_Do_List_API.Models
{
    public class User
    {
        public const int MinUsernameLength = 4;
        public const int MaxUsernameLength = 15;

        public const int MinPasswordLength = 5;
        public const int MaxPasswordLength = 20;

        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public List<ToDoItem> ToDoItems { get; set; } = null!;
    }
}
