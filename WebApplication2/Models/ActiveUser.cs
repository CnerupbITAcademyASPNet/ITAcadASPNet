using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class ActiveUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public DateTime? LastLogin { get; set; }
}
