using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Commands.ChangePassword
{
    public class ChangeUserPasswordCommand : IRequest<ErrorOr<Success>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }
}
