using To_Do_List_API.Models;

namespace To_Do_List_API.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User newUser);
        Task<User?> GetUserById(Guid id);
        Task DeleteUserById(Guid id);
    }
}
