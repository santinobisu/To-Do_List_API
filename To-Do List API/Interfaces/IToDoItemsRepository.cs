using To_Do_List_API.DTOs.ToDoItem;
using To_Do_List_API.Models;

namespace To_Do_List_API.Interfaces
{
    public interface IToDoItemsRepository
    {
        Task CreateToDoItem(ToDoItem newToDoItem);
        Task<IEnumerable<ToDoItem>> GetToDoItemsByUser(Guid id);
        Task DeleteToDoItemByUser(Guid userId, Guid toDoItemId);
        Task<ToDoItem?> UpdateToDoItemByUser(Guid userId, Guid toDoItemId, ToDoItem newToDoItem);
    }
}
