using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Users.Queries.UserTokens;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Queries
{
    public record GetUserByEmailQuery(string Email) : IRequest<ErrorOr<UserLoginDto>>;
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ErrorOr<UserLoginDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper  _mapper;

        public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<UserLoginDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var User=await _userRepository.GetByEmailAsync(request.Email);    
            if(User == null) { return Error.Failure(); }

          var UserDto=  _mapper.Map<UserLoginDto>(User);
            return UserDto;
        }
    }

}
