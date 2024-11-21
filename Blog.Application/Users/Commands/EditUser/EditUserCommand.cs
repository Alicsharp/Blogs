using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Commands.EditUser
{
    public record EditUserCommand(int Id,string Username):IRequest<ErrorOr<Success>>;
}
