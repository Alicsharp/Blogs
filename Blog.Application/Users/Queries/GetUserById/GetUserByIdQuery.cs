using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Users.Queries.UserTokens;
using Blog.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int Id):IRequest<ErrorOr<User>>;
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<User>>
    {
        private  readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) { return Error.Failure(); }
            return user;

        }
    }

}
