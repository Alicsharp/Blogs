using Blog.Application.Common.Interfaces;
using Blog.Infrastructure.JwtTokenBuilder;
using Blog.Infrastructure.Repository;
using Blog.Infrastructure.Repository.YourNamespace;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static IServiceCollection Config(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // تنظیمات احراز هویت با JWT
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"], // خواندن مقدار از IConfiguration
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            // تنظیمات دیتابیس
            services.AddDbContext<BlogDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            return services;
        }
    }

}
