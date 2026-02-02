using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Business.Interfaces;
using UserService.Model;
using UserService.Model.Models;
using UserService.Model.ResponseModel;
using UserService.Repository.DBModels;
using UserService.Repository.Interfaces;

namespace UserService.Business.Services
{
    public class UserReadService : IUserReadService
    {
        private readonly IUserReadRepository _repo;
        public UserReadService(IUserReadRepository repo) => _repo = repo;

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        public  async Task<UserEntity?> GetById(Guid id, string email)
        {
            return await _repo.GetByIdAsync(id,email);
        }

        public async Task<AuthResponse> LoginAsync(LoginModel request)
        {
            var user = await _repo.GetByIdAsync(Guid.Empty,request.Email);
            if (user == null)
                throw new Exception("Invalid email or password");

            //if (!BCrypt.Net.BCrypt.Verify(request.Password, user))
            //    throw new Exception("Invalid email or password");

            //var token = await GenerateJwt(user);
            //return Mapper.LoginToDto(user, token);
            return null;
        }
       // private async Task<string> GenerateJwt(User user)
     //   {
     //       var userRole = await _commonUtilty.UserRoleById(user.Role);
     //       var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
     //       var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

     //       var claims = new[]
     //       {
     //    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
     //    new Claim(ClaimTypes.Role, userRole.ToString()),
     //    new Claim(JwtRegisteredClaimNames.Email, user.Email)
     //};

     //       var token = new JwtSecurityToken(
     //           issuer: _config["Jwt:Issuer"],
     //           audience: _config["Jwt:Audience"],
     //           claims: claims,
     //           expires: DateTime.UtcNow.AddHours(8),
     //           signingCredentials: creds
     //       );

     //       return new JwtSecurityTokenHandler().WriteToken(token);
     //   }



    }
}
