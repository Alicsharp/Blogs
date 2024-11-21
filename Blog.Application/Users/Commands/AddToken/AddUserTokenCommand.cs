using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Commands.AddToken
{
    public class AddUserTokenCommand : IRequest<ErrorOr<Success>>
    {
        public AddUserTokenCommand(int id, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            Id = id;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }


        public int Id { get; }
        public string HashJwtToken { get; }
        public string HashRefreshToken { get; }
        public DateTime TokenExpireDate { get; }
        public DateTime RefreshTokenExpireDate { get; }
        public string Device { get; }

    }
}
