using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Help> Helps { get; set; } = new List<Help>();

    public virtual ICollection<LoanApplication> LoanApplications { get; set; } = new List<LoanApplication>();

    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();

    public virtual Role? Role { get; set; }
}
