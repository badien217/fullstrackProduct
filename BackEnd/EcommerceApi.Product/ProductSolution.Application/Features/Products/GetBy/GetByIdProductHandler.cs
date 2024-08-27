using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductSolution.Application.DTOs.Categories;
using ProductSolution.Application.Features.Products.GetAll;
using ProductSolution.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSolution.Application.Features.Products.GetBy
{
    public class GetByIdProductHandler : BaseHandler, IRequestHandler<GetByIdProductRequest, GetByIdProductReponse>
    {
        public GetByIdProductHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetByIdProductReponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReponsitory<Product>().GetAsync(x => !x.IsDeleted && x.Id == request.Id, include: y => y.Include(b => b.category));
            var category = mapper.Map<CategoryDto, Category>(new Category());
            var map = mapper.Map<GetByIdProductReponse, Product>(product);
            return map;
        }
    }
}
