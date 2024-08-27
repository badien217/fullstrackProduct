using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Order.Application.Features.Order.GetAll;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.GetOne.GetOrderById
{
    public class GetOneOrderByIdHandler : BaseHandler, IRequestHandler<GetOneOrderByIdRequest, GetOneOrderByIdReponse>
    {
        public GetOneOrderByIdHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<GetOneOrderByIdReponse> Handle(GetOneOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetReponsitory<Orders>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<GetOneOrderByIdReponse, Orders>(order);
            return map;
        }
    }
}
