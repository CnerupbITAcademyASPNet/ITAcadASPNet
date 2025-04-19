using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class AdminLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string? Details { get; set; }

    public virtual User User { get; set; } = null!;
}
