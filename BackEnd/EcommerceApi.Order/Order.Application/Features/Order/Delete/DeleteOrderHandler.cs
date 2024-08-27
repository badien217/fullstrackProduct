using EcommerceAPI.SharedLibrary.Base;
using EcommerceAPI.SharedLibrary.Interfaces.AutoMapper;
using EcommerceAPI.SharedLibrary.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Delete
{
    public class DeleteOrderHandler : BaseHandler, IRequestHandler<DeleteOrderRequest, Unit>
    {
        public DeleteOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetReponsitory<Orders>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            order.IsDeleted = true;
            await unitOfWork.GetReponsitory<Orders>().UpdateAsync(order);
            if(await unitOfWork.SaveAsync() > 0)
            {
                var orderDetail = await unitOfWork.GetReponsitory<OrderDetail>().GetAsync(x => x.orderId == request.Id);
                orderDetail.IsDeleted = true;
                await unitOfWork.GetReponsitory<OrderDetail>().UpdateAsync(orderDetail);
                await unitOfWork.SaveAsync();

            }
            return Unit.Value;
        }
    }
}
