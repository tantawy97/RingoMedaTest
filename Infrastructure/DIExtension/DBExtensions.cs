using Application.Interfaces.IUnit;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Unit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DIExtension
{
    public static class DBExtensions
    {
        public static IServiceCollection AddSQLServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RingoMediaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RingoMediaCs"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}