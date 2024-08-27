using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.GetAll
{
    public class GetAllOrderHandler : BaseHandler, IRequestHandler<GetAllOrderRequest, IList<GetAllOrderReponse>>
    {
        public GetAllOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllOrderReponse>> Handle(GetAllOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetReponsitory<Orders>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<GetAllOrderReponse, Orders>(order);
            return map;
        }
    }
}
