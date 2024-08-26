using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Application.Feature.Exception;
using EcommerceAuth.Application.Rule;
using EcommerceAuth.Domain.Entity;
using EcommerceAuth.Infrastructure.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.GetProfiles
{
    public class GetProfileHandler :BaseHandler,IRequestHandler<GetProfileRequest,GetProfileReponse>
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenServices tokenService;
        private readonly AuthRule authRules;

        public GetProfileHandler(UserManager<User> userManager, IConfiguration configuration,
            ITokenServices tokenService, AuthRule authRules, IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }

        public async Task<GetProfileReponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await unitOfWork.GetReponsitory<Profile>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (profile == null) {
                throw new AccountNotFound();
            }
            var map = mapper.Map< GetProfileReponse,Profile>(profile);
            return map;
        }
    }
}
