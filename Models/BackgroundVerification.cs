using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class BackgroundVerification
{
    public int VerificationId { get; set; }

    public int? ApplicationId { get; set; }

    public int? LoanOfficerId { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual LoanApplication? Application { get; set; }

    public virtual User? LoanOfficer { get; set; }
}
