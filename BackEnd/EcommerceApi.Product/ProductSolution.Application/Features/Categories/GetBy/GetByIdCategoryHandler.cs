using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using ProductSolution.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Categories.GetBy
{
    public class GetByIdCategoryHandler : BaseHandler, IRequestHandler<GetByIdCategoryRequest, GetByIdCategoryReponse>
    {
        public GetByIdCategoryHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetByIdCategoryReponse> Handle(GetByIdCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReponsitory<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<GetByIdCategoryReponse, Category>(category);
            return map;
        }
    }
}
