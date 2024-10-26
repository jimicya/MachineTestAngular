using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    public interface IUserRepository
    {
       public Task<User> GetUserByIdAsync(int userId);
       public Task<IEnumerable<User>> GetAllUsersAsync();
       public Task<User> RegisterUserAsync(User user);
       public Task UpdateUserAsync(User user);
       public Task DeleteUserAsync(int userId);
    }

}
