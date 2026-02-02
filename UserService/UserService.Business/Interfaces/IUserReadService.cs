using System;
using System.Collections.Generic;
using System.Text;
using UserService.Model.Models;
using UserService.Model.ResponseModel;

namespace UserService.Business.Interfaces
{
    public interface IUserReadService
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity?> GetById(Guid id, string email);
        Task<AuthResponse?> LoginAsync(LoginModel model);
        
    }

}
