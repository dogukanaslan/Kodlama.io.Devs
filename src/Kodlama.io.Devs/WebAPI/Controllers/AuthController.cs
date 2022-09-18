using Core.Security.Dtos;
using KodlamaDevs.Application.Features.Auth.Commands.UserLogin;
using KodlamaDevs.Application.Features.Auth.Commands.UserRegister;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterCommand userRegisterCommand)
        {
            var result = await Mediator.Send(userRegisterCommand);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginComand userLoginComand)
        {
            var result = await Mediator!.Send(userLoginComand);
            return Ok(result);
        }
    }
}
