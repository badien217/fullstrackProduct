using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using ProductSolution.Domain.Entity;

namespace ProductSolution.Application.Features.Categories.Add
{
    public class CreateCategoryHandler :BaseHandler ,IRequestHandler<CreateCategoryRequest, Unit>
    {
        public CreateCategoryHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor){}

        public async Task<Unit> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            Category category = new Category(request.name, request.images, request.description) ;
            await unitOfWork.GetReponsitory<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
