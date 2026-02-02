using System;
using System.Collections.Generic;

namespace UserService.Repository.DBModels;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? Role { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? PasswordSalt { get; set; }
}
