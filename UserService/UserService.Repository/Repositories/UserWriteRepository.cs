using UserService.Repository.Interfaces;
using UserService.Repository.DBModels;
using UserService.Model.Models;

namespace UserService.Repository.Repositories
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly UserDbContext _context;

        public UserWriteRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            var res = _context.Users.ToList();
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

       

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserEntity user)
        {
            throw new NotImplementedException();
        }

        //public async Task<Guid> CreateAsync(User user)
        //{
        //    user.Id = Guid.NewGuid();
        //    user.CreatedAt = DateTime.UtcNow;

        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return user.Id;
        //}





        //public async Task<bool> UpdateAsync(User user)
        //{
        //    _context.Users.Update(user);
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public async Task<bool> DeleteAsync(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null) return false;

        //    _context.Users.Remove(user);
        //    return await _context.SaveChangesAsync() > 0;
        //}
    }

}
