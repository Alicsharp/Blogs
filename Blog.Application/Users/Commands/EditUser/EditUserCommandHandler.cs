using Blog.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Blog.Application.Users.Commands.EditUser
{
    internal class EditUserCommandHandler : IRequestHandler<EditUserCommand, ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Success>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if(user == null) { throw new ArgumentNullException(); }

            user.Edit(request.Username);
          await  _userRepository.Save();
            return new ErrorOr<Success>();
        }
    }
}
