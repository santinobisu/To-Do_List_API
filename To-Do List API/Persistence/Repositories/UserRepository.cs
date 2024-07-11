using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Interfaces;
using To_Do_List_API.Models;

namespace To_Do_List_API.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateUser(User newUser)
        {
            await _appDbContext.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var getUserResult = await _appDbContext.Users
                .Include(u => u.ToDoItems)
                .FirstOrDefaultAsync(u => u.UserId == id);

            return getUserResult;
        }
        public async Task<User?> GetUserByUsername(string username)
        {
            var getUserResult = await _appDbContext.Users
                .Include(u => u.ToDoItems)
                .FirstOrDefaultAsync(u => u.Username == username);

            return getUserResult;
        }

        public async Task DeleteUserById(Guid id)
        {
            var userToDelete = await _appDbContext.Users.FindAsync(id);

            if (userToDelete is null)
                return;

            _appDbContext.Users.Remove(userToDelete);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
