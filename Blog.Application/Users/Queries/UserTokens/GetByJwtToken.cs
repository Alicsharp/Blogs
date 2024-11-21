using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Common.Interfaces;
using MediatR;
namespace Blog.Application.Users.Queries.UserTokens
{
    //public record GetUserTokenByJwtTokenQuery(string HashJwtToken):IRequest<UserTokenDto>;
    //internal class GetUserTokenByJwtTokenQueryHandler : IRequestHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
    //{
    //    private readonly IUserRepository  _userRepository;

    //    public GetUserTokenByJwtTokenQueryHandler(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }

    //    public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    //    {
    //       var user=_userRepository.GetByIdAsync(request.)
    //    }
    //}
}
