using Geent.Application.Interface.Service;
using Geent.Application.Service;
using Geent.Domain.Interface;
using Geent.Infrastructure;
using Geent.Infrastructure.ConfigurationDB;
using Geent.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Geent.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostgresDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostService>();
            return services;
        }
    }
}
