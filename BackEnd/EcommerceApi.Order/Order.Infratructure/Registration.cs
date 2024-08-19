using EcommerceAPI.SharedLibrary.Interfaces.Reponsitories;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Infratructure.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Infratructure.Services.UnitOfWork;
using Order.Infratructure.Services.Reponsitories;

namespace Order.Infratructure
{
    public static class Registration
    {
        public static void AddInfratructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AddDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnect")));
            services.AddScoped<IUnitOfWork, UnitOfWorkServices>();
            services.AddScoped(typeof(IReponsitory<>), typeof(ReponsitoryServices<>));

        }
    }
}
