using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.RevokeAll
{
    public class RevokeAllHandler : BaseHandler, IRequestHandler<RevokeAllRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        public RevokeAllHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)

        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllRequest request, CancellationToken cancellationToken)
        {
            List<User> user = await userManager.Users.ToListAsync(cancellationToken);
            foreach (User users in user)
            {
                users.RefreshToken = null;
                await userManager.UpdateAsync(users);
            }

            return Unit.Value;
        }
    }
}