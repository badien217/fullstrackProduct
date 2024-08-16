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

namespace ProductSolution.Application.Features.Categories.Delete
{
    public class DeleteCategoryHandler : BaseHandler, IRequestHandler<DeleteCategoryRequest, Unit>
    {
        public DeleteCategoryHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor):base(mapper, unitOfWork, httpContextAccessor) { }
        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.GetReponsitory<Category>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            category.IsDeleted = false;
            await unitOfWork.GetReponsitory<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
