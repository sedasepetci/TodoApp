using Microsoft.Extensions.DependencyInjection;
using TodoApp.Service.Abstracts;
using TodoApp.Service.Concretes;
using TodoApp.Service.Profiles;
using TodoApp.Service.Rules;


namespace TodoApp.Service
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped<TodoBusinessRules>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IToDoService, ToDoService>();

            return services;
        }
    }
}
