using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.JwtTokenBuilder
{
 
    
        public interface IJwtTokenGenerator
        {
            string GenerateToken(int userId, string email);
        }

        public   class JwtTokenGenerator : IJwtTokenGenerator
        {
            private readonly IConfiguration _configuration;

            public JwtTokenGenerator(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public string GenerateToken(int userId, string email )
            {
                // خواندن تنظیمات JWT از appsettings.json
                var key = _configuration["Jwt:Key"];
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var expirationMinutes = int.Parse(_configuration["Jwt:ExpirationMinutes"]);

                // ایجاد کلید امنیتی
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // ایجاد Claims
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
               new Claim("UserId", userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                // ایجاد توکن
                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                    signingCredentials: credentials
                );

                // تبدیل توکن به رشته
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }

 
