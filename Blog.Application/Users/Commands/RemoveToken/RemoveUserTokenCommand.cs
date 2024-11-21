using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Commands.RemoveToken
{
    public record RemoveUserTokenCommand(int UserId, long TokenId) : IRequest<ErrorOr<Success>>;
    internal class RemoveUserTokenCommandHandler : IRequestHandler<RemoveUserTokenCommand,ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository;

        public RemoveUserTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
       async Task<ErrorOr<Success>> IRequestHandler<RemoveUserTokenCommand, ErrorOr<Success>>.Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return Error.NotFound("User.Password", " Password In Corrent");

            user.RemoveToken(request.TokenId);
            await _userRepository.Save();
            return new ErrorOr<Success>();
        }
    }
}
