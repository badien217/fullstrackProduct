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

namespace ProductSolution.Application.Features.Products.Update
{
    public class UpdateProductHandler : BaseHandler, IRequestHandler<UpdateProductRequest, Unit>
    {
        public UpdateProductHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReponsitory<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Product,UpdateProductRequest >(request);

            await unitOfWork.GetReponsitory<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
