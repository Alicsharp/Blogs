using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(string username, string email, string password) : IRequest<ErrorOr<Success>>;
}
