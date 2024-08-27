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

namespace ProductSolution.Application.Features.Products.Delete
{
    public class DeleteProductHandler : BaseHandler, IRequestHandler<DeleteProductRequest, Unit>
    {
        public DeleteProductHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReponsitory<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = false;
            await unitOfWork.GetReponsitory<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
