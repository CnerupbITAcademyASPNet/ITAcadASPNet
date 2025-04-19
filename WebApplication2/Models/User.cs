using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<AdminLog> AdminLogs { get; set; } = new List<AdminLog>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
