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

namespace Order.Application.Features.Order.Add
{
    public class CreateOrderHandler : BaseHandler, IRequestHandler<CreateOrderRequest, Unit>
    {
        public CreateOrderHandler(IAutoMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            Orders orders = new(request.ProfileId, request.name, request.address, request.phoneNumber, request.amount,request.price);
            await unitOfWork.GetReponsitory<Orders>().AddAsync(orders);
            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var ProductId in request.ProductId)
                {
                    await unitOfWork.GetReponsitory<OrderDetail>().AddAsync(new()
                    {
                        orderId = orders.Id,
                        productId = ProductId,
                    });

                }

                await unitOfWork.SaveAsync();
            }
            return Unit.Value;

        }
    }
}
