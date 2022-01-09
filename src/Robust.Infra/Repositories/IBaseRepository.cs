using Robust.Domain.Entities;

namespace Robust.Infra.Repositories
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(long id);
        Task<T?> GetById(long id);
        Task<List<T>> GetAll();
    }
}
