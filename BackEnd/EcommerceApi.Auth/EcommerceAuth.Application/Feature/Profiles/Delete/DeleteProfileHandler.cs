using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Application.Feature.Exception;
using EcommerceAuth.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Profiles.Delete
{
    public class DeleteProfileHandler : BaseHandler, IRequestHandler<DeleteProfileRequest,Unit>
    {
        
        public DeleteProfileHandler( IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            

        }

        public async Task<Unit> Handle(DeleteProfileRequest request, CancellationToken cancellationToken)
        {
            var userProfile = await unitOfWork.GetReponsitory<Profile>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            if (userProfile == null)
            {
                throw new AccountNotFound();
            }
            else
            {
                userProfile.IsDeleted = true;
            }
            await unitOfWork.GetReponsitory<Profile>().UpdateAsync(userProfile);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}