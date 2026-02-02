using System;
using System.Collections.Generic;
using System.Text;
using UserService.CQRS.Commands;
using UserService.Model.ResponseModel;

namespace UserService.Business.Interfaces
{
    public interface IUserWriteService
    {
        Task<CreateUserResponse> Create(CreateUserCommand cmd);
        Task Update(UpdateUserCommand cmd);
        Task Delete(DeleteUserCommand cmd);
    }

}
