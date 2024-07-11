using To_Do_List_API.Exceptions;
using To_Do_List_API.Models;

namespace To_Do_List_API.Utils
{
    public static class ToDoItemCreationErrorHandler
    {
        public static bool IsValidDateTime(string dateTimeString)
        {
            return DateTime.TryParse(dateTimeString, out _);
        }

        public static void HandleErrors(string description, string dueDate)
        {
            List<string> errors = new();

            if (description is null)
                errors.Add("Description for To-Do Item must be provided.");
            else
            {
                if (description.Length < 1)
                    errors.Add("Description for To-Do Item can't be empty.");
                if (description.Length > ToDoItem.MaxDescriptionLength)
                    errors.Add($"Description length can't surpass {ToDoItem.MaxDescriptionLength} characters.");
            }

            if (dueDate is null)
                errors.Add("A Due date for To-Do Item must be provided.");
            else
            {
                if (!DateTime.TryParse(dueDate, out DateTime date))
                    errors.Add("Due date must be in a valid date format.");
                else if (date < DateTime.UtcNow)
                    errors.Add("Due date can't be a past date.");
            }

            if (errors.Count > 0)
                throw new ToDoItemCreationException(errors);
        }
    }
}
