using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Migration
{
    public int MigrationId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime AppliedAt { get; set; }
}
