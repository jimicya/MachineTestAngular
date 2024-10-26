using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository
{
    public interface ILoanRepository
    {
        public Task<Loan> GetLoanByIdAsync(int loanId);
        public Task<IEnumerable<Loan>> GetAllLoansAsync();
        public Task<Loan> CreateLoanAsync(Loan loan);
        public Task UpdateLoanAsync(Loan loan);
        public Task DeleteLoanAsync(int loanId);

    }
}

