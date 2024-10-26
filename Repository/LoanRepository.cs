﻿using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanManagementDbContext _context;

        public LoanRepository(LoanManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> GetLoanByIdAsync(int loanId)
        {
            try
            {
                return await _context.Loans.FindAsync(loanId);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error retrieving loan", ex);
            }
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            try
            {
                return await _context.Loans.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error retrieving all loans", ex);
            }
        }

        public async Task<Loan> CreateLoanAsync(Loan loan)
        {
            try
            {
                await _context.Loans.AddAsync(loan);
                await _context.SaveChangesAsync();
                return loan;
            }
            catch (DbUpdateException ex)
            {
                // Log exception (ex)
                throw new Exception("Error creating loan", ex);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error saving loan", ex);
            }
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            try
            {
                var existingLoan = await _context.Loans.FindAsync(loan.LoanId);
                if (existingLoan == null)
                {
                    throw new Exception("Loan not found");
                }

                existingLoan.MaxAmount = loan.MaxAmount;
                existingLoan.InterestRate = loan.InterestRate;
                existingLoan.DurationMonths = loan.DurationMonths;

                _context.Loans.Update(existingLoan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log exception (ex)
                throw new Exception("Error updating loan", ex);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error saving changes", ex);
            }
        }

        public async Task DeleteLoanAsync(int loanId)
        {
            try
            {
                var loan = await _context.Loans.FindAsync(loanId);
                if (loan == null)
                {
                    throw new Exception("Loan not found");
                }

                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                throw new Exception("Error deleting loan", ex);
            }
        }
    }


}
