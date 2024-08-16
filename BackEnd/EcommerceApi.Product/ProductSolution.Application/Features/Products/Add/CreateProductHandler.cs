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

namespace ProductSolution.Application.Features.Products.Add
{
    public class CreateProductHandler : BaseHandler, IRequestHandler<CreateProductRequest, Unit>
    {
        public CreateProductHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product(request.name, request.images, request.description, request.sellingPrice, request.mrp, request.categoryId);
            await unitOfWork.GetReponsitory<Product>().AddAsync(product);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
