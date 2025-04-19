using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class GroupPermission
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int PermissionId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Permission Permission { get; set; } = null!;
}
