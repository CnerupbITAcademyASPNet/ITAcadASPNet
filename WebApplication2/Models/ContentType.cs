using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ContentType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public int PermissionId { get; set; }

    public virtual Permission IdNavigation { get; set; } = null!;
}
