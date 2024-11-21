using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application
{
    public static class ApplicationBootstrapper
    {
        public static IServiceCollection ApplicationConfig(this IServiceCollection services )
        {
            
            services.AddAutoMapper(typeof(Mapping));
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(ApplicationBootstrapper));
            });

            return services;
        }
    }
   
   
}
