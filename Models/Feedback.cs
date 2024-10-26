using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public string? Comments { get; set; }

    public int? Rating { get; set; }

    public virtual User? User { get; set; }
}
