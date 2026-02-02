using System;
using System.Collections.Generic;
using System.Text;
using UserService.Model.Models;
using UserService.Repository.DBModels;

namespace UserService.Repository.Interfaces
{
    public interface IUserWriteRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(UserEntity user);
        Task DeleteAsync(Guid id);
    }
}
