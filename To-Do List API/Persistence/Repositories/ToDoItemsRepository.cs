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
        public async Task<IEnumerable<ToDoItem>> GetToDoItemsByUser(Guid id, bool? isCompleted, DateTime? dueDate)
        {
            IQueryable<ToDoItem> query =  _appDbContext.ToDoItems.Where(t => t.UserId == id);

            if (isCompleted != null)
                query = query.Where(t => t.IsCompleted == isCompleted);

            if (dueDate != null)
                query = query.Where(t => t.DueDate >= dueDate);

            return await query.ToListAsync();
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


        public async Task<ToDoItem?> UpdateToDoItemByUser(Guid userId, Guid toDoItemId)
        {
            var itemToUpdate = await _appDbContext.ToDoItems.Where(t => t.UserId == userId && t.ToDoItemId == toDoItemId)
                .FirstOrDefaultAsync();

            if (itemToUpdate is null)
                return null;

            if (itemToUpdate.IsCompleted is true)
                itemToUpdate.IsCompleted = false;
            else itemToUpdate.IsCompleted = true;

            await _appDbContext.SaveChangesAsync();

            return itemToUpdate;
        }
    }
}
