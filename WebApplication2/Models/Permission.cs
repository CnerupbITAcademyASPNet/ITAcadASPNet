using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ContentType? ContentType { get; set; }

    public virtual ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
