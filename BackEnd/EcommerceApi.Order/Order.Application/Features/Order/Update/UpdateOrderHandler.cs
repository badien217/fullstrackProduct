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

namespace Order.Application.Features.Order.Update
{
    public class UpdateOrderHandler : BaseHandler, IRequestHandler<UpdateOrderRequest, Unit>
    {
        public UpdateOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.GetReponsitory<Orders>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            var map = mapper.Map<Orders, UpdateOrderRequest>(request);
            var orderdetail = await unitOfWork.GetReponsitory<OrderDetail>().GetAllAsync(x => x.orderId == request.Id
            && !x.IsDeleted);

            await unitOfWork.GetReponsitory<OrderDetail>().HardDeleteRangerAsync(orderdetail);
            foreach (var ProductId in request.ProductId)
            {
                await unitOfWork.GetReponsitory<OrderDetail>().AddAsync(new()
                {
                    orderId = orders.Id,
                    productId = ProductId,
                });

            }
            await unitOfWork.GetReponsitory<Orders>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
