using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

        public LoansController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoanById(int id)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpGet("getallloans")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAllLoans()
        {
            var loans = await _loanRepository.GetAllLoansAsync();
            return Ok(loans);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Loan>> CreateLoan([FromBody] Loan loan)
        {
            if (loan == null)
            {
                return BadRequest("Loan data is null.");
            }

            try
            {
                var createdLoan = await _loanRepository.CreateLoanAsync(loan);
                return CreatedAtAction(nameof(GetLoanById), new { id = createdLoan.LoanId }, createdLoan);
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                return StatusCode(500, "Internal server error while creating loan.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLoan(int id, [FromBody] Loan loan)
        {
            if (loan == null || loan.LoanId != id)
            {
                return BadRequest("Loan data is invalid.");
            }

            try
            {
                await _loanRepository.UpdateLoanAsync(loan);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                return StatusCode(500, "Internal server error while updating loan.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            try
            {
                await _loanRepository.DeleteLoanAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                return StatusCode(500, "Internal server error while deleting loan.");
            }
        }
    }
}

