using Eatstead.Application.Commands;
using Eatstead.Application.DTOs;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eatstead.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;
        public AuthenticationController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterDTO>> Register(UserRegisterDTO userRegisterDTO)
        {
            var mapper = _mapper.Map<RegisterUserCommand>(userRegisterDTO);
            var register = await _mediator.Send(mapper);
            return Ok(register);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> Login(UserLoginDTO userLoginDTO)
        {
            var mapper = _mapper.Map<LoginUserCommand>(userLoginDTO);
            var register = await _mediator.Send(mapper);
            return Ok(register);
        }
    }
}
