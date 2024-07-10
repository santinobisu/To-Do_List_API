using To_Do_List_API.Interfaces;
using To_Do_List_API.Models;
using To_Do_List_API.Utils;

namespace To_Do_List_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(string username, string password)
        {
            // Data Validation
            UserCreationErrorHandler.HandleErrors(username, password);

            // TODO: Check if the username already exists

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User()
            {
                UserId = new Guid(),
                Username = username,
                PasswordHash = hashedPassword,
                DateCreated = DateTime.UtcNow,
                ToDoItems = new List<ToDoItem>()
            };

            await _userRepository.CreateUser(newUser);

            return newUser;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var getUserResult = await _userRepository.GetUserById(id);

            return getUserResult;
        }

        public async Task DeleteUserById(Guid id)
        {
            await _userRepository.DeleteUserById(id);
        }
    }
}
