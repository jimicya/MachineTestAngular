using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly LoanManagementDbContext _context;

        public UserRepository(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _context.Users.FindAsync(userId);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error retrieving user", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error retrieving all users", ex);
            }
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (DbUpdateException ex)
            {
                // Log exception (ex)
                throw new Exception("Error registering user", ex);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error saving user", ex);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(user.UserId);
                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }

                existingUser.Username = user.Username;
                existingUser.Password = user.Password;


                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log exception (ex)
                throw new Exception("Error updating user", ex);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error saving changes", ex);
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error deleting user", ex);
            }
        }
    }

}
