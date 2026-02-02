
using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using UserService.Business.Interfaces;
using UserService.CQRS.Commands;
using UserService.Model;
using UserService.Model.Models;
using UserService.Model.ResponseModel;
using UserService.Repository.DBModels;
using UserService.Repository.Interfaces;

namespace UserService.Business.Services
{
    public class UserWriteService : IUserWriteService
    {
        private readonly IUserWriteRepository _repo;

        public UserWriteService(IUserWriteRepository repo) => _repo = repo;

        public async Task<CreateUserResponse> Create(CreateUserCommand cmd)
        {
            var generatedUserId = Guid.NewGuid();
            var user = new User  //DBModel
            {
                Id = generatedUserId,
                Name = cmd.userName,
                Email = cmd.Email,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                PasswordSalt = BCrypt.Net.BCrypt.HashPassword(cmd.Password)
            };
            await _repo.AddAsync(user);
            return Mapper.CreateUserDBToResponse(cmd, generatedUserId);
        }

        public async Task Update(UpdateUserCommand cmd)
        {
            var user = new UserEntity
            {
                Id = cmd.Id,
                Name = cmd.userName,
                Email = cmd.Email,
                IsActive = true
            };
            await _repo.UpdateAsync(user);
        }

        public Task Delete(DeleteUserCommand cmd) =>
            _repo.DeleteAsync(cmd.Id);
    }

}
