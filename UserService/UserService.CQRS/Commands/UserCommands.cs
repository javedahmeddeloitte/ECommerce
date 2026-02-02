using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.CQRS.Commands
{

    public record CreateUserCommand(string userName, string Email, string Password);
    public record UpdateUserCommand(Guid Id,string userName, string Email);
    public record DeleteUserCommand(Guid Id);
}
