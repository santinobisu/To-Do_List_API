using To_Do_List_API.Models;

namespace To_Do_List_API.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(string username, string password);
        Task<User?> GetUserById(Guid id);
        Task DeleteUserById(Guid id);
        Task<User?> Authenticate(string username, string password);
    }
}
