using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robust.API.Utils;
using Robust.API.ViewModels;
using Robust.Core.Exceptions;
using Robust.Services.Dtos;
using Robust.Services.Services.Users;
using System.Net;

namespace Robust.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(userViewModel);

                var userCreated = await _userService.Create(userDto);

                return Ok(new ResultViewModel()
                {
                    Data = userCreated,
                    Message = "User created.",
                    Success = true,
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                //return StatusCode((int)HttpStatusCode.InternalServerError, Responses.ApplicationErrorMessage());
                return StatusCode(500, ex.Message);
            }
        }
    }
}
