using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
        public class LoginRepository : ILoginRepository
        {

            private readonly LoanManagementDbContext _context;

            public LoginRepository(LoanManagementDbContext context)
            {
                _context = context;
            }
            public async Task<User> ValidateUser(string username, string password)
            {
                try
                {
                    if (_context != null)
                    {
                        var User = await _context.Users
                            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

                        return User; 
                    }

                    return null; 
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while validating the user: {ex.Message}", ex);
                }
            }
        }
    
}

