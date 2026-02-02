using System;
using System.Collections.Generic;
using System.Text;
using UserService.CQRS.Commands;
using UserService.Model.ResponseModel;

namespace UserService.Model
{
    public static class Mapper
    {
        public static CreateUserResponse CreateUserDBToResponse(CreateUserCommand user, Guid Id)
        {
            return new CreateUserResponse
            {
                Email = user.Email,
                UserId = Id,
                UserName =  user.userName
            };
        }
            
    }
}
