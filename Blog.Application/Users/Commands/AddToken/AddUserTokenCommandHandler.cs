using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Blog.Application.Users.Commands.AddToken
{
     
    public class AddUserTokenCommandHandler : IRequestHandler<AddUserTokenCommand,ErrorOr<Success>>
    {
        private readonly IUserRepository _repository;

        public AddUserTokenCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Success>> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null) { return Error.NotFound("User.NotFound", "The user with the specified ID was not found."); }


            user.AddToken(request.HashJwtToken, request.HashRefreshToken, request.TokenExpireDate, request.RefreshTokenExpireDate, request.Device);

            await _repository.Save();
            return new ErrorOr<Success>();
        }
    }
}
