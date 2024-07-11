using To_Do_List_API.Exceptions;
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

            // Check if username already exists
            var checkUser = await _userRepository.GetUserByUsername(username);
            if (checkUser != null)
            {
                throw new UserCreationException("Username is already in use.");
            }

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

        public async Task<User?> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
