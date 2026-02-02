using System;
using System.Collections.Generic;
using System.Text;
using UserService.Model.Models;

namespace UserService.Repository.Interfaces
{
    // Repositories/IUserReadRepository.cs
    public interface IUserReadRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity?> GetByIdAsync(Guid id, string email);
    }

}
