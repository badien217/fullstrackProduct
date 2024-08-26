using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using EcommerceAuth.Application.Feature.Profiles.Update.UpdateProfile;
using EcommerceAuth.Application.Rule;
using EcommerceAuth.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Profiles.Update.UpdateProfile
{
    
public class UpdateProfileUserHandler : BaseHandler, IRequestHandler<UpdateProfileUserRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAutoMapper _autoMapper;
    private readonly AuthRule Rule;
    public UpdateProfileUserHandler(AuthRule Rule, IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this._unitOfWork = unitOfWork;
        this._autoMapper = mapper;
        this.Rule = Rule;
    }
    public async Task<Unit> Handle(UpdateProfileUserRequest request, CancellationToken cancellationToken)
    {
        Profile profile = await unitOfWork.GetReponsitory<Profile>().GetAsync(x => x.UserId == request.UserId && !x.IsDeleted);
        var map = _autoMapper.Map<Profile, UpdateProfileUserRequest>(request);
        if (request.avatar.Length > 0)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", request.avatar.FileName);
            using (var stream = System.IO.File.Create(path))
            {
                await request.avatar.CopyToAsync(stream);


            }
            map.avatar = "/image/" + request.avatar.FileName;
        }
        await _unitOfWork.GetReponsitory<Profile>().UpdateAsync(map);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
}  