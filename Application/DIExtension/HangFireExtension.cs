using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DIExtension
{
    public static class HangFireExtension
    {
        public static IServiceCollection AddHangFireService(this IServiceCollection services, IConfiguration config)
        {
            services.AddHangfire(configuration => configuration.UseSqlServerStorage(config.GetConnectionString("RingoMediaCs")));
            services.AddHangfireServer();
            return services;
        }
    }
}
