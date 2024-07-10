using System.Text.RegularExpressions;
using To_Do_List_API.Exceptions;
using To_Do_List_API.Models;

namespace To_Do_List_API.Utils
{
    public static class UserCreationErrorHandler
    {
        private const string pattern = @"^[a-zA-Z0-9_-]+$";
        private static bool AreCharsValid(string input)
        {
            return Regex.IsMatch(input, pattern);
        }

        public static void HandleErrors(string username, string password)
        {
            List<string> errors = new();

            // Username validations
            if (username is null)
                errors.Add("Username field is required.");
            else
            {
                if (!AreCharsValid(username))
                    errors.Add($"Username can be conformed only by Uppercase and Lowercase Alphabet letters, and Numbers");
                if (username.Length < User.MinUsernameLength)
                    errors.Add($"Username length must be at least {User.MinUsernameLength} characters.");
                else if (username.Length > User.MaxUsernameLength)
                    errors.Add($"Username length must not exceed {User.MaxUsernameLength} characters.");
            }

            // Password validations
            if (password is null)
                errors.Add("Password field is required.");
            else
            {
                if (!AreCharsValid(password))
                    errors.Add($"Password can be conformed only by Uppercase and Lowercase Alphabet letters, and Numbers");
                if (password.Length < User.MinPasswordLength)
                    errors.Add($"Password length must be at least {User.MinPasswordLength} characters.");
                else if (password.Length > User.MaxPasswordLength)
                    errors.Add($"Password length must not exceed {User.MaxPasswordLength} characters.");
            }

            if (errors.Count > 0)
                throw new UserCreationException(errors);
        }
    }
}
