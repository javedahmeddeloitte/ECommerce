using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Model.ResponseModel
{
    public class CreateUserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
    public class AuthResponse : CreateUserResponse
    {
        public string JwtToken { get; set; }
    }
}
