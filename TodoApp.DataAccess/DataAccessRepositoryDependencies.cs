using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess.Abstracts;
using TodoApp.DataAccess.Concretes;
using TodoApp.DataAccess.Contexts;

namespace TodoApp.DataAccess
{
    public static class DataAccessRepositoryDependencies
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IToDoRepository, EfToDoRepository>();

            services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            return services;
        }
    }
}
