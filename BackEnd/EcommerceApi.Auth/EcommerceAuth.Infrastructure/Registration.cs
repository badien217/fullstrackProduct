using EcommerceAPI.SharedLibrary.Interfaces.Reponsitories;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Infrastructure.context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceAuth.Domain.Entity;
using EcommerceAuth.Infrastructure.Services.Reponsitories;
using EcommerceAuth.Infrastructure.Services.UnitOfWords;
using EcommerceAuth.Infrastructure.Interface;
using EcommerceAuth.Infrastructure.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAuth.Infrastructure
{
    public static class Registration
    {
        public static void AddInfratructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AddDbContext>(opt =>
           opt.UseSqlServer(configuration.GetConnectionString("DefaultConnect")));
            services.Configure<TokenSetting>(configuration.GetSection("JWT"));
            services.AddScoped<IUnitOfWork, UnitOfWorkServices>();
            services.AddScoped(typeof(IReponsitory<>), typeof(ReponsitoryServices<>));
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
               .AddRoles<Role>()
               .AddEntityFrameworkStores<AddDbContext>();
            services.AddTransient<ITokenServices, TokenServices>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });



        }
    }
}
