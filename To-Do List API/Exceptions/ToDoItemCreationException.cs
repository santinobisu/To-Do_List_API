namespace To_Do_List_API.Exceptions
{
    public class ToDoItemCreationException : Exception
    {
        public List<string> Errors { get; }

        public ToDoItemCreationException()
        {
            Errors = new List<string>();
        }

        public ToDoItemCreationException(string message)
        : base(message)
        {
            Errors = new List<string> { message };
        }

        public ToDoItemCreationException(List<string> errors)
        : base("To-Do Item creation failed due to validation errors.")
        {
            Errors = errors;
        }
    }
}
