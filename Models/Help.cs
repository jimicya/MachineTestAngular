using System;
using System.Collections.Generic;

namespace LoanManagementSystem.Models;

public partial class Help
{
    public int HelpId { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public int? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }
}
