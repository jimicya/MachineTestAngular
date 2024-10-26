using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class Loan
{
    public int LoanId { get; set; }

    public string? LoanName { get; set; }

    public decimal? MaxAmount { get; set; }

    public decimal? InterestRate { get; set; }

    public int? DurationMonths { get; set; }

    public virtual ICollection<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();
}
