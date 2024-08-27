using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Delete
{
    public class DeleteOrderRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
