using Application.Implementation.Utility;
using Application.Interfaces.IService;
using Application.Interfaces.IUtility;
using Application.Service;
using Client.EmailClient.Interfaces;
using Client.EmailClient.MailKit;
using Client.EmailClient.Services;
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
            services.AddScoped<IReminderService, ReminderService>();
            services.AddScoped<IFileUtility, FileUtility>();
            services.AddScoped<IMailKitEmailClient, MailKitEmailClient>();
            services.AddScoped<IViewRender, ViewRender>();
            services.AddScoped<IViewRender, HandlebarsService>();
            services.AddAutoMapper(typeof(ApplicationServicesDIExtension));


            return services;
        }
    }
}
