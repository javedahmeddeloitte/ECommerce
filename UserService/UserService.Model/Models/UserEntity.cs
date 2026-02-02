using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Model.Models
{
    // Models/User.cs
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
