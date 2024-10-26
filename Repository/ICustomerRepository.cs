using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    public interface ICustomerRepository
    {
        public Task<Loan> ApplyForLoanAsync(Loan loan);

        public Task<IEnumerable<Loan>> GetLoanRequestsByUserIdAsync(int userId);

        public Task<IEnumerable<Help>> GetHelpSectionAsync();

        public Task<Feedback> AddFeedbackAsync(Feedback feedback);
    }
}
