using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class LoanApplication
{
    public int ApplicationId { get; set; }

    public int? CustomerId { get; set; }

    public int? LoanId { get; set; }

    public decimal? RequestedAmount { get; set; }

    public DateOnly? ApplicationDate { get; set; }

    public string? Status { get; set; }

    public int? ApprovedBy { get; set; }

    public DateOnly? ApprovalDate { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual Customer? Customer { get; set; }

    public virtual Loan? Loan { get; set; }

    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();
}
