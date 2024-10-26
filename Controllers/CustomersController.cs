using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // Apply for a loan
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForLoan([FromBody] Loan loan)
        {
            if (loan == null)
            {
                return BadRequest("Loan data is required.");
            }

            try
            {
                var createdLoan = await _customerRepository.ApplyForLoanAsync(loan);
                return CreatedAtAction(nameof(GetLoanRequests), new { userId = createdLoan.LoanId }, createdLoan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal Server Error
            }
        }

        // Get loan requests by user ID
        [HttpGet("loans/{userId}")]
        public async Task<IActionResult> GetLoanRequests(int userId)
        {
            try
            {
                var loans = await _customerRepository.GetLoanRequestsByUserIdAsync(userId);
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal Server Error
            }
        }

        // Get help section
        [HttpGet("help")]
        public async Task<IActionResult> GetHelpSection()
        {
            try
            {
                var helpInfo = await _customerRepository.GetHelpSectionAsync();
                return Ok(helpInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal Server Error
            }
        }

        // Add feedback
        [HttpPost("feedback")]
        public async Task<IActionResult> AddFeedback([FromBody] Feedback feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Feedback data is required.");
            }

            try
            {
                var createdFeedback = await _customerRepository.AddFeedbackAsync(feedback);
                return CreatedAtAction(nameof(AddFeedback), createdFeedback);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal Server Error
            }
        }

    }
}

