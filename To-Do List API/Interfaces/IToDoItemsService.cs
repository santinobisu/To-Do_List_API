using Microsoft.VisualBasic;
using To_Do_List_API.DTOs.ToDoItem;
using To_Do_List_API.Models;

namespace To_Do_List_API.Interfaces
{
    public interface IToDoItemsService
    {
        Task<ToDoItem> CreateToDoItem(Guid userId, CreateToDoItemDto request);
        Task<IEnumerable<ToDoItem>> GetToDoItemsByUser(Guid id, bool? isCompleted, DateTime? dueDate);
        Task DeleteToDoItemByUser(Guid userId, Guid toDoItemId);
        Task<ToDoItem?> UpdateToDoItemByUser(Guid userId, Guid toDoItemId);

    }
}
