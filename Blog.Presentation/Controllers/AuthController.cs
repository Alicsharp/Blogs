using Blog.Application.Common.SecurityUtil;
using Blog.Application.Users.Commands.AddToken;
using Blog.Application.Users.Commands.EditUser;
using Blog.Application.Users.Commands.RegisterUser;
using Blog.Application.Users.Commands.RemoveToken;
using Blog.Application.Users.Queries;
using Blog.Application.Users.Queries.GetUserById;
using Blog.Infrastructure.JwtTokenBuilder;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthController(IMediator mediator, IJwtTokenGenerator jwtTokenGenerator)
        {
            _mediator = mediator;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string email, string password)
        {

            var command = new RegisterUserCommand(username, email, password);
            var result = await _mediator.Send(command);
            return result.Match(
              success => Ok("Category created successfully."),
              error => Problem(title: "Error", detail: error.ToString())
          );
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            {
                var userResult = await _mediator.Send(new GetUserByEmailQuery(Email));
                if (userResult.Value == null)
                    return BadRequest("Invalid email or password.");

                var user = userResult.Value;

                if (!Sha256Hasher.IsCompare(user.Password, Password))
                    return BadRequest("Invalid email or password.");
                // تولید توکن
                var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);

                return Ok(new { Token = token });
            }
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(int Id,string username)
        {

            var userResult = await _mediator.Send(new EditUserCommand(Id,username));
            if (userResult.Value == null)
                return BadRequest("Invalid email or password.");

            var user = userResult.Value;
            return Ok( );
        }

    } 
}
 