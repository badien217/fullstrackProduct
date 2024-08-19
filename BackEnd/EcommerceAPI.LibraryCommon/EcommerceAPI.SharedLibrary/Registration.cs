using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Behevior;
using EcommerceAPI.SharedLibrary.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.SharedLibrary
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
          
            //services.Configure<SendMailCommandAuthsSettings>(configuration.GetSection("MailSetting"));
            //services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);
            return services;
        }
    }

}

