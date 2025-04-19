using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ProductStock
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }
}
