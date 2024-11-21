using Blog.Application.Common.Interfaces;
using Blog.Application.Common.SecurityUtil;
using Blog.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Blog.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Success>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }  
            var passHash= Sha256Hasher.Hash(request.password);
            var user= new User(request.username,request.email, passHash);    
           await _userRepository.AddAsync(user); //چون ثبت نام ما فقط با ایمیل است پس لازم نیست یک  متد ثبت نام داخل دامین بنویسم فقط اضافه کنیم کافیه
           await _userRepository.Save();
            return new ErrorOr<Success>();
            
        }
    }
}
