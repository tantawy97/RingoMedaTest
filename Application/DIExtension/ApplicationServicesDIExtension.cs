using Application.Interfaces.IService;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DIExtension
{
    public static class ApplicationServicesDIExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddAutoMapper(typeof(ApplicationServicesDIExtension));

            return services;
        }
    }
}
