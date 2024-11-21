using Blog.Application.Common.Interfaces;
using Blog.Application.Common.SecurityUtil;
using ErrorOr;
using MediatR;

namespace Blog.Application.Users.Commands.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand,ErrorOr<Success>>
{
         private readonly IUserRepository _userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Success>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if(user == null) { return Error.NotFound("User.NotFound", "The user with the specified ID was not found."); }

            var currentPasswordHash = Sha256Hasher.Hash(request.CurrentPassword);
            if (user.PasswordHash != currentPasswordHash)
            {
                return Error.NotFound("User.Password", " Password In Corrent");
            }
            var newPasswordHash = Sha256Hasher.Hash(request.Password);
            user.ChangePassword(newPasswordHash);
            await _userRepository.Save();
            return new ErrorOr<Success>();
        }
    }
}
