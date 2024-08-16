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

namespace ProductSolution.Application.Features.Categories.GetAll
{
    public class GetAllCategoryHandler : BaseHandler, IRequestHandler<GetAllCategoryRequest, IList<GetAllCategoryReponse>>
    {
        public GetAllCategoryHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllCategoryReponse>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReponsitory<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<GetAllCategoryReponse, Category>(category);
            return map;
        }
    }
}
