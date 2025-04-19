using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? ConfirmDate { get; set; }

    public int Status { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual User User { get; set; } = null!;
}
