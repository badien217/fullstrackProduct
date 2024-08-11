using BuildingBlock.Mapper.AutoMappers;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlock.Mapper
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IAutoMapper, Mapping>();
        }
    }
}
