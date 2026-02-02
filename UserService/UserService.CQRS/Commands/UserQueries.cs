using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.CQRS.Commands
{
    public record GetuserByIdQuery(Guid Id);
    public record GetAllUsersQuery();

}
