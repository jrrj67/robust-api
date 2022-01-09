using Robust.Services.Dtos;

namespace Robust.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task Remove(long id);
        Task<UserDto> GetById(long id);
        Task<List<UserDto>> GetAll();
        Task<List<UserDto>> SearchByName(string name);
        Task<List<UserDto>> SearchByEmail(string email);
        Task<UserDto> GetByEmail(string email);
    }
}
