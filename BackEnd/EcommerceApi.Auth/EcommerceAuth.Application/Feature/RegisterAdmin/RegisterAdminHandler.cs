using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Application.Feature.Register;
using EcommerceAuth.Application.Rule;
using EcommerceAuth.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.RegisterAdmin
{
    public class RegisterAdminHandler : BaseHandler, IRequestHandler<RegisterAdminRequest, Unit>
    {
        private readonly AuthRule authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public RegisterAdminHandler(AuthRule authRules, UserManager<User> userManager, RoleManager<Role> roleManager, IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterAdminRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterAdminRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            var userProfile = new Profile
            {
                Phone = request.Phone,
                Email = request.Email,
                age = request.age,
                Address = request.Address,
                avatar = request.avatar,
            };
            user.profile = userProfile;
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("admin"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "admin");
            }

            return Unit.Value;
        }
    }
}