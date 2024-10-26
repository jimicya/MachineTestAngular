using LoanManagementSystem.Models;
using NuGet.Protocol.Plugins;

namespace LoanManagementSystem.Repository
{
    public interface ILoginRepository
    {
        public Task<User> ValidateUser(string username, string password);
    }
}
