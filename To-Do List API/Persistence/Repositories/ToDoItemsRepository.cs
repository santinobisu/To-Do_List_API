using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Interfaces;
using To_Do_List_API.Models;

namespace To_Do_List_API.Persistence.Repositories
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private readonly AppDbContext _appDbContext;
        
        public ToDoItemsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateToDoItem(ToDoItem newToDoItem)
        {
            await _appDbContext.ToDoItems.AddAsync(newToDoItem);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<ToDoItem>> GetToDoItemsByUser(Guid id)
        {
            return await _appDbContext.ToDoItems.Where(t => t.UserId == id).ToListAsync();
        }

        public async Task DeleteToDoItemByUser(Guid userId, Guid toDoItemId)
        {
            var itemToDelete = await _appDbContext.ToDoItems.Where(t => t.UserId == userId && t.ToDoItemId == toDoItemId)
                .FirstOrDefaultAsync();

            if (itemToDelete != null)
            {
                _appDbContext.ToDoItems.Remove(itemToDelete);
                await _appDbContext.SaveChangesAsync();
            }

        }


        public async Task<ToDoItem?> UpdateToDoItemByUser(Guid userId, Guid toDoItemId, ToDoItem newToDoItem)
        {
            throw new NotImplementedException();
        }
    }
}
