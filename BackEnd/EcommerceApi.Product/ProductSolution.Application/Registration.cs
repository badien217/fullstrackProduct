using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application
{
    public static class Registration
    {
        public static void AddApplications(this IServiceCollection services, IConfiguration configuration)
        {

            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        }
    }
}
