using System.Collections.ObjectModel;
using To_Do_List_API.DTOs.ToDoItem;
using To_Do_List_API.DTOs.User;
using To_Do_List_API.Models;

namespace To_Do_List_API.Utils
{
    public static class ToDoItemControllerUtils
    {
        public static ToDoItemResponseDto MapToItemResponse(ToDoItem toDoItem)
        {
            return new ToDoItemResponseDto
            {
                ToDoItemId = toDoItem.ToDoItemId,
                Description = toDoItem.Description,
                IsCompleted = toDoItem.IsCompleted,
                DueDate = toDoItem.DueDate
            };
        }

        public static List<ToDoItemResponseDto> MapItemCollectionResponse(IEnumerable<ToDoItem> toDoItems)
        {
            List<ToDoItemResponseDto> items = new();

            foreach (ToDoItem item in toDoItems)
            {
                var parsedItem = MapToItemResponse(item);
                items.Add(parsedItem);
            }

            return items;
        }
    }
}
