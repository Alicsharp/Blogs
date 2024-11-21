using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Users.Queries.UserTokens
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserEditDto
    {
        public string UserName {  get; set; }
        public string Email { get; set; }
    }
}
