using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class OrderSummary
{
    public int OrderId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }
}
