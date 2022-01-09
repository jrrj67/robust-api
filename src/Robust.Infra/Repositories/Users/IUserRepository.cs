using Robust.Domain.Entities;

namespace Robust.Infra.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
    }
}
