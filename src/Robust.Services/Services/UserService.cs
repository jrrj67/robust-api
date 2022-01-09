using AutoMapper;
using Robust.Core.Exceptions;
using Robust.Domain.Entities;
using Robust.Infra.Interfaces;
using Robust.Services.Dtos;
using Robust.Services.Interfaces;

namespace Robust.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            var userExists = await _userRepository.GetByEmail(userDto.Email);

            if (userExists != null)
            {
                throw new DomainException("User already exists.");
            }

            var user = _mapper.Map<User>(userDto);

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDto>(userCreated);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new DomainException("User does not exist with this email.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetById(long id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                throw new DomainException("User does not exist.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task Remove(long id)
        {
            var userExists = _userRepository.GetById(id);

            if (userExists == null)
            {
                throw new DomainException("User does not exist.");
            }

            await _userRepository.Remove(id);
        }

        public async Task<List<UserDto>> SearchByEmail(string email)
        {
            var users = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> SearchByName(string name)
        {
            var users = await _userRepository.SearchByName(name);

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            var userExists = await _userRepository.GetById(userDto.Id);

            if (userExists == null)
            {
                throw new DomainException("User does not exist.");
            }

            var user = _mapper.Map<User>(userDto);

            user.Validate();

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDto>(userUpdated);
        }
    }
}
