using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? UserId { get; set; }

    public string? FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public decimal? AnnualIncome { get; set; }

    public virtual ICollection<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();

    public virtual User? User { get; set; }
}
