using System;
using System.Collections.Generic;

namespace UserService.Repository.DBModels;

public partial class Role
{
    public int Id { get; set; }

    public string? UserRole { get; set; }
}
