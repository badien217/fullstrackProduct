using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSolution.Infratructure.Context;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using ProductSolution.Infratructure.Services.UnitOfWork;
using EcommerceAPI.SharedLibrary.Interfaces.Reponsitories;
using ProductSolution.Infratructure.Services.Reponsitory;

namespace ProductSolution.Infratructure
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
