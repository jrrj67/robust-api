using Microsoft.EntityFrameworkCore;
using Robust.Domain.Entities;
using Robust.Infra.Context;

namespace Robust.Infra.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly RobustContext _context;

        public UserRepository(RobustContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await _context.Users
                .Where(x => x.Email.ToLower() == email.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var users = await _context.Users
               .Where(x => x.Email.ToLower().Contains(email.ToLower()))
               .AsNoTracking()
               .ToListAsync();

            return users;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var users = await _context.Users
               .Where(x => x.Name.ToLower().Contains(name.ToLower()))
               .AsNoTracking()
               .ToListAsync();

            return users;
        }
    }
}
