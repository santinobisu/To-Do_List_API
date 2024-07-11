﻿namespace To_Do_List_API.Exceptions
{
    public class UserCreationException : Exception
    {
        public List<string> Errors { get; }

        public UserCreationException()
        {
            Errors = new List<string>();
        }

        public UserCreationException(string message)
        : base(message)
        {
            Errors = new List<string> { message };
        }

        public UserCreationException(List<string> errors)
        : base("User creation failed due to validation errors.")
        {
            Errors = errors;
        }
    }
}
