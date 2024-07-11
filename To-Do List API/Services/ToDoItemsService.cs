using Microsoft.AspNetCore.Http.HttpResults;
using To_Do_List_API.DTOs.ToDoItem;
using To_Do_List_API.Interfaces;
using To_Do_List_API.Models;
using To_Do_List_API.Utils;

namespace To_Do_List_API.Services
{
    public class ToDoItemsService : IToDoItemsService
    {
        private readonly IToDoItemsRepository _toDoItemRepository;
        private readonly IUserRepository _userRepository;

        public ToDoItemsService(IToDoItemsRepository toDoItemsRepository, IUserRepository userRepository)
        {
            _toDoItemRepository = toDoItemsRepository;
            _userRepository = userRepository;
        }
        public async Task<ToDoItem> CreateToDoItem(Guid userId, CreateToDoItemDto request)
        {
            ToDoItemCreationErrorHandler.HandleErrors(request.Description, request.DueDate);

            DateTime.TryParse(request.DueDate, out DateTime dueDate);

            ToDoItem newToDoItem = new ToDoItem
            {
                ToDoItemId = new Guid(),
                Description = request.Description,
                IsCompleted = false,
                DueDate = dueDate,
                UserId = userId,
                User = await _userRepository.GetUserById(userId)
            };

            await _toDoItemRepository.CreateToDoItem(newToDoItem);

            return newToDoItem;
        }
        public async Task<IEnumerable<ToDoItem>> GetToDoItemsByUser(Guid id)
        {
            return await _toDoItemRepository.GetToDoItemsByUser(id);
        }

        public async Task DeleteToDoItemByUser(Guid userId, Guid toDoItemId)
        {
            await _toDoItemRepository.DeleteToDoItemByUser(userId, toDoItemId);
        }


        public async Task<ToDoItem?> UpdateToDoItemByUser(Guid userId, Guid toDoItemId, UpdateToDoItemDto request)
        {
            throw new NotImplementedException();
        }
    }
}
